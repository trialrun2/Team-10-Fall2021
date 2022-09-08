using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Library;
using Newtonsoft.Json;

namespace Bid501_Server.Services
{
    public class BiddingService : WebSocketBehavior
    {
        private TransferItem<AuctionItemsModel> _transferModel;

        public BiddingService(TransferItem<AuctionItemsModel> transfer) => _transferModel = transfer;

        protected override void OnOpen()
        {
            Debug.WriteLine($"[Log][BiddingService] Bidding Client {ID} opened");
            _transferModel(default);
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Debug.WriteLine($"[Log][BiddingService] Bidding Message recieved");
            var temp = JsonConvert.DeserializeObject<Stack<AuctionItem>>(e.Data);
            AuctionItemsModel auctionItems = new AuctionItemsModel() { AuctionItems = temp };
            _transferModel(auctionItems);
        }

    }
}
