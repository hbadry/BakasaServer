namespace BakasaClient.Forms.UserControls
{
    public partial class BakesResultsControl : UserControl
    {
        private string _bakesName;
        private string _itemsToSelectFrom;
        public BakesResultsControl(string bakesName,string itemsToSelectFrom)
        {
            _bakesName = bakesName;
            _itemsToSelectFrom = itemsToSelectFrom;
            InitializeComponent();
        }

        private void BakesResultsControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("Resources\\bakas.gif");
            lblBakes.Text = $"البكس هو ({_bakesName})";
            if (_bakesName == AppState.Instance.Name)
            {
                btnSelectItem.Enabled = true;
            }
        }
        private void btnSelectItem_Click_1(object sender, EventArgs e)
        {
            AppState.Instance.MainForm.LoadUserControl(new PlayerVoteUserControl(_itemsToSelectFrom,false));

        }
    }
}
