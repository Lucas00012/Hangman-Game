using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.Core.Helpers
{
    public static class ScrapperHelper
    {
        public static async Task<HtmlDocument> ObterHtml(string url)
        {
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);

            var response = await client.ExecuteAsync(request);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response.Content);

            return htmlDoc;
        }
    }
}
