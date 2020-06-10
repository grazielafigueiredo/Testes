using System;
using Coypu;
using Coypu.Drivers.Selenium;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace DotnetQaFront.Common
{
    public class BaseTest
    {
        // public String nome;
        // private String _nome;
        // protected String Nome;
        protected BrowserSession Browser;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();


            var sessionConfig = new SessionConfiguration
            {
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Firefox,
                Timeout = TimeSpan.FromSeconds(50),
                // ConsiderInvisibleElements = true
            };
            if (config["appHost"].Equals("qa1"))
            {
                sessionConfig.AppHost = "https://qa1.lottocap.com.br";
            }
            if (config["appHost"].Equals("qa2"))
            {
                sessionConfig.AppHost = "https://qa2.lottocap.com.br";
            }
            if (config["appHost"].Equals("dev1"))
            {
                sessionConfig.AppHost = "https://dev1.lottocap.com.br";
            }
            if (config["appHost"].Equals("dev2"))
            {
                sessionConfig.AppHost = "https://dev2.lottocap.com.br";
            }
 
            Browser = new BrowserSession(sessionConfig);

            Browser.MaximiseWindow();
        }

        [TearDown]

        public void Finish()
        {
            Browser.Dispose();
        }
    }
}