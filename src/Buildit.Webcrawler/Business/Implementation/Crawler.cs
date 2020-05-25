using Buildit.Webcrawler.Business.Interfaces;
using Buildit.Webcrawler.Business.Models;
using Buildit.Webcrawler.Common;
using System;
using System.Collections.Generic;
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

        public async Task<CrawlerData> GetCrawlerData(string url)
        {
            var baseUrl = UrlMatch.GetBaseUrl(url);
            var baseLinks = new List<string>();
            var imageLinks = new List<string>();

            var allLinks = await _htmlParser.GetAllLinks(baseUrl);
            if(allLinks.Count > 0)
            {
                baseLinks = allLinks[1].Value;
                imageLinks = allLinks[0].Value;
            }

            var firstInternalLinks = baseLinks.FindAll(item => item.Contains(baseUrl));

            Stack<string> linksToProcess = new Stack<string>(firstInternalLinks);
            List<string> processedLinks = new List<string>();
            CrawlerData crawlerData = new CrawlerData();

            crawlerData.InternalLinks = firstInternalLinks;
            crawlerData.ExternalLinks = baseLinks.FindAll(item => !item.Contains(baseUrl));
            crawlerData.ImageLinks = imageLinks;

            while (linksToProcess.Count > 0)
            {
                string currentLink = linksToProcess.Pop();
                processedLinks.Add(currentLink);

                if (!crawlerData.InternalLinks.Contains(currentLink))
                {
                    crawlerData.InternalLinks.Add(currentLink);
                }

                var allChildLinks = await _htmlParser.GetAllLinks(currentLink);

                if (allChildLinks.Count > 0)
                {
                    var childLinks = allChildLinks[1].Value;

                    SaveExternalLinks(baseUrl, crawlerData, childLinks);
                    SaveImageLinks(crawlerData, allChildLinks[0].Value);
                    
                    childLinks.RemoveAll(item => processedLinks.Contains(item));
                    childLinks.RemoveAll(item => linksToProcess.Contains(item));

                    var newLinksToProcess = childLinks.FindAll(item => item.Contains(baseUrl));
                    newLinksToProcess.Reverse();
                    newLinksToProcess.ForEach(item => linksToProcess.Push(item));
                }
            }

            return crawlerData;
        }

        private void SaveImageLinks(CrawlerData crawlerData, List<string> imageLinks)
        {
            foreach (var item in imageLinks)
            {
                if(!crawlerData.ImageLinks.Contains(item))
                {
                    crawlerData.ImageLinks.Add(item);
                }
            }
        }

        private void SaveExternalLinks(string baseUrl, CrawlerData crawlerData, List<string> childLinks)
        {
            foreach (var item in childLinks.FindAll(item => !item.Contains(baseUrl)))
            {
                if(!crawlerData.ExternalLinks.Contains(item))
                {
                    crawlerData.ExternalLinks.Add(item);
                }
            }            
        }
    }
}
