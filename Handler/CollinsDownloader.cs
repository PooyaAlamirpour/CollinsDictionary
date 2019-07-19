using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CollinsDictionary.Handler
{
    public class CollinsDownloader : HtmlParser
    {
        private const String _CollinsURL = "https://www.collinsdictionary.com/dictionary/english/";

        public static String getDefinition(String Word)
        {
            string html;
            using (var client = new WebClient())
            {
                try
                {
                    html = client.DownloadString(_CollinsURL + Word);
                }
                catch (Exception ex)
                {
                    html = ex.Message;
                }
            }
            int indexOfDefinition = html.IndexOf("content definitions cobuild br");
            if(indexOfDefinition != -1)
            {
                int indexOfCopyright = html.IndexOf("COBUILD Advanced English Dictionary");
                html = html.Substring(indexOfDefinition, indexOfCopyright - indexOfDefinition);
            }
            else
            {
                int indexOfResult = html.IndexOf("spellcheck_wrapper");
                int indexOfEndResult = html.IndexOf("res_cell_right");
                html = html.Substring(indexOfResult, indexOfEndResult - indexOfResult);
            }
            
            return html;
        }
    }
}
