namespace ChatApp2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Server.AcceptMsg();
			}
			else if (args.Length == 1)
			{
				bool flagContinue = true;
				int count = 0;
				while (true)
				{
					count++;
					string text = Console.ReadLine();
					Client.SendMsg($"{args[0]} {count}", text);
					if ((text == "Exit") || (text == "exit"))
					{
						Console.WriteLine("The client is exiting...");
						return;
					}
				}
			}
		}
	}
}
