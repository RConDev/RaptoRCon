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

        private ICommand getConnectionsCommand = new DelegateCommand(async p => {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await GetConnectionsAsync(viewModel);
        });

        private static async Task GetConnectionsAsync(MainFormViewModel viewModel)
        {
            var response = await viewModel.HttpClient.GetAsync("connection");
            response.EnsureSuccessStatusCode();

            var connections = await response.Content.ReadAsAsync<IEnumerable<RaptoRCon.Shared.Models.Connection>>();
            viewModel.connections.Clear();
            foreach (var connection in connections)
            {
                viewModel.SyncInvoker(() => viewModel.Connections.Add(new ConnectionViewModel(viewModel.SyncInvoker, connection)));
            }
        }

        private ICommand addConnectionCommand = new DelegateCommand(async (p) =>
        {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await AddConnectionAsync(viewModel);
            await GetConnectionsAsync(viewModel);
        });

        private ICommand removeConnectionCommand = new DelegateCommand(async p =>
        {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await RemoveConnectionAsync(viewModel);
            await GetConnectionsAsync(viewModel);
        });

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

        public ConnectionViewModel CurrentConnection { get; set; }

        public MainFormViewModel(Action<Action> syncInvoker)
            : base(syncInvoker)
        {
            this.connections = new ObservableCollection<ConnectionViewModel>();
            Initialize();
            InitializeHub();
        }

        private async Task Initialize()
        {
            await GetConnectionsAsync(this);
        }

        private void InitializeHub()
        {
            this.hubConnection = new HubConnection("http://localhost:10505/");
            var messageHubProxy = hubConnection.CreateHubProxy("MessageHub");
            messageHubProxy.On<Guid, string>("SendMessage", (id, message) => {
                
                var connection = this.connections.SingleOrDefault(x => x.Id == id);
                if (connection == null) return;

                SyncInvoker(() => connection.Packets.Add(new Packet() { Content = message }));
                
            });
            hubConnection.Start();
        }

        public ICommand AddConnectionCommand
        {
            get { return addConnectionCommand; }
        }

        public ICommand RemoveConnectionCommand { get { return removeConnectionCommand; } } 

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
            response.EnsureSuccessStatusCode();

            viewModel.HostName = null;
            viewModel.Port = 0;
        }

        private static async Task RemoveConnectionAsync(MainFormViewModel viewModel)
        {
            if (viewModel.CurrentConnection == null) return;

            var response = await viewModel.HttpClient.DeleteAsync(string.Format("connection/{0}", viewModel.CurrentConnection.Id));
            response.EnsureSuccessStatusCode();
        }

        #endregion

        public Control OwnerControl { get; private set; }

        public HubConnection hubConnection { get; set; }
    }
}
