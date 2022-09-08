using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Bid501_Library;

namespace Bid501_Server
{
    public class FileHandler
    {
        #region Fields
        /// <summary>
        /// The name of the file this handler accesses.
        /// </summary>
        private string _itemsFileName;

        private string _clientFileName;
        #endregion


        #region Constructors
        public FileHandler(string itemName, string clientName)
        {
            _itemsFileName = itemName;
            _clientFileName = clientName;
        }
        #endregion


        #region Methods
        public Stack<AuctionItem> LoadAuctionItems()
        {
            Stack<AuctionItem> items = new Stack<AuctionItem>();

            try
            {
                Debug.WriteLine($"[Log][FileHandler] Reading Auction Item Data from {_itemsFileName}");
                using (StreamReader sr = new StreamReader(_itemsFileName))
                using (JsonTextReader input = new JsonTextReader(sr))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                    JsonSerializer serializer = JsonSerializer.Create(settings);

                    items = serializer.Deserialize<Stack<AuctionItem>>(input);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"[Error][FileHandler] {fnfe.FileName} not found | Creating new Client File");

                using (StreamWriter output = new StreamWriter(_itemsFileName))
                {
                    Stack<AuctionItem> auctionItems = new Stack<AuctionItem>();
                    auctionItems.Push(new AuctionItem("Nintendo Switch") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("Renaissance Artwork") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("Antique Knife") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("RacingHorse") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("PS4") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("iPhone 7") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("Bose SoundSport") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });
                    auctionItems.Push(new AuctionItem("Arduino Microcontroller") { BidCount = 0, HighestBid = 0.0m, HighestBidder = 0, IsSold = false });

                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                    JsonSerializer serializer = JsonSerializer.Create(settings);

                    serializer.Serialize(output, auctionItems);

                    items = auctionItems;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return items;
        }

        public List<Client> LoadClients()
        {
            List<Client> clients = new List<Client>();

            try
            {
                Debug.WriteLine($"[Log][FileHandler] Reading Client Data from {_clientFileName}");
                using (StreamReader input = new StreamReader(_clientFileName))
                {
                    clients = (JsonConvert.DeserializeObject<List<Client>>(input.ReadToEnd()));
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Debug.WriteLine($"[Error][FileHandler] {fnfe.FileName} not found | Creating new Client File");

                using (StreamWriter output = new StreamWriter(_clientFileName))
                {
                    List<Client> newClients = new List<Client>();
                    newClients.Add(new Client(000000000, "admin", "password"));
                    newClients.Add(new Client(456213789, "user1", "password"));
                    newClients.Add(new Client(128748456, "user2", "password"));
                    newClients.Add(new Client(123478965, "user3", "password"));
                    newClients.Add(new Client(984537144, "user4", "password"));

                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };
                    JsonSerializer serializer = JsonSerializer.Create(settings);

                    serializer.Serialize(output, newClients);

                    clients = newClients;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[Error] {e.Message}");
            }

            return clients;
        }

        public void SaveAuctionItems(object data)
        {
            try
            {
                using (StreamWriter output = new StreamWriter(_itemsFileName))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };

                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(output, data);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[Error] {e.Message}");
            }
        }

        public void SaveNewClient(Client client)
        {
            List<Client> clients = LoadClients();
            clients.Add(client);

            try
            {
                Debug.WriteLine($"[Log][FileHandler] Adding the new client to the clients file");
                using (FileStream fileStream = new FileStream(_clientFileName, FileMode.Open))
                using (StreamWriter output = new StreamWriter(fileStream))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented };

                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(output, clients);
                    
                    output.Flush();
                    fileStream.SetLength(fileStream.Position);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[Error] {e.Message}");
            }
        }
        #endregion
    }
}
