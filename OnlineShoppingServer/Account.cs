using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    class Account
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Account(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
