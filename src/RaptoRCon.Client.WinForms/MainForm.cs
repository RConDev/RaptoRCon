using Microsoft.AspNet.SignalR.Client;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection = RaptoRCon.Shared.Models.Connection;
namespace RaptoRCon.Client.WinForms
{
    public partial class MainForm : Form
    {
        private HttpClient httpClient;
        private HubConnection hubConnection;
        private Guid connectionId;

        public MainForm()
        {
            InitializeComponent();
            this.DataContext = new MainFormViewModel(this);

            this.mainFormViewModelBindingSource.DataSource = this.DataContext;
            this.mainFormViewModelBindingSource.ResetBindings(false);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            //var command = new Command() { ConnectionId = this.connectionId, CommandString = this.textBox3.Text };
            //var response = await httpClient.PostAsJsonAsync<Command>("command", command);

            //InvokeIfRequired(this.listBox1, () =>
            //{
            //    this.listBox1.Items.Add(command.CommandString);
            //});
        }

        private static void InvokeIfRequired(ISynchronizeInvoke control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action, null);
            }
            else
            {
                action();
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        public MainFormViewModel DataContext { get; private set; }

        private void addConnectionButton_Click(object sender, EventArgs e)
        {
            var command = DataContext.AddConnectionCommand;
            if (command != null)
            {
                command.Execute(this.DataContext);
            }
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
            var currentConnection = connectionsBindingSource.Current as ConnectionViewModel;
            if (currentConnection == null) return;

            var command = currentConnection.SendCommand;
            if (command != null)
            {
                command.Execute(currentConnection);
            }
        }
    }
}
