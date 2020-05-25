using Buildit.Webcrawler.Business.Implementation;
using Buildit.Webcrawler.Business.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buildit.WebCrawler.Tests
{
    public class CrawlerTests
    {
        private ICrawler _crawler;
        private Mock<IHtmlParser> _htmlParser = new Mock<IHtmlParser>();

        [SetUp]
        public void Setup()
        {
            var testLinks = new List<KeyValuePair<int, List<string>>>();

            testLinks.Add(new KeyValuePair<int, List<string>>(0, new List<string>() { "/img.svc", "/img2.svc" }));
            testLinks.Add(new KeyValuePair<int, List<string>>(1, new List<string>() { "https://www.ve.com/", "http://www.google.com" }));

            _htmlParser.Setup(call => call.GetAllLinks("https://www.ve.com/")).ReturnsAsync(testLinks);
            _crawler = new Crawler(_htmlParser.Object);
        }

        [Test]
        public async Task GetCrawlerData_WhenGivenUrl_ReturnsData()
        {
            //Arrange
            
            //Act
            var crawlerdata = await _crawler.GetCrawlerData("https://www.ve.com/");

            //Assert
            Assert.IsNotNull(crawlerdata);
            Assert.AreEqual(crawlerdata.InternalLinks.Count, 1);
            Assert.AreEqual(crawlerdata.ExternalLinks.Count, 1);
            Assert.AreEqual(crawlerdata.ImageLinks.Count, 2);
            Assert.AreEqual(crawlerdata.ImageLinks[0], "/img.svc");
        }
    }
}
