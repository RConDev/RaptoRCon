using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Common.Logging;

namespace RaptoRCon.Sockets
{
    /// <summary>
    ///     Implementation of <see cref="ISocket" />
    /// </summary>
    public class Socket : ISocket
    {
        private const int DefaultBufferSize = 16384;

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        private readonly System.Net.Sockets.Socket socket;
        private bool disposed;

        /// <summary>
        ///     Creates a new <see cref="Socket" /> instance
        /// </summary>
        public Socket()
        {
            logger.Trace("Creating new instance");
            BufferSize = DefaultBufferSize;
            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        ///     Creates a new <see cref="Socket" /> instance with a self-defined buffer size
        /// </summary>
        /// <param name="bufferSize"></param>
        public Socket(int bufferSize) : this()
        {
            BufferSize = bufferSize;
        }

        /// <summary>
        ///     Gets the size of the buffer used in this connection
        /// </summary>
        public int BufferSize { get; private set; }

        /// <summary>
        ///     Connects to the stated remote host
        /// </summary>
        /// <param name="hostname">Name or IP-Address of the remote host</param>
        /// <param name="port">Port number of the remote host to connect to</param>
        /// <returns></returns>
        public async void ConnectAsync(string hostname, int port)
        {
            logger.DebugFormat("Trying to connect to {0}:{1}", hostname, port);

            await Task.Factory.FromAsync((cb, s) => socket.BeginConnect(hostname, port, cb, s),
                                         (ias) => socket.EndConnect(ias),
                                         null);

            StartListening(socket);
        }

        /// <summary>
        ///     Sends a content to the remote host
        /// </summary>
        /// <param name="socketData"></param>
        public async void SendAsync(ISocketData socketData)
        {
            byte[] data = socketData.Data.ToArray();
            logger.DebugFormat("Sending {0} bytes to remote host", data.Length);

            int bytesSent = await Task.Factory.FromAsync(
                (callback, state) => socket.BeginSend(data, 0, data.Length, SocketFlags.None, callback, state),
                (ias) => socket.EndSend(ias),
                null);

            logger.DebugFormat("{0} bytes were successfully sent to the remote host.", bytesSent);
        }

        /// <summary>
        /// This event is invoked, when the connection receives data from the remote host
        /// </summary>
        public event EventHandler<SocketDataReceivedEventArgs> DataReceived;

        #region Private Members
        // ReSharper disable FunctionRecursiveOnAllPaths
        private async void StartListening(System.Net.Sockets.Socket socket1)
        // ReSharper restore FunctionRecursiveOnAllPaths
        {
            var buffer = new byte[BufferSize];
            int bytesRead = await Task.Factory.FromAsync(
                (cb, s) => socket1.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, cb, s),
                ias => socket1.EndReceive(ias),
                null);

            var targetBytes = new byte[bytesRead];
            Array.Copy(buffer, 0, targetBytes, 0, bytesRead);
            InvokeDataReceived(targetBytes);

            StartListening(socket1);
        }

        private void InvokeDataReceived(byte[] bytesRead)
        {
            if (DataReceived == null) return;
            var eventArgs = new SocketDataReceivedEventArgs(bytesRead);
            Task.Factory.FromAsync<object, SocketDataReceivedEventArgs>(DataReceived.BeginInvoke,
                                                                  DataReceived.EndInvoke,
                                                                  this,
                                                                  eventArgs,
                                                                  null);
        } 
        #endregion

        #region IDisposable Members

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposed) return;

            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing)
            {
                // Dispose managed resources.
                socket.Close();
            }

            // Note disposing has been done.
            disposed = true;
        }

        ~Socket()
        {
            Dispose(false);
        }

        #endregion IDisposable Members
    }
}