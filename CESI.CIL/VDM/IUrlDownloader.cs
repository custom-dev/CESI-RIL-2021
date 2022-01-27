using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESI.CLI.VDM
{
	public interface IUrlDownloader
	{
		string DownloadHtml(string url);
	}
}
