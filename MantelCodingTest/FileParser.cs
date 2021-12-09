using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MantelCodingTest
{
    class FileParser
    {
        private List<string> _ipAddresses;
        private List<string> _urls;
        private Dictionary<string, int> _mostVisitedUrls;
        private Dictionary<string, int> _mostActiveIps;

        private const string _ipRegEx = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

        public List<string> IpAddresses { get => _ipAddresses; set => _ipAddresses = value; }
        public List<string> Urls { get => _urls; set => _urls = value; }
        public Dictionary<string, int> MostVisitedUrls { get => _mostVisitedUrls; set => _mostVisitedUrls = value; }
        public Dictionary<string, int> MostActiveIps { get => _mostActiveIps; set => _mostActiveIps = value; }

        public FileParser()
        {
            IpAddresses = new List<string>();
            Urls = new List<string>();
            MostVisitedUrls = new Dictionary<string, int>();
            MostActiveIps = new Dictionary<string, int>();
        }

        public int NumberOfUniqueIps()
        {
            return IpAddresses.Distinct().Count(); ;
        }

        public void PopulateIps(string[] lines)
        {
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, _ipRegEx);

                if (match.Success)
                {
                    IpAddresses.Add(match.Value);
                }
            }
        }

        public void PopulateUrls(string[] lines)
        {
            foreach (string line in lines)
            {
                int startOfUrl = line.LastIndexOf("GET") + "GET".Length + 1; // + 1 for the whitespace in the data log file
                int endOfUrl = line.IndexOf("HTTP");
                int lengthOfUrl = endOfUrl - startOfUrl;

                Urls.Add(line.Substring(startOfUrl, lengthOfUrl));
            }
        }

        public void CountListItemsOccurrences(Dictionary<string, int> dictOccurrences, List<string> stringList)
        {
            foreach (string value in stringList)
            {
                if (dictOccurrences.TryGetValue(value, out int count))
                {
                    dictOccurrences[value] = count + 1;
                }
                else
                {
                    dictOccurrences.Add(value, 1);
                }
            }
        }

        public void GetTopItemsFromDict(int index, Dictionary<string, int> dict)
        {
            if (index > dict.Count)
            {
                throw new ArgumentException("Index value out of range.");
            }
            else
            {
                var sorted = from pair in dict orderby pair.Value descending select pair;

                foreach (var pair in sorted.Take(index))
                {
                    Console.WriteLine($"{pair.Key} = {pair.Value} occurrences");
                }
            }
        }
    }
}
