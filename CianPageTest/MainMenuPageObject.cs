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
    class MainMenuPageObject : OftenUsedFunctions
    {
        public readonly By _locationButton = By.XPath("//span[@class='_025a50318d--text--SCFDt']");
        private readonly By _rentButton = By.XPath("//a[@class='_25d45facb5--link--rqF9a']");
        private readonly By _magazineButton = By.XPath("//span[@data-testid='dropdown_link_icon']");
        public readonly By _feedbackButton = By.XPath("//img[@class='uxs-17nl1ib uxs-2O1rU349bI']");
        private readonly By _peakButton = By.XPath("//a[@data-name='SpecialPromoDesktop']");
        private readonly By _objectComparisonButton = By.XPath("//a[@data-name='UtilityCompareContainer']");
        private readonly By _asseptCookiesButton = By.XPath("//div[@class='_25d45facb5--button--CaFmg']");
        private readonly By _allTheTopTabs = By.CssSelector("._25d45facb5--link--rqF9a");
        private readonly By _careerInCianButton = By.XPath("//a[@href='https://team.cian.tech/']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ChangeLocation()
        {
            ClickElement(_locationButton);
        }

        public void LookingForAnElement()
        {
            var rentBy = driver.FindElement(_rentButton);
            Actions builder = new Actions(driver);
            builder.MoveToElement(rentBy).Perform();
            WaitElementToBeVisible(_magazineButton);
            ClickElement(_magazineButton);
        }

        public void ClickLeaveFeedback()
        {
            WaitElementToBeVisible(_feedbackButton);
            ClickElement(_feedbackButton);
        }

        public void ClickElementPeak()
        {
            ClickElement(_peakButton);
        }

        public void ClickElementObjectComparison()
        {
            ClickElement(_objectComparisonButton);
        }

        public bool ClickElementAsseptCookies()
        {
            ClickElement(_asseptCookiesButton);

            return CheckElementLocator(_asseptCookiesButton);
        }

        public List<string> AllTheTopTabs()
        {
            var list = driver.FindElements(_allTheTopTabs).Select(x => x.Text).ToList();
            return list;
        }

        public void ClickElementCareerInCian()
        {
            var career = driver.FindElement(_careerInCianButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", career);
            career.Click();
        }

        public void ClickElementSaveOfFavorites()
        {
            ClickElement(_objectComparisonButton);
        }
    }
}
