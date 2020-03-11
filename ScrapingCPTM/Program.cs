using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using Tweetinvi;

namespace ScrapingCPTM
{
    class Program
    {
        static void Main(string[] args)
        {

            var seleniumConfigurations = new SeleniumConfigurations()
            {
                CaminhoDriverChrome = $"C:\\Selenium\\",
                UrlPagina = $"http://www.cptm.sp.gov.br/Pages/Home.aspx",
                Timeout = 60
            };

            var pagina = new SituacaoLinhas(seleniumConfigurations);
            pagina.CarregarPagina();
            var situacoes = pagina.ObterSituacaoLinhas();
            pagina.Fechar();

            Auth.SetUserCredentials(
                "consumerKey",
                "consumerSecret",
                "userAccessToken",
                "userAccessSecret");


            foreach (var linha in situacoes)
            {
                if (linha.Contains("Operação Normal"))
                {
                    Tweet.PublishTweet(linha);
                }
            }
        }
    }
}
