using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class SaveSearchPageObject : OftenUsedFunctions
    {
        private readonly By _saveSearchButtun = By.XPath("//span[text()='Сохранить поиск']");
        private readonly By _frequenceNotificationButton = By.XPath("//div[@class='_93444fe79c--label-wrapper--RJwrx']");
        private readonly By _allfrequenceNotificationButton = By.XPath("//div[@class='_93444fe79c--label--h1kOF']");
        private readonly By _emailInput = By.XPath("(//input[@class='_93444fe79c--input--MqKSA'])[2]");
        private readonly By _newsCianCheckBox = By.XPath("(//span[@class='_93444fe79c--label--S9Iv9'])[1]");
        private readonly By _pushNotification = By.XPath("(//span[@class='_93444fe79c--label--S9Iv9'])[2]");
        private readonly By _saveButton = By.XPath("//div[@class='_93444fe79c--field--VssYf']/child::button");
        public readonly By _saveSearchText = By.XPath("//div[@class='_93444fe79c--title--ZW9Va _93444fe79c--title--mr_4E']");

        public string _saveSearch = "Сохранение поиска";
        public string _email = "meow@cia.ru";

        public SaveSearchPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void SaveSearch(string freq)
        {
            ClickElement(_saveSearchButtun);
            WaitElementToBeVisible(_frequenceNotificationButton);
            ClickElement(_frequenceNotificationButton);
            var any = driver.FindElements(_allfrequenceNotificationButton).FirstOrDefault(x => x.Text == freq);
            any.Click();
            var email = driver.FindElement(_emailInput);
            email.SendKeys(_email);
            ClickElement(_newsCianCheckBox);
            ClickElement(_pushNotification);
            ClickElement(_saveButton);
        }

    }
}
