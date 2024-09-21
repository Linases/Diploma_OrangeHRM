using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class UserProfilePage
    {
        private IWebDriver _driver;
        private By UserProfile => By.XPath("//i[contains(@class, 'userdropdown-icon')]");
        private Button UserProfileButton => new Button(UserProfile);
        private By UserProfileMenu => By.XPath("//*[@class='oxd-dropdown-menu']");
        private DropDown UserProfileMenuDropdown => new DropDown(UserProfileMenu);
        private By Logout => By.XPath("//a[text()='Logout']");
        private Button LogoutButton => new Button(Logout);
        public UserProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickUserProfileDropdown()
        {
            UserProfileButton.ClickWhenClicable(UserProfile);
        }

        public bool IsUserProfileDropdownMenuDisplayed()
        {
            var isDisplayed = UserProfileMenuDropdown.AllElementsAreDisplayed(UserProfileMenu);
            return isDisplayed;
        }

        public void ClickLogout()
        {
            LogoutButton.ClickWhenClicable(Logout);
        }
    }
}
