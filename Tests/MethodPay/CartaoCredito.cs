using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using DotnetQaFront.Models;
using DotnetQaFront.Lib;

namespace DotnetQaFront.Tests.MethodPay
{
    public class CartaoCredito : BaseTest
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

        [Test]
        [Category("pagamento")]
        [Category("cartao")]

        public void PaymnentCreditCard()
        {
            var cartaoCreditoData = new CreditCardModel()
            {
                Name = "Meu Cartao",
                NumberCard = "4242424242424242",
                ValidationCard = "1120",
                NumberCardSegrete = "123",
            };

            
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _cartao.SelectCreditCard();
            _dataAccess.InputDataFirstAccess();
            _cartao.CartaoCreditoData(cartaoCreditoData);
            _cartao.ConfirmPaymentCreditCard();

            Assert.AreEqual("Pedido Recebido!", _cartao.MessagePaymentSuccess());
        }
        [Test]
        public void PaymnentCreditCardSaved()
        {
            var cartaoCreditoData = new CreditCardModel()
            {
                Name = "Meu Cartao",
                NumberCard = "4242424242424242",
                ValidationCard = "1120",
                NumberCardSegrete = "123",
            };

            
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _cartao.SelectCreditCard();
            _dataAccess.InputDataFirstAccess();
            _cartao.CartaoCreditoData(cartaoCreditoData);
            _cartao.ConfirmPaymentCreditCard();

            Assert.AreEqual("Pedido Recebido!", _cartao.MessagePaymentSuccess());

            Browser.Visit("/");
            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _cartao.SelectCreditCard();
            _cartao.ConfirmPaymentCreditCard();

            Assert.AreEqual("Pedido Recebido!", _cartao.MessagePaymentSuccess());
        }
    }
}