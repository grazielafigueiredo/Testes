//Quando o usuário comprar crédito, e o saldo for atribuído, então o usuário tenta pagar a comprar de um novo pedido de credito com o saldo que acabou de adquirir

using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;


namespace DotnetQaFront.Landing.CreditoLottocapLading
{
    public class CreditoLottocapLading : BaseTest
    {        
        private LandingPage _landing;
        private CreditoLottocapPage _buycredido;
        private LoginPage _login;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _landing = new LandingPage(Browser);
            _buycredido = new CreditoLottocapPage(Browser);
            _login.With("user22@gmail.com", "1234");
        }

        [Test]
        [Category("landing")]
        public void ShouldProductAndPaymentExists()
        {
            List<String> selectValue = new List<String>();
            selectValue.Add("2");
            selectValue.Add("3");
            selectValue.Add("4");
            selectValue.Add("5");
            selectValue.Add("6");
            selectValue.Add("7");

            _landing.HeaderPaymentCredito();
            Thread.Sleep(1000);

            foreach (String value in selectValue)
            {
                _landing.SelectValue(value);
                Thread.Sleep(4000);
                Assert.That(_landing.FormPaymentExists(), "Não foi encontrado nenhuma forma de pagamento");
            }
        }

        [Test]
        public void BuyCreditoLottocapBetweenValueLimit()
        {
            List<String> inputValue = new List<String>();
            inputValue.Add("2000");
            inputValue.Add("20.01");
            inputValue.Add("500000");
            inputValue.Add("4999.99");

            _landing.HeaderPaymentCredito();
            Thread.Sleep(1000);

            foreach (String value in inputValue)
            {
                _buycredido.InputValue(value);
                Thread.Sleep(3000);
                Assert.That(_landing.FormPaymentExists(), "Não foi encontrado nenhuma forma de pagamento");
            }
        }

        [Test]
        public void BuyCreditoLottocapValueLimit()
        {
            List<String> inputValueBlock = new List<String>();
            inputValueBlock.Add("19.99");
            inputValueBlock.Add("1900");
            inputValueBlock.Add("5000.01");

            _landing.HeaderPaymentCredito();
            Thread.Sleep(1000);

            foreach (String value in inputValueBlock)
            {
                _buycredido.InputValue(value);
                Assert.That(_landing.FormPaymentNoExists(), "Forma de pagamento encontrada para os valores que ultrapassam os limites");
            }
        }
    }
}
