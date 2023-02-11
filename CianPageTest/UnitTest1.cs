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
        [TestCase]
        public void Test1()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ChooseLocationPageObject chooseLocation = new ChooseLocationPageObject(driver);

            mainMenu.ChangeLocation();
            chooseLocation.ClickOneElementOfList(NameList.ByNizhnyNovgorod, mainMenu._locationButton);
            Assert.AreEqual(NameList.ByNizhnyNovgorod, driver.FindElement(mainMenu._locationButton).Text, "Location is wrong");
        }

        [TestCase]
        public void Test2()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            MagazinePageObject magazine = new MagazinePageObject(driver);

            mainMenu.LookingForAnElement();
            var actualSortDate = magazine.GetListsNewsDates().ToList();
            var expectedSortDate = actualSortDate.OrderByDescending(x => x);
            Assert.IsTrue(expectedSortDate.SequenceEqual(actualSortDate), "The sort date is wrong");
        }

        [TestCase]
        public void Test3()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            PageScore pageScore = new PageScore(driver);

            mainMenu.ClickLeaveFeedback();
            pageScore.RatePages();
            Assert.IsTrue(pageScore.RatePages(), "No such element");
            pageScore.ThankYou();
        }

        [TestCase]
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

        [TestCase]
        public void Test5()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            ApartmentComparisonPageObject apartmentComparison = new ApartmentComparisonPageObject(driver);

            mainMenu.ClickElementObjectComparison();
            apartmentComparison.ClickElementSearchApartments();
            apartmentComparison.ClickAddApartment();
            Assert.AreEqual(apartmentComparison._numberApartmentExpected, apartmentComparison._numberApartmentActual, "Added incorrectly");
        }

        [TestCase]
        public void Test6()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);

            Assert.IsFalse(mainMenu.ClickElementAsseptCookies(), "Element exists");
        }

        [TestCase]
        public void Test7()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);

            Assert.That(mainMenu.AllTheTopTabs(), Has.Member("Аренда"));
        }

        [TestCase]
        public void Test8()
        {
            MainMenuPageObject mainMenu = new MainMenuPageObject(driver);
            CianDreamTeamPageObject cianDreamTeam = new CianDreamTeamPageObject(driver);

            mainMenu.ClickElementCareerInCian();
            cianDreamTeam.ClickElementBlogOnHabr();
            Assert.AreEqual(cianDreamTeam.expectedUrl, cianDreamTeam.currentUrl, "Incorrect Url");
        }

        [TestCase]
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

        [TestCase]
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