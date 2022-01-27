using CESI.CLI.VDM;
using FluentAssertions;
using HtmlAgilityPack;
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
		private Mock<IUrlDownloader> _downloader;
		private VieDeMerdeManager _manager;
		private string _expectedHtml;

		[TestInitialize]
		public void Init()
		{
			_expectedHtml = GetVieDeMerdeHomePage();
			_downloader = new Mock<IUrlDownloader>();
			_manager = new VieDeMerdeManager(_downloader.Object);
		}

		[TestMethod]
		public void ShouldDownloadLatestHtmlPage()
		{
			string html;

			_downloader.Setup(x => x.DownloadHtml(VIE_DE_MERDE_URL)).Returns(_expectedHtml);
			html = _manager.DownloadLatestHtmlPage();

			html.Should().Be(_expectedHtml);
		}

		[TestMethod]
		public void ShouldExtractVDMFromHtml()
		{
			IReadOnlyCollection<VieDeMerde> vdms = _manager.ExtractVDM(_expectedHtml);

			vdms.Should().HaveCount(34);
		}

		[TestMethod]
		public void ShouldExtractVDMTitle()
		{
			string html = GetData("viedemerde.html");
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			VieDeMerde vdm = VieDeMerde.Parse(doc.DocumentNode);

			vdm.Title.Should().Be("Pensée magique");
		}

		[TestMethod]
		public void ShouldExtractVDMContent()
		{
			string html = GetData("viedemerde.html");
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			VieDeMerde vdm = VieDeMerde.Parse(doc.DocumentNode);

			vdm.Content.Should().StartWith("Aujourd'hui, je suis garée mais toujours dans ma voiture quand un conducteur");
		}

		[TestMethod]
		public void ShouldExtractAuthor()
		{
			string html = GetData("viedemerde.html");
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			VieDeMerde vdm = VieDeMerde.Parse(doc.DocumentNode);

			vdm.Author.Should().Be("Anonyme");
		}

		private string GetVieDeMerdeHomePage()
		{
			return GetData("viedemerde_page.html");
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
