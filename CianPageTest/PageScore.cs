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
    class PageScore
    {
        IWebDriver driver;

        public readonly By _emotionsButton = By.XPath("//div[@data-title='Нейтрально']");
        private readonly By _commentInputText = By.XPath("//textarea[@class='uxs-Fu3wBavm51 uxs-158rixt']");
        private readonly By _answerButton = By.XPath("//button[@class='uxs-30xgIMVCYs uxs-weow7w']");
        private readonly By _closeButton = By.XPath("//button[@class='uxs-30xgIMVCYs uxs-weow7w']");

        private string _commentText = "...";
        public string _thankYouText = "uxs-3DTPcx41v5 uxs-1kyr5oa";

        public PageScore(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void RatePages()
        {
            var emotion = driver.FindElement(_emotionsButton);
            emotion.Click();
            var comment = driver.FindElement(_commentInputText);
            comment.SendKeys(_commentText);
            var answer = driver.FindElement(_answerButton);
            answer.Click();
        }

        public void ThankYou()
        {
            var close = driver.FindElement(_closeButton);
            close.Click();
        }

        public bool CheckElement(string str)
        {
            try
            {
                driver.PageSource.Contains(str);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
