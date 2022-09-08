using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Library;

namespace Bid501_Client
{
    class ClientFormController
    {
        #region Fields

        /// <summary>
        /// model of the database
        /// </summary>
        AuctionItemsModel _model;

        /// <summary>
        /// delegate to update the name of the product in the clientview
        /// </summary>
        UpdateText _updateName;

        /// <summary>
        /// delegate to update the status of the product in the clientview
        /// </summary>
        UpdateText _updateStatus;

        /// <summary>
        /// delegate to update the aution time of the product in the clientview
        /// </summary>
        UpdateText _updateUserID;

        /// <summary>
        /// delegate to update the bid count of the product in the clientview
        /// </summary>
        UpdateText _updateNumberOfBids;

        /// <summary>
        /// delegate to update the minimum bid of the product in the clientview
        /// </summary>
        UpdateText _updateMinimumBid;

        /// <summary>
        /// delegate to send the current model held to the server
        /// </summary>
        TransferItem<object> _sendData;

        /// <summary>
        /// delegate used to initiate the client view
        /// </summary>
        ShowView _show;

        /// <summary>
        /// delegate used to update the client view
        /// </summary>
        UpdateView _updateView;

        /// <summary>
        /// delegate used to toggle the bid functions on and off
        /// </summary>
        ToggleControl _allowBid;


        /// <summary>
        /// index of currently selected item
        /// </summary>
        int selectedIndex;

        /// <summary>
        /// ID of current user logged in
        /// </summary>
        int userID;
        #endregion

        #region Constuctors
        public ClientFormController(AuctionItemsModel model)
        {
            _model = model;
        }
        #endregion

        #region Methods

        /// <summary>
        /// opens the view
        /// </summary>
        public void Start() => _show();

        /// <summary>
        /// handles the bidding process and the updates to the ui
        /// </summary>
        /// <param name="amountSTR">amount of money to bid</param>
        public void PlaceBid(string amountSTR)
        {
            //_model.AddItem(new AuctionItem("eee"));

            
            Decimal amount = 0;
            try
            {
                amount = Convert.ToDecimal(amountSTR);
            }
            catch
            {
                amount = 0;
            }

            if (_model[selectedIndex].HighestBid >= amount)
            {
                _updateStatus("Please place a higher bid.");
                return;
            }
            _model[selectedIndex].HighestBid = amount;
            _model[selectedIndex].HighestBidder = userID;
            _model[selectedIndex].BidCount += 1;

            _sendData(_model);

            string status;

            if (_model[selectedIndex].IsSold)
            {
                status = (_model[selectedIndex].HighestBidder == userID) ? "Auction Won" : "Auction Lost";
                _allowBid(false);
            }
            else
            {
                status = "Auction Ongoing";
                _allowBid(true);
            }

            decimal minBid = Decimal.Add(_model[selectedIndex].HighestBid, (decimal) 0.01);
            _updateMinimumBid(minBid.ToString("C"));
            _updateName(_model[selectedIndex].Name);
            _updateStatus(status);
            _updateNumberOfBids($"{_model[selectedIndex].BidCount} Bids");

            _updateView();
        }

        /// <summary>
        /// updates the view to the current product
        /// </summary>
        /// <param name="index">index of item to set it to</param>
        public void SetCurrentProduct(int index)
        {
            selectedIndex = index;
            string status;

            if (_model[selectedIndex].IsSold)
            {
                status = (_model[selectedIndex].HighestBidder == userID) ? "Auction Won" : "Auction Lost";
                _allowBid(false);
            }
            else
            {
                status = "Auction Ongoing";
                _allowBid(true);
            }
            

            decimal minBid = Decimal.Add(_model[selectedIndex].HighestBid, (decimal)0.01);
            _updateMinimumBid(minBid.ToString("C"));
            _updateName(_model[selectedIndex].Name);
            _updateStatus(status);
            _updateNumberOfBids($"{_model[selectedIndex].BidCount} Bids");
        }

        /// <summary>
        /// A method to fill the database proxy. It gets called as a delegate by the WSClient Handler
        /// </summary>
        /// <param name="proxyModel"></param>
        public void FillProxy(List<AuctionItem> proxyModel)
        {
            _model.Clear();
            foreach(AuctionItem i in proxyModel)
            {
                _model.AddItem(i);
            }
            _updateView();
        }

        public void SetID(int id)
        {
            userID = id;
            _updateUserID($"Client: {userID}");
        }
        #endregion

        #region Register Methods

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="un">method passed in</param>
        public void RegisterUpdateName(UpdateText un)
        {
            _updateName = un;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="us">method passed in</param>
        public void RegisterUpdateStatus(UpdateText us)
        {
            _updateStatus = us;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="uat">method passed in</param>
        public void RegisterUserID(UpdateText uuid)
        {
            _updateUserID = uuid;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="unob">method passed in</param>
        public void RegisterUpdateNumberOfBids(UpdateText unob)
        {
            _updateNumberOfBids = unob;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="umb">method passed in</param>
        public void RegisterUpdateMinimumBid(UpdateText umb)
        {
            _updateMinimumBid = umb;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="sv">method passed in</param>
        public void RegisterShow(ShowView sv)
        {
            _show = sv;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="update">method passed in</param>
        public void RegisterUpdateView(UpdateView update)
        {
            _updateView = update;
        }

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="item">method passed in</param>
        public void RegisterSendData(TransferItem<object> item) => _sendData = item;

        /// <summary>
        /// sets the delegate to the method passed in
        /// </summary>
        /// <param name="bb">method passed in</param>
        public void RegisterBid(ToggleControl bb) => _allowBid = bb;
        #endregion

    }
}
