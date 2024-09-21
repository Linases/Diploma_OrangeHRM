using Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class LeftPanelNavigationPage
    {
        private IWebDriver _driver;

        private By Dashboard => By.XPath("//*[@class='oxd-grid-3 orangehrm-dashboard-grid']/div");
        private Button PIMButton => new (By.XPath("//a[@href='/web/index.php/pim/viewPimModule']"));
        private Button AdminButton => new (By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']"));
        private Button DashboardButton => new (By.XPath("//a[@href='/web/index.php/dashboard/index']"));
        private TextBox Search => new(By.XPath("//input[@placeholder='Search']"));
        private DropDown DashboardElements => new(Dashboard);



        public LeftPanelNavigationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool AreDashboardElementsDisplayed() => DashboardElements.AllElementsAreDisplayed(Dashboard);

        public void ClickPIM() =>  PIMButton.Click();

        public void ClickAdmin() => AdminButton.Click();
        public void ClickDashboard() => DashboardButton.Click();
   
        public string GetAdminHeader() => GetText(LeftNavigationMenuNames.Admin);
        public string GetPIMHeader() => GetText(LeftNavigationMenuNames.PIM);
        public string GetAddEmployeeHeader() => GetText(PIMHeadersNames.AddEmployee);
        public string GetDashboradHeader() => GetText(LeftNavigationMenuNames.Dashboard);
        

        public void EnterSearchText(string text)
        {
            Search.SendKeys(text);
        }
        public bool IsQuickLaunchAvailable() => IsElementAvailable(DashboardElementsNames.QuickLaunch);
        private bool IsElementAvailable(string text)
        {
            var list = _driver.FindElements(Dashboard).ToList();

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

        private string GetText(string text)
        {
            By headerLocator = By.XPath($"//h6[text()='{text}']");
            var header = new TextBox(headerLocator);
            var textDisplayed = header.Text;
            return textDisplayed;
        }
    }
}
