using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RaptoRCon.Shared.Models;

namespace RaptoRCon.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient httpClient;

        public MainWindow()
        {
            InitializeComponent();
            this.httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:10505") };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var host = hostTextBox.Text;
            var port = Convert.ToInt32(hostPortTextBox.Text);

            var connection = new Connection() {Address = host, Port = port};
            //httpClient.
        }
    }
}
