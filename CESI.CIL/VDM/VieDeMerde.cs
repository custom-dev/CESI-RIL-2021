using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CESI.CLI.VDM
{
	public class VieDeMerde
	{
		private static readonly Regex _regexAuteur = new Regex(@"Par ([^\s]*)\s*-.*");

		public static VieDeMerde Parse(HtmlNode node)
		{
			VieDeMerde vdm = new VieDeMerde();

			vdm.ExtractTitle(node);
			vdm.ExtractContent(node);
			vdm.ExtractAuthor(node);
			vdm.ExtractVotes(node);
			return vdm;
		}

		public string Title { get; private set; }
		public string Content { get;private set; }
		public string Author { get; private set; }
		public int VDM { get;private set; }
		public int TLBM { get;private set; }

		private void ExtractTitle(HtmlNode node)
		{
			HtmlNode titleNode = node.SelectSingleNode(".//h2/a");
			this.Title = titleNode.InnerText;
		}

		private void ExtractContent(HtmlNode node)
		{
			HtmlNode contentNode = node.SelectSingleNode("./article/a");
			this.Content = HttpUtility.HtmlDecode(contentNode.InnerText).Trim();
		}

		private void ExtractAuthor(HtmlNode node)
		{
			HtmlNode authorNode = node.SelectSingleNode("./article/div/div/div/p");
			Match match = _regexAuteur.Match(authorNode.InnerText);

			if (match.Success)
			{
				this.Author = match.Groups[1].Value;
			}
			else
			{
				this.Author = String.Empty;
			}
		}

		private void ExtractVotes(HtmlNode node)
		{
			HtmlNodeCollection votes = node.SelectNodes("./article/div/div/span[contains(@class, 'vote-btn-count')]");
			HtmlNode voteVDM = votes[0];
			HtmlNode voteTLBM = votes[1];
			this.VDM = int.Parse(voteVDM.InnerText);
			this.TLBM = int.Parse(voteTLBM.InnerText);
		}
	}
}
