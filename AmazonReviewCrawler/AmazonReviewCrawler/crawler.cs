using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Html.Parser;

namespace AmazonReviewCrawler
{
    public class Crawler
    {
        private WebClient objWebClient;
        private string strCode;
        private string strAmazonPageHTML;

        private const string amazonUrl = "http://amazon.co.jp/dp/";
        
        /// <summary>
        /// constructer
        /// </summary>
        /// <returns></returns>
        public Crawler(string code)
        {
            objWebClient = new WebClient();
            strCode = code;
        }

        /// <summary>
        /// Get target Amazon Page
        /// </summary>
        /// <returns>getting result boolean</returns>
        public Boolean GetPageHTML()
        {
            if (strCode.Length == 0) return false;
            string strPageURL = amazonUrl + strCode;

            // try checking exist pageURL
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(strPageURL).Result;
                    if(response.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                }
                catch(HttpRequestException e)
                {
                    return false;
                }
            }
            objWebClient.Encoding = Encoding.UTF8;
            strAmazonPageHTML = objWebClient.DownloadString(strPageURL);
            return true;
        }

        public string GetReviewCount()
        {
            string reviewSelecter = "#dp-summary-see-all-reviews > h2";

            HtmlParser parser = new HtmlParser();
            var htmldoc = parser.ParseDocument(strAmazonPageHTML);
            string reviewCount = htmldoc.QuerySelector(reviewSelecter).InnerHtml;

            Match re = Regex.Match(reviewCount, "^[0-9]+");
            return re.Value;
        }
    }
}
