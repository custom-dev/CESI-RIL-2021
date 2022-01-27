using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.VDM
{
	public class VieDeMerdeManager
	{
		private static readonly string VIE_DE_MERDE_URL = "https://www.viedemerde.fr/";

		private IUrlDownloader _downloader;

		public VieDeMerdeManager(IUrlDownloader downloader)
		{
			_downloader = downloader;
		}

		public string DownloadLatestHtmlPage()
		{
			return _downloader.DownloadHtml(VIE_DE_MERDE_URL);
		}

		public IReadOnlyCollection<VieDeMerde> ExtractVDM(string html)
		{
			HtmlDocument doc = new HtmlDocument();
			HtmlNodeCollection articles;

			doc.LoadHtml(html);
			articles = doc.DocumentNode.SelectNodes("//article");
			return articles.Select(x => new VieDeMerde()).ToArray();
		}
	}
}
