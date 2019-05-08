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
        private Process iisProcessExpress;

        [OneTimeSetUp] // before all tests
        public void OneTimeSetUp() {
            //StartIisExpress();
            //Thread.Sleep(3000);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl(@"localhost");
            //Thread.Sleep(3000);

        }

        [OneTimeTearDown] //after all tests
        public void OneTimeTearDown() {
            driver.Quit();

            //if (iisProcessExpress.HasExited == false) {
            //    iisProcessExpress.Kill();
            //}
        }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp() {
            driver.Navigate().GoToUrl("http://localhost:50723/Index.aspx");
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown() {
            Thread.Sleep(1000);
        }

        //[Conditional("DEBUG")]
        //private void StartIisExpress() {
        //    // var applicationPath = GetApplicationPath("web-shop-v2");
        //    string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        //    var startInfo = new ProcessStartInfo {
        //        WindowStyle = ProcessWindowStyle.Normal,
        //        ErrorDialog = true,
        //        LoadUserProfile = true,
        //        CreateNoWindow = false,
        //        UseShellExecute = false,
        //        Arguments = $"/path:\"{applicationPath}\" /port:50723",
        //        FileName = $@"{programFiles}\IIS Express\iisexpress.exe"
        //    };
        //    startInfo.EnvironmentVariables.Add("TestingType", "forSelenium");

        //    iisProcessExpress = new Process() { StartInfo = startInfo };
        //    iisProcessExpress.Start();
        //}



        [Test]
        public void GoToAbout_Test() {
            var hlkAbout = driver.FindElement(By.Id("hlkAbout"));
            hlkAbout.Click();
        }

        [Test]
        public void TEST_2() {
            // ТУТ КОД
        }
    }
}
