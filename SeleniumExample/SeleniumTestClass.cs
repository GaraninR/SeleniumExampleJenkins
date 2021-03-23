using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumExample
{
    class SeleniumTestClass
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("d:\\selenium_drivers");
            driver.Manage().Window.Maximize();
        }

        /*[Test]
        public void goToHomePage()
        {
            driver.Url = "http://192.168.15.12:8777/";            
            Thread.Sleep(3);
        } */

        [Test]
        public void login()
        {
            driver.Url = "http://192.168.56.1:8997/login";
            
            IWebElement emailFiel = driver.FindElement(By.Id("Email"));
            emailFiel.Click();
            emailFiel.SendKeys("garanin@rikaol.by");

            IWebElement passwordFiel = driver.FindElement(By.Id("Password"));
            passwordFiel.Click();
            passwordFiel.SendKeys("123456");

            IWebElement sendButton = driver.FindElement(By.XPath("//div[@class='customer-blocks']//form/div[@class='buttons']/input"));
            sendButton.Click();

            IWebElement logoutLink = driver.FindElement(By.XPath("//div[@class='header-links']/ul/li[2]/a[@href='/logout']"));
            Assert.NotNull(logoutLink);

            Thread.Sleep(3000);
        }

        [Test]
        public void loginFailed()
        {
            driver.Url = "http://192.168.56.1:8997/login";

            IWebElement emailFiel = driver.FindElement(By.Id("Email"));
            emailFiel.Click();
            emailFiel.SendKeys("garanin@rikaol.by");

            IWebElement passwordFiel = driver.FindElement(By.Id("Password"));
            passwordFiel.Click();
            passwordFiel.SendKeys("654321");

            IWebElement sendButton = driver.FindElement(By.XPath("//div[@class='customer-blocks']//form/div[@class='buttons']/input"));
            sendButton.Click();

            var logoutLink = driver.FindElements(By.XPath("//div[@class='header-links']/ul/li[2]/a[@href='/logout']"));

            Console.WriteLine(logoutLink.Count);

            Assert.That(logoutLink.Count == 0);

            Thread.Sleep(3000);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
