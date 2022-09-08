using System;
using System.Windows.Forms;
using WebSocketSharp.Server;
using Bid501_Server.Services;
using Bid501_Library;


namespace Bid501_Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Model Setup
            var listedAuctionModel = new AuctionItemsModel();
            var unlistedAuctionModel = new AuctionItemsModel();
            var clientModel = new ClientModel();
            var fileHandler = new FileHandler("itemsFile.txt","clientFile.txt");
            #endregion

            #region WSServer Handler Setup
            var serverHandler = new WSServerHandler(listedAuctionModel);
            #endregion


            #region Server View Setup
            var serverView = new ServerForm(listedAuctionModel, clientModel);
            var serverViewController = new ServerFormController(listedAuctionModel, unlistedAuctionModel,clientModel);

            serverView.RegisterAddProduct(serverViewController.AddProduct);
            serverView.RegisterEndAuction(serverViewController.EndAuction);
            
            serverViewController.RegisterSaveFile(fileHandler.SaveNewClient);
            serverViewController.RegisterLoadItemsFile(fileHandler.LoadAuctionItems);
            serverViewController.RegisterLoadClientsFile(fileHandler.LoadClients);

            serverViewController.RegisterSendAuctionData(serverHandler.SendData);

            serverViewController.RegisterToggleEndAuction(serverView.ToggleEndAuction);
            serverViewController.RegisterShow(serverView.ShowView);
            serverViewController.RegisterUpdateView(serverView.InvokeUpdate);

            serverView.Show(); /// The view needs to be fully made for the application to properly get data, I don't know how to do it other than this. 
            serverView.Hide();
            #endregion


            #region Add Product Setup
            var addProductView = new AddProductForm(unlistedAuctionModel);
            var addProductController = new AddProductFormController();

            addProductView.RegisterTransferProduct(addProductController.AddProduct);
            addProductController.RegisterTransferProduct(serverViewController.AddProduct);
            addProductController.RegisterShow(addProductView.ShowView);
            
            serverViewController.RegisterTransferControl(addProductView.ShowView);
            #endregion


            #region Login Setup
            var loginView = new LoginForm();
            var loginControl = new LoginController(serverViewController.Authenticate, serverViewController.Start);

            loginView.RegisterLoginButtonPressed(loginControl.Login);
            loginView.RegisterPasswordChanged(loginControl.EnabledLogin);
            loginView.RegisterUsernameChanged(loginControl.EnablePassword);

            loginControl.RegisterDisplayMessage(loginView.DisplayMessage);
            loginControl.RegisterHideLogin(loginView.Hide);
            loginControl.RegisterResetLogin(loginView.Reset);
            loginControl.RegisterToggleLogin(loginView.ToggleLogin);
            loginControl.RegisterTogglePassword(loginView.TogglePassword);
            #endregion


            #region WSServer Setup
            var wss = new WebSocketServer(8001);

            wss.AddWebSocketService("/BiddingService", () => new BiddingService(serverHandler.UpdateModel));
            wss.AddWebSocketService("/LoginService", () => new LoginService(serverViewController.Authenticate));

            serverHandler.RegisterServer(wss);

            wss.Start();
            #endregion

            Application.Run(loginView);

            wss.Stop();
        }
    }
}
