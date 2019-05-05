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
        public string strBasePageURL { get; set; }

        /// <summary>
        /// constructer
        /// </summary>
        /// <returns></returns>
        public Crawler(string code)
        {
            strCode = code;
            this.strBasePageURL = amazonUrl + strCode;
        }
               
        /// <summary>
        /// Get target Amazon Page
        /// </summary>
        /// <returns>getting result boolean</returns>
        public Boolean GetPageHTML(string strPageURL)
        {
            if (strCode.Length == 0) return false;

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
                    var error = e.Message;
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
            foreach (string Selecter in reviewStarCountSelecter)
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

        /// <summary>
        /// Extract LinkURL From HTML by QuerySelecter
        /// </summary>
        /// <param name="targetHTML">HTML Data</param>
        /// <param name="selecterParam">Extract Parameter</param>
        /// <param name="REparam">(Option)Regex Parameter</param>
        /// <returns></returns>
        private string ExtractLinkURLFromHTMLData(string targetHTML, string selecterParam, string REparam = "")
        {
            HtmlParser parser = new HtmlParser();
            var htmldoc = parser.ParseDocument(targetHTML);
            var extractResult = htmldoc.QuerySelector(selecterParam);
            string extractString = "";

            ///if Selecter Result is NULL
            if (extractResult == null)
                return "";
            else
                extractString = extractResult.Attributes["href"].Value;

            if (REparam == "")
                return extractString;
            else
            {
                Match re = Regex.Match(extractString, REparam);
                return re.Value;
            }
        }

        /// <summary>
        /// ReviewContentCrawler Main
        /// </summary>
        /// <returns>ReviewContentList</returns>
        public List<ReviewData> GetReviewContent()
        {
            var reviewDatas = new List<ReviewData>();

            var url = ExtractAllReviewURL(strAmazonPageHTML);
            if(url != "")
            {
                while(GetPageHTML(url))
                {
                    //it's mannar using crawler
                    System.Threading.Thread.Sleep(3000);

                    List<ReviewData> ExtractResult = ExtractReviewContent(strAmazonPageHTML);
                    if (ExtractResult.Count == 0) break;
                    foreach(ReviewData data in ExtractResult) reviewDatas.Add(data);
                    
                    url = ExtractNextReviewURL(strAmazonPageHTML);
                    if (url == "") break;
                }
            }
            return reviewDatas;
        }

        /// <summary>
        /// Extract AllReviewPageURL
        /// </summary>
        /// <param name="targetHTML">HTMLData contain Product Page</param>
        /// <returns>url</returns>
        private string ExtractAllReviewURL(string targetHTML)
        {
            const string BaseUrl = "https://amazon.co.jp";
            const string strkeyword = "product-reviews";
            const string strAllReviewSelecter = "#reviews-medley-footer > div.a-row.a-spacing-large > a";

            var url = ExtractLinkURLFromHTMLData(strAmazonPageHTML, strAllReviewSelecter);
            if (url == null) return "";
            if (url.Contains(strkeyword) == false) return "";
            return BaseUrl + url;
        }

        /// <summary>
        /// Extract NextReviewPageURL
        /// </summary>
        /// <param name="targetHTML">HTMLData contain Review Page</param>
        /// <returns>url</returns>
        private string ExtractNextReviewURL(string targetHTML)
        {
            const string BaseUrl = "https://amazon.co.jp";
            const string strkeyword = "product-reviews";
            const string strAllReviewSelecter = "#cm_cr-pagination_bar > ul > li.a-last > a";
   
            var url = ExtractLinkURLFromHTMLData(strAmazonPageHTML, strAllReviewSelecter);
            if (url == null) return "";
            if (url.Contains(strkeyword) == false) return "";
            return BaseUrl + url;
        }

        private List<ReviewData> ExtractReviewContent(string targetHTML)
        {
            var ReviewDatas = new List<ReviewData>();
            const string extractClassName = "a-row a-spacing-none";

            HtmlParser parser = new HtmlParser();
            var htmldoc = parser.ParseDocument(targetHTML);
            var extractResult = htmldoc.GetElementsByClassName(extractClassName);

            if(extractResult != null)
            {
                foreach (AngleSharp.Dom.IElement data in extractResult)
                {
                    ReviewData tempData = new ReviewData();

                    //Extract ReviewDetail
                    var name = data.QuerySelector("div:nth-child(1) > a > div.a-profile-content > span");
                    if (name != null) tempData.name = name.InnerHtml;
                    var star = data.QuerySelector("div:nth-child(2) > a:nth-child(1) > i > span");
                    if (star != null) {
                        var resultstr = Regex.Match(star.InnerHtml, "[0-9][.][0-9]");
                        tempData.star = resultstr.Value;
                    }
                    var title = data.QuerySelector("div:nth-child(2) > a.a-size-base.a-link-normal.review-title.a-color-base.review-title-content.a-text-bold > span");
                    if (title != null) tempData.title = title.InnerHtml;
                    var content = data.QuerySelector("div.a-row.a-spacing-small.review-data > span > span");
                    if (content != null) tempData.content = content.InnerHtml;

                    ReviewDatas.Add(tempData);
                }
            }          
            return ReviewDatas;
        }
    }

    public class ReviewData
    {
        public string name { get; set; } = "";
        public string star { get; set; } = "";
        public string title { get; set; } = "";
        public string content { get; set; } = "";
    }
}
