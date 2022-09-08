using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bid501_Library
{
    /// <summary>
    /// A <see cref="Delegate"/> for when a <see cref="TextBox"/>'s text changes.
    /// </summary>
    public delegate void TextboxChanged();

    /// <summary>
    /// A <see cref="Delegate"/> for displaying a message.
    /// </summary>
    /// <param name="msg">A <see cref="string"/> representing the message to be displayed.</param>
    public delegate void DisplayMessage(string msg);

    /// <summary>
    /// A <see cref="Delegate"/> for sending data when a <see cref="Button"/> is pressed.
    /// </summary>
    /// <typeparam name="T">The type of item to send.</typeparam>
    /// <param name="item">The item to send of type <see cref="T"/>.</param>
    public delegate void ActionButtonPressed<T>(T item);

    /// <summary>
    /// A <see cref="Delegate"/> for notifying a controller when a <see cref="Button"/> is pressed.
    /// </summary>
    public delegate void ButtonPressed();

    /// <summary>
    /// A <see cref="Delegate"/> that toggles a <see cref="Control"/>.
    /// </summary>
    /// <param name="enabled"></param>
    public delegate void ToggleControl(bool enabled);

    /// <summary>
    /// A <see cref="Delegate"/> that resets the <see cref="LoginForm"/> View.
    /// </summary>
    public delegate void ResetLogin();

    /// <summary>
    /// A <see cref="Delegate"/> that hides the <see cref="LoginForm"/> View.
    /// </summary>
    public delegate void HideLogin();

    /// <summary>
    /// A <see cref="Delegate"/> used to authenticate a user's credintials.
    /// </summary>
    /// <param name="u">A <see cref="string"/> representing the user's username.</param>
    /// <param name="p">A <see cref="string"/> representing the user's password.</param>
    /// <returns></returns>
    public delegate int Authenticate(string u, string p);

    /// <summary>
    /// A <see cref="Delegate"/> that transfers control between two Controllers.
    /// </summary>
    /// <param name="id">id number of the user logged in</param>
    public delegate void TransferControl();

    /// <summary>
    /// A <see cref="Delegate"/> that reads a JSON text file and returns the deserialized object
    /// </summary>
    /// <returns></returns>
    public delegate object LoadData();

    /// <summary>
    /// A <see cref="Delegate"/> that saves a string representation of an object to a txt file
    /// </summary>
    /// <param name="data"></param>
    public delegate void SaveData(Client data);

    /// <summary>
    /// A <see cref="Delegate"/> that sends an objects between the server and client
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item">Item to be sent</param>
    public delegate void TransferItem<T>(T item);

    /// <summary>
    /// A <see cref="Delegate"/> that updates the selected item on a list
    /// </summary>
    /// <param name="index">index of new selected item on list</param>
    public delegate void SelectionChanged(int index);
    
    /// <summary>
    /// A <see cref="Delegate"/> for when the a textbox is edited
    /// </summary>
    /// <param name="text"></param>
    public delegate void UpdateText(string text);

    /// <summary>
    /// A <see cref="Delegate"/> that makes a View shown.
    /// </summary>
    public delegate void ShowView();

    /// <summary>
    /// A <see cref="Delegate"/> for updating a view.
    /// </summary>
    public delegate void UpdateView();

    /// <summary>
    /// A <see cref="Delegate"/> for setting the client id in a clientform handeler
    /// </summary>
    /// <param name="id"></param>
    public delegate void SetClientID(int id);

    /// <summary>
    /// A <see cref="Delegate"/> for setting the method to be used when the websocket recieves a message for logging in
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public delegate bool LoginMessage(int id);

    /// <summary>
    /// A <see cref="Delegate"/> for setting the method to be used when the websocket recieves a message for bidding
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public delegate bool BiddingMessage(List<AuctionItem> list);
}
