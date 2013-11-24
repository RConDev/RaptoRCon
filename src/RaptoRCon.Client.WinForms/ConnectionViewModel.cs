using RaptoRCon.Client.WinForms.Sdk;
using RaptoRCon.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Data;

namespace RaptoRCon.Client.WinForms
{
    /// <summary>
    /// <see cref="ViewModelBase"/> instance holding data and interacting of/with a connection
    /// </summary>
    public class ConnectionViewModel : ViewModelBase
    {
        private readonly object packetsLock = new object();
        private ObservableCollection<Packet> packets;
        private Connection connection;
        private string commandString;
        private readonly CommandsClient commandsClient = new CommandsClient();

        #region Properties

        public Guid Id
        {
            get { return connection.Id; }
        }

        public string HostName
        {
            get { return connection.HostName; }

        }

        public int Port
        {
            get { return connection.Port; }
        }

        public ConnectionState State
        {
            get { return connection.State; }
        }

        public string CommandStringString
        {
            get { return commandString; }
            set
            {
                commandString = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ConnectionViewModel(Connection connection)
            : base()
        {
            this.connection = connection;
            this.Packets = new ObservableCollection<Packet>();

            BindingOperations.EnableCollectionSynchronization(Packets, packetsLock);
        }

        public void AddPacket(Packet packet)
        {
            this.Packets.Add(packet);
            OnPropertyChanged("Packets");
        }


        private void UpdateConnection(Connection connection)
        {
            this.connection = connection;
            OnPropertyChanged("Id");
            OnPropertyChanged("HostName");
            OnPropertyChanged("Port");
            OnPropertyChanged("State");
        }

        #region Commands

        public ICommand SendCommand
        {
            get
            {
                return new DelegateCommand(
                    async (p) =>
                    {
                        var viewModel = p as ConnectionViewModel;
                        if (viewModel == null) return;

                        var command = new Command()
                                      {
                                          ConnectionId = viewModel.Id,
                                          CommandString = viewModel.CommandStringString
                                      };

                        var commandResult = await commandsClient.SendAsync(command);
                        viewModel.AddPacket(new Packet()
                                            {
                                                Content = viewModel.CommandStringString
                                            });
                        viewModel.CommandStringString = null;
                    });
            }
        }

        public ICommand DisconnectCommand
        {
            get
            {
                return new DelegateCommand(
                    async p =>
                    {
                        var viewModel = p as ConnectionViewModel;
                        if (viewModel == null) return;

                        var connectionClient = new ConnectionClient();
                        var updatedConnection = await connectionClient.DisconnectAsync(viewModel.Id);
                        viewModel.UpdateConnection(updatedConnection);
                    });
            }
        }

        public ICommand ConnectCommand
        {
            get
            {
                return new DelegateCommand(async p =>
                {
                    var viewModel = p as ConnectionViewModel;
                    if (viewModel == null) return;

                    var connectionClient = new ConnectionClient();
                    var updatedConnection = await connectionClient.ConnectAsync(viewModel.Id);
                    viewModel.UpdateConnection(updatedConnection);
                });
            }
        }

        #endregion
    }
}
