using System;

namespace Bid501_Library
{
    /// <summary>
    /// Class holding data that defines a product to be auctioned
    /// </summary>
    public class AuctionItem
    {
        #region Fields
        /// <summary>
        /// False when the Item is still up for auction, True when it's been assigned to a user
        /// </summary>
        public bool IsSold = false;

        /// <summary>
        /// Name of the item for sale
        /// </summary>
        public string Name;

        /// <summary>
        /// Current highest bid on this item by any user
        /// </summary>
        public decimal HighestBid = 0;

        /// <summary>
        /// Total number of bids on this item since the start of the auction
        /// </summary>
        public int BidCount = 0;

        /// <summary>
        /// ID of the client who has placed the highest bid on this item so far
        /// </summary>
        public int HighestBidder;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new instance of the AuctionItem class.
        /// </summary>
        /// <param name="n"> name of the item up for auction </param>
        public AuctionItem(string n)
        {
            Name = n;
        }
        #endregion

        #region Methods

        /// <summary>
        /// overrides the initial to string so we can show only what we need in the list view
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsSold) return Name + "    SOLD";
            else return Name; //+ "\t$" + HighestBid.ToString();
        }
        #endregion
    }
}
