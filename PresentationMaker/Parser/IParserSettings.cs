using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationMaker.Parser
{
    public interface IParserSettings
    {
        public string MainUrl { get; set; }
        public string Prefix { get; set; }
        public List<String> Word { get; set; }
    }
}
