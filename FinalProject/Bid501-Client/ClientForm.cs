using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Library;

namespace Bid501_Client
{
    public partial class ClientForm : Form
    {
        #region Fields

        /// <summary>
        /// delegate variable for when a button is pressed
        /// </summary>
        private ActionButtonPressed<string> _bidButtonPressed;

        /// <summary>
        /// delegate variable for when the product selection is changed
        /// </summary>
        private SelectionChanged _productSelectionChanged;

        /// <summary>
        /// A refrence to the model of avalable auctions
        /// </summary>
        private AuctionItemsModel _model;
        #endregion

        #region Constructors
        /// <summary>
        /// initializes the client form
        /// </summary>
        public ClientForm(AuctionItemsModel mod)
        {
            _model = mod;
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// method for when the user presses the place bid button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBidButton_Click(object sender, EventArgs e)
        {
            _bidButtonPressed(uxBidTextBox.Text);
            uxBidTextBox.Clear();
        }    
        
        /// <summary>
        /// method for when the user changes the product they've selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (uxProductList.SelectedIndex < 0) uxProductList.SelectedIndex = 0;
            _productSelectionChanged(uxProductList.SelectedIndex);
        }

        /// <summary>
        /// exits the application when the form is closed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the name to the currently selected products name
        /// </summary>
        /// <param name="name">current product name</param>
        public void SetDisplayName(string name)
        {
            uxSelectedProductLabel.Text = name;
            uxSelectedProductLabel.Update();
        }

        /// <summary>
        /// Sets the time to the currently selected products auction time
        /// </summary>
        /// <param name="id">id of user logged in</param>
        public void SetUserID(string id)
        {
            Invoke(new Action(() => uxUserIDBox.Text = id));
        }

        /// <summary>
        /// Sets the status to the currently selected products status
        /// </summary>
        /// <param name="status">current status of the product</param>
        public void SetStatus(string status)
        {
            uxStatus.Text = status;
        }

        /// <summary>
        /// Sets the bid count to the currently selected products bid count
        /// </summary>
        /// <param name="num">current number of bids for the product</param>
        public void SetNumberOfBids(string num)
        {
            uxBidCount.Text = num;
        }

        /// <summary>
        /// Sets the minimumbid to the currently selected products minimum bid
        /// </summary>
        /// <param name="price">current highest bid for the product</param>
        public void SetMinimumBid(string price)
        {
            uxMinimumBid.Text = price;
        }

        /// <summary>
        /// updates the displayed list of auctions to match the data in the model
        /// </summary>
        /// <param name="products"></param>
        public void UpdateList()
        {
            Invoke(new Action(() => uxProductList.Items.Clear()));
            foreach (AuctionItem item in _model)
            {
                Invoke(new Action(() => uxProductList.Items.Add(item.ToString())));
            }
        }

        /// <summary>
        /// toggles the bit button and textbox off when the item is sold
        /// </summary>
        /// <param name="onOff">variable holding value for if product is sold</param>
        public void ToggleBid(bool onOff)
        {
            uxBidButton.Enabled = onOff;
            uxBidTextBox.Enabled = onOff;
        }

        #endregion

        #region Register Methods
        /// <summary>
        /// Sets teh ActionButtonPressed delegate variable
        /// </summary>
        /// <param name="bb">method passed in</param>
        public void RegisterBidButton(ActionButtonPressed<string> bb)
        {
            _bidButtonPressed = bb;
        }

        /// <summary>
        /// Sets the SelectionChanged delegate variable
        /// </summary>
        /// <param name="sc">method passed in</param>
        public void RegisterProductSelectionChanged(SelectionChanged sc)
        {
            _productSelectionChanged = sc;
        }
        #endregion

    }
}
