using System;
using System.Windows.Forms;
using System.Diagnostics;
using Bid501_Library;


namespace Bid501_Server
{
    /// <summary>
    /// The server-side View for adding products from the database to active auctions.
    /// </summary>
    public partial class AddProductForm : Form
    {
        #region Fields
        /// <summary>
        /// The interface to the AuctionItemsModel for products not in auction.
        /// </summary>
        private AuctionItemsModel _unlistedItemsModel;

        /// <summary>
        /// The <see cref="Delegate"/> method to add a product from the database to active auction.
        /// </summary>
        private ActionButtonPressed<AuctionItem> _addProduct;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="AddProductForm"/> class.
        /// </summary>
        /// <param name="uail"> Auction Item model from database </param>
        public AddProductForm(AuctionItemsModel uail)
        {
            InitializeComponent();
            _unlistedItemsModel = uail;
            uxProducts.SelectionMode=SelectionMode.None;
        }
        #endregion


        #region Methods
        public void ShowView()
        {
            uxProducts.Items.Clear();
            foreach (AuctionItem item in _unlistedItemsModel) uxProducts.Items.Add(item.Name);
            Show();
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// An event handler that adds a product from the database to the active auction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            if (_unlistedItemsModel.AuctionItems.Count <= 0)
            {
                Debug.WriteLine($"[Error][AddProductForm] Stack is empty");
                return;
            } 
            Debug.WriteLine($"[Log][AddProductForm] Popping {_unlistedItemsModel.AuctionItems.Peek()} to [AddProductFormController]");
            _addProduct(_unlistedItemsModel.GetItem());
            uxProducts.Items.Clear();
            foreach (AuctionItem item in _unlistedItemsModel) uxProducts.Items.Add(item.Name);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers the <see cref="AddProductForm"/>'s _addProduct <see cref="Delegate"/>.
        /// </summary>
        /// <param name="ap">The method to register.</param>
        public void RegisterTransferProduct(ActionButtonPressed<AuctionItem> ap) => _addProduct = ap;
        #endregion
    }
}
