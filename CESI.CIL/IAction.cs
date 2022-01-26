using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI
{
	public interface IAction
	{
		string Name { get; }
		string Description { get; }
		void Execute(string[] args);
	}
}
