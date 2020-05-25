using System.Text.RegularExpressions;

namespace Buildit.Webcrawler.Common
{
    public  static class UrlMatch
    {
        public static string GetBaseUrl(string url)
        {
            var regexPattern = "^[^\\/]+:\\/\\/[^\\/]*?\\.?([^\\/.]+)\\.[^\\/.]+(?::\\d+)?\\/";

            return Regex.Match(url, regexPattern).ToString();
        }
    }
}
