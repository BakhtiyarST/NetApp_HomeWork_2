using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp2
{
	internal class Server
	{
		public static void AcceptMsg()
		{
			bool flagContinue;
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
			UdpClient udpClient = new UdpClient(12345);
			flagContinue = true;
			while(flagContinue)
			{
				byte[] buffer = udpClient.Receive(ref endPoint);
				string data = Encoding.UTF8.GetString(buffer);

				new Thread(() =>
				{
					Message msg = Message.FromJson(data);
					Console.WriteLine(msg.ToString());
					string text = msg.Text;
					if ((text == "Exit")||(text=="exit"))
					{
						flagContinue = false;
						Console.WriteLine("The server is exiting...");
					}
					else
					{
						Message msgResponse = new Message("Server", "Message accepted on server side");
						string msgResponseJson = msgResponse.ToJson();
						byte[] dataResponse = Encoding.UTF8.GetBytes(msgResponseJson);
						udpClient.Send(dataResponse, endPoint);
					}
				}).Start();
			}
			if (!flagContinue)
				Console.WriteLine("Server: \"Bye bye\"");
		}
	}
}
