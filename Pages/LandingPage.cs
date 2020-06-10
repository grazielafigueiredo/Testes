using Coypu;
using System.Threading;

namespace DotnetQaFront.Pages
{
    public class LandingPage
    {
        private readonly BrowserSession _browser;
        public LandingPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void HeaderJa()
        {
            _browser.FindCss(("div[class='Header__dropdown']"), text: "Adquira").Click();
            _browser.FindCss("[href='/lottocap-ja/'] > div", text: "LottoCap Já").Click();
        }
        public void HeaderMax()
        {
            _browser.FindCss(("div[class='Header__dropdown']"), text: "Adquira").Click();
            _browser.FindCss("a[href='/lottocap-max/'] > div", text: "LottoCap Max").Click();
        }
        public void HeaderPaymentCredito()
        {
            _browser.FindCss(("div[class='Header__dropdown']"), text: "Adquira").Click();
            _browser.FindCss("a[href='/carrinho/creditos/'] > div", text: "Comprar créditos").Click();
        }
        public bool ProductExists()
        {
            return _browser.FindCss("div:nth-child(1) > fieldset > label > span.main").Exists();
        }

        public bool FormPaymentExists()
        {
            return _browser.FindCss("button[class='btn btn-secondary']").Exists();
        }
        public bool FormPaymentNoExists()
        {
            return _browser.FindCss("button[class='btn btn-secondary']").Missing();
        }

        public void SelectValue(string value)
        {
            _browser.FindCss($"div.col-xl-6.carrinho > div > div:nth-child({value})").Click();
        }  
    }
}