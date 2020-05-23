using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Models
{
    public class CrawlerData
    {
        public List<string> InternalLinks { get; set; }
        public List<string> ExternalLinks { get; set; }
        public List<string> ImageLinks { get; set; }

    }
}
