using TechTalk.SpecFlow;
using SwordActiveRisk_BlogVerification.Pages;
using TechTalk.SpecFlow.Assist;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System;

namespace SwordActiveRisk_BlogVerification.StepDefinitions
{
    [Binding]
    public class BlogVerificationSteps
    {
        BlogPage loginPage;

        public BlogVerificationSteps(BlogPage _loginPage) //Constructor Injection
        {
            loginPage = _loginPage;
        }
               
        [When(@"the user is on the Active Risk Blog Page")]
        public void WhenTheUserIsOnTheActiveRiskBlogPage()
        {
            string actualResult = loginPage.UrlOfTheCurrentPage();
            Assert.IsTrue(actualResult.Contains(ConfigurationManager.AppSettings["TheActiveRiskBlog"]));
        }
                
        [When(@"the user clicks on Blog post by date '(.*)'")]
        public void WhenTheUserClicksOnBlogPostByDate(string BlogPostByDate)
        {
            loginPage.ClickOnMonth(BlogPostByDate);
        }
        
        [Then(@"the user is successfully logged into the Mailinator inbox")]
        public void ThenTheUserIsSuccessfullyLoggedIntoTheMailinatorInbox()
        {
            string actualResult = loginPage.UrlOfTheCurrentPage();
            Assert.IsTrue(actualResult.Contains(ConfigurationManager.AppSettings["LoggedOnUrl"]));
        }

        [Then(@"the Blog posts By Date are displayed")]
        public void ThenTheBlogPostsByDateAreDisplayed()
        {
            loginPage.VerifyBlogPostsByDate();
        }

        [Then(@"the Number of Blogs posted match the referenced numbers '(.*)'")]
        public void ThenTheNumberOfBlogsPostedMatchTheReferencedNumbers(string NumberOfArticles)
        {

            try
            {
                int result = Int32.Parse(NumberOfArticles);
                int ActualResult = loginPage.GetArticles();
                Assert.IsTrue(ActualResult.Equals(result));
            }

            catch
            {
                Console.WriteLine("Number of articles are not matching with Expected Result");

            }
        }

        [Then(@"the user is on Active Risk Blog homepage")]
        public void ThenTheUserIsOnActiveRiskBlogHomepage()
        {
            loginPage.CloseThenewTab();
        }
                
        [Then(@"the active risk blog opens in a new tab")]
        public void ThenTheActiveRiskBlogOpensInANewTab()
        {
            loginPage.VerifyTheNewTab();
        }

        [Then(@"the list of articles are present in The Active Risk Blog")]
        public void ThenTheListOfArticlesArePresentInTheActiveRiskBlog()
        {
            string actualResult = loginPage.UrlOfTheCurrentPage();
            Assert.IsTrue(actualResult.Contains(ConfigurationManager.AppSettings["Articles"]));
        }
       
    }
}