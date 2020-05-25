using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Models
{
    public class CrawlerData
    {
        public CrawlerData()
        {
            InternalLinks = new List<string>();
            ExternalLinks = new List<string>();
            ImageLinks = new List<string>();
        }

        public List<string> InternalLinks { get; set; }
        public IList<string> ExternalLinks { get; set; }
        public List<string> ImageLinks { get; set; }

    }
}
