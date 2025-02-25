using BakasaClient.Forms;
using BakasaClient.ServerHandling;
using BakasaCommon.Commands;
using System.Net.Sockets;
using System.Text;

namespace BakasaClient
{
    public partial class LoginForm : Form
    {
        private bool isConnected = false;
        public LoginForm()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\bakasa.ico");
            pbStatus.Invalidate();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ClickConnect();

        }

        private void ClickConnect()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIP.Text))
                {
                    MessageBox.Show("يجب وضع IP");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("يجب وضع الاسم");
                    return;
                }
                AppState.Instance.Name = txtName.Text;
                AppState.Instance.ServerIp = txtIP.Text;
                TcpClient client = new TcpClient();
                client.ConnectAsync(AppState.Instance.ServerIp, AppState.Instance.ServerPort).GetAwaiter().GetResult();
                btnConnect.Enabled = false;
                btnPaste.Enabled = false;
                txtIP.ReadOnly = true;
                txtName.ReadOnly = true;
                isConnected = true;
                pbStatus.Invalidate();
                AppState.Instance.Client = client;
                StartReceiveTask(client);
                MessageHelper.ShowInfo("تم الاتصال بنجاح");
                this.DialogResult = DialogResult.OK;
                this.Hide();

            }
            catch (Exception ex)
            {
                Logger.LogException(ex, "حدث خطا اثناء الاتصال");
            }
        }

        private void StartReceiveTask(TcpClient client)
        {
            var setNameCommand = SystemCommands.SetName(AppState.Instance.Name);

            NetworkStream stream = client.GetStream();
            stream.WriteAsync(SystemCommands.ToBytes(setNameCommand)).GetAwaiter().GetResult();
            _ = ReceiveMessages(stream); // Start receiving messages in the background

        }
        private static async Task ReceiveMessages(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // Server disconnected

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Logger.Log($"\n {message}");
                await CommandHandler.Handle(message);

            }
        }

        private void pbStatus_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color circleColor = isConnected ? Color.Green : Color.Red;

            using (SolidBrush brush = new SolidBrush(circleColor))
            {
                e.Graphics.FillEllipse(brush, 0, 0, pbStatus.Width, pbStatus.Height);
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtIP.Text = Clipboard.GetText();
        }

        private void LoginForm_Enter(object sender, EventArgs e)
        {
            ClickConnect();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            ClickConnect();
        }

        private void txtIP_Enter(object sender, EventArgs e)
        {
            ClickConnect();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("settings.txt");
            if (lines?.Length>0)
            {
                txtName.Text = lines[0];    
            }
            if (lines?.Length>1)
            {
                txtIP.Text = lines[1];
            }


        }
    }
}
