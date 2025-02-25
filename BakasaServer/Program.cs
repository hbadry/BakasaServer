using BakasaCommon.Commands;
using BakasaServer;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ChatServer
{
    private static List<Player> _players = new List<Player>();
    private static TcpListener _server;
    private static Game _game;
    private const int PORT = 8085; // Change this if needed

    private static bool _gameStarted = false;

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
            Console.WriteLine("2 - new round");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    NewRound().GetAwaiter().GetResult();
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
        if (_gameStarted)
        {
            Console.WriteLine("There is already active game running");
        }
        Task.Run(async () =>
        {
            await CreateGame();
        });


    }
    private async static Task NewRound()
    {
        if (_players?.Where(x => x.Connected)?.Count() < 2)
        {
            Console.WriteLine("Must be at least 3 users to play!");
        }
        if (_gameStarted)
        {
            Console.WriteLine("There is no game started!");
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
            Console.WriteLine("player disconnected.");
        }
    }



}