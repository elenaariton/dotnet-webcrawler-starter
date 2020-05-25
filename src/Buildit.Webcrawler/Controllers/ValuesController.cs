using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Buildit.Webcrawler.Models;
using Buildit.Webcrawler.Business.Interfaces;
using Buildit.Webcrawler.Business.Models;

namespace Buildit.Webcrawler.Controllers
{
    [Route("crawl")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICrawler _crawler;

        public ValuesController(ICrawler crawler)
        {
            _crawler = crawler;
        }

        [HttpGet]
        public async Task<CrawlerData> Get(string url)
        {
            return await _crawler.GetCrawlerData(url);
        }
    }
}
