using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShoppingServer
{
    public class OnlineShoppingHandler
    {
        private readonly TcpClient m_tcpClient;
        private readonly CancellationToken m_cancellationToken;
        private readonly Products m_products;
        private readonly Account account1;
        private readonly Account account2;
        private readonly Account account3;
        private Order final_Order;
        private readonly Shopper m_shopper = new Shopper();
        //private readonly List<Shopper> m_shopper;


        public OnlineShoppingHandler(TcpClient tcpClient, Object acount, CancellationToken cancellationToken, Products products, Order order)
        {
            m_tcpClient = tcpClient;
            // m_shopper = shopper;
            (account1, account2, account3) = ((Account, Account, Account )) acount;
            m_cancellationToken = cancellationToken;
            m_products = products;
            final_Order = order;
        }

        public void Run(object threadInfo)
        {
            using (m_tcpClient)
            {
                try
                {
                    NetworkStream stream = m_tcpClient.GetStream();
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    m_cancellationToken.Register(stream.Close);
                    m_cancellationToken.Register((thread) => ((Thread)thread).Interrupt(), Thread.CurrentThread);
                    while (!m_cancellationToken.IsCancellationRequested)
                    {
                        string line = reader.ReadLine();
                        //string line = "CONNECT";
                        if (line != null) // A null value indicates the client may have closed the connection
                        {
                            if (line == "DISCONNECT")
                            {
                                if (m_cancellationToken.IsCancellationRequested)
                                    break;
                                Console.WriteLine("DISCONNECT");
                                break;
                            }
                            string[] request = line.Split(':');
                            if (request[0] == "CONNECT")
                            {
                                if (m_cancellationToken.IsCancellationRequested)
                                    break;

                                int.TryParse(request[1], out int shopperId);
                                if (account1.ID == shopperId)
                                {
                                    m_shopper.ID = account1.ID;
                                    m_shopper.Name = account1.Name;
                                }
                                else if (account2.ID == shopperId)
                                {
                                    m_shopper.ID = account1.ID;
                                    m_shopper.Name = account2.Name;
                                }
                                else if (account3.ID == shopperId)
                                {
                                    m_shopper.ID = account1.ID;
                                    m_shopper.Name = account3.Name;
                                }
                                else
                                {
                                    m_shopper.Name = "CONNECT_ERROR";
                                }
                                if (m_shopper.Name != "CONNECT_ERROR")
                                {
                                    string command = "CONNECTED:" + m_shopper.Name;
                                    writer.WriteLine(command);
                                    Console.WriteLine(command);
                                }
                                else
                                {
                                    writer.WriteLine(m_shopper.Name);
                                    Console.WriteLine(m_shopper.Name);
                                }
                            }

                           

                            if (request[0] == "GET_PRODUCTS")
                            {
                                Console.WriteLine(m_products.cilent_product);
                                writer.WriteLine(m_products.cilent_product);
                            }

                            if(request[0] == "GET_ORDERS")
                            {
                                Console.WriteLine(final_Order.finish_order);
                                writer.WriteLine(final_Order.finish_order);
                            }

                            if (request[0] == "PURCHASE")
                            { 
                                if(request[1] == "Apple")
                                {
                                    if (m_products.Apple != 0)
                                    {
                                        m_products.Apple -= 1;
                                        final_Order.sort(final_Order.finish_order, "Apple", m_shopper.Name);
                                        Console.WriteLine("DONE");
                                        writer.WriteLine("DONE");
                                    }

                                    else
                                    {
                                        Console.WriteLine("NOT_AVAILABLE");
                                        writer.WriteLine("NOT_AVAILABLE");
                                    }
                                }
                                else if (request[1] == "Orange")
                                {
                                    if (m_products.Orange != 0)
                                    {
                                        m_products.Orange -= 1;
                                        final_Order.sort(final_Order.finish_order, "Orange", m_shopper.Name);
                                        Console.WriteLine("DONE");
                                        writer.WriteLine("DONE");
                                    }

                                    else
                                    {
                                        Console.WriteLine("NOT_AVAILABLE");
                                        writer.WriteLine("NOT_AVAILABLE");
                                    }
                                }
                                else if (request[1] == "Mango")
                                {
                                    if (m_products.Mango != 0)
                                    {
                                        m_products.Mango -= 1;
                                        final_Order.sort(final_Order.finish_order, "Mango", m_shopper.Name);
                                        Console.WriteLine("DONE");
                                        writer.WriteLine("DONE");
                                    }

                                    else
                                    {
                                        Console.WriteLine("NOT_AVAILABLE");
                                        writer.WriteLine("NOT_AVAILABLE");
                                    }
                                }
                                else if (request[1] == "Printer")
                                {
                                    if (m_products.Printer != 0)
                                    {
                                        m_products.Printer -= 1;
                                        final_Order.sort(final_Order.finish_order, "Printer", m_shopper.Name);
                                        Console.WriteLine("DONE");
                                        writer.WriteLine("DONE");
                                    }

                                    else
                                    {
                                        Console.WriteLine("NOT_AVAILABLE");
                                        writer.WriteLine("NOT_AVAILABLE");
                                    }
                                }
                                else if (request[1] == "Mouse")
                                {
                                    if (m_products.Mouse != 0)
                                    {
                                        m_products.Mouse -= 1;
                                        final_Order.sort(final_Order.finish_order, "Mouse", m_shopper.Name);
                                        Console.WriteLine("DONE");
                                        writer.WriteLine("DONE");
                                    }

                                    else
                                    {
                                        Console.WriteLine("NOT_AVAILABLE");
                                        writer.WriteLine("NOT_AVAILABLE");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("NOT_VALID");
                                    writer.WriteLine("NOT_VALID");
                                }
                                if (m_cancellationToken.IsCancellationRequested)
                                    break;
                            }
                            
                        }
                    }
                }

                catch (IOException) // Exception takes us out of the loop, so client handler thread will end
                {
                    Console.WriteLine("***Network Error***");
                }
                catch (OutOfMemoryException)
                {
                    
                }
            }
        }
    }
}
