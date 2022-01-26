using FluentAssertions;
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
	}
}
