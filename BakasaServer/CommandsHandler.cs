using BakasaCommon.Commands;
using System.Xml.Linq;

namespace BakasaServer
{
    public  class CommandsHandler
    {
        private readonly int maxNumberOfAsk = 12;
        public CommandsHandler(Command command, Player caller, Game game, List<Player> players)
        {
            Command = command;
            Caller = caller;
            Game = game;
            Players = players;
        }

        public Command Command { get; set; }
        public Player Caller { get; set; }
        public Game Game { get; set; }
        public List<Player> Players { get; set; }
        public async Task Handle()
        {
            switch(Command?.Name)
            {
                case CommandsNames.Client_SetName:
                    SetName();
                    break;
                case CommandsNames.Client_SawItem:
                    await SawItem(); 
                    break;
                case CommandsNames.Client_QuestionAsked:
                    await QuestionAsked();
                    break;
                case CommandsNames.Client_ReadyToVote:
                    await ReadyToVote();
                    break;
                case CommandsNames.Client_Voted:
                    await ClientVoted();
                    break;
                case CommandsNames.Client_BakesVoted:
                    await BakesVoted();
                    break;
                case CommandsNames.Client_ShowScore:
                    await ShowScore();
                    break;
                default:
                    Console.WriteLine("No commands found");
                    break;
            }
        }

        public void SetName()
        {
            Caller.PlayerName = Command.Parameters[0];
        }
        public async Task SawItem()
        {
            Game.ActiveRound.PlayerRoundData.Single(x => x.PlayerId == Caller.Id).Status = PlayerRoundStatus.SawItem;
            Game.ActiveRound.Stage = Game.ActiveRound.PlayerRoundData.Any(x => x.Status != PlayerRoundStatus.SawItem) ? RoundStage.AwaitAllToSeeItem :
                RoundStage.QuestionsStage;
            if (Game.ActiveRound.Stage == RoundStage.QuestionsStage)
            {
                await SendQuestionToAll();
            }
        }
        private async Task QuestionAsked()
        {
            Game.ActiveRound.NumberOfAsk++;
            if (Game.ActiveRound.NumberOfAsk <= maxNumberOfAsk)
            {
                await SendQuestionToAll();
            }
            else
            {
                await StartReadyToVoteStage();
            }
            
        }

        private async Task SendQuestionToAll()
        {
            var rnd = new Random();
            var sender = Players[rnd.Next(Players.Count)];
            var receiver = Players[rnd.Next(Players.Count)];
            while (receiver.Id == sender.Id)
            {
                receiver = Players[rnd.Next(Players.Count)];
            }
            var command = SystemCommands.AskingQuestion(sender.PlayerName, receiver.PlayerName);
            await BroadCaster.BroadcastMessageToAllPlayers(command, Players);
        }
        private async Task ReadyToVote()
        {
            Game.ActiveRound.PlayerRoundData.Single(x => x.PlayerId == Caller.Id).Status = PlayerRoundStatus.ReadyToVote;
            Game.ActiveRound.Stage = Game.ActiveRound.PlayerRoundData.Any(x => x.Status != PlayerRoundStatus.ReadyToVote) ? RoundStage.QuestionsStage :
                RoundStage.VoteStage;
            if (Game.ActiveRound.Stage == RoundStage.VoteStage)
            {
                await StartReadyToVoteStage();
            }
        }

        private async Task StartReadyToVoteStage()
        {
            Game.ActiveRound.Stage = RoundStage.VoteStage;
            var playerNamesSeperated = string.Join("$$", Players.Select(x => x.DisplayName));
            var command = SystemCommands.Server_StartVoting(playerNamesSeperated);
            await BroadCaster.BroadcastMessageToAllPlayers(command, Players);
        }

        private async Task ClientVoted()
        {
            Game.ActiveRound.PlayerRoundData.Single(x => x.PlayerId == Caller.Id).Status = PlayerRoundStatus.Voted;
            if (Command.Parameters[0] == Game.ActiveRound.SelectedPlayer.PlayerName)
            {
                Game.PlayerScores.Single(x => x.PlayerId == Caller.Id).Score++;
            }
            Game.ActiveRound.Stage = Game.ActiveRound.PlayerRoundData.Any(x => x.Status != PlayerRoundStatus.Voted) ? RoundStage.VoteStage :
                RoundStage.BakesVoteStage;
            if (Game.ActiveRound.Stage == RoundStage.BakesVoteStage)
            {
                string bakesName = Game.ActiveRound.SelectedPlayer.PlayerName;
                string selectedItem = Game.ActiveRound.SelectedItem;
                Random rng = new Random();
                List<string> itemsToSentToBakes = Game.ActiveRound.SelectedCategory.CategoryOptions
                    .OrderBy(_ => rng.Next())
                    .Where(x=> x!=Game.ActiveRound.SelectedItem)
                    .Take(9)
                    .ToList();
                itemsToSentToBakes.Add(selectedItem);
                var command = SystemCommands.Server_BakesStartVoting(bakesName,itemsToSentToBakes);
                await BroadCaster.BroadcastMessageToAllPlayers(command, Players);
            }

        }
        private async Task BakesVoted()
        {
            if (Caller.Id != Game.ActiveRound.SelectedPlayer.Id)
            {
                return;
            }
            string addedString = " (خطا)";
            if (Command.Parameters[0] == Game.ActiveRound.SelectedItem)
            {
                Game.PlayerScores.Single(x => x.PlayerId == Caller.Id).Score++;
                addedString = " (صح)";
            }
            Game.ActiveRound.Stage = RoundStage.Finished;
            string playersWithScore = string.Join("$$", Game.PlayerScores.Select(x => x.PlayerId + "$$" + x.Score));
            var command = SystemCommands.Server_RoundFinished(Command.Parameters[0]+ addedString, playersWithScore);
            await BroadCaster.BroadcastMessageToAllPlayers(command, Players);
        }
        private async Task ShowScore()
        {
            if (Game == null) return;
            string playersWithScore = string.Join("$$", Game.PlayerScores.Select(x => Players.Single(p => p.Id == x.PlayerId).PlayerName + "$$" + x.Score));
            var command = SystemCommands.Server_ScoreIs(playersWithScore);
            await BroadCaster.BroadcastMessage(command, Caller);
        }

    }
}
