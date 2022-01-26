using System;
using System.IO;

namespace CESI.CLI
{
	public class Program
	{
		private TextWriter _writer;

		public Program(TextWriter writer)
		{
			_writer = writer;
		}

		static void Main(string[] args)
		{
			Program program = new Program(Console.Out);
			program.Execute(args);
		}

		public void Execute(string[] args)
		{
			string actionName = ExtractActionName(args);

			if (actionName == "Hello")
			{
				_writer.WriteLine("Hello World !");
			}
			else
			{
				_writer.WriteLine("Aide");
			}
		}

		private static string ExtractActionName(string[] args)
		{
			return (args != null && args.Length > 0) ? args[0] : String.Empty;
		}
	}
}
