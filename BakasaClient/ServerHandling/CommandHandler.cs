using BakasaClient.Forms.UserControls;
using BakasaCommon.Commands;
using System.Reflection.Metadata;

namespace BakasaClient.ServerHandling
{
    public static class CommandHandler
    {
        public static async Task Handle(string message)
        {
            var command = CommandProcessor.ProcessCommand(message);
            switch (command?.Name)
            {
                case CommandsNames.Server_StartGame:
                    StartGame(command.Parameters[0]);
                    break;
                case CommandsNames.Server_AskingQuestion:
                    AskingQuestion(command);
                    break;
                case CommandsNames.Server_StartVoting:
                    StartVoting(command);
                    break;
                case CommandsNames.Server_BakesStartVoting:
                    BakesStartVoting(command);
                    break;
                case CommandsNames.Server_RoundFinished:
                    RoundFinished(command);
                    break;
                case CommandsNames.Server_ScoreIs:
                    ScoreIs(command);
                    break;
                default:
                    Logger.Log("No commands found");
                    break;
            }
        }


        private static void StartGame(string itemName)
        {
            AppState.Instance.MainForm.LoadUserControl(new SeeItemUserControl(itemName));
        }
        private static void AskingQuestion(Command command)
        {
            AppState.Instance.MainForm.LoadUserControl(new QuestionsUserControl(command.Parameters[0], command.Parameters[1]));
        }
        private static void StartVoting(Command command)
        {
            AppState.Instance.MainForm.LoadUserControl(new PlayerVoteUserControl(command.Parameters[0]));
        }
        private static void BakesStartVoting(Command command)
        {
            AppState.Instance.MainForm.LoadUserControl(new BakesResultsControl(command.Parameters[0], command.Parameters[1]));
        }
        private static void RoundFinished(Command command)
        {
            MessageHelper.ShowInfo($"البكس قال ان الحاجه {command.Parameters[0]}");
        }
        private static void ScoreIs(Command command)
        {
            List<string> playersWithScore = command.Parameters[0].Split("$$").ToList();
            string playerWithScore = "";
            for (int i = 0; i < playersWithScore.Count; i++)
            {
                playerWithScore += $"{playersWithScore[i]} : {playersWithScore[++i]}"+"\n";
            }
            new Thread(() =>
            {
                MessageHelper.ShowInfo($"{playerWithScore}");
            })
            { IsBackground = true }.Start();
            
        }
    }
}
