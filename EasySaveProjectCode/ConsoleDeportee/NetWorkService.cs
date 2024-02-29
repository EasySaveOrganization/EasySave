using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace ConsoleDeportee
{
    public class NetWorkService
    {
        private readonly Socket _socket;
        private readonly IPEndPoint _endPoint;
        //queue for requests 
        private ConcurrentQueue<Message> _requestQueue = new ConcurrentQueue<Message>();
        //queue for responses 
        private ConcurrentQueue<Message> _responseQueue = new ConcurrentQueue<Message>();

        public NetWorkService()
        {
            //initialize the socket
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //initialize the endPoint
            _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090);
        }

        //This methos is to connect
        public void ConnectSocket()
        {
            _socket.Connect(_endPoint);
        }

        //this method is to send a request to the server 
        public async Task<Dictionary<string, string>> SendRequest(Dictionary<string, string> request)
        {
            //generate a unique id
            long requestId = new Random().Next();
            //creating a message
            var message = new Message(requestId, request);
            //serialize the message
            string serializedMessage = JsonConvert.SerializeObject(message);
            byte[] messageBuffer = Encoding.UTF8.GetBytes(serializedMessage);
            //Send a message
            await _socket.SendAsync(new ArraySegment<byte>(messageBuffer), SocketFlags.None);
            //Enqueue the request
            _requestQueue.Enqueue(message);

            // Await response
            var tcs = new TaskCompletionSource<Dictionary<string, string>>();
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int received = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    string receivedJson = Encoding.UTF8.GetString(buffer, 0, received);
                    //Deserialize the response received
                    Message responseMessage = JsonConvert.DeserializeObject<Message>(receivedJson);
                    //check if the request id and the response id matche
                    if (responseMessage.Id == requestId)
                    {
                        tcs.SetResult(responseMessage.Content);
                        break;
                    }
                    else
                    {
                        //if the id didn't match enque the response in the response queue
                        _responseQueue.Enqueue(responseMessage);
                    }
                }
            });

            return await tcs.Task;
        }

        //method to close the connection
        public void Close()
        {
            if (_socket.Connected)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
        }
    }
}