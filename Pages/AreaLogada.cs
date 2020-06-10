using Coypu;

namespace DotnetQaFront.Pages
{
    public class AreaLogada
    {
        private readonly BrowserSession _browser;

        // construtor com mesmo nome da classe
        public AreaLogada(BrowserSession browser)
        {
            _browser = browser; 
        }

        public string AlertMessage()
        {
            return _browser.FindCss("div[class='Toastify__toast-body']").Text;

        }
    }
}