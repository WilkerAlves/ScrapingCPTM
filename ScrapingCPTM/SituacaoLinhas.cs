using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Tweetinvi;

namespace ScrapingCPTM
{
    public class SituacaoLinhas
    {
        private SeleniumConfigurations _configurations;
        private IWebDriver _driver;

        public SituacaoLinhas(SeleniumConfigurations seleniumConfigurations)
        {
            _configurations = seleniumConfigurations;

            ChromeOptions optionsFF = new ChromeOptions();
            //optionsFF.AddArgument("--headless");

            _driver = new ChromeDriver(_configurations.CaminhoDriverChrome, optionsFF);
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.Navigate().GoToUrl(_configurations.UrlPagina);
        }

        public List<string> ObterSituacaoLinhas()
        {

            var rubi = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("rubi")).Text;

            var diamante = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("diamante")).Text;

            var esmeralda = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("esmeralda")).Text;

            var turquesa = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                            .FindElement(By.ClassName("turquesa")).Text;

            var coral = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("coral")).Text;


            var safira = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("safira")).Text;


            var jade = _driver
                .FindElement(By.ClassName("situacao_linhas"))
                .FindElement(By.ClassName("jade")).Text;

            return new List<string>
            {
                rubi,
                diamante,
                esmeralda,
                turquesa,
                coral,
                safira,
                jade
            };
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

    }
}