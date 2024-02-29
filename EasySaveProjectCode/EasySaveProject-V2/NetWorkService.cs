using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ExecuteFolder;
using Newtonsoft.Json;

namespace EasySaveProject_V2
{
    public class NetWorkService
    {
        private readonly Socket _serverSocket;
        private readonly IPEndPoint _serverEndPoint;

        public NetWorkService()
        {
            //initialize the socket
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //initialize the endpoint
            _serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8090);
            _serverSocket.Bind(_serverEndPoint);
            _serverSocket.Listen(100);
        }

        //method to listen to the client
        public void StartListening()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    //accept connection
                    Socket clientSocket = _serverSocket.Accept();
                    MessageBox.Show("Connected", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //if a request is made handle it
                    Task.Run(() => HandleRequest(clientSocket));
                }
            });
        }

        //method to handle requests received from the client
        private async void HandleRequest(Socket clientSocket)
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                //Receive message
                int bytesReceived = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                if (bytesReceived == 0) // Check if connection is closed by client
                {
                    break; // Exit loop if client closes the connection
                }
                string receivedText = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                //deserialize the message
                Message requestMessage = JsonConvert.DeserializeObject<Message>(receivedText);

                //try to get the value type so we know which action to do
                requestMessage.Content.TryGetValue("type", out string requestType);

                string responseMessage;
                int responseStatus;
                Dictionary<string, string> responseContent = new Dictionary<string, string>();

                //treat the request according to the action needed
                switch (requestType)
                {
                    case "createBackup":
                        // Extract the fields from the request message
                        string name = requestMessage.Content["name"];
                        string target = requestMessage.Content["target"];
                        string source = requestMessage.Content["source"];
                        string type = requestMessage.Content["BackupType"];
                        string extensionFileToCrypt = requestMessage.Content["extensionFileToCrypt"];
                        //convert the log fromat into a string
                        int logsFormat = int.Parse(requestMessage.Content["logsFormat"]);

                        // add the work
                        SaveWorkViewModel saveWorkViewModel = new SaveWorkViewModel();
                        saveWorkViewModel.AddWork(name, target, source, type, extensionFileToCrypt, logsFormat);

                        responseMessage = "Backup creation completed successfully.";
                        responseStatus = 200; // OK status code
                        break;
                    case "executeBackup":
                        //deserialize the data 
                        string workDataJson = requestMessage.Content["Data"];
                        var workToExecute = JsonConvert.DeserializeObject<SaveWorkModel>(workDataJson);

                        ExecuteWorkService executeWorkService = new ExecuteWorkService();
                        executeWorkService.executeWork(workToExecute);
                        responseMessage = "Backup execution completed successfully.";
                        responseStatus = 200; // OK status code
                        break;
                    case "obtainBackupList":
                        try
                        {
                            WorkListService workListService = new WorkListService();
                            List<SaveWorkModel> worksList = workListService.LoadWorkListFromFile();
                            if (worksList != null)
                            {
                                responseMessage = JsonConvert.SerializeObject(worksList);
                                responseStatus = 200; // OK status code
                            }
                            else
                            {
                                responseMessage = "No backup list found.";
                                responseStatus = 404; // Not Found status code
                            }
                        }
                        catch (Exception ex)
                        {
                            responseMessage = $"Error loading backup list: {ex.Message}";
                            responseStatus = 500; // Internal Server Error
                        }
                        break;
                    default:
                        responseMessage = "Invalid request type.";
                        responseStatus = 400; // Bad Request status code
                        break;
                }


                //add the response content to the response
                responseContent.Add("response", responseMessage);
                var response = new Message(requestMessage.Id, responseContent, responseStatus);
                string serializedResponse = JsonConvert.SerializeObject(response);

                byte[] responseBuffer = Encoding.UTF8.GetBytes(serializedResponse);
                //send the message
                await clientSocket.SendAsync(new ArraySegment<byte>(responseBuffer), SocketFlags.None);
            }
        }
    }
}