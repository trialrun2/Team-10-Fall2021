using System;
using System.Diagnostics;

namespace Bid501_Library
{
    /// <summary>
    /// The Controller that controls the <see cref="LoginForm"/> View.
    /// </summary>
    public class LoginController
    {
        #region Fields
        /// <summary>
        /// The <see cref="Delegate"/> method that asks the Server to authenticate the user's credentials.
        /// </summary>
        private Authenticate _authenticate;

        /// <summary>
        /// The <see cref="Delegate"/> method that transfers control to another Controller.
        /// </summary>
        private TransferControl _transferControl;

        /// <summary>
        /// The <see cref="Delegate"/> method that displays a message in the <see cref="LoginForm"/> View.
        /// </summary>
        private DisplayMessage _displayMessage;

        /// <summary>
        /// The <see cref="Delegate"/> method that resets the display of the <see cref="LoginForm"/> View.
        /// </summary>
        private ResetLogin _resetLogin;

        /// <summary>
        /// The <see cref="Delegate"/> method that hides the <see cref="LoginForm"/> View.
        /// </summary>
        private HideLogin _hideLogin;

        /// <summary>
        /// The <see cref="Delegate"/> method that toggles the password in the <see cref="LoginForm"/> View.
        /// </summary>
        private ToggleControl _togglePassword;

        /// <summary>
        /// The <see cref="Delegate"/> method that toggles the login in the <see cref="LoginForm"/> View.
        /// </summary>
        private ToggleControl _toggleLogin;
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="auth">The <see cref="Delegate"/> method that asks the Server to authenticate the user's credentials.</param>
        /// <param name="tc">The <see cref="Delegate"/> method that transfers control to another Controller.</param>
        public LoginController(Authenticate auth, TransferControl tc)
        {
            _authenticate = auth;
            _transferControl = tc;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Enables the password in the <see cref="LoginForm"/> View.
        /// </summary>
        public void EnablePassword() => _togglePassword(true);

        /// <summary>
        /// Enables the login in the <see cref="LoginForm"/> View.
        /// </summary>
        public void EnabledLogin() => _toggleLogin(true);

        /// <summary>
        /// Attempts to login into the application with the given credintials.
        /// </summary>
        /// <param name="credentials">The given username and password.</param>
        public void Login(string[] credentials) 
        {
            Debug.WriteLine($"[Log][LoginController] Authenticating u:{credentials[0]} p:{credentials[1]}");
            int id = _authenticate(credentials[0], credentials[1]);
            if (id == -1)
            {
                _displayMessage("Incorrect Password");
                _resetLogin();              
            }
            else
            {
                _hideLogin();
                _transferControl();
            }
        }
        #endregion


        #region RegisterMethods
        /// <summary>
        /// Registers the <see cref="LoginController"/>'s _resetLogin <see cref="Delegate"/>.
        /// </summary>
        /// <param name="rl">The <see cref="ResetLogin"/> method to register.</param>
        public void RegisterResetLogin(ResetLogin rl) => _resetLogin = rl;

        /// <summary>
        /// Registers the <see cref="LoginController"/>'s _hideLogin <see cref="Delegate"/>.
        /// </summary>
        /// <param name="hl">The <see cref="HideLogin"/> method to register.</param>
        public void RegisterHideLogin(HideLogin hl) => _hideLogin = hl;

        /// <summary>
        /// Registers the <see cref="LoginController"/>'s _displayMessage <see cref="Delegate"/>.
        /// </summary>
        /// <param name="dm">The <see cref="DisplayMessage"/> method to register.</param>
        public void RegisterDisplayMessage(DisplayMessage dm) => _displayMessage = dm;

        /// <summary>
        /// Registers the <see cref="LoginController"/>'s _togglePassword <see cref="Delegate"/>.
        /// </summary>
        /// <param name="tp">The <see cref="ToggleControl"/> method to register.</param>
        public void RegisterTogglePassword(ToggleControl tp) => _togglePassword = tp;
        
        /// <summary>
        /// Registers the <see cref="LoginController"/>'s _toggleLogin <see cref="Delegate"/>.
        /// </summary>
        /// <param name="tl">The <see cref="ToggleControl"/> method to register.</param>
        public void RegisterToggleLogin(ToggleControl tl) => _toggleLogin = tl;
        #endregion
    }
}
