using Coypu;
using System.Threading;
using DotnetQaFront.Models;

namespace DotnetQaFront.Pages
{

    public class CreditCardPage
    {
        private readonly BrowserSession _browser;
        public CreditCardPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void SelectCreditCard()
        {
            _browser.FindCss(
                "li[class*='tab-list-item']", 
                text: "Cartão de crédito"
            ).Click();
        }
        public void SelectCreditCardSaved()
        {
            _browser.FindCss("div.col-xl-6.pagamento > div.tabs > div > div > div > div > div").Click();
        }
        public void CartaoCreditoData(CreditCardModel cartao)
        {
            _browser.FindCss("input[placeholder='Nome do titular']").SendKeys(cartao.Name);
            _browser.FindCss("input[placeholder='Número do cartão']").SendKeys(cartao.NumberCard);
            _browser.FindCss("input[placeholder='Validade']").SendKeys(cartao.ValidationCard);
            _browser.FindCss("input[placeholder='CVV']").SendKeys(cartao.NumberCardSegrete);
        }
        public void CartaoCreditoExceptionData(CreditCardExceptionModel cartao)
        {
            _browser.FindCss("input[placeholder='Nome do titular']").SendKeys(cartao.Name);
            _browser.FindCss("input[placeholder='Número do cartão']").SendKeys(cartao.NumberCard);
            _browser.FindCss("input[placeholder='Validade']").SendKeys(cartao.ValidationCard);
            _browser.FindCss("input[placeholder='CVV']").SendKeys(cartao.NumberCardSegrete);
        }
        public void ConfirmPaymentCreditCard()
        {
            _browser.ClickButton("Pagar com cartão de crédito");
            Thread.Sleep(5000);
        }
        public string MessagePaymentSuccess()
        {
            return _browser.FindCss("div > h1").Text;

        }  

        public bool ExistsMessagePaymentSuccess()
        {
            return _browser.FindCss("div > h1").Missing();
        }

        public string MessagePaymentException()
        {
            return _browser.FindCss("span[class='form-error']").Text;
        }  

        public void PaymentCardSave()
        {
            
        }
    }

}