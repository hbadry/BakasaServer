using BakasaClient.Forms.UserControls;
using BakasaCommon.Commands;

namespace BakasaClient.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon("Resources\\bakasa.ico");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"بكاسة - {AppState.Instance.Name}";
            LoadUserControl(new WelcomeUserControl());
            this.BackColor = Color.White; // Base background
            //LoadUserControl(new BakesResultsControl("حسن بدري","1$$2$$3$$4"));
        }
        public void LoadUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear(); // Remove previous controls
            userControl.Dock = DockStyle.Fill; // Fill the panel
            panelContainer.Controls.Add(userControl); // Add new control
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowScore_Click(object sender, EventArgs e)
        {
            var command = SystemCommands.Client_ShowScore();
            AppState.BroadcastMessage(command).GetAwaiter().GetResult();
        }

        //private void btnShowUserControl1_Click(object sender, EventArgs e)
        //{
        //    LoadUserControl(new UserControl1());
        //}

        //private void btnShowUserControl2_Click(object sender, EventArgs e)
        //{
        //    LoadUserControl(new UserControl2());
        //}
    }
}
