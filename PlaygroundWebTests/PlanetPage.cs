using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PlaygroundWebTests
{
    internal class PlanetPage
    {
        private WebDriver driver;

        public PlanetPage(WebDriver driver)
        {
            this.driver = driver;
        }

        internal object getPlanet(Predicate<Planet> testLogic)
        {
            for (WebElement planetElement : driver.FindElement(By.ClassName("planet")))
            {
                var planet = new Planet(planetElement);
                if (testLogic.test(planet))
                {
                    return planet;
                }
            }
            throw new NotFoundException("Could not find planet");
        }

        internal void clickExplore(Planet planet)
        {
            planet.clickExplore();
            waitForPopupMessage();
        }

        internal void waitForPopupMessage()
        {
            var popupElement = driver.FindElement(By.ClassName("popup-message"));
            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(d => popupElement.Displayed);
        }

        internal string getPopupText()
        {
            return getPopupMessage().Text;
        }

        internal WebElement getPopupMessage()
        {
            return driver.FindElement(By.ClassName("popup-message"));
        }
    }
}