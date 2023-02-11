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
    class CianDreamTeamPageObject : OftenUsedFunctions
    {
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
            WaitElementUrlToBe(currentUrl);
            ClickElement(_blogOnHabrButton);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(100);
            currentUrl = driver.Url;
        }
    }
}
