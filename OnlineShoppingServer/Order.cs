using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    public class Order
    {
        public string finish_order { get; set; }
        public void sort(string given_order, string product, string Name)
        {
            if (!given_order.EndsWith(":"))
                given_order = $"{given_order}|";
            finish_order = $"{given_order}{product},1,{Name}";
        }
    }
}
