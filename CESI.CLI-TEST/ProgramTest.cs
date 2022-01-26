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
		[TestMethod]
		public void ShouldDisplayHelpWhenNoParameter()
		{
			TextWriter writer = new StringWriter();
			Program program = new Program(writer);

			program.Execute(null);

			string sortie = writer.ToString();

			sortie.Should().Contain("Aide");
		}
	}
}
