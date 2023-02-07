using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace CianPageTest
{
    public class BaseClass
    {
        protected static IWebDriver driver;

        [OneTimeSetUp]
        protected void DoBeforeAllTheTests()
        {
            var options = new ChromeOptions();
            // измененить user-agent
            options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:90.0) Gecko/20100101 Firefox/90.0");
            // отключить расширения selenium
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddAdditionalOption("useAutomationExtension", false);
            // убрать надпись сообщающую о том, что "Браузером Chrome управляет автоматизированное тестовое ПО"
            options.AddExcludedArgument("--enable-automation");

            driver = new ChromeDriver(options);
        }

        [SetUp]
        protected void DoBeforeEach()
        {
            driver.Navigate().GoToUrl(TestSettings.HostPrefix);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        protected void DoAfterEach()
        {
           //driver.Quit();
        }
    }
}
