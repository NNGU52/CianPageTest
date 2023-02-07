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

        //[Test]
        //public void Test2()
        //{
            
        //}

        //[Test]
        //public void Test3()
        //{
            
        //}

        //[Test]
        //public void Test4()
        //{
            
        //}
    }
}