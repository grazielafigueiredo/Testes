using System.Threading;
using Coypu;

namespace DotnetQaFront.Pages
{
    public class LoginPage
    {
        // atributo privado instancia com _browser
        private readonly BrowserSession _browser;

        // construtor com mesmo nome da classe
        public LoginPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void Acessa()
        {
            _browser.Visit("/");
        }
        public void With(string email, string senha)
        {
            this.Acessa();
            _browser.FindCss("div.Header__login", text: "Entrar").Click();
            _browser.FillIn("email").With(email);
            _browser.FillIn("senha").With(senha);
            _browser.ClickButton("Entrar");
            Thread.Sleep(3000);

        }

         public string ErrorMessageLogin()
        {
            return _browser.FindCss("span[class='form-error']").Text;
        }    
        public bool ExistsMessageInsideSpan(string message)
        {
            var errors = _browser.FindAllCss("span[class*='inputError']");
            foreach(var error in errors)
            {
                if(error.Text == message ){
                    return true;
                }                
            };
            return false;
        }
    }
}

