using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace EasySaveProject_V2
{
    public class NetWorkService
    {
        //Socket
        private readonly Socket _ServerSocket;
        //EndPoint
        private readonly IPEndPoint _ServerEndPoint;
       
        //constructor
        public NetWorkService() 
        { 
            //initialize sockt 
            _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //initialize endpoint
            _ServerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090);
        }

        private Socket ConnectServer()
        {
            _ServerSocket.Bind(_ServerEndPoint);
            _ServerSocket.Listen(100);
            return _ServerSocket;
        }

        //method to accept the connexion
        private Socket AcceptConnexion(Socket socket)
        {
            var handler = socket.Accept();
            return handler;
        }

        //Listen to the traffic
        private void Listen(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesReceived = clientSocket.Receive(buffer);

                string jsonRequest = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                var requestDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonRequest);

                if (requestDictionary != null)
                {
                    foreach (var entry in requestDictionary)
                    {
                        Console.WriteLine($"Received: Key={entry.Key}, Value={entry.Value}");
                    }
                    // Handle the request and prepare a response
                    string response = HandleRequest(requestDictionary);

                    // Send back the response
                    byte[] byteData = Encoding.UTF8.GetBytes(response);
                    clientSocket.Send(byteData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Deconnect(clientSocket);
            }
        }

        private string HandleRequest(Dictionary<string, string> requestDictionary)
        {
            return "Request processed.";
        }

        //Method to deconnect 
        private void Deconnect(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
