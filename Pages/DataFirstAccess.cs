using Coypu;
using System.Threading;

namespace DotnetQaFront.Pages
{
    public class DataFirstAccess
    {
        private readonly BrowserSession _browser;
        public DataFirstAccess(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void InputDataFirstAccess()
        {
            _browser.FindCss("input[name='telefoneUsuario']").SendKeys("(11)98765-4345");
            _browser.FindCss("input[name='cep']").SendKeys("06192-100");
            Thread.Sleep(1000);
            _browser.FindCss("input[name='enderecoNumero']").SendKeys("100");
        }
    }

}