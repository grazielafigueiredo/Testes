using Coypu;
using System.Threading;

namespace DotnetQaFront.Pages
{
    public class BoxMenu
    {
        private readonly BrowserSession _browser;
        public BoxMenu(BrowserSession browser)
        {
            _browser = browser; 
        }
        public void MenuMyCard()
        {
            _browser.FindCss(
                "a[href='/minha-conta/metodos-pagamento']", 
                text: "Meus cartões"
            ).Click();
        }
    }
}