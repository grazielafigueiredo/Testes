using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using DotnetQaFront.Lib;

namespace DotnetQaFront.Tests.MethodPay
{
    public class Boleto : BaseTest
    {
        private LoginPage _login;
        private ProductPage _product;
        private PaymentCartPage _cart;
        private BoletoPage _boleto;
        private DataFirstAccess _dataAccess;


        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _product = new ProductPage(Browser);
            _cart = new PaymentCartPage(Browser);
            _boleto = new BoletoPage(Browser);
            _dataAccess = new DataFirstAccess(Browser);
            Database.ClearDataFirstAccess();
            _login.With("user22@gmail.com", "1234");
        }

        [Test]
        [Category("boleto")]
        [Category("pagamento")]

        public void PayBoleto()
        {
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _boleto.SelectBoleto();
            _dataAccess.InputDataFirstAccess();
            _boleto.ConfirmPaymentBoleto();

            Assert.AreEqual("Pedido Recebido!", _boleto.MessagePaymentSuccess());
        }
    }
}