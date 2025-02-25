using BakasaCommon.Commands;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class ChatClient
{
    private const string SERVER_IP = "127.0.0.1"; // Change to your public IP
    private const int PORT = 8085; // Must match server port

    static async Task Main()
    {
        try
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            using TcpClient client = new TcpClient();
            await client.ConnectAsync(SERVER_IP, PORT);
            Console.WriteLine("Connected to the chat server!");
            var setNameCommand = SystemCommands.SetName(name);

            NetworkStream stream = client.GetStream();
            await stream.WriteAsync(SystemCommands.ToBytes(setNameCommand));
            _ = ReceiveMessages(stream); // Start receiving messages in the background

            while (true)
            {
                string message = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(message)) continue;

                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ReceiveMessages(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0) break; // Server disconnected

            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"\n {message}");
        }
    }
}