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

namespace RaptoRCon.Client.WinForms
{
    public class ConnectionViewModel : ViewModelBase
    {
        private Guid id;
        private string hostName;
        private int port;
        private ObservableCollection<Packet> packets;
        private Connection connection;
        private ICommand sendCommand = new DelegateCommand(async (p) => {
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

        public ConnectionViewModel(Control owner, Connection connection) : base(owner)
        {
            this.connection = connection;
            this.Packets = new ObservableCollection<Packet>();
        }

        public ObservableCollection<Packet> Packets
        {
            get { return packets; }
            set
            {
                packets = new ObservableCollection<Packet>(value);
                OnPropertyChanged();
            }
        }

    }
}
