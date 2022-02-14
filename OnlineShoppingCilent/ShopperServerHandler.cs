using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShoppingCilent
{
    public class ShopperServerHandler : IShopperdata
    {
        
        public string HostName { get; set; }
        public int HostPort { get; set; } = 55555;
        public string User { get; set; } = null;
        public string[] Stock_Products { get; set; }
        public string[] orders_purchased { get; set; }
        public string purchase_result { get; set; }

        public TcpClient m_tcpClient = null;
        private StreamReader m_reader;
        private StreamWriter m_writer;
        public void Server(string Host)
        {

            if (Host != null)
            {
                HostName = Host;
            }
            try
            {
                m_tcpClient = m_tcpClient = new TcpClient(); // Default constructor only allows IPv4
                m_tcpClient.Connect(HostName, HostPort);
                NetworkStream stream = m_tcpClient.GetStream();
                m_reader = new StreamReader(stream);
                m_writer = new StreamWriter(stream);


            }
            catch (SocketException exception)
            {
                // m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", exception);
            }
        }
        public async Task Connect(string accountno)
        {
            string readline = null;
            try
            {
                await m_writer.WriteLineAsync($"CONNECT:{accountno}");
                await m_writer.FlushAsync();
                readline = await m_reader.ReadLineAsync();
            }
            catch (SocketException exception)
            {
                throw new InvalidOperationException("Server Unavailable", exception);
            }
            if (readline == "CONNECT_ERROR")
            {
                Disconnect();

            }

            User = readline;
        }

        public async Task GEt_Products()
        {
            string get_product;
            try
            {
                await m_writer.WriteLineAsync("GET_PRODUCTS");
                await m_writer.FlushAsync();
                get_product = await m_reader.ReadLineAsync();
                Products products = new Products(get_product);
                Stock_Products = products.str1;
            }
            catch (SocketException exception)
            {
                throw new InvalidOperationException("Server Unavailable", exception);
            }
        }

        public async Task Get_Order()
        {
            string get_orders;
            try
            {
                await m_writer.WriteLineAsync("GET_ORDERS");
                await m_writer.FlushAsync();
                get_orders = await m_reader.ReadLineAsync();
                Orders products = new Orders(get_orders);
                orders_purchased = products.str1;
            }
            catch (SocketException exception)
            {
                throw new InvalidOperationException("Server Unavailable", exception);
            }
        }

        public async Task Purchase(string item)
        {
            string purchase_server_response;
            try
            {
                await m_writer.WriteLineAsync($"PURCHASE:{item}");
                await m_writer.FlushAsync();
                purchase_server_response = await m_reader.ReadLineAsync();
            }
            catch (SocketException exception)
            {
                throw new InvalidOperationException("Server Unavailable", exception);
            }
            purchase_result = purchase_server_response;
        }

        public void Disconnect()
        {
            try
            {
                m_writer.WriteLine("DISCONNECT");
                m_writer.Flush();
            }
            catch (IOException)
            {
                // Do nothing
            }
            finally
            {
                m_tcpClient.Close();
                m_tcpClient = null;
            }
        }
    }
}
