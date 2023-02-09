using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class CianDreamTeamPageObject
    {
        IWebDriver driver;

        private readonly By _blogOnHabrButton = By.XPath("//div[@data-id='5fcce2fa57c044009f261644']");

        public string currentUrl = "";
        public string expectedUrl = "https://habr.com/ru/company/cian/blog/";

        public CianDreamTeamPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void ClickElementBlogOnHabr()
        {
            currentUrl = driver.Url;
            WaitElement(currentUrl);
            var blogOnHabr = driver.FindElement(_blogOnHabrButton);
            blogOnHabr.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            currentUrl = driver.Url;
        }

        public void WaitElement(string url)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(url));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Not found: {url}", ex);
            }
        }



    }
}
