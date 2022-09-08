using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using System.Diagnostics;
using WebSocketSharp.Server;
using Bid501_Library;
using Newtonsoft.Json;

namespace Bid501_Server
{
    /// <summary>
    /// A class that handles sending data to clients.
    /// </summary>
    public class WSServerHandler
    {
        /// <summary>
        /// The IAuctionModel of the application.
        /// </summary>
        private IAuctionModel _model;

        /// <summary>
        /// The <see cref="WebSocketServer"/> used for sending data.
        /// </summary>
        private WebSocketServer _server;

        /// <summary>
        /// Constructs a new instance of the <see cref="WSServerHandler"/> class.
        /// </summary>
        /// <param name="model">The <see cref="IAuctionModel"/> to use as a model.</param>
        public WSServerHandler(IAuctionModel model) => _model = model;

        /// <summary>
        /// Sends data to all clients that subscribe to the BiddingService.
        /// </summary>
        /// <param name="model">The IAuctionModel to send to the clients.</param>
        public void SendData(IAuctionModel model)
        {
            if (_server.WebSocketServices["/BiddingService"].Sessions != null)
            {
                Debug.WriteLine($"[Log][WSServerHandler] Sending data: {model} to bidding clients.");
                _server.WebSocketServices["/BiddingService"].Sessions.Broadcast(JsonConvert.SerializeObject(model));
            }
        }

        public void UpdateModel(AuctionItemsModel model)
        {
            Debug.WriteLine($"[Log][WSServerHandler] Updating AuctionItems Model.");

            if (model != null) if (model.AuctionItems != null) ((AuctionItemsModel)_model).AuctionItems = model.AuctionItems;

            SendData(_model);
        }

        public void RegisterServer(WebSocketServer webSocketServer) => _server = webSocketServer; 

    }
}
