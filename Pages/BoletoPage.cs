using Coypu;
using System.Threading;

namespace DotnetQaFront.Pages
{
    public class BoletoPage
    {
        private readonly BrowserSession _browser;
        public BoletoPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void SelectBoleto()
        {
            _browser.FindCss("li[class='tab-list-item']", text: "Boleto Bancário").Click();
        }
        public void ConfirmPaymentBoleto()
        {
            _browser.ClickButton("Pagar com boleto");
            Thread.Sleep(5000);
        }
        public string MessagePaymentSuccess()
        {
            return _browser.FindCss("div > h1").Text;

        }  
    }

}