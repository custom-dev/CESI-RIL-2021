using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionAdd : BaseOperationAction
	{
		public ActionAdd(TextWriter writer): base(writer) { }

		public override string Name => "Add";

		public override string Description => "Ajoute deux entiers";

		protected override int Compute(int number1, int number2)
		{
			return number1 + number2;
		}
	}
}
