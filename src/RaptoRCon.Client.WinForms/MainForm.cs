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
    public partial class MainForm : Form, ISyncCall
    {
        private HttpClient httpClient;
        private HubConnection hubConnection;
        private Guid connectionId;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainFormViewModel DataContext { get; private set; }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.DataContext = new MainFormViewModel(a => this.Invoke(a));

            this.mainFormViewModelBindingSource.DataSource = this.DataContext;
            this.mainFormViewModelBindingSource.ResetBindings(false);
        }

        private void addConnectionButton_Click(object sender, EventArgs e)
        {
            var command = DataContext.AddConnectionCommand;
            if (command != null && command.CanExecute(null))
            {
                command.Execute(this.DataContext);
            }
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
            var currentConnection = this.DataContext.CurrentConnection;
            if (currentConnection == null) return;

            var command = currentConnection.SendCommand;
            if (command != null && command.CanExecute(null))
            {
                command.Execute(currentConnection);
            }
        }

        private void connectionsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.DataContext.CurrentConnection = connectionsBindingSource.Current as ConnectionViewModel;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var command = DataContext.RemoveConnectionCommand;
            if (command != null)
            {
                command.Execute(this.DataContext);
            }
        }

        void ISyncCall.Invoke(Action action)
        {
            this.Invoke(action);
        }

        public bool syncInvoker { get; set; }
    }
}
