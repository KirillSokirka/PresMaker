using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;

namespace PresentationMaker.Parser
{
    class SlovnykParser : IParser<List<string>>
    {
        public List<string> Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("td")
                .Where(item => item.ClassName == null);
            
            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list;
        }
    }
}
