using Constants.Html;
using Constants.TestSettings.Enum;
using FactoryPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using Orange_HRM_Modules;
using Orange_HRM_Pages;
using TestSettingsConfiguration;

namespace Orange_HRM_Tests
{
    public class BaseTest
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        private LoginPage LoginPage => new();
        private UserProfilePage UserProfilePage => new();
        private TestSettings TestSettings => new();
        protected readonly LeftPanelNavigationPage LeftPanelNavigationPage;

        public BaseTest()
        {
            LeftPanelNavigationPage = new LeftPanelNavigationPage();
            TestSettings.SetDefaultValues();
        }

        [SetUp]
        public void OneTimeSetUp() => Login();

        [TearDown]
        public void TearDown() => Logout();

        [OneTimeTearDown]
        public static void OneTimeTearDown() => BrowserFactory.CloseDriver();

        private void Login()
        {
            Driver.Navigate().GoToUrl(TestSettings.MainUrl);
            Driver.Manage().Window.Maximize();
            Assert.That(Driver.Title, Is.EqualTo("OrangeHRM"), "Login Page is not displayed");
            Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Login), "Login Page is not opened");
            LoginPage.LoginAsAdministrator(User.GetAdminUser().UserName, User.GetAdminUser().Password);
            Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Dashboard),
                "User was not redirected to it's dashboard");
        }

        private void Logout()
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