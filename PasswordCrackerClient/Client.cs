using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    private const string ServerAddress = "127.0.0.1";
    private const int ServerPort = 12345;

    public void SendMessage(string message)
    {
        using (TcpClient client = new TcpClient(ServerAddress, ServerPort))
        using (NetworkStream stream = client.GetStream())
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine($"Sent: {message}");
        }
    }

    public static void Main()
    {
        Client client = new Client();
        Console.WriteLine("Enter a message to send to the server:");
        string message = Console.ReadLine();
        client.SendMessage(message);
    }
}
