using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            MessageBox.Show("Connected", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            RequestQueue.Enqueue(message);

            //create a task completion to represent the asynchronous operation
            var tcs = new TaskCompletionSource<Dictionary<string, string>>();

            _ = Task.Run(() =>
            {
                while (true)
                {
                    if (ResponseQueue.TryDequeue(out var response))
                    {
                        if (response.Id == requestId)
                        {
                            tcs.SetResult(response.Content); 
                            return; 
                        }
                        else
                        {
                            ResponseQueue.Enqueue(response); 
                        }
                    }
                }
            });

            return await tcs.Task;  
        }
    }

}