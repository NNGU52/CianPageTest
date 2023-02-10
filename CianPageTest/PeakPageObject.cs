using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CianPageTest
{
    class PeakPageObject
    {
        IWebDriver driver;

        private readonly By _calculateMortgageForm = By.XPath("//div[@class='_9330de7794--side--m7mv9']");
        private readonly By _sliderSlider1 = By.XPath("(//span[@role='slider'])[1]");
        private readonly By _sliderSlider2 = By.XPath("(//span[@role='slider'])[2]");
        private readonly By _sliderSlider3 = By.XPath("(//span[@role='slider'])[3]");
        private readonly By _sliderSlider4 = By.XPath("(//span[@role='slider'])[4]");
        public readonly By _realEstateValueInput = By.XPath("(//input[@class='_9330de7794--input--YmTjn'])[1]");
        public readonly By _anInitialFeeInput = By.XPath("(//input[@class='_9330de7794--input--YmTjn'])[2]");
        public readonly By _creditTermInput = By.XPath("(//input[@class='_9330de7794--input--YmTjn'])[3]");
        public readonly By _interestRateInput = By.XPath("(//input[@class='_9330de7794--input--YmTjn'])[4]");

        public string _checkResultRealEstate = "6 950 000";
        public string _checkResultInitialFee = "4 965 000";
        public string _checkResultCreditTerm = "21";
        public string _checkResultInterestRate = "8,6";

        public PeakPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void CalculateMortgage()
        {
            Actions builder = new Actions(driver);
            var mortgage = driver.FindElement(_calculateMortgageForm);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", mortgage);
            Thread.Sleep(200);
            var realEstate = driver.FindElement(_realEstateValueInput);
            realEstate.Clear();
            realEstate.SendKeys("7000000");
            var initialFee = driver.FindElement(_anInitialFeeInput);
            initialFee.Clear();
            initialFee.SendKeys("5000000");
            var creditTerm = driver.FindElement(_creditTermInput);
            creditTerm.Clear();
            creditTerm.SendKeys("15");
            var interestRate = driver.FindElement(_interestRateInput);
            interestRate.Clear();
            interestRate.SendKeys("7");
            var slider1 = driver.FindElement(_sliderSlider1);
            var slider2 = driver.FindElement(_sliderSlider2);
            var slider3 = driver.FindElement(_sliderSlider3);
            var slider4 = driver.FindElement(_sliderSlider4);
            builder.MoveToElement(slider1).ClickAndHold().MoveByOffset(0,250).Release().Perform();
            Thread.Sleep(100);
            builder.MoveToElement(slider2).ClickAndHold().MoveByOffset(0, 300).Release().Perform();
            Thread.Sleep(100);
            builder.MoveToElement(slider3).ClickAndHold().MoveByOffset(100, 0).Release().Perform();
            Thread.Sleep(100);
            builder.MoveToElement(slider4).ClickAndHold().MoveByOffset(100, 0).Release().Perform();
            Thread.Sleep(100);
        }
    }
}
