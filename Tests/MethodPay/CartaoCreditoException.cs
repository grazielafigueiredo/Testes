using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using DotnetQaFront.Models;
using DotnetQaFront.Lib;
using System.Collections.Generic;
using System.Threading;

namespace DotnetQaFront.Tests.MethodPay
{
    public class CartaoCreditoException : BaseTest
    {
        private LoginPage _login;
        private ProductPage _product;
        private PaymentCartPage _cart;
        private CreditCardPage _cartao;
        private BoxMenu _menu;
        private MyCardPage _myCard;
        private DataFirstAccess _dataAccess;


        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _product = new ProductPage(Browser);
            _cart = new PaymentCartPage(Browser);
            _cartao = new CreditCardPage(Browser);
            _menu = new BoxMenu(Browser);
            _myCard = new MyCardPage(Browser);
            _dataAccess = new DataFirstAccess(Browser);
            Database.RemoveCreditCard();
            Database.ClearDataFirstAccess();
            _login.With("user22@gmail.com", "1234");
        }

        [Category("pagamento")]
        [Category("cartao")]

        [Test]
        public void PaymnentCreditCard()
        {
            List<CreditCardExceptionModel> selectValue = new List<CreditCardExceptionModel>();

            selectValue.Add(new CreditCardExceptionModel("", "4242424242424242", "1120", "123")); // Nome vazio
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "1234567891234567", "1120", "123")); // Número cartão inválido
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "", "1120", "123")); // Número de cartão vazio
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "erty4567rt567", "1120", "123")); // Número de cartão com letras
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "1420", "123")); // Validade do cartão com mês inexistente - mês 14
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "0020", "123")); // Validade do cartão com mês inexistente - mês 00
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "1a20", "123")); // Validade do cartão com mês inexistente - mês 1a
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "1119", "123")); // Ano de validade do cartão, com vencimento do ano passado
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "11", "123")); // Ano de validade do cartão, com vencimento vazio
            selectValue.Add(new CreditCardExceptionModel("CARLOS ROR", "4242424242424242", "1134", "")); // CVV vazio

            foreach (CreditCardExceptionModel value in selectValue)
            {
                Browser.Visit("/");
                Thread.Sleep(5000);
                _product.AddProductCartPay();
                _cart.ConfirmPaymentCart();
                _cartao.SelectCreditCard();
                _dataAccess.InputDataFirstAccess();
                _cartao.CartaoCreditoExceptionData(value);
                _cartao.ConfirmPaymentCreditCard();
            
                Assert.That(_cartao.ExistsMessagePaymentSuccess());
            }
        }

        public void InputLoginInvalido(string email, string pass, string expectMessage)
        {
            _login.With(email, pass);            
            Assert.IsTrue(_login.ExistsMessageInsideSpan(expectMessage));
        }

    }
}