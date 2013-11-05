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
        private object packetsLock = new object();
        private ObservableCollection<Packet> packets;
        private Connection connection;

        private ICommand sendCommand = new DelegateCommand(async (p) =>
        {
            var viewModel = p as ConnectionViewModel;
            if (viewModel == null) return;

            var command = new Command() { ConnectionId = viewModel.Id, CommandString = viewModel.CommandString };
            var response = await viewModel.HttpClient.PostAsJsonAsync<Command>("command", command);

            viewModel.Packets.Add(new Packet() { Content = viewModel.CommandString });
            viewModel.CommandString = null;
        });

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

        private string command;

        public string CommandString
        {
            get { return command; }
            set
            {
                command = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendCommand { get { return sendCommand; } }

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

        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = value;
                OnPropertyChanged();
            }
        }

    }
}
