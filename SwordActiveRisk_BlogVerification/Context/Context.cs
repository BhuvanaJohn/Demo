using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;

namespace SwordActiveRisk_BlogVerification.Hooks
{
    public static class Context
    {
        private static IWebDriver driver;
        static string testUrl = ConfigurationManager.AppSettings["TESTURL"];
        static string browser = ConfigurationManager.AppSettings["browser"];

        public static IWebDriver Driver { get => driver; set => driver = value; }
              

        public static void SetUp()
        {
            var chromeDriverProcesses = Process.GetProcessesByName("chromedriver"); //launch chrome browser
            foreach (var chromeDriverProcess in chromeDriverProcesses)
            {
                try
                {
                    chromeDriverProcess.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            switch (browser)
            {
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "InternetExplorer":
                    Driver = new InternetExplorerDriver();
                    break;
            }
            Driver.Manage().Window.Maximize(); // maximise the browser window
            Driver.Navigate().GoToUrl(testUrl); // type the Url of AUT
            Thread.Sleep(2000); //slow the browser for 2 seconds 
        }

        
        public static void ReloadApplication(string urlToLoad)
        {
            int counter = 0;
            ReadOnlyCollection<string> windowHandles = Context.Driver.WindowHandles;
            foreach (var window in windowHandles)
            {
                counter = windowHandles.Count;
                if (windowHandles.Count > 1)
                {
                    Context.Driver.SwitchTo().Window(window).Close();
                    counter--;
                }
            }
            Driver.Manage().Cookies.DeleteAllCookies();
            Thread.Sleep(2000);

            Driver.Manage().Window.Maximize();

          if (urlToLoad.Contains("blog"))
            {
                Driver.Navigate().GoToUrl(testUrl);
            }
            
        }
        public static void ShutDown()
        {
            Driver.Quit();
            
            Driver.Dispose();
        }
    }
}
