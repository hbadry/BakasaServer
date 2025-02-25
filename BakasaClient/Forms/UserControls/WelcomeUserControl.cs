namespace BakasaClient.Forms.UserControls
{
    public partial class WelcomeUserControl : UserControl
    {
        public WelcomeUserControl()
        {
            InitializeComponent();
        }

        private void WelcomeUserControl_Load(object sender, EventArgs e)
        {
            lbWelcome.Text = $"مرحبا {AppState.Instance.Name}" + "\n";
            lbWelcome.Text += "في إنتظار اللاعبين لبدا اللعبة";
            lbWelcome.Font = new Font("Tahoma", 14, FontStyle.Bold); // Arabic-friendly font
            lbWelcome.ForeColor = Color.Green; // Green text
            lbWelcome.RightToLeft = RightToLeft.Yes; // Align text for Arabic (if needed)

        }

        private void lbWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
