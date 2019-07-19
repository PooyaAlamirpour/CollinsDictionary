using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollinsDictionary.Handler
{
    public class HtmlParser
    {
        public static List<String> ClearDefinition(String Definition)
        {
            List<String> retValue = new List<string>();
            Definition = RemoveString(Definition, "content definitions cobuild br\">");
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Definition);
            List<HtmlNode> htmlNodes = htmlDocument.DocumentNode.DescendantNodes().Where(x => x.Name.Equals("div", StringComparison.InvariantCultureIgnoreCase)).ToList();
            foreach (HtmlNode item in htmlNodes)
            {
                if(item.HasAttributes)
                {
                    if (item.Attributes["class"].Value == "hom")
                    {
                        retValue.Add(item.InnerText.Replace("\n", "\r\n"));
                    }
                }
            }

            return retValue;
        }

        public static List<String> ClearResults(String Result)
        {
            List<String> retValue = new List<string>();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Result);
            List<HtmlNode> htmlNodes = htmlDocument.DocumentNode.DescendantNodes().Where(x => x.Name.Equals("div", StringComparison.InvariantCultureIgnoreCase)).ToList();
            foreach (HtmlNode item in htmlNodes)
            {
                if (item.HasAttributes)
                {
                    if (item.Attributes["class"].Value == "res_cell_center")
                    {
                        retValue.Add(ClearExtra(item.InnerText));
                    }
                }
            }
            return retValue;
        }

        private static String RemoveString(String Main, String Word)
        {
            return Main.Replace(Word, "");
        }

        private static String ClearExtra(String input)
        {
            input = input.Replace("\n", "\r\n");
            input = input.Replace("\r\n\r\n", "\r\n");
            return input;
        }
    }
}
