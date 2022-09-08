using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Library
{
    public class Client
    {
        #region Fields
        /// <summary>
        /// ID number for the client object
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// username for the client
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password for the client
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// checked so that two of the same user cannot log on
        /// </summary>
        public bool Used { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Constructs a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client(int id, string u, string p)
        {
            ID = id;
            Username = u;
            Password = p;
        }
        #endregion
    }
}
