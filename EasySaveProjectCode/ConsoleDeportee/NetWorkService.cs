using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDeportee
{
    public class NetWorkService
    {
        //creating socket 
        private readonly Socket _socket;
        //dictionary to manage request data
        public Dictionary<int, string> _requestictionary;
        //EndPoint
        private readonly IPEndPoint _EndPoint;
        public NetWorkService() 
        {
            //initialize dictionary
            _requestictionary = new Dictionary<int, string>();
            //initialize socket
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Initialize endpoint
            _EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090);
        }
        private Socket ConnectSocket()
        {
            _socket.Connect(_EndPoint);
            return _socket;
        }
        public void Close()
        {
            // Shutdown the socket and close the connection
            if (_socket.Connected)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
        }
    }
}
