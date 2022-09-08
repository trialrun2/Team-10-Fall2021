using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Bid501_Library;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Bid501_Client
{
    class WSClientHandler
    {
        #region Fields

        /// <summary>
        /// bidding websocket
        /// </summary>
        private WebSocket _wsBidding;

        /// <summary>
        /// login websocket
        /// </summary>
        private WebSocket _wsLogIn;

        /// <summary>
        /// event called when a message is recieved on the login websocket
        /// </summary>
        public event LoginMessage LoginMessageRecieved;

        /// <summary>
        /// event called when a message is recieved on the bidding websocket
        /// </summary>
        public event BiddingMessage BiddingMessageRecieved;
        
        /// <summary>
        /// delegate used to populate the proxy in the controller
        /// </summary>
        private TransferItem<List<AuctionItem>> _populateProxy;

        /// <summary>
        /// delegate used to set the client id in the controller
        /// </summary>
        private SetClientID _setClientID;
        #endregion

        #region Contructor
        /// <summary>
        /// the constructor for the WS clietn handler creates the websockets and tells them what to do when they recieve a message
        /// </summary>
        public WSClientHandler()
        {
            _wsLogIn = new WebSocket("ws://192.168.1.170:8001/LoginService"); // This is the connection to another pc, still needs done.
            //_wsLogIn = new WebSocket("ws://127.0.0.1:8001/LoginService"); // This is the connection to your own pc, comment out in final version.
            _wsLogIn.OnMessage += (sender, e) => { if (LoginMessageRecieved != null) LoginMessageRecieved(JsonConvert.DeserializeObject<int>(e.Data)); };
            _wsLogIn.Connect();

            _wsBidding = new WebSocket("ws://192.168.1.170:8001/BiddingService"); // This is the connection to another pc, still needs done.
            //_wsBidding = new WebSocket("ws://127.0.0.1:8001/BiddingService"); // This is the connection to your own pc, comment out in final version.
            _wsBidding.OnMessage += (sender, e) => { if (BiddingMessageRecieved != null) BiddingMessageRecieved(JsonConvert.DeserializeObject<List<AuctionItem>>(e.Data)); };
            _wsBidding.Connect();
        }
        #endregion

        #region Methods
        /// <summary>
        /// seds the username and password to the server to be authenticated
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string user, string password)
        {
            if (_wsLogIn.IsAlive)
            {
                var auth = user + ":" + password;
                _wsLogIn.Send(JsonConvert.SerializeObject(auth));
            }
            return 1;
 
        }

        /// <summary>
        /// sends the bidding data to the server to update
        /// </summary>
        /// <param name="data"></param>
        public void SendData(object data)
        {
            if (_wsBidding.IsAlive)
            {
                _wsBidding.Send(JsonConvert.SerializeObject(data as AuctionItemsModel));
            }
        }

        /// <summary>
        /// populates the proxy with the list of items recieved from the server
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool onMessageBidding(List<AuctionItem> list)
        {
            _populateProxy(list);
            return true;
        }
        
        /// <summary>
        /// catches bad logins/ sets the client id of the controller and asks the server to send the initial model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool onMessageLogin(int id)
        {
            if (id == -1)
            {
                MessageBox.Show("Incorrect Password");
                return false;
            }
            else
            {
                _setClientID(id);
                SendData(null);
                return true;
            }
        }
        #endregion

        #region Register Methods
        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="pp">method passed in</param>
        public void RegisterProxy(TransferItem<List<AuctionItem>> pp)
        {
            _populateProxy = pp;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="scid">delegate passed in</param>
        public void RegisterSetID(SetClientID scid)
        {
            _setClientID = scid;
        }
        #endregion
    }
}
