using Buildit.Webcrawler.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Interfaces
{
    public interface ICrawler
    {
        Task<CrawlerData> GetCrawlerData(string url);
    }
}
