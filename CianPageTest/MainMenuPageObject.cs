using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class MainMenuPageObject
    {
        IWebDriver driver;

        private readonly By _locationButton = By.XPath("//span[@class='_025a50318d--text--SCFDt']");


        public MainMenuPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ChangeLocation()
        {
            var nameBy = driver.FindElement(_locationButton);
            nameBy.Click();
        }

    }
}
