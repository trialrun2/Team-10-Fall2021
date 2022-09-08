using System;
using System.Windows.Forms;
using Bid501_Library;

namespace Bid501_Server
{
    /// <summary>
    /// The server-side View for monitoring product auctions and clients.
    /// </summary>
    public partial class ServerForm : Form
    {
        #region Fields
        /// <summary>
        /// Interface to the model for Auction Items currently on auction.
        /// </summary>
        private AuctionItemsModel _listedItemsModel;

        /// <summary>
        /// Model for clients using Auction service
        /// </summary>
        private ClientModel _clientModel;

        /// <summary>
        ///  The <see cref="Delegate"/> method to add a product from the database to the live auction
        /// </summary>
        private ButtonPressed _addProduct;

        /// <summary>
        /// The <see cref="Delegate"/> method to simulate an auction ending for a particular product
        /// </summary>
        private ActionButtonPressed<int> _endAuction;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="ServerForm"/> class.
        /// </summary>
        /// <param name="lim"> The interface to the Auction Items Model</param>
        /// <param name="cm"> The Client model for the instance of the Auction Service</param>
        public ServerForm(AuctionItemsModel lim, ClientModel cm)
        {
            InitializeComponent();
            _listedItemsModel = lim;
            _clientModel = cm;
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// An event handler that notifies the controller when the Add <see cref="Button"/> has been pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void uxAddbtn_Click(object sender, EventArgs e) => _addProduct();

        /// <summary>
        /// An event handler that notifies the contorller when the End <see cref="Button"/> has been pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void uxEndBtn_Click(object sender, EventArgs e) => _endAuction(uxProducts.SelectedIndex);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region Methods
        public void ShowView()
        {
            UpdateList();
            Show();
        }

        /// <summary>
        /// Toggles the login <see cref="Button"/> to either enabled or disabled.
        /// </summary>
        /// <param name="enabled"> True when the End button is should be enabled and false otherwise. </param>
        public void ToggleEndAuction(bool enabled) => uxEndBtn.Enabled = enabled;
        
        public void UpdateList()
        {
            //Invoke(new Action(() => uxProducts.Items.Clear()));
            uxProducts.Items.Clear();
            foreach (AuctionItem auctionItem in _listedItemsModel) uxProducts.Items.Add(auctionItem.Name);
            // makes sure some item is always selected so we can't end an auction for a negative index
            if (uxProducts.SelectedIndex < 0) uxProducts.SelectedIndex = 0;

            uxClients.Items.Clear();
            foreach (Client client in _clientModel) if (client.Used) uxClients.Items.Add($"Client: {client.ID}");
        }

        public void InvokeUpdate() => Invoke(new Action(() => UpdateList()));
        #endregion


        #region Register Methods
        /// <summary>
        ///  Registers the <see cref="ServerForm"/>'s _addProduct <see cref="Delegate"/>
        /// </summary>
        /// /// <param name="ap">The <see cref="ButtonPressed"/> method to register.</param>
        public void RegisterAddProduct(ButtonPressed ap) => _addProduct = ap;

        /// <summary>
        ///  Registers the <see cref="ServerForm"/>'s _endAuction <see cref="Delegate"/>
        /// </summary>
        /// /// <param name="ea">The <see cref="ActionButtonPressed"/> method to register.</param>
        public void RegisterEndAuction(ActionButtonPressed<int> ea) => _endAuction = ea;
        #endregion
    }
}
