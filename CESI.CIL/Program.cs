using CESI.CLI.Actions;
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
			string actionName = ExtractActionName(args);
			
			switch(actionName)
			{
				case "":
					DisplayHelp();
					break;
				case "Hello":
					ActionHello();
					break;
				case "Add":
					ActionAdd(args);
					break;
				case "Sub":
					ActionSub(args);
					break;
				default:
					ActionUnknown();
					break;
			}										
		}

		private void ActionUnknown()
		{
			_writer.WriteLine("Commande inconnue");
		}

		private void ActionHello()
		{
			ActionHello action = new ActionHello(_writer);
			action.Execute(null);
		}

		private void DisplayHelp()
		{
			_writer.WriteLine("Aide");
			_writer.WriteLine("Ensemble des commandes disponibles :");
			_writer.WriteLine("- Hello");
			_writer.WriteLine("- Add");
			_writer.WriteLine("- Sub");

		}

		private static string ExtractActionName(string[] args)
		{
			return (args != null && args.Length > 0) ? args[0] : String.Empty;
		}

		private void ActionAdd(string[] args)
		{
			ActionAdd action = new ActionAdd(_writer);
			action.Execute(args);
		}

		private void ActionSub(string[] args)
		{
			ActionSub action = new ActionSub(_writer);
			action.Execute(args);
		}
	}
}
