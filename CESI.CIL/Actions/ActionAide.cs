using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.Actions
{
	public class ActionAide : IAction
	{
		private TextWriter _writer;

		public ActionAide(TextWriter writer)
		{
			_writer = writer;
		}

		public string Name => "Aide";

		public string Description => "Affiche l'aide";

		public void Execute(string[] args)
		{
			_writer.WriteLine("Aide");
			_writer.WriteLine("Ensemble des commandes disponibles :");
			_writer.WriteLine("- Hello");
			_writer.WriteLine("- Add");
			_writer.WriteLine("- Sub");
		}
	}
}
