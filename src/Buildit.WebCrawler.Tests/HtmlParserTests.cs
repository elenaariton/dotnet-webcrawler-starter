using Buildit.Webcrawler.Business.Implementation;
using Buildit.Webcrawler.Business.Interfaces;
using HtmlAgilityPack;
using Moq;
using NUnit.Framework;

namespace Buildit.WebCrawler.Tests
{
    public class HtmlParserTests
    {
        private IHtmlParser _htmlParser;

        [SetUp]
        public void Setup()
        {
            _htmlParser = new HtmlParser();
        }

        [Test]
        public void GetAllLinks_WhenGivenAPageUrl_ReturnsLinks()
        {
            //Arrange
            var pageUrl = "https://www.amazon.co.uk/about";
           
            //Act
            var links = _htmlParser.GetAllLinks(pageUrl, "https://www.amazon.co.uk");

            //Assert
            Assert.IsNotNull(links);
            Assert.IsTrue(links.Count > 0);            
        }

        [Test]
        public void GetAllLinks_WhenGivenAPageHtmlWithoutLinks_ReturnsEmptyLinkList()
        {
            //Arrange
            //if we don`t load DOM, and the website doesn`t work without javascript enabled,
            //the content might be affected, so no links
            //could be done in an improved version of the crawler
            var testPageUrl = "https://www.boatyardx.com/";

            //Act
            var links = _htmlParser.GetAllLinks(testPageUrl,testPageUrl);

            //Assert
            Assert.IsNotNull(links);
            Assert.AreEqual(links.Count, 0);
        }

        [Test]
        public void GetAllLinks_WhenGivenEmptyString_ReturnsEmptyLinkList()
        {
            //Arrange

            //Act
            var links = _htmlParser.GetAllLinks("","");

            //Assert
            Assert.IsNotNull(links);
            Assert.AreEqual(links.Count, 0);
        }
    }
}