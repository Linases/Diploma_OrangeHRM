using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange_HRM_Tests
{
    public class LogoutTest : BaseTest
    {
        private LoginPage _loginPage;
        private UserProfilePage _userProfilePage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(Driver);
            _loginPage.Login(ValidCredentials.userName, ValidCredentials.password);
            _userProfilePage = new UserProfilePage(Driver);
        }

        [Test]
        public void Logout()
        {
            _userProfilePage.ClickUserProfileDropdown();
            Assert.That(_userProfilePage.IsUserProfileDropdownMenuDisplayed(), "Dropdown options did not appear");
            _userProfilePage.ClickLogout();
            Assert.That(Driver.Url.Contains("login"), "Login Page is not opened");
            Assert.That(_loginPage.IsLoginButtonDisplayed(), Is.True, "Login button is not displayed");
        }
    }
}
