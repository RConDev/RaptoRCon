using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Common.Logging;

namespace RaptoRCon.Sockets
{
    /// <summary>
    ///     Implementation of <see cref="ISocketClient" />
    /// </summary>
    public class SocketClient : ISocketClient
    {
        private const int DefaultBufferSize = 16384;

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();
        private bool disposed;

        #region Events

        /// <summary>
        /// This event is invoked, when the underlying connection is closed.
        /// </summary>
        public event EventHandler<ConnectionClosedEventArgs> ConnectionClosed;

        /// <summary>
        /// This event is invoked, when the connection receives data from the remote host
        /// </summary>
        public event EventHandler<SocketDataReceivedEventArgs> DataReceived;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the size of the buffer used in this connection
        /// </summary>
        public int BufferSize { get; private set; }

        /// <summary>
        /// Gets the underlying communication instance of <see cref="ISocket"/>
        /// </summary>
        public ISocket Socket { get; private set; }

        #endregion

        /// <summary>
        /// Creates a new <see cref="SocketClient" /> instance
        /// </summary>
        public SocketClient(ISocket socket)
        {
            #region Contracts
            if (socket == null)
            {
                throw new ArgumentNullException();
            }
            #endregion

            logger.Trace("Creating new instance");
            BufferSize = DefaultBufferSize;
            this.Socket = socket;
        }

        /// <summary>
        /// Connects to the stated remote host and initiates reading
        /// </summary>
        /// <param name="hostname">Name or IP-Address of the remote host</param>
        /// <param name="port">Port number of the remote host to connect to</param>
        /// <returns></returns>
        public async Task<ISocketClient> ConnectAsync(string hostname, int port)
        {
            logger.DebugFormat("Trying to connect to {0}:{1}", hostname, port);
            await Task.Factory.FromAsync(
                    (callback, state) => Socket.BeginConnect(hostname, port, callback, state),
                    asyncResult => ((ISocket)asyncResult.AsyncState).EndConnect(asyncResult),
                    this.Socket);
            logger.DebugFormat("Connection to {0}:{1} successfully established", hostname, port);

            #pragma warning disable 4014
            StartListening(Socket);
            #pragma warning restore 4014

            return this;
        }

        /// <summary>
        ///     Sends a content to the remote host
        /// </summary>
        /// <param name="socketData"></param>
        public async Task<int> SendAsync(ISocketData socketData)
        {
            byte[] data = socketData.Data.ToArray();
            logger.DebugFormat("Sending {0} bytes to remote host", data.Length);

            return await Task.Factory
                       .FromAsync(
                           (callback, state) =>
                           Socket.BeginSend(data, 0, data.Length, SocketFlags.None, callback, state),
                           ias => Socket.EndSend(ias),
                           null);
        }

        #region Private Members

        // ReSharper disable FunctionRecursiveOnAllPaths
        private async Task StartListening(ISocket socket)
        // ReSharper restore FunctionRecursiveOnAllPaths
        {
            var buffer = new byte[BufferSize];
            int bytesRead;

            try
            {
                bytesRead = await Task.Factory.FromAsync(
                (callback, state) => ((ISocket)state).BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, callback, state),
                ias => ((ISocket)ias.AsyncState).EndReceive(ias),
                socket);
            }
            catch (SocketException ex)
            {
                logger.Warn("Error in socketWrapper-communication.", ex);
                InvokeConnectionClosed();
                return;
            }
            catch (ObjectDisposedException ex)
            {
                logger.Warn("Waiting listening socketWrapper was closed", ex);
                InvokeConnectionClosed();
                return;
            }
            catch (Exception ex)
            {
                logger.Warn("Other error in listening socketWrapper communication", ex);
                InvokeConnectionClosed();
                return;
            }

            if (bytesRead == 0)
            {
                // Connection was closed by the remote host
                InvokeConnectionClosed();
                return;
            }


            var targetBytes = new byte[bytesRead];
            Array.Copy(buffer, 0, targetBytes, 0, bytesRead);
            await InvokeDataReceived(targetBytes);

            StartListening(socket);
        }

        private async Task InvokeDataReceived(byte[] bytesRead)
        {
            var dataReceivedEventHandler = DataReceived;
            if (dataReceivedEventHandler == null) return;
            var eventArgs = new SocketDataReceivedEventArgs(bytesRead);

            var receivers = dataReceivedEventHandler.GetInvocationList();
            foreach (EventHandler<SocketDataReceivedEventArgs> receiver in receivers)
            {
                await Task.Factory
                    .FromAsync<object, SocketDataReceivedEventArgs>(receiver.BeginInvoke,
                                                                    receiver.EndInvoke,
                                                                    this,
                                                                    eventArgs,
                                                                    null);
            }
        }

        protected void InvokeConnectionClosed()
        {
            var handler = ConnectionClosed;
            var eventArgs = new ConnectionClosedEventArgs();

            if (handler != null)
            {
                handler(this, eventArgs);
            }
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
                Socket.Close();
            }

            // Note disposing has been done.
            disposed = true;
        }

        ~SocketClient()
        {
            Dispose(false);
        }

        #endregion IDisposable Members

        public async Task DisconnectAsync(bool reuseSocket)
        {
            logger.DebugFormat("Trying to disconnect");
            await Task.Factory.FromAsync(
                (callback, state) => Socket.BeginDisconnect(reuseSocket, callback, Socket),
                Socket.EndDisconnect,
                Socket);
            logger.DebugFormat("Successfully disconnected from remote host. Socket can be reused.");
        }
    }
}