using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionDiv : BaseOperationAction
	{
		public ActionDiv(TextWriter writer) : base(writer) { }

		public override string Name => "Div";

		public override string Description => "Multiplie 2 entiers";

		protected override int Compute(int number1, int number2)
		{
			return number1 / number2;
		}		
	}
}
