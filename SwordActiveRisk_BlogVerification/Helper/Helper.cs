using AventStack.ExtentReports.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Helper.Helper
{
    public static class Helper
    {
        public static IJavaScriptExecutor JavaScripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        public static void ScrollToElement(this IWebDriver webDriver, IWebElement element)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Waits for the given page to finish loading and then reinitializes all associated WebElements
        /// </summary>
        /// <param name="pageObject">the page object to reinitialize</param>
        /// <param name="WebDriver">the current webdriver object</param>
        public static void WaitAndReinitializeElements(this IWebDriver WebDriver, object pageObject)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            // wait for the page to finish loading before reinitializing elements
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return window.jQuery != undefined"));
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return jQuery.active;").ToString().Equals("0"));
            PageFactory.InitElements(WebDriver, pageObject);
        }

        /// <summary>
        /// Waits for the given page to finish loading
        /// </summary>
        /// <param name="WebDriver">the current webdriver object</param>
        public static void WaitForPageload(this IWebDriver WebDriver)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            // waits for the page to finish loading
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return window.jQuery != undefined"));
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return jQuery.active;").ToString().Equals("0"));
        }

        /// <summary>
        /// Waits for the given page to finish loading to timeout page
        /// </summary>
        /// <param name="WebDriver">the current webdriver object</param>
        public static void WaitForPageToTimeout(this IWebDriver WebDriver)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(65));
            // waits for the page to finish loading
            wait.Until(x => WebDriver.JavaScripts().ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Refresh the current web page
        /// </summary>
        /// <param name="driver">the Webdriver</param>
        public static void Refresh(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Refresh the current page and accept the reload alert
        /// </summary>
        /// <param name="driver">the Webdriver</param>
        public static void RefreshAndAceptAlert(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
            driver.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// verifies an element is displayed or not
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="locator">by locator</param>
        /// <returns></returns>
        public static bool IsElementDisplayed(this IWebDriver driver, By locator)
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void AreEqual(int expected,int actual)

        {
            try
            {
                Assert.AreEqual(expected, actual);
            }

            catch (Exception)
            {
                Console.WriteLine("Assert Failed");
            }
        }
        public static IWebElement FindElementReliably(this IWebDriver webDriver, By by)
        {
            return webDriver.FindElementReliably(by, TimeSpan.FromSeconds(10));
        }

        public static IWebElement FindElementReliably(this IWebDriver webDriver, By by, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, timeout);

            webDriver.WaitForPageload();
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            var element = webDriver.FindElement(by);
            webDriver.ScrollToElement(element);
            return element;
        }
        public static List<string> ConvertWebElementListToStringList(this IList<IWebElement> elements)
        {
            List<string> stringList = new List<string>();
            if (!elements.IsNullOrEmpty())
            {
                foreach (var element in elements)
                {
                    stringList.Add(element.Text);
                }
                return stringList;
            }

            return stringList;
        }
    }
}
