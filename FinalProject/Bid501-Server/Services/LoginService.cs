using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Library;
using Newtonsoft.Json;

namespace Bid501_Server.Services
{
    public class LoginService : WebSocketBehavior
    {
        private Authenticate _authenticate;

        public LoginService(Authenticate authenticate) => _authenticate = authenticate;

        protected override void OnOpen()
        {
            Debug.WriteLine($"[Log][LoginService] Login Client {ID} connected.");
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Debug.WriteLine($"[Log][LoginService] Login Client {ID} connected.");
            string[] data = JsonConvert.DeserializeObject<string>(e.Data).Split(':');
            Send(JsonConvert.SerializeObject(_authenticate(data[0], data[1])));
        }

    }
}
