using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionSub : BaseOperationAction
	{
		public ActionSub(TextWriter writer) : base(writer) { }
		
		public override string Name => "Sub";

		public override string Description => "Soustrait deux entiers";

		protected override int Compute(int number1, int number2)
		{
			return number1 - number2;
		}		
	}
}
