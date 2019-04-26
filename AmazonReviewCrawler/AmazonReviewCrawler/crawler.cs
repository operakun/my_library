using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonReviewCrawler
{
    public class Crawler
    {
        private string strCode;
        private string strAmazonPageHTML;
        private WebClient objWebClient = new WebClient();

        private const string amazonUrl = "http://amazon.co.jp/dp/";
        
        /// <summary>
        /// constructer
        /// </summary>
        /// <returns></returns>
        public Crawler(string code)
        {
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
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                }
                catch (HttpRequestException e)
                {
                    return false;
                }
            }
            objWebClient.Encoding = Encoding.UTF8;
            strAmazonPageHTML = objWebClient.DownloadString(strPageURL);
            return true;
        }

        public string ExtractReviewCount()
        {
            const string reviewCountSelecter = "#dp-summary-see-all-reviews > h2";
            const string reviewCountRE = "^[0-9]+";
            return ExtractInnerHTMLFromHTMLData(strAmazonPageHTML, reviewCountSelecter, reviewCountRE);
        }

        public Dictionary<int, string> ExtractReviewStarCount()
        {
            string[] reviewStarCountSelecter =
            {
                "#histogramTable > tbody > tr:nth-child(1) > td.a-text-right.aok-nowrap > a",
                "#histogramTable > tbody > tr:nth-child(2) > td.a-text-right.aok-nowrap > a",
                "#histogramTable > tbody > tr:nth-child(3) > td.a-text-right.aok-nowrap > a",
                "#histogramTable > tbody > tr:nth-child(4) > td.a-text-right.aok-nowrap > a",
                "#histogramTable > tbody > tr:nth-child(5) > td.a-text-right.aok-nowrap > a"
            };

            Dictionary<int, string> dicReviewStarCount = new Dictionary<int, string>();
            int counter = 5;
            foreach(string Selecter in reviewStarCountSelecter)
            {
                string extractStarCount = ExtractInnerHTMLFromHTMLData(strAmazonPageHTML, Selecter);
                if (extractStarCount == "") extractStarCount = "0%";    
                dicReviewStarCount.Add(counter, extractStarCount);
                counter--;
            }
            return dicReviewStarCount;
        }

        /// <summary>
        /// Extrarct StringData From HTML by QuerySelecter
        /// </summary>
        /// <param name="targetHTML">HTMLData</param>
        /// <param name="selecterParam">Extract Parameter</param>
        /// <param name="REparam">(Option)Regex Parameter</param>
        /// <returns></returns>
        private string ExtractInnerHTMLFromHTMLData(string targetHTML, string selecterParam, string REparam = "")
        {
            HtmlParser parser = new HtmlParser();
            var htmldoc = parser.ParseDocument(targetHTML);
            var extractResult = htmldoc.QuerySelector(selecterParam);
            string extractString = "";

            ///if Selecter Result is NULL
            if (extractResult == null)
                return "";
            else
                extractString = extractResult.InnerHtml;

            if (REparam == "")
                return extractString;
            else {
                Match re = Regex.Match(extractString, REparam);
                return re.Value;
            }
            
        }
    }
}
