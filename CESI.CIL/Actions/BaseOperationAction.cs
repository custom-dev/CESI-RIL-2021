using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public abstract class BaseOperationAction : IAction
	{
		private TextWriter _writer;

		public BaseOperationAction(TextWriter writer)
		{
			_writer = writer;
		}

		public abstract string Name { get; }

		public abstract string Description { get; }

		public void Execute(string[] args)
		{
			int number1 = int.Parse(args[1]);
			int number2 = int.Parse(args[2]);
			int result = this.Compute(number1, number2);

			_writer.WriteLine(result.ToString());
		}

		protected abstract int Compute(int number1, int number2);
	}
}
