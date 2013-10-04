using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Shared.Util
{
    public static class EventHandlerExtensions
    {
        public static async Task InvokeAllAsync<T>(this EventHandler<T> eventHandler, object sender, T eventArgs)
        {
            var receivers = eventHandler.GetInvocationList();
            foreach (EventHandler<T> receiver in receivers)
            {
                await Task.Factory.FromAsync<object, T>(receiver.BeginInvoke,
                                                        receiver.EndInvoke,
                                                        sender,
                                                        eventArgs,
                                                        null);
            }
        }
    }
}
