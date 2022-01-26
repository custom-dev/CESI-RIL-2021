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
			_writer.WriteLine("Aide");
		}
	}
}
