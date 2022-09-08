using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Library;



namespace Bid501_Client
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

            AuctionItemsModel model = new AuctionItemsModel();

            ClientForm view = new ClientForm(model);
            ClientFormController controller = new ClientFormController(model);

            WSClientHandler clientHandler = new WSClientHandler();

            LoginForm loginView = new LoginForm();
            LoginController loginControl = new LoginController(clientHandler.Authenticate, controller.Start);

            #region Client View Setup
            view.RegisterBidButton(controller.PlaceBid);
            view.RegisterProductSelectionChanged(controller.SetCurrentProduct);
            view.Show(); /// The view needs to be fully made for the application to properly get data, I don't know how to do it other than this. 
            view.Hide(); 
            #endregion

            #region Controller Setup
            controller.RegisterUserID(view.SetUserID);
            controller.RegisterUpdateMinimumBid(view.SetMinimumBid);
            controller.RegisterUpdateName(view.SetDisplayName);
            controller.RegisterUpdateNumberOfBids(view.SetNumberOfBids);
            controller.RegisterUpdateStatus(view.SetStatus);
            controller.RegisterShow(view.Show);
            controller.RegisterUpdateView(view.UpdateList);
            controller.RegisterBid(view.ToggleBid);
            #endregion

            #region Login Setup
            loginView.RegisterLoginButtonPressed(loginControl.Login);
            loginView.RegisterPasswordChanged(loginControl.EnabledLogin);
            loginView.RegisterUsernameChanged(loginControl.EnablePassword);

            loginControl.RegisterDisplayMessage(loginView.DisplayMessage);
            loginControl.RegisterHideLogin(loginView.Hide);
            loginControl.RegisterResetLogin(loginView.Reset);
            loginControl.RegisterToggleLogin(loginView.ToggleLogin);
            loginControl.RegisterTogglePassword(loginView.TogglePassword);
            #endregion

            #region WS ClientHandler Setup
            clientHandler.RegisterProxy(controller.FillProxy);
            clientHandler.RegisterSetID(controller.SetID);
            clientHandler.LoginMessageRecieved += clientHandler.onMessageLogin;
            clientHandler.BiddingMessageRecieved += clientHandler.onMessageBidding;
            controller.RegisterSendData(clientHandler.SendData);
            #endregion


            Application.Run(loginView);
        }
    }
}
