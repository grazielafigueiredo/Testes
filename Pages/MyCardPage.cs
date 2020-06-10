using Coypu;
using System.Threading;

namespace DotnetQaFront.Pages
{
    public class MyCardPage
    {
        private readonly BrowserSession _browser;
        public MyCardPage(BrowserSession browser)
        {
            _browser = browser; 
        }
        public void RemoverCard()
        {
            _browser.FindCss("div[class='box-cartao__remover']", text: "Remover").Click();
        }
        public string RemoveCardSuccess()
        {
            return _browser.FindCss("div[class='Toastify__toast-body']").Text;
        }
    }
}