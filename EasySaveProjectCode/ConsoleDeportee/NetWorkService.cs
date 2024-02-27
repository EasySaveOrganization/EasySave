using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace ConsoleDeportee
{
    public class NetWorkService
    {
        //creating socket 
        private readonly Socket _socket;
        //EndPoint
        private readonly IPEndPoint _EndPoint;
        //concurrent queue for requests 
        ConcurrentQueue<Message> RequestQueue;
        //concurrent queue for answers 
        ConcurrentQueue<Message> ResponseQueue;

        public NetWorkService() 
        {
            //initialize socket
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Initialize endpoint
            _EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090);
            //Initialize the Request concurrent queue 
            RequestQueue = new ConcurrentQueue<Message>();
            //Initialize the answer concurrent queue
            ResponseQueue = new ConcurrentQueue<Message>();
        }
        public Socket ConnectSocket()
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
                MessageBox.Show("Closed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        public async Task<Dictionary<string, string>> SendRequest(Dictionary<string, string> request)
        {
            //generate a unique id 
            long requestId = new Random().Next(); 
            var message = new Message(requestId, request);
            //serialize the message to JSON string 
            string serializedMessage = JsonConvert.SerializeObject(message);
            // Convert JSON string to byte array
            byte[] messageBuffer = Encoding.UTF8.GetBytes(serializedMessage);
            // Send serialized message to server
            await _socket.SendAsync(new ArraySegment<byte>(messageBuffer), SocketFlags.None);

            RequestQueue.Enqueue(message);

            //create a task completion to represent the asynchronous operation
            var tcs = new TaskCompletionSource<Dictionary<string, string>>();

            _ = Task.Run(async() =>
            {
                while (true)
                {
                    // Buffer for incoming data
                    byte[] buffer = new byte[4096];
                    int received = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                    // Deserialize received message
                    string receivedJson = Encoding.UTF8.GetString(buffer, 0, received);
                    Message responseMessage = JsonConvert.DeserializeObject<Message>(receivedJson);

                    // Check if the received response matches the request ID
                    if (responseMessage.Id == requestId)
                    {
                        tcs.SetResult(responseMessage.Content);
                        break;
                    }
                    else
                    {
                        // If it's not the expected response, enqueue it for future processing
                        ResponseQueue.Enqueue(responseMessage);
                    }
                }
            });

            return await tcs.Task;  
        }
    }

}