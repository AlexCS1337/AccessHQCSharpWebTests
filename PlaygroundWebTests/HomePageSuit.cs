using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PlaygroundWebTests
{
    [TestClass]
    public class HomePageSuit
    {
        WebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.FullScreen();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/";
        }
        [TestMethod]
        public void TestSubmitButton()
        {
            // Arrange
            driver.FindElement(By.Id("forename")).SendKeys("Blah");

            // Act
            driver.FindElement(By.Id("submit")).Click();
            var popupElement = driver.FindElement(By.ClassName("popup-message"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(d => popupElement.Displayed);
          
            // Assert
            Assert.AreEqual("Hello Blah", popupElement.Text);
        }

        [TestMethod]
        public void Verify_Exploring_Earth()
        {
            //Arrange
            driver.FindElement(By.CssSelector("[aria-label=planets]")).Click();

            //Act
            String planetName = GetPlanetName();
            PlanetPage planetPage = new PlanetPage(driver);
            planetPage.getPlanet(p => p.getName() == planetName);

            //Assert
            Assert.AreEqual("Exploring Earth", planetPage.getPopupText());
        }

        private string GetPlanetName()
        {
            return "Earth";
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
