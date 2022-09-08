using System;
using System.Diagnostics;
using Bid501_Library;

namespace Bid501_Server
{
    /// <summary>
    /// Controller for the <see cref="AddProductForm"/> View.
    /// </summary>
    class AddProductFormController
    {
        #region Fields
        /// <summary>
        /// The <see cref="Delegate"/> for transferring products to be auctioned.
        /// </summary>
        public TransferItem<AuctionItem> _transferProduct;

        /// <summary>
        /// The <see cref="Delegate"/> for showing the form.
        /// </summary>
        public ShowView _show;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="AddProductFormController"/> class.
        /// </summary>
        /// <param name="ulai"> The interface to the auction items model. </param>
        public AddProductFormController()
        {
            // empty constructor
        }
        #endregion


        #region Methods
        /// <summary>
        /// Calls the form show function
        /// </summary>
        public void Start() => _show();

        /// <summary>
        /// Adds a product from the database to the live Auctions.
        /// </summary>
        public void AddProduct(AuctionItem item)
        {
            Debug.WriteLine($"[Log][AddProductFormController] Transfering Item {item.Name} to [ServerFormController]");
            _transferProduct(item);
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers the <see cref="AddProductFormController"/>'s _transferProduct <see cref="Delegate"/>.
        /// </summary>
        /// <param name="ti">The method to register.</param>
        public void RegisterTransferProduct(TransferItem<AuctionItem> ti) => _transferProduct = ti;

        /// <summary>
        /// Registers the <see cref="AddProductFormController"/>'s _show <see cref="Delegate"/>.
        /// </summary>
        /// <param name="sv">The method to register.</param>
        public void RegisterShow(ShowView sv) => _show = sv;
        #endregion
    }
}
