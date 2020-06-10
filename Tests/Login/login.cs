using NUnit.Framework;
using DotnetQaFront.Pages;
using DotnetQaFront.Common;
using DotnetQaFront.Lib;

namespace DotnetQaFront.Tests.Login
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;
        private AreaLogada _alert;

        [SetUp]

        public void Start()
        {
            _login = new LoginPage(Browser);
            _alert = new AreaLogada(Browser);
        }

        [Test]
        public void SucessoLogin()
        {
            _login.With("user22@gmail.com", "1234");
            Assert.AreEqual("😃 Olá user! 🎉", _alert.AlertMessage());
        }


        [TestCase("user22@gmail.com.123", "", "Senha é obrigatória.")]
        [TestCase("1@11", "1234", "Informe um email válido.")]
        [TestCase("", "1234", "E-mail é obrigatório.")]
        public void InputLoginInvalido(string email, string pass, string expectMessage)
        {
            _login.With(email, pass);            
            Assert.IsTrue(_login.ExistsMessageInsideSpan(expectMessage));
        }

        [Test]
        public void LoginInvalido()
        {
            _login.With("user22@gmail.com", "123499");            
            Assert.AreEqual("* Usuário e/ou Senha incorretos.", _login.ErrorMessageLogin());
        }
    }
}