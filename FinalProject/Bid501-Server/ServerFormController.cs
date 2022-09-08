using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Bid501_Library;

// TODO: Add comments as marked, Method logic, make sure TransferItem<T> delegates are correct, check parameter type in constructor

namespace Bid501_Server
{
    /// <summary>
    /// Controller for the <see cref="ServerForm"/> View.
    /// </summary>
    public class ServerFormController
    {
        #region Fields
        /// <summary>
        /// The interface to the Auction items on auction.
        /// </summary>
        private AuctionItemsModel _listedAuctionItems;

        private AuctionItemsModel _unlistedAuctionItems;

        /// <summary>
        /// The Model for active Clients.
        /// </summary>
        private ClientModel _clients;

        /// <summary>
        /// The <see cref="Delegate"/> to enable and disable the End button
        /// </summary>
        private ToggleControl _toggleEndButton;

        /// <summary>
        /// The <see cref="Delegate"/> for loading Product Data from file
        /// </summary>
        private LoadData _loadItemsFile;

        /// <summary>
        /// The <see cref="Delegate"/> for loading Product Data from file
        /// </summary>
        private LoadData _loadClientsFile;

        /// <summary>
        /// The <see cref="Delegate"/> for saving Product Data to file
        /// </summary>
        private SaveData _saveFile;

        /// <summary>
        /// The <see cref="Delegate"/> for sending Auction Data to the active clients
        /// </summary>
        private TransferItem<IAuctionModel> _sendAuctionData; 

        /// <summary>
        /// The <see cref="Delegate"/> for showing the Add Product View
        /// </summary>
        public ShowView _show;

        /// <summary>
        /// The <see cref="Delegate"/> for transferring control to the Add Product View
        /// </summary>
        private TransferControl _showAddProductForm;

        private UpdateView _updateView;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="ServerFormController"/> class.
        /// </summary>
        /// <param name="lai"> The Model for products listed for active auction. </param>
        public ServerFormController(AuctionItemsModel lai, AuctionItemsModel ulai, ClientModel cm)
        {
            _listedAuctionItems = lai;
            _unlistedAuctionItems = ulai;
            _clients = cm;
        }
        #endregion


        #region Methods
        /// <summary>
        /// TODO: Start method description
        /// </summary>
        public void Start() => _show();

        /// <summary>
        ///  Load the data from file
        /// </summary>
        public void LoadData()
        {
            Debug.WriteLine($"[Log][ServerFormController] Loading Data");
            _unlistedAuctionItems.AuctionItems = (Stack<AuctionItem>)_loadItemsFile();
            _listedAuctionItems.AuctionItems.Clear();
            for (int i = 0; i < 3; i++) _listedAuctionItems.AddItem(_unlistedAuctionItems.GetItem());
            _clients.Clients = (List<Client>)_loadClientsFile();
        }

        /// <summary>
        /// Calls the AddProductForm view for pushing a new product to Auction.
        /// </summary>
        public void AddProduct() => _showAddProductForm();

        /// <summary>
        /// TODO: Description for polymorphic AddProduct
        /// </summary>
        /// <param name="newItem"></param> TODO: Parameter Description
        public void AddProduct(AuctionItem newItem)
        {
            Debug.WriteLine($"[Log][ServerFormConstroller] Adding new Item {newItem.Name} to model");
            _listedAuctionItems.AddItem(newItem);
            _sendAuctionData(_listedAuctionItems);
            _updateView();
        }

        /// <summary>
        /// Ends an auction to award a product to the highest bidder.
        /// </summary>
        /// <param name="index"> Index of the Auction to end </param>
        public void EndAuction(int index)
        {
            Debug.WriteLine($"[Log][ServerFormController] Ending auction for item {index}");
            _listedAuctionItems[index].IsSold = true;
            _sendAuctionData(_listedAuctionItems);
        }

        /// <summary>
        /// Checks for valid Username and Password.
        /// </summary>
        /// <param name="u"> Username from login attempt </param>
        /// <param name="p"> Password from login attempt </param>
        /// <returns></returns>
        public int Authenticate(string u, string p)
        {
            if (_clients.Clients == null) LoadData();
            Client loggedInClient = null;

            Debug.WriteLine($"[Log][ServerFormController] Checking Clients for successful login U:{u} P:{p}");
            foreach (Client client in _clients.Clients) 
            {
                if (u.Equals(client.Username) && p.Equals(client.Password)) 
                {
                    if (client.ID != 0) client.Used = true;
                    loggedInClient = client; 
                }
                if (u.Equals(client.Username) && !p.Equals(client.Password)) loggedInClient = new Client(-1, "", "");
            }

            if (loggedInClient == null) loggedInClient = new Client(-1, "", "");

            /*if (loggedInClient == null)
            {
                
                Debug.WriteLine($"[Log][ServerFormController] Client not found, adding new client");
                loggedInClient = new Client(_clients[_clients.Clients.Count - 1].ID + 1, u, p);
                _saveFile(loggedInClient);
                loggedInClient.Used = true;
                _clients.Add(loggedInClient);
            }*/

            Debug.WriteLine($"[Log][ServerFormController] Sending Client ID: {loggedInClient.ID}");
            _updateView();
            return loggedInClient.ID;
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _toggleEndButton <see cref="Delegate"/>
        /// </summary
        /// <param name="tea"> method to register</param>
        public void RegisterToggleEndAuction(ToggleControl tea) => _toggleEndButton = tea;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _saveFile <see cref="Delegate"/>
        /// </summary
        /// <param name="sf"> method to register</param>
        public void RegisterSaveFile(SaveData sf) => _saveFile = sf;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _loadItemsFile <see cref="Delegate"/>
        /// </summary
        /// <param name="lif"> method to register</param>
        public void RegisterLoadItemsFile(LoadData lif) => _loadItemsFile = lif;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _loadClientsFile <see cref="Delegate"/>
        /// </summary
        /// <param name="lcf"> method to register</param>
        public void RegisterLoadClientsFile(LoadData lcf) => _loadClientsFile = lcf;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _sendAuctionData <see cref="Delegate"/>
        /// </summary
        /// <param name="sad"> method to register</param>
        public void RegisterSendAuctionData(TransferItem<IAuctionModel> sad) => _sendAuctionData = sad;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _show <see cref="Delegate"/>
        /// </summary
        /// <param name="sv"> method to register</param>
        public void RegisterShow(ShowView sv) => _show = sv;

        /// <summary>
        /// Registers the <see cref="ServerFormController"/>'s _showAddProductForm <see cref="Delegate"/>
        /// </summary
        /// <param name="sapf"> method to register</param>
        public void RegisterTransferControl(TransferControl sapf) => _showAddProductForm = sapf;

        public void RegisterUpdateView(UpdateView update) => _updateView = update; 
        #endregion
    }
}
