using DotnetQaFront.Common;
using DotnetQaFront.Pages;
using NUnit.Framework;


namespace DotnetQaFront.Landing.MaxLading
{
    public class MaxLading : BaseTest
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
            _landing.HeaderMax();
            Assert.That(_landing.ProductExists(), "Erro ao verificar que o produto MAX está disponível na landing");
        }
    }
}
