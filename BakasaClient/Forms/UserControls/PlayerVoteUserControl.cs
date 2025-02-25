using BakasaCommon.Commands;
using System.Data;

namespace BakasaClient.Forms.UserControls
{
    public partial class PlayerVoteUserControl : UserControl
    {
        private List<string> _players;
        private string selectedPlayer;
        private bool _isPlayerSelection;
        public PlayerVoteUserControl(string playersToVoteFor,bool isPlayerSelection = true)
        {
            _isPlayerSelection = isPlayerSelection;
            _players = playersToVoteFor.Split("$$")
                .Where(x => x != AppState.Instance.Name)
                .ToList();
            InitializeComponent();
        }

        private void PlayerVoteUserControl_Load(object sender, EventArgs e)
        {
            listControl.SetItems(_players);
            listControl.SelectionChanged += ListControl_SelectionChanged;
        }
        private void ListControl_SelectionChanged(object sender, string selectedItem)
        {
            selectedPlayer = selectedItem;
            btnUserSelected.Enabled = true;
        }

        private void btnUserSelected_Click(object sender, EventArgs e)
        {
            if (_isPlayerSelection)
            {
                var command = SystemCommands.ClientVoted(selectedPlayer);
                AppState.BroadcastMessage(command).GetAwaiter().GetResult();
            }
            else
            {
                var command = SystemCommands.ClientBakesVoted(selectedPlayer);
                AppState.BroadcastMessage(command).GetAwaiter().GetResult();
            }
            
            btnUserSelected.Enabled = false;
            listControl.Enabled = false;
        }
    }
}
