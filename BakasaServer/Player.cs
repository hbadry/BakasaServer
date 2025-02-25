using System.Net;
using System.Net.Sockets;
using System.Numerics;

namespace BakasaServer
{
    public class Player
    {
        public Player(TcpClient client)
        {
            Client = client;
            IPEndPoint remoteEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            Id = $"{remoteEndPoint.Address}:{remoteEndPoint.Port}";
        }
        public string Id { get; set; }
        public TcpClient Client { get; set; }
        public bool Connected
        {
            get
            {

                return Client?.Connected ?? false;
            }
        }
        public string PlayerName { get; set; }
        public string DisplayName
        {
            get
            {
                return string.IsNullOrWhiteSpace(PlayerName) ? Id : PlayerName;
            }
        }

    }
}
