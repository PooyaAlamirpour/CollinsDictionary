using CollinsDictionary.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollinsDictionary.Core
{
    public class Collins : CollinsDownloader
    {

        internal static string Search(string Word, int index = 0)
        {
            List<String> DefinitionList = new List<string>();
            String Definition = getDefinition(Word);
            if(!Definition.Contains("Sorry, no results for "))
            {
                DefinitionList = ClearDefinition(Definition);
            }
            else
            {
                DefinitionList = ClearResults(Definition);
            }
            return DefinitionList[index];
        }
    }
}
