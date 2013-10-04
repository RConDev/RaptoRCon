using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RaptoRCon.Shared.Util;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace RaptoRCon.Client.WinForms
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {


        protected async void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler == null)
            {
                return;
            }

            var receivers = propertyChangedEventHandler.GetInvocationList();
            foreach (PropertyChangedEventHandler receiver in receivers) 
            {
                Task.Factory.StartNew(() => Owner.Invoke(new MethodInvoker(delegate() { receiver.Invoke(this, new PropertyChangedEventArgs(propertyName)); })));
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected Control Owner { get; private set; }

        public ViewModelBase(Control owner)
        {
            this.Owner = owner;
            this.HttpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:10505/api/") };
        }

        protected HttpClient HttpClient { get; private set; }
    }
}
