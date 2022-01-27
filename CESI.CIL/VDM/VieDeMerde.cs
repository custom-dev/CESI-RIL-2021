using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CESI.CLI.VDM
{
	public class VieDeMerde
	{

		public static VieDeMerde Parse(HtmlNode node)
		{
			VieDeMerde vdm = new VieDeMerde();
			HtmlNode titleNode = node.SelectSingleNode(".//h2/a");
			HtmlNode contentNode = node.SelectSingleNode("./article/a");

			vdm.Title = titleNode.InnerText;
			vdm.Content = HttpUtility.HtmlDecode(contentNode.InnerText).Trim();
			return vdm;
		}

		public string Title { get; private set; }
		public string Content { get;private set; }
	}
}
