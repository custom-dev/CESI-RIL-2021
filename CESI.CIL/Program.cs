using CESI.CLI.Actions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

			if (String.IsNullOrEmpty(actionName))
			{
				ActionAide action = new ActionAide(_writer);
				action.Execute(null);
			}

			Dictionary<string, IAction> actions = GetActions();

			if (actions.ContainsKey(actionName))
			{
				actions[actionName].Execute(args);
			}
			else
			{
				ActionUnknown();
			}			
		}

		private void ActionUnknown()
		{
			_writer.WriteLine("Commande inconnue");
		}

		private static string ExtractActionName(string[] args)
		{
			return (args != null && args.Length > 0) ? args[0] : String.Empty;
		}

		private Dictionary<string, IAction> GetActions()
		{
			Dictionary<string, IAction> actions = new Dictionary<string, IAction>();
		 	Assembly assembly = Assembly.GetExecutingAssembly();
			IEnumerable<Type> actionTypes = assembly
				.GetTypes()
				.Where(x => x.IsClass && !x.IsAbstract && typeof(IAction).IsAssignableFrom(x));
			ServiceCollection collection = new ServiceCollection();
			collection.AddSingleton(typeof(TextWriter), _writer);

			IServiceProvider services = collection.BuildServiceProvider();

			foreach(Type actionType in actionTypes)
			{
				IAction action = ActivatorUtilities.CreateInstance(services, actionType) as IAction;
				actions.Add(action.Name, action);
			}
			
			return actions;
		}
	}
}
