using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using System;
using DotnetQaFront.Lib;

namespace DotnetQaFront.Tests.MethodPay
{
    public class CreditoLottocap : BaseTest
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
            _credito = new CreditoLottocapPage(Browser);
            _dataAccess = new DataFirstAccess(Browser);
            Database.ClearDataFirstAccess();
            _login.With("user22@gmail.com", "1234");
            Database.ValueInputCredit(1000);
        }

        [Test]
        [Category("pagamento")]
        [Category("credito")]

        public void PaymentCreditoLottocap()
        {
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _dataAccess.InputDataFirstAccess();
            _credito.ConfirmPaymentCreditoLottocap();

            Assert.AreEqual("Pedido Recebido!", _credito.MessagePaymentSuccess());
        }
        [TearDown]
        public void ValueInputCredit()
        {
            Database.ValueInputCredit(0);
        }
    }
}