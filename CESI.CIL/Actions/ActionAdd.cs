using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionAdd : IAction
	{
		private TextWriter _writer;

		public ActionAdd(TextWriter writer)
		{
			_writer = writer;
		}

		public string Name => "Add";

		public string Description => "Ajoute deux entiers";

		public void Execute(string[] args)
		{
			int number1 = int.Parse(args[1]);
			int number2 = int.Parse(args[2]);
			int result = number1 + number2;

			_writer.WriteLine(result.ToString());
		}
	}
}
