using System.Text;

namespace BakasaServer
{
    public static class BroadCaster
    {
        public static string LastCommandToAllPlayers;
        public static async Task BroadcastMessageToAllPlayers(string message, List<Player> players)
        {
            LastCommandToAllPlayers = message;
            byte[] data = Encoding.UTF8.GetBytes(message);
            foreach (var player in players)
            {
                await BroadcastMessage(data, player);
            }
        }
        public static async Task BroadcastMessage(byte[] data, Player player)
        {
            try
            {
                await player.Client.GetStream().WriteAsync(data, 0, data.Length);

            }
            catch
            {
                /* Ignore failed sends (e.g., disconnected clients) */
            }
        }
        public static async Task BroadcastMessage(string message, Player player)
        {

            byte[] data = Encoding.UTF8.GetBytes(message);
            await BroadcastMessage(data, player);

        }
    }
}
