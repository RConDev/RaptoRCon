using Microsoft.AspNet.SignalR.Client;
using RaptoRCon.Client.WinForms.Sdk;
using RaptoRCon.Shared.Commands;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RaptoRCon.Client.WinForms
{
    public class MainFormViewModel : ViewModelBase
    {
        private string hostName;
        private int port;
        private readonly ObservableCollection<ConnectionViewModel> connections;
        private readonly GamesClient gamesClient = new GamesClient();

        private ObservableCollection<Game> games;
        private string password;
        private static readonly ConnectionClient connectionsClient;

        public ObservableCollection<ConnectionViewModel> Connections
        {
            get { return connections; }
        }

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

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ConnectionViewModel CurrentConnection { get; set; }
        
        public MainFormViewModel()
        {
            this.connections = new ObservableCollection<ConnectionViewModel>();
            Initialize();
            InitializeHub();
        }

        private async void Initialize()
        {
            await GetConnectionsAsync(this);
            await GetGamesAsync(this);
        }

        private void InitializeHub()
        {
            this.HubConnection = new HubConnection("http://localhost:10505/");
            var messageHubProxy = HubConnection.CreateHubProxy("MessageHub");
            messageHubProxy.On<Guid, string>("SendMessage", (id, message) =>
            {
                var connection = this.connections.SingleOrDefault(x => x.Id == id);
                if (connection == null) return;

                connection.Context.Post(state => ((ConnectionViewModel)state).AddPacket(new Packet() { Content = message }), connection);

            });
            HubConnection.Start();
        }

        #region Commands

        public ICommand AddConnectionCommand
        {
            get
            {
                return new DelegateCommand(
                    async (p) =>
                          {
                              var viewModel = p as MainFormViewModel;
                              if (viewModel == null) return;

                              await AddConnectionAsync(viewModel);
                          });
            }
        }

        public ICommand RemoveConnectionCommand
        {
            get
            {
                return new DelegateCommand(
                    async p =>
                          {
                              var viewModel = p as MainFormViewModel;
                              if (viewModel == null) return;

                              await RemoveConnectionAsync(viewModel);
                          });
            }
        }

        #endregion

        #region Private Methods

        private static async Task GetGamesAsync(MainFormViewModel viewModel)
        {
            var games = await viewModel.gamesClient.GetAsync();
            viewModel.Context.Post(state => ((MainFormViewModel)state).Games = new ObservableCollection<Game>(games), viewModel);

        }

        private static async Task AddConnectionAsync(MainFormViewModel viewModel)
        {
            var createConnection = new CreateConnectionCommand()
            {
                GameId = viewModel.CurrentGameId.Value,
                HostName = viewModel.HostName,
                Port = viewModel.Port,
                Password = viewModel.Password
            };

            var connectionCreated = await connectionsClient.CreateAsync(createConnection);
            viewModel.Context.Post(state => ((MainFormViewModel)state).AddConnection(new ConnectionViewModel(connectionCreated.Connection)), viewModel);

            viewModel.CurrentGameId = null;
            viewModel.HostName = null;
            viewModel.Port = 0;
        }

        

        private void AddConnection(ConnectionViewModel connectionViewModel)
        {
            this.Connections.Add(connectionViewModel);
            this.OnPropertyChanged("Connections");
        }

        private void RemoveConnection(ConnectionViewModel connectionViewModel)
        {
            this.Connections.Remove(connectionViewModel);
            OnPropertyChanged("Connections");
        }

        private static async Task RemoveConnectionAsync(MainFormViewModel viewModel)
        {
            if (viewModel.CurrentConnection == null) return;

            var response = await viewModel.HttpClient.DeleteAsync(string.Format("connection/{0}", viewModel.CurrentConnection.Id));
            response.EnsureSuccessStatusCode();

            viewModel.RemoveConnection(viewModel.CurrentConnection);
        }

        private static async Task GetConnectionsAsync(MainFormViewModel viewModel)
        {
            var connections = await connectionsClient.GetAllAsync();
            viewModel.connections.Clear();
            foreach (var connection in connections)
            {
                viewModel.Context.Post(state => ((MainFormViewModel)state).Connections.Add(new ConnectionViewModel(connection)), viewModel);
            }
        }

        #endregion

        public HubConnection HubConnection { get; set; }

        
        static MainFormViewModel()
        {
            connectionsClient = new ConnectionClient();
        }

        public ObservableCollection<Game> Games
        {
            get { return games; }
            set
            {
                this.games = value;
                OnPropertyChanged();
            }
        }

        public Guid? CurrentGameId { get; set; }
    }
}
