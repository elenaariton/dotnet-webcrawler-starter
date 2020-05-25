using Buildit.Webcrawler.Business.Interfaces;
using Buildit.Webcrawler.Common;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Implementation
{
    public class HtmlParser : IHtmlParser
    {

        public async Task<List<KeyValuePair<int, List<string>>>> GetAllLinks(string pageUrl)
        {
            var web = new HtmlWeb();
            var document = new HtmlDocument();

            try
            {
                document = await web.LoadFromWebAsync(pageUrl);
            }
            catch (Exception)
            {
                return new List<KeyValuePair<int, List<string>>>();
            }

            var allLinks = new List<KeyValuePair<int, List<string>>>();

            var anchorElements = document.DocumentNode.SelectNodes("//a");

            allLinks.Add(new KeyValuePair<int, List<string>>(0, anchorElements
                        .Descendants("img")
                        .Select(a => a.GetAttributeValue("src", null))
                        .Where(item => !String.IsNullOrEmpty(item))
                        .Distinct()
                        .ToList()));

            allLinks.Add(new KeyValuePair<int, List<string>>(1, anchorElements.Select(a => a.GetAttributeValue("href", null))
            .Where(u => !String.IsNullOrEmpty(u)
                     && !u.StartsWith("#")
                     && !u.StartsWith("tel")
                     && !u.StartsWith("javascript")
                     && !u.EndsWith("/")
                     && !string.IsNullOrEmpty(UrlMatch.GetBaseUrl(u)))
            .Distinct()
            .ToList()));

            return allLinks;

        }

    }
}
