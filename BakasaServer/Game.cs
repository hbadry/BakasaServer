namespace BakasaServer
{
    public class Game
    {
        public List<PlayerScores> PlayerScores { get; set; }
        public List<Round> Rounds { get; set; }
        Random rnd = new Random();
        public Game(List<Player> players)
        {

            PlayerScores = players.Select(x => new BakasaServer.PlayerScores()
            {
                PlayerId = x.Id,
                Score = 0
            }).ToList();
            Rounds = new List<Round>();
            AddNewActiveRound(players);
        }

        public void AddNewActiveRound(List<Player> players)
        {
            var categories = Category.GetCategories();
            Category selectedCategory = categories[rnd.Next(categories.Count)];
            string selectedItem = selectedCategory.CategoryOptions[rnd.Next(selectedCategory.CategoryOptions.Count)];
            Player selectedPlayer = players[rnd.Next(players.Count)];

            AddNewRound(players, selectedCategory, selectedItem, selectedPlayer);
        }

        private void AddNewRound(List<Player> players, Category selectedCategory, string selectedItem, Player selectedPlayer)
        {
            Rounds.Add(new Round()
            {
                IsActiveRound = true,
                RoundNumber = Rounds.Count + 1,
                SelectedCategory = selectedCategory,
                SelectedPlayer = selectedPlayer,
                SelectedItem = selectedItem,
                Stage = RoundStage.AwaitAllToSeeItem,
                PlayerRoundData = players.Select(x => new PlayerRoundData(x.Id, PlayerRoundStatus.AwaitToSeeItem)).ToList()
            });
        }

        public Round ActiveRound
        {
            get
            {
                return Rounds.Single(x => x.IsActiveRound);
            }
        }

    }
    public class PlayerScores
    {
        public string PlayerId { get; set; }
        public int Score { get; set; }
    }
    public class Round
    {
        public int RoundNumber { get; set; }
        public int NumberOfAsk { get; set; }
        public Category SelectedCategory { get; set; }
        public string SelectedItem { get; set; }
        public Player SelectedPlayer { get; set; }
        public List<PlayerRoundData> PlayerRoundData { get; set; }
        public bool IsActiveRound { get; set; } = true;
        public RoundStage Stage { get; set; }
        public static Dictionary<RoundStage, PlayerRoundStatus> PlayerStatusMapper = new Dictionary<RoundStage, PlayerRoundStatus>()
        {
            {RoundStage.AwaitAllToSeeItem,PlayerRoundStatus.AwaitToSeeItem},
            {RoundStage.QuestionsStage,PlayerRoundStatus.SawItem },
            {RoundStage.VoteStage,PlayerRoundStatus.ReadyToVote },
            {RoundStage.BakesVoteStage,PlayerRoundStatus.ReadyToVote },
            {RoundStage.Finished,PlayerRoundStatus.Voted },
        };

    }
    public class PlayerRoundData
    {
        public PlayerRoundData(string playerId, PlayerRoundStatus status)
        {
            PlayerId = playerId;
            Status = status;
        }

        public string PlayerId { get; set; }
        public PlayerRoundStatus Status { get; set; }

    }
    public enum RoundStage
    {
        AwaitAllToSeeItem = 0,
        QuestionsStage = 1,
        VoteStage = 2,
        BakesVoteStage = 3,
        Finished = 4

    }
    public enum PlayerRoundStatus
    {
        AwaitToSeeItem = 0,
        SawItem = 1,
        ReadyToVote = 2,
        Voted = 3


    }
}
