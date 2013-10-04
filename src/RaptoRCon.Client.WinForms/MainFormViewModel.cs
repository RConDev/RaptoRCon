using Microsoft.AspNet.SignalR.Client;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RaptoRCon.Client.WinForms
{
    public class MainFormViewModel : ViewModelBase
    {
        private string hostName;
        private int port;
        private ObservableCollection<ConnectionViewModel> connections;
        private HttpClient httpClient;

        public string HostName
        {
            get { return hostName; }
            set
            {
                hostName = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged();
            }
        }

        private ICommand addConnectionCommand = new DelegateCommand(async (p) =>
        {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await AddConnectionAsync(viewModel);
        });

        public MainFormViewModel(Control owner) : base(owner)
        {
            this.connections = new ObservableCollection<ConnectionViewModel>();
            InitializeHub();
        }

        private void InitializeHub()
        {
            this.hubConnection = new HubConnection("http://localhost:10505/");
            var messageHubProxy = hubConnection.CreateHubProxy("MessageHub");
            messageHubProxy.On<Guid, string>("SendMessage", (id, message) => {
                
                var connection = this.connections.SingleOrDefault(x => x.Id == id);
                if (connection == null) return;

                Owner.Invoke(new MethodInvoker(delegate() {connection.Packets.Add(new Packet() { Content = message });}));
                
            });
            hubConnection.Start();
        }

        public ICommand AddConnectionCommand
        {
            get { return addConnectionCommand; }
        }

        public ObservableCollection<ConnectionViewModel> Connections
        {
            get { return connections; }
            set
            {
                connections = new ObservableCollection<ConnectionViewModel>(value);
                OnPropertyChanged();
            }
        }

        #region Private Methods

        private static async Task AddConnectionAsync(MainFormViewModel viewModel)
        {
            var connection = new RaptoRCon.Shared.Models.Connection()
            {
                HostName = viewModel.HostName,
                Port = viewModel.Port
            };

            var response = await viewModel.HttpClient.PostAsJsonAsync<RaptoRCon.Shared.Models.Connection>("connection", connection);
            var connectionCreated = await response.Content.ReadAsAsync<ConnectionCreated>();
            connection.Id = connectionCreated.ConnectionId;

            viewModel.Connections.Add(new ConnectionViewModel(viewModel.Owner, connection));

            viewModel.HostName = null;
            viewModel.Port = 0;
        }

        #endregion

        public Control OwnerControl { get; private set; }

        public HubConnection hubConnection { get; set; }
    }
}
