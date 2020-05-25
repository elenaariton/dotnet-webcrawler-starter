using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Business.Interfaces
{
    public interface IHtmlParser
    {
        Task<List<KeyValuePair<int, List<string>>>> GetAllLinks(string pageUrl);
    }
}
