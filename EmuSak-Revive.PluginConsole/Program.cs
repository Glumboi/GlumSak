using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace EmuSak_Revive.PluginConsole
{
    internal class Program
    {
        private static NamedPipeServerStream server;
        
        public static void Main(string[] args)
        {
            InitServer();
        }

        private static void WarnOnServer(string msg)
        {
            PrintOnServer("WARNING", msg, ConsoleColor.Yellow, ConsoleColor.White);
        }        
        
        private static void ErrorOnServer(string msg)
        {
            PrintOnServer("ERROR", msg, ConsoleColor.Red, ConsoleColor.White);
        }        
        
        private static void TraceOnServer(string msg)
        {
            PrintOnServer("INFO", msg, ConsoleColor.Cyan, ConsoleColor.White);
        }
        
        private static void PrintOnServer(string type, string msg, ConsoleColor foreColor1, ConsoleColor foreColor2)
        {
            Console.ForegroundColor = foreColor1;
            Console.Write(DateTime.Now.ToString("g") + " "  + $"[{type}]: ");
            Console.ForegroundColor = foreColor2;
            Console.Write(msg + Environment.NewLine);
        }

private static void InitServer()
{
    // Create a new named pipe server
    server = new NamedPipeServerStream("GlumSakConsolePipe", PipeDirection.InOut);

    while (true)
    {
        try
        {
            // Wait for a client to connect
            server.WaitForConnection();

            TraceOnServer("Client connected!");

            // Start a new thread to handle the client
            Task.Run(() =>
            {
                try
                {
                    // Read data from the client
                    StreamReader reader = new StreamReader(server);
                    string data;

                    while ((data = reader.ReadLine()) != null)
                    {
                        string type = data.Substring(0, data.IndexOf(']') + 1);
                        int clientNameIndex = data.IndexOf(':', data.IndexOf(']') + 1);
                        string clientName = data.Substring(data.IndexOf(']') + 2, clientNameIndex - data.IndexOf(']') - 2);
                        string message = data.Substring(clientNameIndex + 2);

                        // Check type of message
                        switch (type)
                        {
                            case "[ERROR]":
                                ErrorOnServer($"[{clientName}]: " + message);
                                break;
                            case "[WARNING]":
                                WarnOnServer($"[{clientName}]: " + message);
                                break;
                            case "[INFO]":
                                TraceOnServer($"[{clientName}]: " + message);
                                break;
                        }
                    }
                }
                catch (IOException ex)
                {
                    // Handle the exception if the client disconnects unexpectedly
                    WarnOnServer($"Client disconnected unexpectedly: {ex.Message}");
                }
                finally
                {
                    // Disconnect from the client
                    server.Disconnect();
                    TraceOnServer("Client disconnected.");
                }
            });
        }
        catch (IOException ex)
        {
            // Handle the exception if the server fails to start
            ErrorOnServer($"Server failed to start: {ex.Message}");
            return;
        }
    }
}

    }
}