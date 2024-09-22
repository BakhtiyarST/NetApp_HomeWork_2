using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatApp2
{
	internal class Client
	{
		public static void SendMsg(string name, string msgStr)
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
			UdpClient client = new UdpClient();
			Message msg = new Message(name, msgStr);
			string msgJ = msg.ToJson();
			byte[] bytes= Encoding.UTF8.GetBytes(msgJ);
			client.Send(bytes,endPoint);

			byte[] bytesR = client.Receive(ref endPoint);
			string msgRJ=Encoding.UTF8.GetString(bytesR);
			Message msgR=Message.FromJson(msgRJ);
			Console.WriteLine(msgR.ToString());

		}
		


	}
}
