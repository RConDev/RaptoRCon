using System;
using System.Net.Sockets;

namespace RaptoRCon.Sockets
{
    /// <summary>
    /// This interface describes the public API of <see cref="System.Net.Sockets.Socket"/> available in this current 
    /// project. All calls to this type are echoed to a real <see cref="System.Net.Sockets.Socket"/> instance
    /// </summary>
    public interface ISocket
    {
        IAsyncResult BeginConnect(string host, int port, AsyncCallback requestCallback, object state);
        void EndConnect(IAsyncResult asyncResult);
        IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback asyncCallback, object state);
        int EndSend(IAsyncResult asyncResult);
        IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state);
        int EndReceive(IAsyncResult asyncResult);
        void Close();
        IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback callback, object state);
        void EndDisconnect(IAsyncResult asyncResult);
    }
}
