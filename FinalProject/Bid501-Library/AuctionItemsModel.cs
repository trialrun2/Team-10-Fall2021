using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// TODO: add method logic and comments where noted

namespace Bid501_Library
{
    /// <summary>
    /// Model that access the Auction Items through an interface in the Library
    /// </summary>
    public class AuctionItemsModel : IEnumerable<AuctionItem> , IAuctionModel
    {
        #region Fields
        /// <summary>
        /// Stack maintaining the active Auction items
        /// </summary>
        public Stack<AuctionItem> AuctionItems;

        /// <summary>
        /// needed for IEnumerable
        /// </summary>
        public int Count => AuctionItems.Count;

        /// <summary>
        /// needed for IEnumerable
        /// </summary>
        public object SyncRoot => AuctionItems.ElementAt(0);

        /// <summary>
        /// needed for IEnumerable
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// needed for IEnumerable
        /// </summary>
        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// gets the Auction item at the index
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
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="AuctionItemsModel"/> class.
        /// </summary>
        public AuctionItemsModel()
        {
            AuctionItems = new Stack<AuctionItem>();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets a product to be auctioned from the interface in the Library.
        /// </summary>
        /// <param name="index"> Index of which item to get </param>
        /// <returns></returns>
        public AuctionItem GetItem()
        {
            return AuctionItems.Pop();
        }

        /// <summary>
        /// Adds an item to the model
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(AuctionItem item)
        {
            AuctionItems.Push(item);
        }

        /// <summary>
        /// gets the enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<AuctionItem> GetEnumerator() => AuctionItems.GetEnumerator();

        /// <summary>
        /// gets the enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => AuctionItems.GetEnumerator();

        /// <summary>
        /// need for Ienumerable
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  need for Ienumerable made our own
        /// </summary>
        /// <param name="item"></param>
        public void Add(AuctionItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// clears the stack
        /// </summary>
        public void Clear()
        {
            AuctionItems.Clear();
        }

        /// <summary>
        /// checks to see if the stack contains given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(AuctionItem item)
        {
            return AuctionItems.Contains(item);
        }

        /// <summary>
        ///  need for Ienumerable
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(AuctionItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  need for Ienumerable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(AuctionItem item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
