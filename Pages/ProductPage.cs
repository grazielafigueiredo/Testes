using Coypu;
using System.Threading;
using DotnetQaFront.Common;
using System;

namespace DotnetQaFront.Pages
{
    public class ProductPage
    {
        private readonly BrowserSession _browser;

        // construtor com mesmo nome da classe
        public ProductPage(BrowserSession browser)
        {
            _browser = browser; 
        }
        public void AddProductCartPay()
        {            
            var query = ("document.querySelector('div.home-vitrine > div:nth-child(1) > div > div.card-vitrine__bottom > div.card-vitrine__compra > div > div:nth-child(2) > div').click();");
            Console.WriteLine(query);
            _browser.ExecuteScript(query);

            Thread.Sleep(2000);
        }
        public void AddProductPreVenda()
        {            
            var query = ("document.querySelector('div.home-vitrine > div:nth-child(4) > div > div.card-vitrine__bottom > div.card-vitrine__compra > div > div:nth-child(1) > div').click();");
            // Console.WriteLine(query);
            _browser.ExecuteScript(query);

            Thread.Sleep(2000);
        }
        public void SelectVitrinePreVenda()
        {            
            _browser.FindCss("button", text: "Escolha as dezenas do seu título").Click();
        }
    }
}