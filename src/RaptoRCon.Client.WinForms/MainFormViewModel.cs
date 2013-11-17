﻿using Microsoft.AspNet.SignalR.Client;
using RaptoRCon.Client.WinForms.Sdk;
using RaptoRCon.Shared.Commands;
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
        private GamesClient gamesClient = new GamesClient();

        private static async Task GetConnectionsAsync(MainFormViewModel viewModel)
        {
            var response = await viewModel.HttpClient.GetAsync("connection");
            response.EnsureSuccessStatusCode();

            var connections = await response.Content.ReadAsAsync<IEnumerable<RaptoRCon.Shared.Models.Connection>>();
            viewModel.connections.Clear();
            foreach (var connection in connections)
            {
                viewModel.Context.Post(state => ((MainFormViewModel)state).Connections.Add(new ConnectionViewModel(connection)), viewModel);
            }
        }

        private ICommand addConnectionCommand = new DelegateCommand(async (p) =>
        {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await AddConnectionAsync(viewModel);
        });

        private ICommand removeConnectionCommand = new DelegateCommand(async p =>
        {
            var viewModel = p as MainFormViewModel;
            if (viewModel == null) return;

            await RemoveConnectionAsync(viewModel);

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

        public MainFormViewModel()
        {
            this.connections = new ObservableCollection<ConnectionViewModel>();
            Initialize();
            InitializeHub();
        }

        private async Task Initialize()
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

        public ICommand AddConnectionCommand
        {
            get { return addConnectionCommand; }
        }

        public ICommand RemoveConnectionCommand { get { return removeConnectionCommand; } }

        public ObservableCollection<ConnectionViewModel> Connections
        {
            get { return connections; }
        }

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
                Port = viewModel.Port
            };

            var response = await viewModel.HttpClient.PostAsJsonAsync("connection", createConnection);
            response.EnsureSuccessStatusCode();

            var connectionCreated = await response.Content.ReadAsAsync<ConnectionCreated>();
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

        #endregion

        public HubConnection HubConnection { get; set; }

        private ObservableCollection<Game> games;
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
