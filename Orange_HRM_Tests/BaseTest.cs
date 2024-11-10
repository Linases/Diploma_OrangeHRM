using Constants;
using FactoryPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using Orange_HRM_Modules;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected readonly string MainUrl;
        protected  LoginPage LoginPage => new();
        private  UserProfilePage UserProfilePage => new();


        public BaseTest()
        {
            MainUrl = "https://opensource-demo.orangehrmlive.com";
        }

        [SetUp]
        public void OneTimeSetUp()
        {
            SuccesfullLogin();
        }

        [TearDown]
        public void TearDown()
        {

            SuccessfullLogout();

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            BrowserFactory.CloseDriver();
        }

        private void SuccesfullLogin()
        {
            Driver.Navigate().GoToUrl(MainUrl);
            Driver.Manage().Window.Maximize();
            Assert.That(Driver.Title, Is.EqualTo("OrangeHRM"), "Login Page is not displayed");
            Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Login), "Login Page is not opened");
            LoginPage.LoginAsAdministrator(User.Admin);
            Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Dashboard), "User was not redirected to it's dashboard");
        }

        private void SuccessfullLogout()
        {
            UserProfilePage.ClickUserProfileDropdown();
            var isUserProfileDropdownDisplayed = UserProfilePage.IsUserProfileDropdownMenuDisplayed();
            Assert.That(isUserProfileDropdownDisplayed, Is.True, "Dropdown options did not appear");
            UserProfilePage.ClickLogout();
            Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Login), "Login Page is not opened");
            var isLoginButtonDisplayed = LoginPage.IsLoginButtonDisplayed();
            Assert.That(isLoginButtonDisplayed, Is.True, "Login button is not displayed");
        }
    }
}
