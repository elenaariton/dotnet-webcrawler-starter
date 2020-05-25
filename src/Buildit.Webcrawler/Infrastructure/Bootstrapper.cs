using Buildit.Webcrawler.Business.Implementation;
using Buildit.Webcrawler.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildit.Webcrawler.Infrastructure
{
    public class Bootstrapper
    {
        public static void ConfigureIoC(IServiceCollection services)
        {
            services.AddSingleton<IHtmlParser, HtmlParser>();
            services.AddSingleton<ICrawler, Crawler>();
        }
    }
}
