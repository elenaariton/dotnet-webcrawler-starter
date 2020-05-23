using Buildit.Webcrawler.Business.Interfaces;
using Buildit.Webcrawler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Implementation
{
    public class Crawler : ICrawler
    {
        private IHtmlParser _htmlParser;
        public Crawler(IHtmlParser htmlParser)
        {
            _htmlParser = htmlParser;
        }
        public CrawlerData GetCrawlerData(string url)
        {
            var baseUrl = GetBaseUrl(url);
            var baseLinks = _htmlParser.GetAllLinks(url,baseUrl);

            baseLinks.RemoveAll(item => item.StartsWith("#"));
                                 
            return new CrawlerData();
        }

        private static string GetBaseUrl(string url)
        {
            var regexPattern = "^[^\\/]+:\\/\\/[^\\/]*?\\.?([^\\/.]+)\\.[^\\/.]+(?::\\d+)?\\/";

            return Regex.Match(url, regexPattern).ToString();
        }
    }
}
