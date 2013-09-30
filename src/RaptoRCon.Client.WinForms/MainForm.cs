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

namespace RaptoRCon.Client.WinForms
{
    public partial class MainForm : Form
    {
        private HttpClient httpClient;

        public MainForm()
        {
            InitializeComponent();

            this.httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:10505/api/") };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var connection = new Connection()
            {
                Address = this.textBox1.Text,
                Port = Convert.ToInt32(this.textBox2.Text)
            };

            var response = await httpClient.PostAsJsonAsync<Connection>("connection", connection);
            MessageBox.Show(string.Format("Connection to {0} on port {1} created.", connection.Address, connection.Port));
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            var command = new Command() { CommandString = this.textBox3.Text };
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
    }
}
