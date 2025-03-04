using BakasaCommon.Commands;
using BakasaServer;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ChatServer
{
    private static List<Player> _players = new List<Player>();
    private static List<DisconnectedPlayer> _disconnectedPlayers = new List<DisconnectedPlayer> ();
    private static TcpListener _server;
    private static Game _game;
    private const int PORT = 8085; // Change this if needed


    static async Task Main()
    {
        _server = new TcpListener(IPAddress.Any, PORT);
        _server.Start();
        Console.WriteLine($"Server started on port {PORT}...");
        Task.Run(async () =>
        {
            while (true)
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                var player = new Player(client);
                _players.Add(player);
                Console.WriteLine($"New player connected: {player.Id}");
                _ = HandlePlayer(player);
            }
        });

        while (true)
        {
            Console.WriteLine("Please enter a command");
            Console.WriteLine("0 - re-list commands");
            Console.WriteLine("1 - start the game");
            Console.WriteLine("2 - Send Command To All");
            Console.WriteLine("3 - Send Command To Player");
            Console.WriteLine("4 - Show Player Id");
            Console.WriteLine("5 - Show Last Command To All");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    SendCommandToAll();
                    break;
                case "3":
                    SendCommandToPlayer();
                    break;
                case "4":
                    ShowPlayersIds();
                    break;
                case "5":
                    Console.WriteLine(BroadCaster.LastCommandToAllPlayers);
                    break;
                case "0":
                    continue;
                default:
                    continue;
            }
        }

    }


    private static void StartGame()
    {
        if (_players?.Where(x => x.Connected)?.Count() < 2)
        {
            Console.WriteLine("Must be at least 3 users to play!");
        }
        if (_game == null)
        {
            Task.Run(async () =>
            {
                await CreateGame();
            });
        }
        else
        {
            NewRound().GetAwaiter().GetResult();
        }
       


    }
    private static void SendCommandToAll()
    {
        Console.WriteLine("Enter the command");
        var command = Console.ReadLine();
        BroadCaster.BroadcastMessageToAllPlayers(command,_players).GetAwaiter().GetResult();
    }

    private static void SendCommandToPlayer()
    {
        Console.WriteLine("Enter PlayerId");
        var playerId = Console.ReadLine();
        while(!_players.Any(x => x.Id == playerId))
        {
            Console.WriteLine("Wrong player Id");
            playerId = Console.ReadLine();
        }
        var player = _players.Single(x => x.Id == playerId);
        Console.WriteLine("Enter the command");
        var command = Console.ReadLine();
        BroadCaster.BroadcastMessage(command, player).GetAwaiter().GetResult();
    }
    private static void ShowPlayersIds()
    {
        foreach(var player in _players)
        {
            Console.WriteLine($"{player.DisplayName}: {player.Id}");
        }
    }
    private async static Task NewRound()
    {
        if (_players?.Where(x => x.Connected)?.Count() < 2)
        {
            Console.WriteLine("Must be at least 3 users to play!");
        }
        var players = _players.Where(x => x.Connected).ToList();
        _game.ActiveRound.IsActiveRound = false;
        _game.AddNewActiveRound(players);
        await StartRound(players);

    }
    private static async Task CreateGame()
    {
        var players = _players.Where(x => x.Connected).ToList();
        _game = new Game(players);
        await StartRound(players);

    }

    private static async Task StartRound(List<Player> players)
    {
        var activeRound = _game.ActiveRound;
        var startGameCommand = SystemCommands.StartGame(activeRound.SelectedItem);
        var startGameCommandSelectedPlayer = SystemCommands.StartGame("بكس");
        await BroadCaster.BroadcastMessageToAllPlayers(startGameCommand, players.Where(x => x.Id != _game.ActiveRound.SelectedPlayer.Id).ToList());
        await BroadCaster.BroadcastMessage(startGameCommandSelectedPlayer, activeRound.SelectedPlayer);
    }

    private static async Task HandlePlayer(Player player)
    {
        try
        {
            var client = player.Client;
            using (client)
            {
                AddPlayerToActiveGameIfAny(player);
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"({player.DisplayName}): {message}");
                    var command = CommandProcessor.ProcessCommand(message);
                    var commandHandler = new CommandsHandler(command, player, _game, _players);
                    await commandHandler.Handle();
                    if (command.Name == CommandsNames.Client_SetName)
                    {
                        AttachScoreIfInDisconnectedPlayers(player);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Client error: {ex.Message}");
        }
        finally
        {
            _players.Remove(player);
            int score = RemovePlayerFromGame(player);
            _disconnectedPlayers.Add(new DisconnectedPlayer()
            {
                Player = player,
                Score = score
            });
            Console.WriteLine($"{player.DisplayName}: player disconnected.");
        }
    }

    private static void AttachScoreIfInDisconnectedPlayers(Player player)
    {
        if (_game == null) return;
        int disconnectedPlayerScore = _disconnectedPlayers
            .Where(x => x.Player.PlayerName == player.PlayerName)
            .OrderByDescending(x => x.Score)
            .Select(x => x.Score)
            .FirstOrDefault();
        _game.PlayerScores.Single(x => x.PlayerId == player.Id).Score = disconnectedPlayerScore;

    }

    private static async void AddPlayerToActiveGameIfAny(Player player)
    {
        if (_game == null) return;
        _game.PlayerScores.Add(new PlayerScores()
        {
            PlayerId = player.Id,
            Score = 0,
        });
        _game.ActiveRound.PlayerRoundData.Add(new PlayerRoundData(player.Id, Round.PlayerStatusMapper[_game.ActiveRound.Stage]));
    }

    private static int RemovePlayerFromGame(Player player)
    {
        if (_game == null)
            return 0;
        int score = _game.PlayerScores
            .Where(x => player.Id == x.PlayerId)
            .Select(x => x.Score)
            .FirstOrDefault();
        _game.PlayerScores = _game.PlayerScores
            .Where(x => player.Id != x.PlayerId)
            .ToList();
        _game.ActiveRound.PlayerRoundData = _game.ActiveRound.PlayerRoundData
            .Where(x => x.PlayerId != player.Id)
            .ToList();
        // In case the disconnected player is the player who is bakes start new round
        if (_game.ActiveRound.SelectedPlayer.Id == player.Id)
        {
            NewRound().GetAwaiter().GetResult();
        }
        return score;

    }
}