using Buildit.Webcrawler.Business.Implementation;
using Buildit.Webcrawler.Business.Interfaces;
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
        public void GetAllLinks_WhenGivenAPageHtmlWithLinks_ReturnsAllLinks()
        {
            //Arrange
            var testPageHtml = "<html><body><a href=\"www.google.com\"></a><br/><a href=\"bing.com\"></a></body></html>";

            //Act
            var links = _htmlParser.GetAllLinks(testPageHtml);

            //Assert
            Assert.IsNotNull(links);
            Assert.AreEqual(links.Count, 2);
            Assert.AreEqual(links[0], "www.google.com");
        }

        [Test]
        public void GetAllLinks_WhenGivenAPageHtmlWithoutLinks_ReturnsEmptyLinkList()
        {
            //Arrange
            var testPageHtml = "<html><body><p>this is a simple page without links</p></body><html>";

            //Act
            var links = _htmlParser.GetAllLinks(testPageHtml);

            //Assert
            Assert.IsNotNull(links);
            Assert.AreEqual(links.Count, 0);
        }

        [Test]
        public void GetAllLinks_WhenGivenEmptyString_ReturnsEmptyLinkList()
        {
            //Arrange

            //Act
            var links = _htmlParser.GetAllLinks("");

            //Assert
            Assert.IsNotNull(links);
            Assert.AreEqual(links.Count, 0);
        }

        [Test]
        public void GetPageHtml_WhenGivenAPageUrl_ReturnsThatPageHtml()
        {

        }
    }
}