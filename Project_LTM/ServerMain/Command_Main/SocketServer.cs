using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;

namespace Command_Main
{
    public class SocketServer
    {
        public Socket serverSocket;

        public event OnConnectedEventHandler OnConnected;

        public event OnDisconnectedEventHandler OnDisconnected;

        public event OnReceivedEventHandler OnDataReceived;

        private List<CommunicationState> ConnectedClients { get; set; }


        public SocketServer()
        {
            this.ConnectedClients = new List<CommunicationState>();

            this.Listen();

        }

        private void Listen()
        {

            serverSocket = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);

            //gan cho tat ca cac client ket noi vao he thong voi port 1000
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1000);

            //lang nghe ket noi
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(100);

            //chap nhap ket noi 
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

        }

        private CommunicationState GetClientByKey(string key)
        {
            return this.ConnectedClients.FirstOrDefault(p => p.Key == key);
        }

        private List<CommunicationState> GetClientByMaKH(int maKH)
        {
            return this.ConnectedClients.Where(p => p.MaKH == maKH).ToList();
        }

        public void SetClientMaKH(string key, int MaKH)
        {
            CommunicationState c = GetClientByKey(key);
            if (c != null) c.MaKH = MaKH;
        }

        private string AddClient(CommunicationState state)
        {
            state.Key = System.Guid.NewGuid().ToString();
            this.ConnectedClients.Add(state);
            return state.Key;
        }

        private CommunicationState DeleteClient(string key)
        {
            CommunicationState state = this.ConnectedClients.FirstOrDefault(p => p.Key == key);
            if (state != null)
            {
                this.ConnectedClients.Remove(state);
            }
            return state;
        }

        //ham chap nhan ket noi
        public void OnAccept(IAsyncResult ar)
        {

            Socket clientSocket = serverSocket.EndAccept(ar);

            CommunicationState state = new CommunicationState()
            {
                Data = new byte[10240],
                Socket = clientSocket,
                Certificate = SecureEncryption_server.GenerateSessionKey()
            };

            string key = this.AddClient(state);

            //bat dau lang nghe
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

            clientSocket.BeginReceive(state.Data,
                                       0,
                                       state.Data.Length,
                                       SocketFlags.None,
                                       new AsyncCallback(OnReceive),
                                       state);


        }

        public void OnSend(IAsyncResult ar)
        {
            var state = ar.AsyncState as CommunicationState;
            state.Socket.EndSend(ar);
        }

        public void Disconnect() { }

        public void Broadcast(byte[] data)
        {
            foreach (var state in this.ConnectedClients)
            {
                this.Send(data, state.Key, true);
            }
        }

        public void Send(byte[] byteData, string key)
        {
            this.Send(byteData, key, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteData">Unsecured data</param>
        public void Send(byte[] byteData, string key, bool encrypt)
        {
            var state = this.GetClientByKey(key);
            if (encrypt)
            {
                byteData = Command_Main.Cryptography.Encrypt(byteData, state.Certificate.ShareKey); // server nam sereckey
            }
            state.Socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), state);
        }

        public void Send(byte[] byteData, int maKH)
        {
            var clients = this.GetClientByMaKH(maKH);
            foreach (var client in clients)
            {
                this.Send(byteData, client.Key, true);
            }
        }

        public void Receive() { }

        private void OnConnect(IAsyncResult ar)
        {
            serverSocket.EndConnect(ar);

            if (this.OnConnected != null)
            {
                this.OnConnected(this, EventArgs.Empty);
            }
        }

        // nhan
        private void OnReceive(IAsyncResult ar)
        {
            // nhan du lieu
            CommunicationState state = ar.AsyncState as CommunicationState;
            int byteCount = state.Socket.EndReceive(ar);

            if (!state.Certificate.PublicKeySent)
            {
                // Gui public key cho client
                CertificateResponse caResponse = new CertificateResponse() { ResponseTime = DateTime.Now, PublicKey = state.Certificate.PublicKey };
                Command_Main.Message caMessage = new Message(Command.RequestCertificate, SerializeHelpers.SerializeData(caResponse));
                this.Send(caMessage.ToMessage(), state.Key, false);
                state.Certificate.PublicKeySent = true;
            }
            else if (state.Certificate.ShareKey == null)
            {
                Command_Main.Message sharedKeyRequestMessage = Command_Main.Message.Parse(state.Data);
                SharedKeyRequest sharedKeyRequest = (SharedKeyRequest)SerializeHelpers.DeserializeData(sharedKeyRequestMessage.DataByte);

                state.Certificate.ShareKey = SecureEncryption_server.DecryptShareKey(state.Certificate.PrivateKey, sharedKeyRequest.SharedKey);

                SharedKeyResponse sharedKeyResponse = new SharedKeyResponse() { ResponseTime = DateTime.Now };
                Command_Main.Message sharedKeyResponseMessage = new Message(Command.SendSharedKey, SerializeHelpers.SerializeData(sharedKeyResponse));
                this.Send(sharedKeyRequestMessage.ToMessage(), state.Key, false);
            }
            else
            {
                // giai ma data
                byte[] encryptedBuffer = new byte[byteCount];
                Array.Copy(state.Data, 0, encryptedBuffer, 0, encryptedBuffer.Length);
                byte[] unencryptedData = Command_Main.Cryptography.Decrypt(encryptedBuffer, state.Certificate.ShareKey);

                if (this.OnDataReceived != null)
                {
                    this.OnDataReceived(this, new ReceivedDataEventArgs()
                    {
                        Data = unencryptedData,
                        SocketKey = state.Key
                    });
                }
            }

            state.Data = new byte[10240];
            state.Socket.BeginReceive(state.Data,
                                      0,
                                      state.Data.Length,
                                      SocketFlags.None,
                                      new AsyncCallback(OnReceive),
                                      state);
        }
    }
}
