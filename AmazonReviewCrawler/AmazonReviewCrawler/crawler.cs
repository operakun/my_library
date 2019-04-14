using System;
using System.Net;
using System.Net.Http;
using System.IO;

namespace AmazonReviewCrawler
{
    class Crawler
    {
        private WebClient objWebClient;
        private string strCode;
        private Stream streamAmazonPage;

        private const string amazonUrl = "http://amazon.co.jp/dp/";
        
        /// <summary>
        /// constructer
        /// </summary>
        /// <returns></returns>
        Crawler(string code)
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
            streamAmazonPage = objWebClient.OpenRead(strPageURL);
            return true;
        }
    }
}
