using NUnit.Framework;
using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using DotnetQaFront.Lib;
using System.Threading;

namespace DotnetQaFront.Tests.Crud
{
    public class EscolhaDezena : BaseTest
    {

        private LoginPage _login;
        private ProductPage _product;
        private PaymentCartPage _cart;
        private ModalPreVenda _modal;
        private DataFirstAccess _dataAccess;


        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _product = new ProductPage(Browser);
            _cart = new PaymentCartPage(Browser);
            _modal = new ModalPreVenda(Browser);
            _dataAccess = new DataFirstAccess(Browser);
            Database.ClearDataFirstAccess();
            _login.With("user22@gmail.com", "1234");
        }

        [Test]
        [Category("preVenda")]

        public void AddThreeDezenas()
        {
            Browser.Visit("https://qa2.lottocap.com.br/");

            _product.SelectVitrinePreVenda();
            _modal.SelectUniqueDezenas();
            Thread.Sleep(5000);

            Assert.That(_modal.ButtonConfirmEnableDezena());
        }
        [Test]
        public void RandomAndDeleteButtonConfirmDisabledDezena()
        {
            Browser.Visit("https://qa2.lottocap.com.br/");

            _product.SelectVitrinePreVenda();
            _modal.RandomDezenas();
            Assert.That(_modal.ButtonConfirmEnableDezena());
            _modal.DeleteDezenas();
            Assert.That(_modal.ButtonConfirmDisabledDezena());
            _modal.DeleteDezenas();
            Assert.That(_modal.ButtonConfirmDisabledDezena());
            _modal.DeleteDezenas();
            Assert.That(_modal.ButtonConfirmDisabledDezena());
            _modal.CloseModalDezenas();
        }
        [Test]
        public void DeleteAndRandomModalTitulo()
        {
            Browser.Visit("https://qa2.lottocap.com.br/");

            _product.AddProductPreVenda();
            _modal.ViewDezenas();
            _modal.AddNewTitulo();
            _modal.RandomDezenas();
            _modal.ChooseVitrineDezenas();
            Assert.AreEqual("2", _modal.amountTitulos());
            _modal.DeleteTitulo();
            _modal.CanceledDeleteTitulo();
            Assert.AreEqual("2", _modal.amountTitulos());
            _modal.DeleteTitulo();
            _modal.ConfirmDeleteTitulo();
            Assert.AreEqual("1", _modal.oneTitulo());

        }
    }
}