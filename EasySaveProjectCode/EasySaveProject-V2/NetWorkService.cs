using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.AddWork;

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

        public Socket ConnectServer()
        {
            _ServerSocket.Bind(_ServerEndPoint);
            _ServerSocket.Listen(100);
            return _ServerSocket;
        }

        //method to accept the connexion
        public Socket AcceptConnexion(Socket socket)
        {
            var handler = socket.Accept();
            return handler;
        }

        public async void HandleRequest(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[2048];
                int bytesReceived = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                // Deserialize into Message object
                Message requestMessage = JsonSerializer.Deserialize<Message>(receivedText);

                // Check if the message is valid
                if (requestMessage != null && requestMessage.Content != null)
                {
                    // Assuming 'requestType' is the key in the Content dictionary that holds the type of request
                    string requestType = requestMessage.Content.TryGetValue("requestType", out var typeValue) ? typeValue : null;

                    string responseType = "response";
                    string responseMessage = "";
                    int responseStatus = 200; // OK status code, change as per your application's protocol

                    if (!string.IsNullOrEmpty(requestType))
                    {
                        switch (requestType)
                        {
                            case "createBackup":
                                // Handle createBackup
                                // ...
                                break;
                            case "executeBackup":
                                // Handle executeBackup
                                // ...
                                break;
                            case "obtainBackupList":
                                // Handle obtainBackupList
                                WorkListService workListService = new WorkListService();
                                List<SaveWorkModel> worksList = workListService.LoadWorkListFromFile();
                                if (worksList != null)
                                {
                                    // Serialize the list to JSON
                                    responseMessage = JsonSerializer.Serialize(worksList);
                                    responseStatus = 200; // OK status code
                                }
                                else
                                {
                                    responseType = "error";
                                    responseMessage = "Failed to load backup list.";
                                    responseStatus = 500; // Internal Server Error status code
                                }
                                break;
                            default:
                                responseType = "error";
                                responseMessage = "Invalid request type.";
                                responseStatus = 400; // Bad Request status code
                                break;
                        }
                    }
                    else
                    {
                        responseType = "error";
                        responseMessage = "Request type not specified.";
                        responseStatus = 400; // Bad Request status code
                    }

                    // Create a response message
                    var responseContent = new Dictionary<string, string>
            {
                { "type", responseType },
                { "message", responseMessage }
            };
                    Message responseMessageObject = new Message(requestMessage.Id, responseContent, responseStatus);

                    string jsonResponse = JsonSerializer.Serialize(responseMessageObject);
                    byte[] byteData = Encoding.UTF8.GetBytes(jsonResponse);

                    // Send response back to client
                    await clientSocket.SendAsync(new ArraySegment<byte>(byteData), SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        //Method to disconnect 
        public void Disconnect(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void StartListening()
        {
            Task.Run(() => // Run server logic on a background thread
            {
                _ServerSocket.Bind(_ServerEndPoint);
                _ServerSocket.Listen(100); // Listen for at least one connection

                try
                {
                    var handler = _ServerSocket.Accept(); // Accept a connection

                        MessageBox.Show("Connection has been made.", "Connection Established", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                catch (Exception ex)
                {
                        MessageBox.Show($"Error accepting connection: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                   
                }
            });
        }

    }
}
