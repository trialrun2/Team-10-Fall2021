using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Library;

namespace Bid501_Client
{
    class BidFormController
    {
        private IAuctionModel _model;
        private UpdateText _updateName;
        private UpdateText _updateStatus;
        private UpdateText _updateAuctionTime;
        private UpdateText _updateNumberOfBids;
        private UpdateText _updateMinumumBid;
        private TransferItem<object> _sendData;
        private ShowView _show;

        public BidFormController()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void PlaceBid(string item)
        { 
            throw new NotImplementedException();
        }

        public void SetCurrentProduct(int index)
        {
            throw new NotImplementedException();
        }

        public void FillProxy(object pp)
        {
            throw new NotImplementedException();
        }

        #region registerMethods
        public void RegisterUpdateName(UpdateText un)
        {
            _updateName = un;
        }

        public void RegisterUpdateStatus(UpdateText us)
        {
            _updateStatus = us;
        }

        public void RegisterUpdateAuctionTime(UpdateText uat)
        {
            _updateAuctionTime = uat;
        }

        public void RegisterUpdateNumberOfBids(UpdateText unob)
        {
            _updateNumberOfBids = unob;
        }

        public void RegisterUpdateMinimumBid(UpdateText umb)
        {
            _updateMinumumBid = umb;
        }

        public void RegisterShow(ShowView sv)
        {
            _show = sv;
        }
        #endregion
    }
}
