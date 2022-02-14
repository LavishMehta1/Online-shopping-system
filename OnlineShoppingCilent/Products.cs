using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCilent
{
    public class Products
    {
        public string[] str1 = new string[5];

        public Products(string str)
        {
            int count = 0;
            string[] firstTime = str.Split(':');
            string[] second = firstTime[1].Split('|');
            foreach (var m in second)
            {
                string[] third = m.Split(',');
                str1[count] = third[0];
                count++;
            }
        }
    }
}
