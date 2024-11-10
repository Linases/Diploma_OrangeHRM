using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class UserProfilePage
    {
        private By UserProfile => By.XPath("//i[contains(@class, 'userdropdown-icon')]");
        private By UserProfileMenu => By.XPath("//*[@class='oxd-dropdown-menu']");
        private By Logout => By.XPath("//a[text()='Logout']");
        private Button UserProfileButton => new Button(UserProfile);
        private DropDown UserProfileMenuDropdown => new DropDown(UserProfileMenu);
        private Button LogoutButton => new Button(Logout);

        public void ClickUserProfileDropdown() => UserProfileButton.ClickWhenClicable(UserProfile);

        public bool IsUserProfileDropdownMenuDisplayed()
        {
            var isDisplayed = UserProfileMenuDropdown.AllElementsAreDisplayed(UserProfileMenu);
            return isDisplayed;
        }

        public void ClickLogout() => LogoutButton.ClickWhenClicable(Logout);
    }
}
