using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCilent
{
    public interface IShopperdata
    {
        
        string HostName { get; set; }
        int HostPort { get; set; }
        string User { get; set; }
        string[] Stock_Products { get; set; }
        string[] orders_purchased { get; set; }
        string purchase_result { get; set; }

        void Server(string Host);
        Task Connect(string accountno);
        Task Get_Order();
        Task GEt_Products();
        Task Purchase(string item);
        void Disconnect();

    }
}
