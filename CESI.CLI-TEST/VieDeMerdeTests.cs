using CESI.CLI.VDM;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CESI.CLI_TEST
{
	[TestClass]
	public class VieDeMerdeTests
	{
		private static string VIE_DE_MERDE_URL = "https://www.viedemerde.fr/";

		[TestMethod]
		public void ShouldDownloadLatestHtmlPage()
		{
			string expectedHtml = GetData("viedemerde.html");
			Mock<IUrlDownloader> downloader = new Mock<IUrlDownloader>();
			VieDeMerdeManager vdm;

			downloader.Setup(x => x.DownloadHtml(VIE_DE_MERDE_URL)).Returns(expectedHtml);
			vdm = new VieDeMerdeManager(downloader.Object);

			string html = vdm.DownloadLatestHtmlPage();

			html.Should().Be(expectedHtml);
		}

		[TestMethod]
		public void ShouldExtractVDMFromHtml()
		{
			string html = GetData("viedemerde.html");
			Mock<IUrlDownloader> downloader = new Mock<IUrlDownloader>();
			VieDeMerdeManager vdm = new VieDeMerdeManager(downloader.Object);

			IReadOnlyCollection<VieDeMerde> vdms = vdm.ExtractVDM(html);

			vdms.Should().HaveCount(34);
		}

		private string GetData(string manifestName)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			using (Stream data = assembly.GetManifestResourceStream($"CESI.CLI_TEST.Data.{manifestName}"))
			using (StreamReader reader = new StreamReader(data))
			{
				string content = reader.ReadToEnd();
				return content;
			}
		}
	}
}
