#!/usr/bin/env dotnet-script
#r "nuget: Coypu, 3.1.1"
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;

var sessionConfig = new SessionConfiguration
            {
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(30),
                AppHost = "https://dev1.lottocap.com.br"
                // ConsiderInvisibleElements = true
            };

var _browser = new BrowserSession(sessionConfig);

_browser.Visit("https://qa2.lottocap.com.br/");
_browser.FindCss("button", text: "Escolha as dezenas do seu título").Click();

_browser.FindCss("span", text: "Ver dezenas dos títulos").Click();
_browser.FindCss("button", text: "+ Adicionar título").Click();
Thread.Sleep(2000);
_browser.FindCss("span", text: "Aleatório").Click();
Thread.Sleep(2000);
_browser.FindCss("span", text: "Apagar").Click();
Thread.Sleep(2000);
_browser.FindCss("span", text: "Apagar").Click();
Thread.Sleep(2000);
_browser.FindCss("span", text: "Apagar").Click();
_browser.FindCss("li > span", text: "01").Click();
_browser.FindCss("li > span", text: "17").Click();
_browser.FindCss("li > span", text: "54").Click();
_browser.FindCss("button", text: "Confirmar escolha").Click();

// v2 Comando para excluir item modal
_browser.FindCss("li:nth-child(1) > span", text : "excluir").Click();

_browser.FindCss("button", text: "Excluir").Click();
_browser.FindCss("button", text: "Confirmar").Click();





// Browser.FindCss("#root > section > div > div > div.col-xl-6.carrinho > div.carrinho__item.carrinho__item--pre-venda").Click();

// browser.FindXPath("Ver dezenas dos títulos");
// Browser.FindCss("span”, text: "Ver dezenas dos títulos”).Click();


// document.querySelector("")

// document.querySelector("")


// Browser.FindCss("#root > header > div > div > div.col-xl-5.col-8 > div > div.Header__login").Click();


// document.querySelector("#root > header > button")

// document.querySelector()