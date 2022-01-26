using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionHello : IAction
	{
		private TextWriter _writer;

		public ActionHello(TextWriter writer)
		{
			_writer = writer;
		}

		public string Name => "Hello";

		public string Description => "Affiche Hello World";

		public void Execute(string[] args)
		{
			_writer.WriteLine("Hello World !");
		}
	}
}
