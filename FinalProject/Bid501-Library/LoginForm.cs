using System;
using System.Windows.Forms;

namespace Bid501_Library
{
    /// <summary>
    /// The View that handles the user logging in.
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Fields
        /// <summary>
        /// The <see cref="Delegate"/> method that tells the controller that the username has changed.
        /// </summary>
        private TextboxChanged _usernameChanged;

        /// <summary>
        /// The delegate method that tells the controller that the password has changed.
        /// </summary>
        private TextboxChanged _passwordChanged;

        /// <summary>
        /// The <see cref="Delegate"/> method that tells the controller that the login <see cref="Button"/> was pressed.
        /// </summary>
        private ActionButtonPressed<string[]> _loginButtonPressed;
        #endregion


        #region Constuctors
        /// <summary>
        /// Constructs a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// An event handler that notifies the controller when the username has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUsername_TextChanged(object sender, EventArgs e) => _usernameChanged();

        /// <summary>
        /// An event handler that notifies the controller when the password has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPassword_TextChanged(object sender, EventArgs e) => _passwordChanged();

        /// <summary>
        /// An event handler that notifies the controller when the login <see cref="Button"/> has been pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginButton_Click(object sender, EventArgs e) => _loginButtonPressed(new string[] { uxUsername.Text, uxPassword.Text });
        #endregion


        #region Methods
        /// <summary>
        /// Toggles the password <see cref="TextBox"/> to either enabled or disabled.
        /// </summary>
        /// <param name="enabled">A <see cref="bool"/> that is true when the password should be enabled and false otherwise.</param>
        public void TogglePassword(bool enabled) => uxPassword.Enabled = enabled;

        /// <summary>
        /// Toggles the login <see cref="Button"/> to either enabled or disabled.
        /// </summary>
        /// <param name="enabled">A <see cref="bool"/> that is true when the login <see cref="Button"/> should be enabled and false otherwise.</param>
        public void ToggleLogin(bool enabled) => uxLoginButton.Enabled = enabled;

        /// <summary>
        /// Displays a <see cref="MessageBox"/> with a given message.
        /// </summary>
        /// <param name="msg">A <see cref="string"/> that is the message to display.</param>
        public void DisplayMessage(string msg) => MessageBox.Show(msg);

        /// <summary>
        /// Resets the <see cref="LoginForm"/> to its default appearance.
        /// </summary>
        public void Reset()
        {
            uxUsername.Text = "";
            uxPassword.Text = "";
            uxLoginButton.Enabled = false;
        }
        #endregion


        #region Register Methods
        /// <summary>
        /// Registers the <see cref="LoginForm"/>'s _usernameChanged <see cref="Delegate"/>.
        /// </summary>
        /// <param name="uc">The <see cref="TextboxChanged"/> method to register.</param>
        public void RegisterUsernameChanged(TextboxChanged uc) => _usernameChanged = uc;

        /// <summary>
        /// Registers the <see cref="LoginForm"/>'s _passwordChanged <see cref="Delegate"/>.
        /// </summary>
        /// <param name="pc">The <see cref="TextboxChanged"/> method to register.</param>
        public void RegisterPasswordChanged(TextboxChanged pc) => _passwordChanged = pc;

        /// <summary>
        /// Registers the <see cref="LoginForm"/>'s _loginButtonPressed <see cref="Delegate"/>.
        /// </summary>
        /// <param name="lbp">The <see cref="ActionButtonPressed{T}"/> method to register.</param>
        public void RegisterLoginButtonPressed(ActionButtonPressed<string[]> lbp) => _loginButtonPressed = lbp;
        #endregion
    }
}
