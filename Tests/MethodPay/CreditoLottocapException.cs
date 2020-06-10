using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using System;
using DotnetQaFront.Lib;
using Coypu;
using System.Threading;



namespace DotnetQaFront.Tests.MethodPay
{
    public class CreditoLottocapException : BaseTest
    {
        private LoginPage _login;
        private ProductPage _product;
        private PaymentCartPage _cart;
        private CreditoLottocapPage _credito;
        private DataFirstAccess _dataAccess;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _product = new ProductPage(Browser);
            _cart = new PaymentCartPage(Browser);
            _dataAccess = new DataFirstAccess(Browser);
            Database.ClearDataFirstAccess();
            _login.With("user22@gmail.com", "1234");
            Database.ValueInputCredit(0);
        }

        [Test]
        [Category("pagamento")]
        [Category("credito")]

        public void UserWithoutCredit()
        {
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            // _dataAccess.InputDataFirstAccess();

            Assert.That(_credito.PaymentDisabled(), "Pagamento com créditos foi habilitado");
        }
    }
}