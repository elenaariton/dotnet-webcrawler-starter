using Buildit.Webcrawler.Business.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buildit.Webcrawler.Business.Implementation
{
    public class HtmlParser : IHtmlParser
    {
        public List<string> GetAllLinks(string testPageHtml)
        {
            var document = new HtmlDocument();
            document.LoadHtml(testPageHtml);

            return document.DocumentNode.Descendants("a")
                                              .Select(a => a.GetAttributeValue("href", null))
                                              .Where(u => !String.IsNullOrEmpty(u))
                                              .ToList();
        }
    }
}
