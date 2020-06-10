using Coypu;
using System.Threading;
using DotnetQaFront.Models;

namespace DotnetQaFront.Pages
{
    public class TransferenciaPage
    {
        private readonly BrowserSession _browser;
        public TransferenciaPage(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void SelectTransferencia()
        {
            _browser.FindCss("li[class*='tab-list-item']", text: "Transferência bancária").Click();
            Thread.Sleep(1000);
        }
        public void AddAccount()
        {
            _browser.FindCss("span[class='payment-form__title__text']", text: "Adicionar Conta").Click();
        }
        public void TransferenciaBradescoData(TransferenciaModel bank)
        {
            _browser.FindCss("div.col-xl-6.pagamento > div.tabs > div > div > div > form > div > ul > li:nth-child(1)").Click(); //selecionar banco
            _browser.FindCss("input[placeholder='Titular da conta']").SendKeys(bank.Titular);
            _browser.FindCss("input[placeholder='Agência']").SendKeys(bank.Agencia);
            _browser.FindCss("input[placeholder='Conta']").SendKeys(bank.Conta);
            _browser.FindCss("input[placeholder='Dígito']").SendKeys(bank.Digito);
        }
        public void TransferenciaSantanderData(TransferenciaModel bank)
        {
            _browser.FindCss("div.col-xl-6.pagamento > div.tabs > div > div > div > form > div > ul > li:nth-child(3)").Click(); //selecionar banco
            _browser.FindCss("input[placeholder='CPF']").SendKeys(bank.Cpf);
        }
        public void TransferenciaItauData(TransferenciaModel bank)
        {
            _browser.FindCss("div.col-xl-6.pagamento > div.tabs > div > div > div > form > div > ul > li:nth-child(2)").Click(); //selecionar banco
            _browser.FindCss("input[placeholder='Titular da conta']").SendKeys(bank.Titular);
            _browser.FindCss("input[placeholder='Agência']").SendKeys(bank.Agencia);
            _browser.FindCss("input[placeholder='Conta']").SendKeys(bank.Conta);
            _browser.FindCss("input[placeholder='Dígito']").SendKeys(bank.Digito);
        }
        public void TransferenciaBrasilData(TransferenciaModel bank)
        {
            _browser.FindCss("div.col-xl-6.pagamento > div.tabs > div > div > div > form > div > ul > li:nth-child(4)").Click(); //selecionar banco
            _browser.FindCss("input[placeholder='Titular da conta']").SendKeys(bank.Titular);
            _browser.FindCss("input[placeholder='Agência']").SendKeys(bank.Agencia);
            _browser.FindCss("input[name='digitoAgencia']").SendKeys(bank.DigitoAgencia);
            _browser.FindCss("input[placeholder='Conta']").SendKeys(bank.Conta);
            _browser.FindCss("input[name='digitoConta']").SendKeys(bank.Digito);
        }
        public void SelectBankSaved(string optionBank)
        {
            _browser.FindCss($"div > div:nth-child({optionBank}) > div.sc-kjoXOD.cKXcJm > div.sc-gisBJw.ikuvHn").Click();
        }
        public void ConfirmPaymentTransferencia()
        {
            _browser.ClickButton("Pagar via transferência");
            Thread.Sleep(5000);
        }
        public string MessagePaymentSuccess()
        {
            return _browser.FindCss("div > h1").Text;
        }  
        public string MessagePaymentException()
        {
            return _browser.FindCss("span[class='form-error']").Text;
        }  
    }
}