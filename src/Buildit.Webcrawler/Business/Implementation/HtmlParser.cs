using Buildit.Webcrawler.Business.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buildit.Webcrawler.Business.Implementation
{
    public class HtmlParser : IHtmlParser
    {
        public List<string> GetAllLinks(string pageUrl, string baseUrl)
        {
            var web = new HtmlWeb();
            var document = web.Load(pageUrl);

            return document.DocumentNode.Descendants("a")
                                              .Select(a => a.GetAttributeValue("href", null))
                                              .Where(u => !String.IsNullOrEmpty(u)
                                                          && !u.StartsWith("#")
                                                          && !u.StartsWith("tel")
                                                          && !u.StartsWith("javascript")
                                                          && u.Contains(baseUrl))
                                              .ToList();
        }
    }
}
