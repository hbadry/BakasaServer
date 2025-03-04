using BakasaClient.Forms;
using BakasaClient.Forms.Classes;
using System.Net.Sockets;
using System.Text;

namespace BakasaClient
{
    public class AppState
    {
        private static AppState? _instance;
        private static readonly object _lock = new object();

        // Example properties
        public string Name { get; set; } = "";
        public string ServerIp { get; set; } = "";
        public int ServerPort { get; set; } = 8085;

        public bool ReadyToVote { get; set; } = false;
        public string CurrentItem { get; set; } = "";

        public UserSettings UserSettings { get; set; }

        public TcpClient Client { get; set; }

        private AppState() { } // Private constructor

        public static AppState Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new AppState();
                }
            }
        }
        public static async Task BroadcastMessage(string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                await Instance.Client.GetStream().WriteAsync(data, 0, data.Length);
            }
            catch
            {
                /* Ignore failed sends (e.g., disconnected clients) */
            }
        }

        public MainForm MainForm { get; internal set; }
    }

}
