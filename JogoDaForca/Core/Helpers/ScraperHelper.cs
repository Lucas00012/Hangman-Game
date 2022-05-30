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
        public static async Task<string> ObterPalavra()
        {
            var client = new RestClient();
            var request = new RestRequest("https://www.palabrasaleatorias.com/palavras-aleatorias.php", Method.Get);

            var response = await client.ExecuteAsync(request);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response.Content);

            var palavra = htmlDoc.DocumentNode.SelectSingleNode("//html/body/center/table/tr/td/div").InnerText.ToUpper();

            return palavra.ToUpper().Replace("\r\n", string.Empty);
        }
    }
}
