using Constants.Dashboard;
using Constants.LeftNavigation;
using Constants.PIM;
using OpenQA.Selenium;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class LeftPanelNavigationPage : BasePage
    {
        private By Dashboard => By.XPath("//*[@class='oxd-grid-3 orangehrm-dashboard-grid']/div");
        private By MenuItemsLocator => By.XPath("//*[@class ='oxd-main-menu']/li//a//span");
        private Button PIMButton => new(By.XPath("//*[contains(@class, 'main-menu-item--name')and text()='PIM']"));
        private Button AdminButton => new(By.XPath("//*[contains(@class, 'main-menu-item--name')and text()='Admin']"));

        private Button DashboardButton => new(By.XPath("//*[contains(@class, 'main-menu-item--name')and text()='Dashboard']"));
        private Button PerformanceButton => new(By.XPath("//*[contains(@class, 'main-menu-item--name')and text()='Performance']"));
        private TextBox Search => new(By.XPath("//input[@placeholder='Search']"));
        private HrmWebElement MenuItems => new HrmWebElement(MenuItemsLocator);
        private DropDown DashboardElements => new(Dashboard);

        public bool AreDashboardElementsDisplayed() => DashboardElements.AllElementsAreDisplayed();

        public EmployeePage ClickPIM()
        {
            PIMButton.Click();

            return new EmployeePage();
        }

        public AdminPage ClickAdmin()
        {
            AdminButton.Click();

            return new AdminPage();
        }

        public void ClickDashboard() => DashboardButton.Click();

        public PerformancePage ClickPerformance()
        {
            PerformanceButton.Click();

            return new PerformancePage();
        }

        public string GetAddEmployeeHeader() => GetMenuName(PimTabNames.AddEmployee);

        public string GetDashboardHeader() => GetMenuName(LeftNavigationMenuNames.Dashboard);

        public void EnterSearchText(string text) => Search.SendKeys(text);

        public List<string> GetAllMenuItems()
        {
            Driver.GetWait().Until(x => MenuItems.AllElementsAreDisplayed());
            var menuItems = Driver.FindElements(MenuItemsLocator).ToList();
            var allItems = menuItems.Select(x => x.Text).ToList();

            return allItems;
        }

        public bool IsQuickLaunchAvailable() => IsElementAvailable(Dashboard, DashboardMenusNames.QuickLaunch);

        private bool IsElementAvailable(By locator, string text)
        {
            var list = Driver.FindElements(locator).ToList();

            foreach (var item in list)
            {
                var elementValue = item.Text;
                if (item.Displayed && item.Enabled && elementValue.Equals(text))
                {
                    return true;
                }
            }

            return false;
        }

        private string GetMenuName(string text)
        {
            var header = new TextBox(By.XPath($"//h6[text()='{text}']"));

            return header.Text;
        }
    }
}