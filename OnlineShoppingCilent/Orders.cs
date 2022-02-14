using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCilent
{
    public class Orders
    {
        public string[] str1 = new string[5];

        public Orders(string str)
        {
            //int Count2 = 0;+
            //int count = 1;
            string[] firstTime = str.Split(':');
            str1 = firstTime[1].Split('|');

        }
    }
}
