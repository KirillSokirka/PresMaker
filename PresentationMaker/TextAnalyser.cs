using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PresentationMaker
{
    public class TextAnalyser
    {
        public List<string> Analyse(string file, string words)
        {
            string text = ReadFile(file);
            var sentances = SplitIntoSentances(text);
            var keyWords = SplitIntoWords(words);
            var resultSentances = GetResultSentances(sentances.ToList(), keyWords);
            return resultSentances;
        }
        private static string ReadFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            var text = reader.ReadToEnd();
            return text;
        }
        private static string[] SplitIntoSentances(string text)
        {
            var sentances = Regex.Split(text, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < sentances.Length; i++)
            {
                sentances[i] = sentances[i].Trim();
                sentances[i] = Regex.Replace(sentances[i], @"\s+", " ");
            }
            return sentances;
        }    
        private static List<string> SplitIntoWords(string text)
        {
            text = Regex.Replace(text, @"\s+", "");
            var words = text.Split(",");
            return words.Where(word => !String.IsNullOrEmpty(word)).ToList();
        }
        private static List<string> GetResultSentances(List<string> sentances, List<string> keyWords)
        {
            var keySentances = new List<string>();
            foreach (var sentance in sentances)
            {
                if (CheckForKeyWords(sentance, keyWords))
                    keySentances.Add(sentance);
            }
            return keySentances;
        }
        private static bool CheckForKeyWords(string sentance, List<string> keyWords)
        {
            foreach (var word in keyWords)
            {
                if (sentance.ToLower().Contains(word.ToLower()))
                    return true;
            }
            return false;
        }
    }
}
