using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Security.Cryptography;

namespace Command_Main
{

        public class SocketClient
        {
            public event OnConnectedEventHandler OnConnected;

            public event OnDisconnectedEventHandler OnDisconnected;

            public event OnReceivedEventHandler OnDataReceived;

            public Socket clientSocket;

            public byte[] receiveBuffer;

            public CommunicationState State { get; set; }

            public void Connect(IPAddress address, int port)
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint ipEndPoint = new IPEndPoint(address, port);

                //Connect den server
                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            }

            public void Disconnect() { }

            public void Send(byte[] byteData)
            {
                this.Send(byteData, true);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="byteData">Unsecured data</param>
            public void Send(byte[] byteData, bool encrypt)
            {
                // ma hoa data
                if (encrypt)
                {
                    byteData = Command_Main.Cryptography.Encrypt(byteData, this.State.Certificate.ShareKey);
                }
                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }

            public void Receive() { }

            private void OnConnect(IAsyncResult ar)
            {
                clientSocket.EndConnect(ar);

                this.State = new CommunicationState()
                {
                    Data = new byte[10240],
                    Socket = clientSocket,
                    Certificate = new SessionKey()
                };

                clientSocket.BeginReceive(this.State.Data,
                                           0,
                                           this.State.Data.Length,
                                           SocketFlags.None,
                                           new AsyncCallback(OnReceive),
                                           this.State);

                if (this.OnConnected != null)
                {
                    this.OnConnected(this, EventArgs.Empty);
                }
            }

            // gui
            private void OnSend(IAsyncResult ar)
            {
                clientSocket.EndSend(ar);
            }
            // nhan
            private void OnReceive(IAsyncResult ar)
            {
                // nhan du lieu
                int byteCount = clientSocket.EndReceive(ar);

                CommunicationState state = ar.AsyncState as CommunicationState;
                if (!state.Certificate.HasPublicKey)
                {
                    // Response cho lan dau tien nhan duoc public key
                    if (this.OnDataReceived != null)
                    {
                        this.OnDataReceived(this, new ReceivedDataEventArgs() { Data = state.Data });
                    }
                }
                else if (!state.Certificate.SharedKeyReceived)
                {
                    // Server response la da nhan sharedkey, can phai update lai SharedKeyReceived
                    state.Certificate.SharedKeyReceived = true;
                    if (this.OnDataReceived != null)
                    {
                        this.OnDataReceived(this, new ReceivedDataEventArgs() { Data = state.Data });
                    }
                }
                else
                {
                    byte[] encryptedBuffer = new byte[byteCount];
                    Array.Copy(state.Data, 0, encryptedBuffer, 0, encryptedBuffer.Length);
                    // giai ma data
                    byte[] unencryptedData = Command_Main.Cryptography.Decrypt(encryptedBuffer, state.Certificate.ShareKey);
                    if (this.OnDataReceived != null)
                    {
                        this.OnDataReceived(this, new ReceivedDataEventArgs() { Data = unencryptedData });
                    }
                }

                state.Data = new byte[10240];
                clientSocket.BeginReceive(state.Data,
                                          0,
                                          state.Data.Length,
                                          SocketFlags.None,
                                          new AsyncCallback(OnReceive),
                                          state);
            }

        }
    


}

