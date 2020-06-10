// 

using Coypu;

namespace DotnetQaFront.Pages
{
    public class ModalPreVenda
    {
        private readonly BrowserSession _browser;

        // construtor com mesmo nome da classe
        public ModalPreVenda(BrowserSession browser)
        {
            _browser = browser; 
        }

        public void ViewDezenas()
        {
            _browser.FindCss("span", text: "Ver dezenas dos títulos").Click();
        }
        public void AddNewTitulo()
        {
            _browser.FindCss("button", text: "+ Adicionar título").Click();
        }
        public void SelectUniqueDezenas()
        {
            _browser.FindCss("li > span", text: "78").Click();
            _browser.FindCss("li > span", text: "79").Click();
            _browser.FindCss("li > span", text: "80").Click();
        }
        public void RandomDezenas()
        {
            _browser.FindCss("span", text: "Aleatório").Click();
        }
        public void DeleteDezenas()
        {
            _browser.FindCss("span", text: "Apagar").Click();
        }
        public void CloseModalDezenas()
        {
            _browser.FindCss("body > div.ReactModalPortal > div > div > div.escolhaModal__header.escolhaModal__header--escolha > span > svg").Click();
        }
        public void ConfirmNewTitulo()
        {
            _browser.FindCss("button", text: "Confirmar escolha").Click();
        }
        public void EditTitulo()
        {
            _browser.FindCss("body > div.ReactModalPortal > div > div > div.escolhaModal__body.escolhaModal__body--lista > ul > li > span:nth-child(3)").Click();
        }
        public void DeleteTitulo()
        {
            _browser.FindCss("li:nth-child(1) > span", text : "excluir").Click();
            _browser.FindCss("button", text: "Excluir").Click();        
        }
        public void ConfirmDeleteTitulo()
        {
            _browser.FindCss("button", text: "Excluir").Click();        
        }
        public void CanceledDeleteTitulo()
        {
            _browser.FindCss("button", text: "Cancela").Click();        
        }
        public void ChooseVitrineDezenas()
        {
            _browser.ClickButton("Confirmar escolha");
        }
        public bool ButtonConfirmDisabledDezena()
        {
            return _browser.FindCss("button[class='escolhaModal__btn escolhaModal__btn--escolha escolhaModal__btn--disabled']").Exists();
        }  
        public bool ButtonConfirmEnableDezena()
        {
            return _browser.FindCss("button[class='escolhaModal__btn escolhaModal__btn--escolha']").Exists();
        }  
        public string amountTitulos()
        {
            return _browser.FindCss("div > span > span", text: "2").Text;
        }  
        public string oneTitulo()
        {
            return _browser.FindCss("div > span > span", text: "1").Text;
        }  
    }
}