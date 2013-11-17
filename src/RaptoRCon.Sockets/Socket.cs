using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// Implementation of <see cref="ISocket"/>
    /// </summary>
    public class Socket : ISocket
    {
        private readonly System.Net.Sockets.Socket socket;

        public Socket()
        {
            this.socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public Socket(System.Net.Sockets.Socket socket)
        {
            this.socket = socket;
        }

        public IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state)
        {
            return this.socket.BeginConnect(host, port, requestCallback, state);
        }

        public void EndConnect(IAsyncResult asyncResult)
        {
            this.socket.EndConnect(asyncResult);
        }

        public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback callback, object state)
        {
            return this.socket.BeginDisconnect(reuseSocket, callback, state);
        }

        public void EndDisconnect(IAsyncResult asyncResult)
        {
            this.socket.EndDisconnect(asyncResult);
        }

        public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback asyncCallback, object state)
        {
            return this.socket.BeginSend(buffer, offset, size, socketFlags, asyncCallback, state);
        }

        public int EndSend(IAsyncResult asyncResult)
        {
            return this.socket.EndSend(asyncResult);
        }

        public void Close()
        {
            this.socket.Close();
        }

        public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
        {
            return this.socket.BeginReceive(buffer, offset, size, socketFlags, callback, state);
        }

        public int EndReceive(IAsyncResult asyncResult)
        {
            return this.socket.EndReceive(asyncResult);
        }
    }
}
