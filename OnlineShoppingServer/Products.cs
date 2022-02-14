using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    public class Products
    {
        Random random = new Random();

        public int Apple { get; set; }
        public int Orange { get; set; }
        public int Mango { get; set; }
        public int Printer { get; set; }
        public int Mouse { get; set; }
        public string cilent_product;
        public Products()
        {
            
            Apple = random.Next(1, 4);
            Orange = random.Next(1, 4);
            Mango = random.Next(1, 4);
            Printer = random.Next(1, 4);
            Mouse = random.Next(1, 4);
            // Apple,3|Orange,1|
            cilent_product = $"PRODUCTS:Apple,{Apple}|Orange,{Orange}|Mango,{Mango}|Printer,{Printer}|Mouse,{Mouse}";
        }

        
    }
}
