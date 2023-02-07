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
    class ChooseLocationPageObject
    {
        IWebDriver driver;

        // общий локатор для всех городов и регионов
        private readonly By _allCityButton = By.XPath("//button[@class='_025a50318d--city-button--CDYzz']");
        // локатор кнопки "Выбрать"
        private readonly By _chooseButton = By.XPath("//span[@class='_025a50318d--text--rH6sj']");

        public ChooseLocationPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ClickOneElementOfList(string nameList)
        {
            var any = driver.FindElements(_allCityButton).FirstOrDefault(x => x.Text == nameList);
            any.Click();

            var choose = driver.FindElement(_chooseButton);
            choose.Click();
        }
    }
}
