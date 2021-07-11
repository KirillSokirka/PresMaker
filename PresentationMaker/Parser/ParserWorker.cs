using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace PresentationMaker.Parser
{
    class ParserWorker<T> where T : class
    {
        private IParser<T> parser;
        private IParserSettings parserSettings;

        private HtmlLoader loader;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            parserSettings = settings;
            loader = new HtmlLoader(settings);
        }
        public async Task<List<string>> Work()
        {
            List<string> words = new List<string>();
            foreach (var word in parserSettings.Word)
            {
                var source = await loader.GetSourceByWord(word);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);
                words.Add(parser.Parse(document).ToString());
            }
            return words;
        }
    }
}
