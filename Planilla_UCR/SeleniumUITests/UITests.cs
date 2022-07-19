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
        
        [Test]
        public void IncompleteRegisterEmployerTest()
        {
            IWebElement registerEmployerButton;
            IWebElement nameTextBox;
            IWebElement lastName1TextBox;
            IWebElement lastName2TextBox;
            IWebElement phoneNumberTextBox;
            IWebElement ssnTextBox;
            IWebElement addressTextBox;
            IWebElement bankAccountTextBox;
            IWebElement passwordTextBox;
            IWebElement confirmPasswordTextBox;
            IWebElement registerButton;
            IWebElement errorMessage =null;

            // Arrange
            string URL = "https://localhost:44304/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;


            //Act
            Thread.Sleep(2000);
            registerEmployerButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(8) > button.mud-button-root.mud-button.mud-button-filled.mud-button-filled-transparent.mud-button-filled-size-medium.mud-ripple"));
            registerEmployerButton.Click();
            Thread.Sleep(2000);
            nameTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(2) > div > div.mud-input-control-input-container > div > input"));
            nameTextBox.SendKeys("Mar�a");

            lastName1TextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(6) > div > div > div > input"));
            lastName1TextBox.SendKeys("Porras");

            lastName2TextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(7) > div > div > div > input"));
            lastName2TextBox.SendKeys("Lopez");

            phoneNumberTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(10) > div > div > div > input"));
            phoneNumberTextBox.SendKeys("89433965");

            ssnTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(11) > div > div > div > input"));
            ssnTextBox.SendKeys("118070615");

            addressTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(14) > div > div > div > input"));
            addressTextBox.SendKeys("SJ,CR");

            bankAccountTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(17) > div > div > div > input"));
            bankAccountTextBox.SendKeys("CR12345678910");

            passwordTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(20) > div > div > div > input"));
            passwordTextBox.SendKeys("Prueba01!");

            confirmPasswordTextBox = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(21) > div > div.mud-input-control-input-container > div > input"));
            confirmPasswordTextBox.SendKeys("Prueba01!");

            registerButton = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > button.mud-button-root.mud-button.mud-button-filled.mud-button-filled-primary.mud-button-filled-size-medium.mud-ripple"));
            Thread.Sleep(2000);
            registerButton.Click();

            Thread.Sleep(2000);
            errorMessage = driver.FindElement(By.CssSelector("#banner > div > div > div > div.mud-grid-item.mud-grid-item-xs-10.mud-grid-item-sm-12 > div > form > div > div:nth-child(3) > div > div.mud-input-control-helper-container.px-2 > p > div > div"));

            //Assert
            Thread.Sleep(2000);
            Assert.IsTrue(errorMessage!=null);
        }
        
    }
}