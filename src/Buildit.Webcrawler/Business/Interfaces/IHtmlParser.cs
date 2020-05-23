using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Interfaces
{
    public interface IHtmlParser
    {
        List<string> GetAllLinks(string testPageHtml);
    }
}
