﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CESI.CLI;
using System.IO;

namespace CESI.CLI_TEST
{
	[TestClass]
	public class ProgramTest
	{
		private TextWriter _writer;
		private Program _program;

		[TestInitialize]
		public void OnInit()
		{
			_writer = new StringWriter();
			_program = new Program(_writer);
		}

		[TestMethod]
		public void ShouldDisplayHelpWhenNoParameter()
		{
			_program.Execute(null);

			string sortie = _writer.ToString();

			sortie.Should().Contain("Aide");
		}

		[TestMethod]
		public void ShouldDisplayHelloWorldWhenCallingHello()
		{
			_program.Execute(new string[] { "Hello" });

			string sortie = _writer.ToString();

			sortie.Should().Contain("Hello World");
		}

		[TestMethod]
		public void ShouldDisplayCommandeInconnueWhenUnknownAction()
		{
			_program.Execute(new string[] { "slkdhvsidh" });

			string sortie = _writer.ToString();

			sortie.Should().Contain("Commande inconnue");
		}

		[TestMethod]
		public void ShouldAddNumbers()
		{
			_program.Execute(new string[] { "Add", "5", "10" });

			string sortie = _writer.ToString();

			sortie.Should().Be("15\r\n");
		}
	}
}
