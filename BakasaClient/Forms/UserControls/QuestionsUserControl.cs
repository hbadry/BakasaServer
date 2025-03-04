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
    public partial class QuestionsUserControl : UserControl
    {
        private readonly string _sender;
        private readonly string _receiver;

        public QuestionsUserControl(string sender, string receiver)
        {
            _sender = sender;
            _receiver = receiver;
            InitializeComponent();
        }

        private void QuestionsUserControl_Load(object sender, EventArgs e)
        {
            lblText.Text = $"سيقوم ({_sender}) بسوال ({_receiver})";
            if (_sender == AppState.Instance.Name)
            {
                btnIAsked.Enabled = true;
            }
            if (AppState.Instance.ReadyToVote)
            {
                btnReadyToVote.Enabled = false;
            }
        }

        private void btnIAsked_Click(object sender, EventArgs e)
        {
            var command = SystemCommands.QuestionAsked();
            AppState.BroadcastMessage(command).GetAwaiter().GetResult();
            this.btnIAsked.Enabled = false;
        }

        private void btnReadyToVote_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageHelper.Confirm("هل انت متاكد من انك جاهز للتصويت؟");

            if (result == DialogResult.Yes)
            {
                var command = SystemCommands.ReadyToVote();
                AppState.BroadcastMessage(command).GetAwaiter().GetResult();
                AppState.Instance.ReadyToVote = true;
                btnReadyToVote.Enabled = false;
            }
        }

        private void btnShowWord_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                MessageHelper.ShowInfo($"{AppState.Instance.CurrentItem}");
            })
            { IsBackground = true }.Start();
        }
    }
}
