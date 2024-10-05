using Constants;
using FactoryPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected readonly string MainUrl;
        private LoginPage _loginPage => new LoginPage(Driver);
        private UserProfilePage _userProfilePage => new UserProfilePage(Driver);

        private bool _isLogoutNeeded;

        public BaseTest( bool isLogoutNeeded = true)
        {
            MainUrl = "https://opensource-demo.orangehrmlive.com";
            isLogoutNeeded = _isLogoutNeeded;
        }

        [SetUp]
        public void OneTimeSetUp()
        {
            SuccesfullLogin();
        }

        [TearDown]
        public void TearDown()
        {
            if (_isLogoutNeeded)
            {
                SuccessfullLogout();
            }
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
            Assert.That(Driver.Url.Contains("login"), Is.True, "Login Page is not opened");
            _loginPage.Login(ValidCredentials.userName, ValidCredentials.password);
            Assert.That(Driver.Url.Contains("dashboard"), Is.True, "User was not redirected to it's dashboard");
        }

        private void SuccessfullLogout()
        {
            _userProfilePage.ClickUserProfileDropdown();
            var isUserProfileDropdownDisplayed = _userProfilePage.IsUserProfileDropdownMenuDisplayed();
            Assert.That(isUserProfileDropdownDisplayed, Is.True, "Dropdown options did not appear");
            _userProfilePage.ClickLogout();
            Assert.That(Driver.Url.Contains("login"), Is.True, "Login Page is not opened");
            var isLoginButtonDisplayed = _loginPage.IsLoginButtonDisplayed();
            Assert.That(isLoginButtonDisplayed, Is.True, "Login button is not displayed");
        }
    }
}
