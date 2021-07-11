using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMaker.Parser
{
    public class SlovnykSettings : IParserSettings
    {
        public string MainUrl { get; set; } = "https://slovnyk.ua/";
        public string Prefix { get; set; } = "index.php?swrd=";
        public List<string> Word { get; set; }
    }
}
