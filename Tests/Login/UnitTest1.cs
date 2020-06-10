using NUnit.Framework;
using DotnetQaFront.Common;

namespace DotnetQaFront.Tests.Login
{
    public class Tests : BaseTest
    {

        [Test]
        public void MostrarTextoDaPaginaMax()
        {

            Browser.Visit("/lottocap-max");
            Assert.AreEqual("Lottocap Max - Melhor que um bolão da quina e online. Prêmio de R$ 250 mil!", Browser.Title);
        }

        [Test]
        public void MostrarTextoDaPaginaJa()
        {

            Browser.Visit("/lottocap-ja");
            Assert.AreEqual("Lottocap Já - Prêmios de até R$ 500 mil na hora!", Browser.Title);
        }

    }
}