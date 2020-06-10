using Coypu;
using System.Threading;
using System;


namespace DotnetQaFront.Pages
{
    public class CreditoLottocapPage
    {
        private readonly BrowserSession _browser;
        public CreditoLottocapPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void SelectCreditoLottocap()
        {
            _browser.FindCss("li[class='tab-list-item']", text: "Créditos Lottocap").Click();
        }
        public void ConfirmPaymentCreditoLottocap()
        {
            _browser.ClickButton("Pagar com créditos LottoCap");
            Thread.Sleep(5000);
        }
        public bool BlockPaymentCreditoLottocap()
        {
           return _browser.FindButton("Pagar com Créditos Lottocap").Missing();
        }

        public string MessagePaymentSuccess()
        {
            return _browser.FindCss("div > h1").Text;
        }  
        public void InputValue(string value)
        {
                var query = ("var numberInput = document.querySelectorAll('.creditos__value')[0];" 
                + " let input = numberInput; "
                + " let lastValue = input.value;"
                + $" input.value = {value};"
                + " let event = new Event('input', { bubbles: true });"
                + " let tracker = input._valueTracker;"
                + "  if (tracker) {"
                + " tracker.setValue(lastValue);"
                + " }"
                + " input.dispatchEvent(event);"
            );
            Console.WriteLine(query);


            _browser.ExecuteScript(query);
        }  

        public bool PaymentDisabled()
        {
            return _browser.FindCss("[class='tab-list-item tab-list-item--disabled'] > div > span", text: "Créditos Lottocap", Options.First).Exists();
            // return _browser.FindCss("li[class='tab-list-item']", Options.First).Exists();
        }  
    }
}