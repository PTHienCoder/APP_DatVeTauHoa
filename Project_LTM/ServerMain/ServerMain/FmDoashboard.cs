using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
//
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.OleDb;
using Command_Main;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace ServerMain
{

    //trao doi server - client
    enum Command // dinh nghia cac lenh
    {
        KeySV, // key server
        HictoryVT, // lịch sử đặt vé
        DeleteVT, // key server
        send_gadi,
        send_gaden,
        search,
        Login,      //dag nhap
        Logout,     //dang xuat
        Message,    //thong diep
        List,       //lay danh sach client
        recData,    //nhan datatu server
        sendData,   // giu data cho server
        discon,     // ngat ket noi với 1 clent
        Null,      //No command,
        Booking,
        sendInfouser,
        changeInfoUser,
        bookingt,
        Historybooking,
        RequestCertificate,
        SendSharedKey
    }
    public delegate void DlgInitGrid(object datasource);
    public partial class FmDoashboard : Form
    {
       private string keyserver;
        private string KEYsearch;
        //struct ClientInfo chua thong tin client dang nhap tren he thong
        struct ClientInfo
        {
            public Socket socket;   //bien Socket
            public string strName;  //ten 
        }

        //mang chua cac client tren server
        ArrayList clientList;

        //khai bao bien socket tren server
        Socket serverSocket;

        byte[] byteData = new byte[2048];


        public static string stree = Login_admin.keySV;
        public static string stree2;
        int IDcus;
        //


        public static int solog;
         SocketServer socketServer;
         DBconnection connect = new DBconnection();
        public FmDoashboard()
        {
            clientList = new ArrayList();
            InitializeComponent();
            //  SetServer(Server);
            socketServer = new SocketServer();
            socketServer.OnDataReceived += socketServer_OnDataReceived;
        }
        void socketServer_OnDataReceived(object sender, ReceivedDataEventArgs e)
        {    
            // Xuly
            Command_Main.Message message = Command_Main.Message.Parse(e.Data);
            switch (message.Command)
              
            {
                case Command_Main.Command.KeySV:
                    RequestKeySerVer request2 = (RequestKeySerVer)SerializeHelpers.DeserializeData(message.DataByte);
                    keyserver = request2.KEYSV;
                    KEYsearch = request2.KEYsearch;

                    if (request2.KEYsearch.Equals("all"))
                    {
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SendInfoTicketResponse sendInfoResponse = this.GetInfoTicketResponse();
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.sendData, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
         
                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {

                            SendInfoTicketResponse sendInfoResponse = this.GetInfoTicketResponse();
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.sendData, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);


                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                            SendInfoTicketResponse sendInfoResponse = this.GetInfoTicketResponse();
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.sendData, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);

                        }

                    }
                  
                   
                    break;
                case Command_Main.Command.send_gadi:
                    /*
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SenReponse_Gadi sendInfoResponsegadi = new SenReponse_Gadi();
                            var sendInfoResponsegadiMsg = new Command_Main.Message(Command_Main.Command.send_gadi, SerializeHelpers.SerializeData(sendInfoResponsegadi));
                            ((SocketServer)sender).Send(sendInfoResponsegadiMsg.ToMessage(), e.SocketKey);           
                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {
                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                          

                         }
                */
                        
                    break;

                case Command_Main.Command.search:
                    SendRequest_Search requestSech = (SendRequest_Search)SerializeHelpers.DeserializeData(message.DataByte);
                    string keysearch = requestSech.keyseach;

                    if (keysearch != "all" )
                    {
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponsessss0(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
            
                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponsessss0(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponsessss0(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                    }
                     if (keysearch.Equals(">200,000VND"))
                    {
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVlonhon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);

                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVlonhon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVlonhon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                    }
                    else if (keysearch.Equals("<200,000VND"))
                    {
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVnhohon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);

                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVnhohon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVnhohon200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                    }
                    else if (keysearch.Equals("=200,000VND"))
                    {
                        if (keyserver.Equals("Đà Nẵng"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVbang200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);

                        }
                        else if (keyserver.Equals("Hồ Chí Minh"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVbang200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                        else if (keyserver.Equals("Hà Nội"))
                        {
                            SendRepone_Search sendInfoResponse = this.GetInfoTicketResponses0_GVbang200(keysearch);
                            var sendInfoResponseMsg = new Command_Main.Message(Command_Main.Command.search, SerializeHelpers.SerializeData(sendInfoResponse));
                            ((SocketServer)sender).Send(sendInfoResponseMsg.ToMessage(), e.SocketKey);
                        }
                    }

                    break;
                case Command_Main.Command.sendInfouser:
                    var SendInfUserRequest = (SendInfUserRequest)SerializeHelpers.DeserializeData(message.DataByte);
                    SendInfUserResponse sendInfoUserResponse = this.GetInfoUserResponse(SendInfUserRequest.ID, SendInfUserRequest.Password);

                    var sendmesg = new Command_Main.Message(Command_Main.Command.sendInfouser, SerializeHelpers.SerializeData(sendInfoUserResponse));
                    ((SocketServer)sender).Send(sendmesg.ToMessage(), e.SocketKey);
                    break;


                case Command_Main.Command.Login:
                    LoginRequest request = (LoginRequest)SerializeHelpers.DeserializeData(message.DataByte);
                
                    // Validate
                    int makh = 0;
                    bool success = connect.ValidateLogin(request.ID, request.Password);
                

                    if (success == true)
                    {
                        DataTable db = connect.GetIDNguoidung(request.ID);
                        makh = Convert.ToInt32(db.Rows[0]["Id"].ToString());
                    }

                    LoginResponse response = new LoginResponse() { Success = success };

                    Command_Main.Message responseMsg = new Command_Main.Message(Command_Main.Command.Login, SerializeHelpers.SerializeData(response));
                    ((SocketServer)sender).SetClientMaKH(e.SocketKey, makh);
                    ((SocketServer)sender).Send(responseMsg.ToMessage(), e.SocketKey);

                    break;


             


                case Command_Main.Command.HictoryVT:
                    SendRequestHistoty res = (SendRequestHistoty)SerializeHelpers.DeserializeData(message.DataByte);
                    IDcus = res.ID;

                    if (keyserver.Equals("Đà Nẵng"))
                    {
                        SenReponHistory sendhisoResponse = this.GetHistorybooking0();
                        var senhisResponseMsg = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(sendhisoResponse));
                        ((SocketServer)sender).Send(senhisResponseMsg.ToMessage(), e.SocketKey);

                    }
                    else if (keyserver.Equals("Hồ Chí Minh"))
                    {

                        SenReponHistory sendhisoResponse = this.GetHistorybooking1();
                        var senhisResponseMsg = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(sendhisoResponse));
                        ((SocketServer)sender).Send(senhisResponseMsg.ToMessage(), e.SocketKey);
                    }
                    else if (keyserver.Equals("Hà Nội"))
                    {
                        SenReponHistory sendhisoResponse = this.GetHistorybooking2();
                        var senhisResponseMsg = new Command_Main.Message(Command_Main.Command.HictoryVT, SerializeHelpers.SerializeData(sendhisoResponse));
                        ((SocketServer)sender).Send(senhisResponseMsg.ToMessage(), e.SocketKey);
                    }
              
                    break;

                case Command_Main.Command.DeleteVT:
                    DeleteBookingRequest resss = (DeleteBookingRequest)SerializeHelpers.DeserializeData(message.DataByte);
                   string mahd = resss.mahd;
                    int maHD = Convert.ToInt32(mahd);
                    if (keyserver.Equals("Đà Nẵng"))
                    {
                        DBconnection0 connect0 = new DBconnection0();
                        connect0.DeleteCT(maHD);
                    }
                    else if (keyserver.Equals("Hồ Chí Minh"))
                    {
                        DBconnection1 connect1 = new DBconnection1();
                        connect1.DeleteCT(maHD);

                    }
                    else if (keyserver.Equals("Hà Nội"))
                    {
                        DBconnection2 connect2 = new DBconnection2();
                        connect2.DeleteCT(maHD);
                    }


                    break;

                case Command_Main.Command.Booking:

                    BuyTicketRequest response_Booking = (BuyTicketRequest)SerializeHelpers.DeserializeData(message.DataByte);

                    int sovecapnhat = Convert.ToInt32(response_Booking.Soveconlai.ToString());
                    string tenct = Convert.ToString(response_Booking.TenCT.ToString());
                    string loaighe = Convert.ToString(response_Booking.loaighe.ToString());
                    int Soluong = Convert.ToInt32(response_Booking.Soluong.ToString());
                    string thoigianchay = Convert.ToString(response_Booking.Thoigianchay.ToString());
                    string ngaydi = Convert.ToString(response_Booking.Ngaydi.ToString());
                    int idnguoidung = Convert.ToInt32(response_Booking.Idnguoidung.ToString());
                    string Gadi = Convert.ToString(response_Booking.Gadi.ToString());
                    string Gaden = Convert.ToString(response_Booking.Gaden.ToString());
                    string total = Convert.ToString(response_Booking.tongtien.ToString());
                    string tinhtrangve = "New";

    

                    if (keyserver.Equals("Đà Nẵng"))
                    {
                        DBconnection0 connect0 = new DBconnection0();
                        connect0.InsertOrder(sovecapnhat, tenct, loaighe, Soluong, thoigianchay, ngaydi, idnguoidung, tinhtrangve, Gadi, Gaden, total);
                    }
                    else if (keyserver.Equals("Hồ Chí Minh"))
                    {
                        DBconnection1 connect1 = new DBconnection1();
                        connect1.InsertOrder(sovecapnhat, tenct, loaighe, Soluong, thoigianchay, ngaydi, idnguoidung, tinhtrangve, Gadi, Gaden, total);

                    }
                    else if (keyserver.Equals("Hà Nội"))
                    {
                        DBconnection2 connect2 = new DBconnection2();
                        connect2.InsertOrder(sovecapnhat, tenct, loaighe, Soluong, thoigianchay, ngaydi, idnguoidung, tinhtrangve, Gadi, Gaden, total);
                    }


                    break;


                case Command_Main.Command.changeInfoUser:
                    UpdateProfile_Request requestuser = (UpdateProfile_Request)SerializeHelpers.DeserializeData(message.DataByte);

                    connect.UpdateProfile(requestuser.Id, requestuser.TenDayDu, requestuser.Diachi, requestuser.Sodienthoai, requestuser.Email);

             
                    break;

               
     
 
            }
        }

        public SendRepone_Search GetInfoTicketResponses0_GVbang200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection connect0 = new DBconnection();
            DataTable InfoData = connect0.SendInfoSearch_bang(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses1_GVbang200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.SendInfoSearch_bang(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses2_GVbang200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.SendInfoSearch_bang(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses0_GVlonhon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection connect0 = new DBconnection();
            DataTable InfoData = connect0.SendInfoSearch_lonhon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses1_GVlonhon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.SendInfoSearch_lonhon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses2_GVlonhon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.SendInfoSearch_lonhon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses0_GVnhohon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection connect0 = new DBconnection();
            DataTable InfoData = connect0.SendInfoSearch_nhohon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses1_GVnhohon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.SendInfoSearch_nhohon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponses2_GVnhohon200(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.SendInfoSearch_nhohon(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponsessss0(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection connect0 = new DBconnection();
            DataTable InfoData = connect0.SendInfoSearch(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponsessss1(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.SendInfoSearch(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }
        public SendRepone_Search GetInfoTicketResponsessss2(string kesearch)
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.SendInfoSearch(kesearch);

            Command_Main.SendRepone_Search response = new Command_Main.SendRepone_Search()
            {
                Itemseach = new Command_Main.DataObjects.ItemSearch[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();
                response.Itemseach[i] = new Command_Main.DataObjects.ItemSearch(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }





        public SendInfUserResponse GetInfoUserResponse(string id, string pass)
        {

            string tendangnhap;
            string matkhau;
            string diachi;
            string sodienthoai;
            string sotien;
            int Id;
            string tendaydu, email;
            DataTable InfoData = connect.SendInfoUser(id, pass);

            Command_Main.SendInfUserResponse response = new Command_Main.SendInfUserResponse()
            {
                Items = new Command_Main.DataObjects.InfoUser[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                tendangnhap = InfoData.Rows[i]["TenDangNhap"].ToString();
                matkhau = InfoData.Rows[i]["MatKhau"].ToString();
                sodienthoai = InfoData.Rows[i]["SoDienThoai"].ToString();
                diachi = InfoData.Rows[i]["DiaChi"].ToString();
                sotien = InfoData.Rows[i]["SoDu"].ToString();
                email = InfoData.Rows[i]["Email"].ToString();
                tendaydu = InfoData.Rows[i]["TenDayDu"].ToString();
                Id = Convert.ToInt32(InfoData.Rows[i]["Id"].ToString());

                response.Items[i] = new Command_Main.DataObjects.InfoUser(Id, tendangnhap, matkhau, sodienthoai, diachi, sotien, tendaydu, email);
            }
            return response;
        }





        public SenReponHistory GetHistorybooking0() { 
            int mahd;
            string tenct;
            string gadi;
            string gaden;
            string loaighe;
            string thoigianchay;
            string soluong;
            string tinhtrang;
            string total;
            string ngaydi;

            DBconnection0 connect0 = new DBconnection0();
            DataTable InfoData = connect0.GetHistory(IDcus);

            Command_Main.SenReponHistory response = new Command_Main.SenReponHistory()
            {
                Items = new Command_Main.DataObjects.ItemHis[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                mahd = Convert.ToInt32(InfoData.Rows[i]["MaHD"]);
                tenct = InfoData.Rows[i]["Tenct"].ToString();
                gadi = InfoData.Rows[i]["Gadi"].ToString();
                gaden = InfoData.Rows[i]["Gaden"].ToString();
                loaighe = InfoData.Rows[i]["Ngaydi"].ToString();
                thoigianchay = InfoData.Rows[i]["Loaighe"].ToString();
                soluong = InfoData.Rows[i]["Thoigianchay"].ToString();
                ngaydi = InfoData.Rows[i]["Ngaydi"].ToString();
                total = InfoData.Rows[i]["Total"].ToString();
                tinhtrang = InfoData.Rows[i]["Tinhtrang"].ToString();



                response.Items[i] = new Command_Main.DataObjects.ItemHis(mahd, tenct, gadi, gaden, ngaydi, loaighe, thoigianchay, soluong, total, tinhtrang);
            }
            return response;
        }
        public SenReponHistory GetHistorybooking1()
        {
            int mahd;
            string tenct;
            string gadi;
            string gaden;
            string loaighe;
            string thoigianchay;
            string soluong;
            string tinhtrang;
            string total;
            string ngaydi;

            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.GetHistory(IDcus);

            Command_Main.SenReponHistory response = new Command_Main.SenReponHistory()
            {
                Items = new Command_Main.DataObjects.ItemHis[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                mahd = Convert.ToInt32(InfoData.Rows[i]["MaHD"]);
                tenct = InfoData.Rows[i]["Tenct"].ToString();
                gadi = InfoData.Rows[i]["Gadi"].ToString();
                gaden = InfoData.Rows[i]["Gaden"].ToString();
                loaighe = InfoData.Rows[i]["Ngaydi"].ToString();
                thoigianchay = InfoData.Rows[i]["Loaighe"].ToString();
                soluong = InfoData.Rows[i]["Thoigianchay"].ToString();
                ngaydi = InfoData.Rows[i]["Ngaydi"].ToString();
                total = InfoData.Rows[i]["Total"].ToString();
                tinhtrang = InfoData.Rows[i]["Tinhtrang"].ToString();



                response.Items[i] = new Command_Main.DataObjects.ItemHis(mahd, tenct, gadi, gaden, ngaydi, loaighe, thoigianchay, soluong, total, tinhtrang);
            }
            return response;
        }
        public SenReponHistory GetHistorybooking2()
        {
            int mahd;
            string tenct;
            string gadi;
            string gaden;
            string loaighe;
            string thoigianchay;
            string soluong;
            string tinhtrang;
            string total;
            string ngaydi;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.GetHistory(IDcus);

            Command_Main.SenReponHistory response = new Command_Main.SenReponHistory()
            {
                Items = new Command_Main.DataObjects.ItemHis[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                mahd = Convert.ToInt32(InfoData.Rows[i]["MaHD"]);
                tenct = InfoData.Rows[i]["Tenct"].ToString();
                gadi = InfoData.Rows[i]["Gadi"].ToString();
                gaden = InfoData.Rows[i]["Gaden"].ToString();
                loaighe = InfoData.Rows[i]["Ngaydi"].ToString();
                thoigianchay = InfoData.Rows[i]["Loaighe"].ToString();
                soluong = InfoData.Rows[i]["Thoigianchay"].ToString();
                ngaydi = InfoData.Rows[i]["Ngaydi"].ToString();
                total = InfoData.Rows[i]["Total"].ToString();
                tinhtrang = InfoData.Rows[i]["Tinhtrang"].ToString();



                response.Items[i] = new Command_Main.DataObjects.ItemHis(mahd, tenct, gadi, gaden, ngaydi, loaighe, thoigianchay, soluong, total, tinhtrang);
            }
            return response;
        }
        public SendInfoTicketResponse GetInfoTicketResponse()
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection connect0 = new DBconnection();
            DataTable InfoData = connect0.SendInfo();

            Command_Main.SendInfoTicketResponse response = new Command_Main.SendInfoTicketResponse()
            {
                Items = new Command_Main.DataObjects.InfoItem[InfoData.Rows.Count]
            };

            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();



                response.Items[i] = new Command_Main.DataObjects.InfoItem(soluongct, tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }


        public SendInfoTicketResponse GetInfoTicketResponse1()
        {
            string soluongvetau;
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection1 connect1 = new DBconnection1();
            DataTable InfoData = connect1.SendInfo();

            Command_Main.SendInfoTicketResponse response = new Command_Main.SendInfoTicketResponse()
            {
                Items = new Command_Main.DataObjects.InfoItem[InfoData.Rows.Count]
            };


            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();



                response.Items[i] = new Command_Main.DataObjects.InfoItem(soluongct,tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }



        public SendInfoTicketResponse GetInfoTicketResponse2()
        {
            string soluongvetau;
  
            string thoigianchay;
            string tengadi;
            string tengaden;
            string tenchuyentau;
            string ngaydi;
            string giave;
            DBconnection2 connect2 = new DBconnection2();
            DataTable InfoData = connect2.SendInfo();

            Command_Main.SendInfoTicketResponse response = new Command_Main.SendInfoTicketResponse()
            {
                Items = new Command_Main.DataObjects.InfoItem[InfoData.Rows.Count]
            };


            for (int i = 0; i < InfoData.Rows.Count; i++)
            {
                soluongvetau = InfoData.Rows[i]["SoVeToiDa"].ToString();
                int soluongct = int.Parse(soluongvetau);
                tenchuyentau = InfoData.Rows[i]["TenChuyenTau"].ToString();
                ngaydi = InfoData.Rows[i]["NgayDi"].ToString();
                thoigianchay = InfoData.Rows[i]["ThoiGianChay"].ToString();
                tengadi = InfoData.Rows[i]["TenGaDi"].ToString();
                tengaden = InfoData.Rows[i]["TenGaDen"].ToString();
                giave = InfoData.Rows[i]["GiaVe"].ToString();

                response.Items[i] = new Command_Main.DataObjects.InfoItem(soluongct,tenchuyentau, ngaydi, thoigianchay, tengadi, tengaden, giave);
            }
            return response;
        }


        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void FmDoashboard_Load_1(object sender, EventArgs e)
        {
           
            System.Runtime.Remoting.Channels.Http.HttpChannel server = new System.Runtime.Remoting.Channels.Http.HttpChannel(9000);
            ChannelServices.RegisterChannel(server, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ClassLibrary.Class1), "MyObj", WellKnownObjectMode.SingleCall);
            // MessageBox.Show("Server đã chạy");

            guna2ComboBox1.Text = stree;
            stree2 = stree;

            uC_Doashboard1.Visible = true;
            uC_Additems1.Visible = false;
            uC_UpdateData1.Visible = false;
            uC_ThongKe1.Visible = false;
            uC_Doashboard1.loadInfoChuyentau();

        }
        private void DoashBoard(object sender, EventArgs e)
        {

     
           uC_Additems1.Visible = false;
            uC_UpdateData1.Visible = false;
            uC_ThongKe1.Visible = false;
            guna2Transition1.ShowSync(uC_Doashboard1);
            uC_Doashboard1.loadInfoChuyentau();
            uC_Doashboard1.Visible = true;
            uC_Doashboard1.BringToFront();
        }
        private void Button_Add_Items_Click(object sender, EventArgs e)
        {
            uC_Doashboard1.Visible = false;
            uC_UpdateData1.Visible = false;
            uC_ThongKe1.Visible = false;
            guna2Transition1.ShowSync(uC_Additems1);
            uC_Additems1.Visible = true;
            uC_Additems1.loadInfoChuyentau();
            uC_Additems1.BringToFront();
        }
  

        private void Button_UpdateData_Click(object sender, EventArgs e)
        {
           uC_Additems1.Visible = false;
            uC_Doashboard1.Visible = false;
           uC_ThongKe1.Visible = false;
           guna2Transition1.ShowSync(uC_UpdateData1);
           uC_UpdateData1.Visible = true;
            uC_UpdateData1.BringToFront();
            uC_UpdateData1.loadInfoHD();
        }

        private void Button_Statistic_Click(object sender, EventArgs e)
        {
                uC_Additems1.Visible = false;
                uC_Doashboard1.Visible = false;
                uC_UpdateData1.Visible = false;
                  guna2Transition1.ShowSync(uC_ThongKe1);      
                uC_ThongKe1.Visible = true;
                uC_ThongKe1.BringToFront();
        }

        private void logout_Click(object sender, EventArgs e)
        {

        }

        private void uC_Doashboard1_Load(object sender, EventArgs e)
        {

        }

        private void uC_Additems1_Load(object sender, EventArgs e)
        {

        }

        private void uC_UpdateData1_Load(object sender, EventArgs e)
        {

        }

        private void uC_ThongKe1_Load(object sender, EventArgs e)
        {

        }
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();

            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stree2 = guna2ComboBox1.Text;
                 
   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uC_Doashboard1.loadInfoChuyentau();
            stree2 = guna2ComboBox1.Text;
        }
    }




    //cau truc data nhan va send 
    //each other
    class Data // khi nhan - giu du lieu he thong se chuyen doi du  lieu truoc khi hien thi
    {
        public Data()
        {
            this.cmdCommand = Command.Null;// lenh
            this.strMessage = null;// thong diep
            this.strName = null;// ten user
        }

        //cat chuoi byte sang du lieu 
        public Data(byte[] data)
        {
            //ta quy dinh 4 bit dau tien cho lenh
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //4 bit tip theo ten client
            int nameLen = BitConverter.ToInt32(data, 4);

            //4 bit tip theo chieu dai tin nhan
            int msgLen = BitConverter.ToInt32(data, 8);

            //kiem tra doi dai ten client 
            if (nameLen > 0)// neu do dai >0 
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            //kiem tra doi dai tin nhan 
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        //chuyen doi du lieu vao mang byte
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //4 bit dau . danh cho lenh
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //thêm chieu dai ten
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //doi dai tin nhan
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //them ten
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //thong diep
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      //ten khach hang tren he thong 
        public string strMessage;   //thong diep
        public Command cmdCommand;  //loai lenh : 5 loai (login, logout, send message, etcetera)
    }
}
