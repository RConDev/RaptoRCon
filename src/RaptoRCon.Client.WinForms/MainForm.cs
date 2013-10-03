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

            this.httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:10505/api/") };
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var connection = new Connection()
            {
                HostName = this.textBox1.Text,
                Port = Convert.ToInt32(this.textBox2.Text)
            };

            var response = await httpClient.PostAsJsonAsync<Connection>("connection", connection);
            var connectionCreated = await response.Content.ReadAsAsync<ConnectionCreated>();
            this.connectionId = connectionCreated.ConnectionId;
            MessageBox.Show(string.Format("Connection to {0} on port {1} created. Id: {2}", connection.HostName, connection.Port, this.connectionId));
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            var command = new Command() { ConnectionId = this.connectionId, CommandString = this.textBox3.Text };
            var response = await httpClient.PostAsJsonAsync<Command>("command", command);

            InvokeIfRequired(this.listBox1, () =>
            {
                this.listBox1.Items.Add(command.CommandString);
            });
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
            this.hubConnection = new HubConnection("http://localhost:10505/");
            var messageHubProxy = hubConnection.CreateHubProxy("MessageHub");
            messageHubProxy.On<Guid, string>("SendMessage", (id, message) => InvokeIfRequired(this, () => listBox1.Items.Add(string.Format("{0} - {1}", id, message))));
            hubConnection.Start();
        }
    }
}
