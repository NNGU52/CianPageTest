using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace CianPageTest
{
    [TestFixture]

    public class Tests : BaseClass
    {
        [Test]
        public void Test1()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ChooseLocationPageObject chooseLocation = new ChooseLocationPageObject(driver);

            mainMenu.ChangeLocation();
            chooseLocation.ClickOneElementOfList(NameList.ByNizhnyNovgorod);
            mainMenu.WaitElement(driver.FindElement(mainMenu._locationButton), NameList.ByNizhnyNovgorod);
            Assert.AreEqual(NameList.ByNizhnyNovgorod, driver.FindElement(mainMenu._locationButton).Text, "Location is wrong");
        }

        [Test]
        public void Test2()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            MagazinePageObject magazine = new MagazinePageObject(driver);

            mainMenu.LookingForAnElement();
            var actualSortDate = magazine.GetListsNewsDates().ToList();
            var expectedSortDate = actualSortDate.OrderByDescending(x => x);
            Assert.IsTrue(expectedSortDate.SequenceEqual(actualSortDate), "The sort date is wrong");
        }

        [Test]
        public void Test3()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            PageScore pageScore = new PageScore(driver);

            mainMenu.WaitElement(mainMenu._feedbackButton);
            mainMenu.ClickLeaveFeedback();
            mainMenu.WaitElement(pageScore._emotionsButton);
            pageScore.RatePages();
            Assert.IsTrue(pageScore.CheckElement(pageScore._thankYouText), "No such element");
            pageScore.ThankYou();
        }

        [Test]
        public void Test4()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            PeakPageObject peakPage = new PeakPageObject(driver);

            mainMenu.ClickElementPeak();
            peakPage.CalculateMortgage();
            Assert.AreEqual(peakPage._checkResultRealEstate, driver.FindElement(peakPage._realEstateValueInput).GetAttribute("value"), "");
        }

        [Test]
        public void Test5()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ApartmentComparisonPageObject apartmentComparison = new ApartmentComparisonPageObject(driver);

            mainMenu.ClickElementObjectComparison();
            apartmentComparison.ClickElementSearchApartments();
            apartmentComparison.ClickAddApartment();
            Assert.AreEqual(apartmentComparison._numberApartmentExpected, apartmentComparison._numberApartmentActual, "Added incorrectly");
        }

        [Test]
        public void Test6()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);

            Assert.IsFalse(mainMenu.ClickElementAsseptCookies(), "Element exists");
        }

        [Test]
        public void Test7()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);

            Assert.That(mainMenu.AllTheTopTabs(), Has.No.Member("Аренда"));
        }

        [Test]
        public void Test8()
        {
            
        }

        [Test]
        public void Test9()
        {
            
        }

        [Test]
        public void Test10()
        {
            
        }
    }
}