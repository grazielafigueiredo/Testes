using Coypu;
using System.Threading;
using DotnetQaFront.Common;

namespace DotnetQaFront.Pages
{
    public class PaymentCartPage
    {
        private readonly BrowserSession _browser;

        // construtor com mesmo nome da classe
        public PaymentCartPage(BrowserSession browser)
    
        {
            _browser = browser; 
        }

        public void ConfirmPaymentCart()
        {
            _browser.FindCss("a[href='/carrinho']").Click();
            Thread.Sleep(3000);
        }

        public void DeletePaymentCart()
        {
            var btn = Helper.getElementByIndex(
                _browser,
                "svg[class='jss1']", 
                3
            );
            btn.Click();
            Thread.Sleep(2000);
        }
    }
}