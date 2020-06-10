using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using NUnit.Framework;


namespace DotnetQaFront.Landing.JaLading
{
    public class JaLading : BaseTest
    {        
        private LandingPage _landing;

        [SetUp]
        public void Before()
        {
            _landing = new LandingPage(Browser);
        }


        [Test]
        public void ShouldProductExists()
        {
            Browser.Visit("/");
            _landing.HeaderJa();
            Assert.That(_landing.ProductExists(), "Erro ao verificar que o produto JÁ está disponível na landing");
        }
    }
}
