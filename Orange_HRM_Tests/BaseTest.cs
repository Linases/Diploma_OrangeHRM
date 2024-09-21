using NUnit.Framework;
using OpenQA.Selenium;
using FactoryPattern;
using Constants;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected static IWebDriver Driver;
        protected readonly string MainUrl;
        private LoginPage _loginPage;
        private UserProfilePage _userProfilePage;
        public BaseTest()
        {
            MainUrl = "https://opensource-demo.orangehrmlive.com";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver = BrowserFactory.GetDriver(BrowserType.Chrome);
            Driver.Navigate().GoToUrl(MainUrl);
            Driver.Manage().Window.Maximize();
            Assert.That(Driver.Title, Is.EqualTo("OrangeHRM"), "Login Page is not displayed");
            Assert.That(Driver.Url.Contains("login"), "Login Page is not opened");
        }

        
        [TearDown] 
        public void TearDown() 
        {
            _userProfilePage= new UserProfilePage(Driver);
            _loginPage= new LoginPage(Driver);
            _userProfilePage.ClickUserProfileDropdown();
            Assert.That(_userProfilePage.IsUserProfileDropdownMenuDisplayed(), "Dropdown options did not appear");
            _userProfilePage.ClickLogout();
            Assert.That(Driver.Url.Contains("login"), "Login Page is not opened");
            Assert.That(_loginPage.IsLoginButtonDisplayed(), Is.True, "Login button is not displayed");
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            BrowserFactory.CloseDriver();
        }
    }
}
