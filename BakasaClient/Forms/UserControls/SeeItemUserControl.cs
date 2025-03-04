using BakasaCommon.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakasaClient.Forms.UserControls
{
    public partial class SeeItemUserControl : UserControl
    {
        private string _itemName;
        public SeeItemUserControl(string itemName)
        {
            _itemName = itemName;
            AppState.Instance.CurrentItem = itemName;
            InitializeComponent();
            card.CardFlippedEvent += card_OnCardFlipped;
        }
        // Event handler in the parent form
        private void card_OnCardFlipped(object sender, EventArgs e)
        {
            this.btnReady.Enabled = true;
        }
        private void SeeItemUserControl_Load(object sender, EventArgs e)
        {
            AppState.Instance.ReadyToVote = false;
            card.SetImages(Image.FromFile("Resources\\front-image.jpg"), Image.FromFile("Resources\\back-image.jpg"), _itemName);
        }

        private async void btnReady_Click(object sender, EventArgs e)
        {
            var command = SystemCommands.SawItem();
            AppState.BroadcastMessage(command).GetAwaiter().GetResult();
            this.btnReady.Enabled = false;
        }
    }
}
