using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System;

namespace AutoTest {
    [TestFixture]
    public class Test {
        private static string igWorkDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //find dll
        private static IWebDriver driver;

        [OneTimeSetUp] // before all tests
        public void OneTimeSetUp() {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown] //after all tests
        public void OneTimeTearDown() {
            driver.Quit();
        }

        [SetUp] //before every test
        public void SetUp() {
            driver.Navigate().GoToUrl("http://localhost:50723/Index.aspx");
        }

        [TearDown] //after every test
        public void TearDown() {
            Thread.Sleep(1000);
        }

        [Test]
        public void GoToAbout_Test() {
            var hlkAbout = driver.FindElement(By.Id("hlkAbout"));
            hlkAbout.Click();
            var body = driver.FindElement(By.TagName("body"));
            bool result = body.Text.Contains("тел. 123-45-67");
            Assert.AreEqual(result, true);
        }

        [Test]
        public void Login_Test() {
            const string login = "asd@asd.ru";
            const string cph = "ContentPlaceHolder1_";

            driver.FindElement(By.Id("hlkLogin")).Click();
            driver.FindElement(By.Id(cph + "txtLogin")).SendKeys(login);
            driver.FindElement(By.Id(cph + "txtPasword")).SendKeys("111111");
            driver.FindElement(By.Id(cph + "btnConfirm")).Click();

            //Thread.Sleep(10000);
            var hlkStatus = driver.FindElement(By.Id("hlkStatus"));
            bool result = hlkStatus.Text.Contains(login.ToUpper());

            Assert.AreEqual(result, true);
        }
    }
}
