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
            Assert.AreEqual(peakPage._checkResultRealEstate, driver.FindElement(peakPage._realEstateValueInput).GetAttribute("value"), "Error");
            Assert.AreEqual(peakPage._checkResultInitialFee, driver.FindElement(peakPage._anInitialFeeInput).GetAttribute("value"), "Error");
            Assert.AreEqual(peakPage._checkResultCreditTerm, driver.FindElement(peakPage._creditTermInput).GetAttribute("value"), "Error");
            Assert.AreEqual(peakPage._checkResultInterestRate, driver.FindElement(peakPage._interestRateInput).GetAttribute("value"), "Error");
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

            Assert.That(mainMenu.AllTheTopTabs(), Has.Member("Аренда"));
        }

        [Test]
        public void Test8()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            CianDreamTeamPageObject cianDreamTeam = new CianDreamTeamPageObject(driver);

            mainMenu.ClickElementCareerInCian();
            cianDreamTeam.ClickElementBlogOnHabr();
            Assert.AreEqual(cianDreamTeam.expectedUrl, cianDreamTeam.currentUrl, "Incorrect Url");
        }

        [Test]
        public void Test9()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ApartmentComparisonPageObject apartmentComparison = new ApartmentComparisonPageObject(driver);
            SaveToFavoritesPageObject saveToFavorites = new SaveToFavoritesPageObject(driver);

            mainMenu.ClickElementSaveOfFavorites();
            apartmentComparison.ClickElementSearchApartments();
            saveToFavorites.SaveToFavorites();
            Assert.AreEqual(saveToFavorites._saveToFavorites, driver.FindElement(saveToFavorites._saveToFavoritesText).Text, "Not saved");
            saveToFavorites.RemoveFromFavorites();
            Assert.AreEqual(saveToFavorites._removeToFavorites, driver.FindElement(saveToFavorites._removeToFavoritesTest).Text, "Not removed");
        }

        [Test]
        public void Test10()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ApartmentComparisonPageObject apartmentComparison = new ApartmentComparisonPageObject(driver);
            SaveSearchPageObject saveSearch = new SaveSearchPageObject(driver);

            mainMenu.ClickElementSaveOfFavorites();
            apartmentComparison.ClickElementSearchApartments();
            saveSearch.SaveSearch("Раз в неделю");
            Assert.AreEqual(saveSearch._saveSearch, driver.FindElement(saveSearch._saveSearchText).Text, "Not saved search");
        }
    }
}