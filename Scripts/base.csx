#!/usr/bin/env dotnet-script
#r "nuget: Coypu, 3.1.1"
using Coypu;
using Coypu.Drivers.Selenium;

var sessionConfig = new SessionConfiguration
            {
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(5),
                AppHost = "https://dev1.lottocap.com.br"
                // ConsiderInvisibleElements = true
            };

var _browser = new BrowserSession(sessionConfig);
