using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Library;

namespace Bid501_Client
{
    class ProductsDBProxy : IAuctionModel
    {
        #region Fields
        /// <summary>
        /// the stack holding the current database used by the client view
        /// </summary>
        public Stack<AuctionItem> AuctionItems { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// when it's initialized it sets the _AuctionItems to a new empty stack
        /// </summary>
        public ProductsDBProxy()
        {
            AuctionItems = new Stack<AuctionItem>();
        }

        /// <summary>
        /// 2nd contructor to pass in an IAuctionModel
        /// </summary>
        /// <param name="model"></param>
        public ProductsDBProxy(IAuctionModel model)
        {
            AuctionItems = new Stack<AuctionItem>();
            foreach(AuctionItem item in model)
            {
                AuctionItems.Append(item);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// get or set the element at a specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AuctionItem this[int index]
        {
            get { return AuctionItems.ElementAt(index); }
            set
            {
                List<AuctionItem> tempItems = new List<AuctionItem>();
                while (AuctionItems.Count > 0) tempItems.Add(AuctionItems.Pop());

                tempItems[AuctionItems.Count - 1] = value;

                foreach (AuctionItem item in tempItems) AuctionItems.Push(item);
            }
        }

        /// <summary>
        /// gets the top auction item from the _AuctionItems stack
        /// </summary>
        /// <returns>the top auction item</returns>
        public AuctionItem GetItem()
        {
            return AuctionItems.Pop();
        }

        /// <summary>
        /// updates the product if a bid is placed on it
        /// </summary>
        /// <param name="itemIndex">index in stack of item to be bid on</param>
        /// <param name="amount">amount to be bid</param>
        /// <param name="bidderID">id of user who is bidding</param>
        /// <returns>true if successful</returns>
        public bool PlaceBid(int itemIndex, decimal amount, int bidderID)
        {
            if(AuctionItems.Count <= itemIndex) return false;
            AuctionItem item = AuctionItems.ElementAt(itemIndex);
            if (item.IsSold || item.HighestBid >= amount) return false;
            item.HighestBid = amount;
            item.HighestBidder = bidderID;
            item.BidCount++;
            return true;
        }

        /// <summary>
        /// adds the passed in item to the _AuctionItems stack
        /// </summary>
        /// <param name="item">auction item to add</param>
        public void AddItem(AuctionItem item)
        {
            AuctionItems.Push(item);
        }


        /// <summary>
        /// gets the enumerator of the product
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// gets the enumerator of the AuctionITems
        /// </summary>
        /// <returns></returns>
        public IEnumerator<AuctionItem> GetEnumerator()
        {
            return AuctionItems.GetEnumerator();
        }
        #endregion
    }
}
