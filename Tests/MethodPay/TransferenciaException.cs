using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using DotnetQaFront.Models;
using DotnetQaFront.Lib;

namespace DotnetQaFront.Tests.MethodPay
{
    public class TransferenciaException : BaseTest
    {
        private LoginPage _login;
        private ProductPage _product;
        private PaymentCartPage _cart;
        private TransferenciaPage _transferencia;


        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _product = new ProductPage(Browser);
            _cart = new PaymentCartPage(Browser);
            _transferencia = new TransferenciaPage(Browser);
            _login.With("user22@gmail.com", "1234");
            Database.InsertAccount();
            Database.InsertDataFirstAccess();
        }

        [Test]
        [Category("pagamento")]
        [Category("transferencia")]

        public void PaymnentTransferenciaBradesco()
        {
            var TransferenciaBradescoData = new TransferenciaModel()
            {
                Titular = "Sou titular",
                Agencia = "9876",
                Conta = "1120",
                Digito = "1",
            };

            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _transferencia.SelectTransferencia();
            _transferencia.AddAccount();
            _transferencia.TransferenciaBradescoData(TransferenciaBradescoData);
            _transferencia.ConfirmPaymentTransferencia();

            Assert.AreEqual("* Essa conta bancária já foi adicionada anteriormente.", _transferencia.MessagePaymentException());
        }

        [Category("pagamento")]
        [Category("transferencia")]
        [Test]
        public void PaymnentTransferenciaItau()
        {
            var TransferenciaItauData = new TransferenciaModel()
            {
                Titular = "Meu titulo",
                Agencia = "42424",
                Conta = "11201",
                Digito = "1",
            };

            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _transferencia.SelectTransferencia();
            _transferencia.AddAccount();
            _transferencia.TransferenciaItauData(TransferenciaItauData);
            _transferencia.ConfirmPaymentTransferencia();

            Assert.AreEqual("* Essa conta bancária já foi adicionada anteriormente.", _transferencia.MessagePaymentException());
        }

        [Test]
        [Category("pagamento")]
        [Category("transferencia")]
        public void PaymnentTransferenciaSantander()
        {
            var TransferenciaSantanderData = new TransferenciaModel()
            {
                Cpf = "00000009652",
            };

            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _transferencia.SelectTransferencia();
            _transferencia.AddAccount();
            _transferencia.TransferenciaSantanderData(TransferenciaSantanderData);
            _transferencia.ConfirmPaymentTransferencia();

            Assert.AreEqual("* Essa conta bancária já foi adicionada anteriormente.", _transferencia.MessagePaymentException());
        }

        [Test]
        [Category("pagamento")]
        [Category("transferencia")]
        public void PaymnentTransferenciaBrasil()
        {
            var TransferenciaBrasilData = new TransferenciaModel()
            {
                Titular = "Meu Cartao",
                Agencia = "4242",
                DigitoAgencia = "2",
                Conta = "1120",
                Digito = "1",
            };

            _product.AddProductCartPay();
            _cart.ConfirmPaymentCart();
            _transferencia.SelectTransferencia();
            _transferencia.AddAccount();
            _transferencia.TransferenciaBrasilData(TransferenciaBrasilData);
            _transferencia.ConfirmPaymentTransferencia();

            Assert.AreEqual("* Essa conta bancária já foi adicionada anteriormente.", _transferencia.MessagePaymentException());
        }

        [TearDown]
        public void RemoveAccount()
        {
            Database.RemoveAccount();
        }
    }
}