using Constants;
using OpenQA.Selenium;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class LeftPanelNavigationPage
    {
        private IWebDriver _driver;

        private By Dashboard => By.XPath("//*[@class='oxd-grid-3 orangehrm-dashboard-grid']/div");
        private By MenuItemsLocator => By.XPath("//*[@class ='oxd-main-menu']/li//a//span");
        private Button PIMButton => new(By.XPath("//a[@href='/web/index.php/pim/viewPimModule']"));
        private Button AdminButton => new(By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']"));
        private Button DashboardButton => new(By.XPath("//a[@href='/web/index.php/dashboard/index']"));
        private Button PerformanceButton => new(By.XPath("//a[@href='/web/index.php/performance/viewPerformanceModule']"));
        private TextBox Search => new(By.XPath("//input[@placeholder='Search']"));
        private HrmWebElement MenuItems => new HrmWebElement(MenuItemsLocator);
        private DropDown DashboardElements => new(Dashboard);

        public LeftPanelNavigationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool AreDashboardElementsDisplayed() => DashboardElements.AllElementsAreDisplayed(Dashboard);

        public EmployeePage ClickPIM()
        {
            PIMButton.Click();

            return new EmployeePage(_driver);
        }

        public AdminPage ClickAdmin()
        {
            AdminButton.Click();

            return new AdminPage(_driver);
        }

        public void ClickDashboard() => DashboardButton.Click();

        public PerformancePage ClickPerformance()
        {
            PerformanceButton.Click();

            return new PerformancePage(_driver);
        }

        public string GetAdminHeader() => GetMenuName(LeftNavigationMenuNames.Admin);

        public string GetPIMHeader() => GetMenuName(LeftNavigationMenuNames.PIM);

        public string GetAddEmployeeHeader() => GetMenuName(PIMHeadersNames.AddEmployee);

        public string GetDashboradHeader() => GetMenuName(LeftNavigationMenuNames.Dashboard);

        public void EnterSearchText(string text) => Search.SendKeys(text);

        public List<string> GetAllMenuItems()
        {
            _driver.GetWait().Until(x =>
            {
                MenuItems.AllElementsAreDisplayed(MenuItemsLocator);

                return true;
            });

            var menuItems = _driver.FindElements(MenuItemsLocator).ToList();
            return menuItems.Select(x => x.Text).ToList();
        }

        public bool IsQuickLaunchAvailable() => IsElementAvailable(Dashboard, DashboardElementsNames.QuickLaunch);

        private bool IsElementAvailable(By locator, string text)
        {
            var list = _driver.FindElements(locator).ToList();

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
            By headerLocator = By.XPath($"//h6[text()='{text}']");
            var header = new TextBox(headerLocator);
            var textDisplayed = header.Text;
            return textDisplayed;
        }
    }
}
