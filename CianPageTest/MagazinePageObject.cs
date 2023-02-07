using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace CianPageTest
{
    class MagazinePageObject
    {

        IWebDriver driver;

        private readonly By _allTheDateNews = By.XPath("//span[@itemprop='datePublished']");

        public MagazinePageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public IEnumerable<DateTime> GetListsNewsDates()
        {
            var tableColumnData_ = driver.FindElements(_allTheDateNews);
            IEnumerable<DateTime> dateTimes = tableColumnData_.Select(x => DateTime.Parse(x.Text));

            return dateTimes;
        }
    }
}
