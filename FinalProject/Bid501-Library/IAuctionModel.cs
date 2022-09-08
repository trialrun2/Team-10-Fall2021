using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Library
{
    public interface IAuctionModel : IEnumerable<AuctionItem>
    {
        AuctionItem GetItem();
        void AddItem(AuctionItem item);
    }
}
