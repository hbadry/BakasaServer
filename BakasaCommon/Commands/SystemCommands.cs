using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace BakasaCommon.Commands
{
    public static class SystemCommands
    {
        public static byte[] ToBytes(string command)
        {
            byte[] data = Encoding.UTF8.GetBytes(command);
            return data;
        }

        public static string SetName(string name)
        {
            return new CommandBuilder(CommandsNames.Client_SetName).AddParameter(name).Build();
        }
        public static string StartGame(string wordToPredict)
        {
            return new CommandBuilder(CommandsNames.Server_StartGame).AddParameter(wordToPredict).Build();
        }
        public static string SawItem()
        {
            return new CommandBuilder(CommandsNames.Client_SawItem).Build();
        }
        public static string AskingQuestion(string sender, string receiver)
        {
            return new CommandBuilder(CommandsNames.Server_AskingQuestion)
                .AddParameter(sender)
                .AddParameter(receiver)
                .Build();
        }
        public static string QuestionAsked()
        {
            return new CommandBuilder(CommandsNames.Client_QuestionAsked)
                .Build();
        }
        public static string ReadyToVote()
        {
            return new CommandBuilder(CommandsNames.Client_ReadyToVote)
                .Build();
        }
        public static string Server_StartVoting(string playerNamesSeperated)
        {
            return new CommandBuilder(CommandsNames.Server_StartVoting)
                .AddParameter(playerNamesSeperated)
                .Build();
        }
        public static string ClientVoted(string name)
        {
            return new CommandBuilder(CommandsNames.Client_Voted)
                .AddParameter(name)
                .Build();
        }
        public static string Server_BakesStartVoting(string bakesName,List<string> items)
        {
            Random rng = new Random();
            List<string> shuffledItems = items.OrderBy(_ => rng.Next()).ToList();
            var shuffledItemsStr = string.Join("$$", shuffledItems);
            return new CommandBuilder(CommandsNames.Server_BakesStartVoting)
                .AddParameter(bakesName)
                .AddParameter(shuffledItemsStr)
                .Build();
        }
        public static string ClientBakesVoted(string name)
        {
            return new CommandBuilder(CommandsNames.Client_BakesVoted)
                .AddParameter(name)
                .Build();
        }
        public static string Server_RoundFinished(string bakesVote, string playersScores)
        {
            return new CommandBuilder(CommandsNames.Server_RoundFinished)
                .AddParameter(bakesVote)
                .AddParameter(playersScores)
                .Build();
        }
        public static string Client_ShowScore()
        {
            return new CommandBuilder(CommandsNames.Client_ShowScore)
                .Build();
        }
        public static string Server_ScoreIs(string playersScoreData)
        {
            return new CommandBuilder(CommandsNames.Server_ScoreIs)
                .AddParameter(playersScoreData)
                .Build();
        }


    }
}
