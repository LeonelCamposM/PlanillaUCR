using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumUITests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void DavidEmployerLogginTest()
        {
            IWebElement textBox;
            IWebElement passBox;
            IWebElement loginButton;

            // Arrange
            string URL = "https://localhost:44304/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;

            //Act
            Thread.Sleep(2000);
            textBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(2) > div > div.mud-input-control-input-container > div > input"));
            textBox.SendKeys("david@ucr.ac.cr");
            passBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(5) > div > div > div > input"));
            passBox.SendKeys("Prueba01!");
            loginButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(8) > button.mud-button-root.mud-button.mud-button-filled.mud-button-filled-primary.mud-button-filled-size-medium.mud-ripple > span > p"));
            Thread.Sleep(2000);
            loginButton.Click();

            //Assert
            Thread.Sleep(2000);
            string currentURL = driver.Url;
            string expectedURL = "https://localhost:44304/DashboardEmployer/david@ucr.ac.cr/";
            Assert.IsTrue(currentURL.Equals(expectedURL));
        }
    }
}