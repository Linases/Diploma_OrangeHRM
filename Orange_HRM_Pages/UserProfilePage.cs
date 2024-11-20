using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class UserProfilePage
    {
        private Button UserProfileButton => new(By.XPath("//i[contains(@class, 'userdropdown-icon')]"));
        private DropDown UserProfileMenuDropdown => new(By.XPath("//*[@class='oxd-dropdown-menu']"));
        private Button LogoutButton => new(By.XPath("//a[text()='Logout']"));

        public void ClickUserProfileDropdown() => UserProfileButton.ClickWhenClicable();

        public bool IsUserProfileDropdownMenuDisplayed()
        {
            var isDisplayed = UserProfileMenuDropdown.AllElementsAreDisplayed();

            return isDisplayed;
        }

        public void ClickLogout() => LogoutButton.ClickWhenClicable();
    }
}