using OpenQA.Selenium;
using System;

namespace PlaygroundWebTests
{
    internal class Planet
    {
        private WebElement planetElement;
        private string planetName;

        public Planet(WebElement planetElement)
        {
            this.planetElement = planetElement;
        }

        internal string getName()
        {
            return planetElement.FindElement(By.ClassName("name")).Text;
        }

        internal void clickExplore()
        {
            planetElement.FindElement(By.TagName("button")).Click();
        }
    }
}