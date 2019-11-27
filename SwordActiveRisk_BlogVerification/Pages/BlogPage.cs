using SwordActiveRisk_BlogVerification.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using Helper.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwordActiveRisk_BlogVerification.Pages
{
    public class BlogPage
    {
        protected WebDriverWait Wait;

        By blogPostsByDate = By.XPath("//h2[contains(text(),'Blog Posts By Date')]");
        By blogLink = By.XPath("//a[contains(text(),'February 2017')]");
        By popupMessage = By.XPath("//img[@class='sgpb-popup-close-button-6']");
        By backToBlog = By.XPath("//a[@class='back-to-blog']");
        IList<IWebElement> NumberOfArticles => Context.Driver.FindElements(By.XPath("//article"));

                       
        public string UrlOfTheCurrentPage()
        {
            return Context.Driver.Url.Trim(); //.Trim gets rid of all unwanted space in the Url
        }

        public bool VerifyBlogPostsByDate()
        {
            return Context.Driver.FindElement(blogPostsByDate).Displayed;
        }

        public void ClickOnDate()
        {
            Context.Driver.FindElement(popupMessage).Click();
            Thread.Sleep(1000);
            Context.Driver.FindElement(blogLink).Click();
        }

        public void ClickOnMonth(string BlogPostByDate)
        {
            Context.Driver.FindElement(popupMessage).Click();
            Thread.Sleep(2000);
            Context.Driver.WaitForPageload();
            Context.Driver.FindElement(By.XPath($"//a[contains(text(),'{BlogPostByDate}')]")).Click();
            
        }

        public List<string> GetNumberOfArticles(string Articles)
        {
            Context.Driver.WaitForPageload();
            return NumberOfArticles.ConvertWebElementListToStringList();
            
        }

        
        public int  GetArticles()
        {
            IList<IWebElement> elementList = Context.Driver.FindElements(By.XPath("//article"));
            int Count = elementList.Count;
            return Count;
                                   
        }

        public bool VerifyTheNewTab()
        {
            
            Context.Driver.WaitForPageload();
            var browserTabs = Context.Driver.WindowHandles;
            Context.Driver.SwitchTo().Window(browserTabs[1]);
            Thread.Sleep(7000);
            Context.Driver.FindElement(popupMessage).Click();
            Thread.Sleep(1000);
            return Context.Driver.FindElement(backToBlog).Displayed;
                        
        }
        public void CloseThenewTab()
        {
            var browserTabs = Context.Driver.WindowHandles;
            Context.Driver.Close();
            Context.Driver.SwitchTo().Window(browserTabs[0]);
        }

    }
}
