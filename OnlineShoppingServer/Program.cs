using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Products intial_Products = new Products();
            Order final_Order = new Order();
            final_Order.finish_order = "ORDERS:";
            OnlineShoppingServer server = new OnlineShoppingServer(cancellationTokenSource.Token, intial_Products, final_Order);
            Thread thServer = new Thread(server.Start);
            thServer.Start();
            Console.WriteLine("Press Q to shut down");
            while (thServer.IsAlive && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Q))
                ;
            cancellationTokenSource.Cancel();
            Console.WriteLine("Server is shutting down.");
            Console.ReadKey();
        }
    }
}
