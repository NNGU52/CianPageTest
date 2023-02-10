using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CianPageTest
{
    class SaveToFavoritesPageObject
    {
        IWebDriver driver;

        private readonly By _oneApartmentForm = By.XPath("(//span[@class='_93444fe79c--link-area--NQqFo'])[1]");
        private readonly By _addOneApartmentInFavorites = By.XPath("//button[@data-mark='FavoritesControl']");
        public readonly By _saveToFavoritesText = By.XPath("//div[@class='_93444fe79c--message--BHjBi']");
        public readonly By _removeToFavoritesTest = By.XPath("//div[@class='_93444fe79c--body--HBy2Z']/child::span");

        public string _saveToFavorites = "Сохранено в избранное";
        public string _removeToFavorites = "Удалено из избранного";

        public SaveToFavoritesPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void SaveToFavorites()
        {
            Actions builder = new Actions(driver);
            // добавлена к сравнению 1 квартира
            var oneApartment = driver.FindElement(_oneApartmentForm);
            builder.MoveToElement(oneApartment).Perform();
            var addFavorites = driver.FindElement(_addOneApartmentInFavorites);
            addFavorites.Click();
        }

        public void RemoveFromFavorites()
        {
            var addFavorites = driver.FindElement(_addOneApartmentInFavorites);
            addFavorites.Click();
        }
    }
}
