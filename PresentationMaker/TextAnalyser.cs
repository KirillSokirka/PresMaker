using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PresentationMaker.Parser;

namespace PresentationMaker
{
    public class TextAnalyser<T> where T: class
    {
        private IParser<List<string>> parser;
        private IParserSettings slovnykSettings;
        public TextAnalyser(IParser<List<string>> parser, IParserSettings settings)
        {
            this.parser = parser;
            this.slovnykSettings = settings;
        }
        public async Task<string[]> Analyse(string file, string words)
        {
            string text = ReadFile(file);
            var sentances = SplitIntoSentances(text);
            List<string> keyWords = SplitIntoWords(words);
            slovnykSettings.Word = keyWords;
            var parserWorker = new ParserWorker<List<string>>(parser, slovnykSettings);
            var keyWordsForms =  await parserWorker.Work();
            List<string> resultSentances = GetResultSentances(sentances, keyWords.Concat(keyWordsForms));
            return resultSentances.ToArray();
        }
        private static string ReadFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            string text = reader.ReadToEnd();
            return text;
        }
        private static List<string> SplitIntoSentances(string text)
        {
            string[] sentances = Regex.Split(text, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < sentances.Length; i++)
            {
                if (sentances[i] == null)
                    continue;
                if (i+1 != sentances.Length)
                {
                    if (char.IsLower(sentances[i + 1][0]))
                    {
                        sentances[i] += " " + sentances[i + 1];
                        sentances[i + 1] = null;
                    }                       
                }
                sentances[i] = sentances[i].Trim();
                sentances[i] = Regex.Replace(sentances[i], @"\s+", " ");
            }
            var sentancesList = new List<string>();
            foreach (var sentance in sentances)
            {
                if (sentance == null)
                    continue;
                sentancesList.Add(sentance);
            }
            return sentancesList;
        }
        private static List<string> SplitIntoWords(string text)
        {
            text = Regex.Replace(text, @"\s+", "");
            string[] words = text.Split(",");
            return words.Where(word => !string.IsNullOrEmpty(word)).ToList();
        }
        private static List<string> GetResultSentances(IEnumerable<string> sentances, IEnumerable<string> keyWords)
        {
            List<string> keySentances = new List<string>();
            foreach (string sentance in sentances)
            {
                if (CheckForKeyWords(sentance, keyWords))
                {
                    keySentances.Add(sentance);
                }
            }
            return keySentances;
        }
        private static bool CheckForKeyWords(string sentance, IEnumerable<string> keyWords)
        {
            foreach (string word in keyWords)
            {
                if (sentance.ToLower().Contains(word.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
