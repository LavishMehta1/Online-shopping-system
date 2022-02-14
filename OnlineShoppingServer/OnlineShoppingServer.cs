using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    public class OnlineShoppingServer
    {
        private readonly CancellationToken m_cancellationToken;
        private readonly Products m_products;
        private readonly Order final_Order;
        public IPAddress ServerIp { get; set; } = IPAddress.Any;
        public int ServerPort { get; set; } = 55555;
        //private readonly List<Shopper> m_shopper = new List<Shopper>();
        Account account1 = new Account(1111, "John");
        Account account2 = new Account(2222, "Lucy");
        Account account3 = new Account(3333, "Ram");
        public OnlineShoppingServer(CancellationToken cancellationToken, Products products, Order order)
        {
            m_cancellationToken = cancellationToken;
            m_products = products;
            final_Order = order;
        }

        public void Start()
        {
            try
            {

                object Account = (account1, account2, account3);

                TcpListener listener = new TcpListener(ServerIp, ServerPort);
                listener.Start(); // Once the listener is started, the client can connect and send data.  More than one client can connect.
                m_cancellationToken.Register(listener.Stop); // Stop the server port listener if a cancellation is requested
                while (!m_cancellationToken.IsCancellationRequested)
                {
                    
                    TcpClient tcpClient = listener.AcceptTcpClient(); // Get the next ready client connection, or wait for a client connection if no new clients are connected
                    OnlineShoppingHandler handler = new OnlineShoppingHandler(tcpClient, Account, m_cancellationToken, m_products, final_Order);
                    ThreadPool.QueueUserWorkItem(handler.Run);
                    // new Thread(new MouseWatcherClientHandler(clientColor, tcpClient, m_cancellationToken).Run).Start();
                }
            }
            catch (SocketException)
            { 
            
            }


        }
    }
}
