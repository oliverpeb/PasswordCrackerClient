using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    private const string ServerAddress = "172.20.10.13";
    private const int ServerPort = 12345;

    public void SendFile(string filePath)
    {
        using (TcpClient client = new TcpClient(ServerAddress, ServerPort))
        using (NetworkStream stream = client.GetStream())
        {
            byte[] data = System.IO.File.ReadAllBytes(filePath);
            stream.Write(data, 0, data.Length);
            Console.WriteLine($"Sent file: {filePath}");
        }
    }

    public static void Main()
    {
        Client client = new Client();
        Console.WriteLine("Enter the path of the text file to send to the server:");
        string filePath = Console.ReadLine();
        client.SendFile(filePath);
    }
}
