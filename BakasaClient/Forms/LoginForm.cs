using AutoUpdaterDotNET;
using BakasaClient.Forms;
using BakasaClient.ServerHandling;
using BakasaCommon.Commands;
using System.Drawing.Drawing2D;
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

            this.BackColor = Color.White; // White background
            this.FormBorderStyle = FormBorderStyle.None; // Remove default Windows border
            this.Padding = new Padding(1); // Add slight padding for a custom border


            btnConnect.BackColor = Color.FromArgb(0, 122, 204); // Nice blue color
            btnConnect.ForeColor = Color.White;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.Font = new Font("Tahoma", 10, FontStyle.Bold);

            btnPaste.BackColor = Color.FromArgb(60, 179, 113); // Green color
            btnPaste.ForeColor = Color.White;
            btnPaste.FlatStyle = FlatStyle.Flat;
            btnPaste.FlatAppearance.BorderSize = 0;
            btnPaste.Font = new Font("Tahoma", 10, FontStyle.Bold);
            this.FormBorderStyle = FormBorderStyle.None; // Removes ugly Windows border
            this.Padding = new Padding(1); // Padding for border

            // Paint event to draw a border
            this.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };
            Button btnExit = new Button();
            btnExit.Text = "✖";
            btnExit.Font = new Font("Tahoma", 12, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Size = new Size(35, 30);
            btnExit.Location = new Point(this.Width - 40, 5);
            btnExit.Click += (s, e) => this.Close(); // Close form when clicked
            this.Controls.Add(btnExit);


        }
        #region Form dragging
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = false;
        }
        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Corner radius
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
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
                WriteAllLines();
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
            AutoUpdater.Start("https://gist.githubusercontent.com/hbadry/e508f050baddb5b5a643676a2c1a3cc6/raw/bakasa_client_auto_updater.xml");
            string[] lines = File.ReadAllLines("settings.txt");
            if (lines?.Length > 0)
            {
                txtName.Text = lines[0];
            }
            if (lines?.Length > 1)
            {
                txtIP.Text = lines[1];
            }
        }
        private void WriteAllLines()
        {
            try
            {
                string[] lines = { txtName.Text, txtIP.Text };
                File.WriteAllLines("settings.txt", lines);
            }
            catch { }
            
        }
    }
}
