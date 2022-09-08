using System.Collections;
using System.Collections.Generic;
using Bid501_Library;

namespace Bid501_Server
{
    /// <summary>
    /// The model that's composed of <see cref="Client"/> objects to be accessed by various entities
    /// </summary>
    public class ClientModel : IEnumerable
    {
        #region Fields
        /// <summary>
        /// List of active clients in the auctions
        /// </summary>
        public List<Client> Clients;
        #endregion

        public Client this[int index]
        {
            get { return Clients[index]; }
            set { Clients[index] = value; }
        }

        public void Add(Client client) => Clients.Add(client);

        public IEnumerator GetEnumerator() => Clients.GetEnumerator();

        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="ClientModel"/> class.
        /// </summary>
        public ClientModel()
        {

        }
        #endregion
    }
}
