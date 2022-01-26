using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionMul : IAction
	{
		private TextWriter _writer;

		public ActionMul(TextWriter writer)
		{
			_writer = writer;
		}

		public string Name => "Mul";

		public string Description => "Multiplie 2 entiers";

		public void Execute(string[] args)
		{
			int number1 = int.Parse(args[1]);
			int number2 = int.Parse(args[2]);
			int result = number1 * number2;

			_writer.WriteLine(result.ToString());
		}
	}
}
