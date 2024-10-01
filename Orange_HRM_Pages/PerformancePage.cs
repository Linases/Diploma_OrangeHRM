using OpenQA.Selenium;
using Wrappers;
using Orange_HRM_Forms;

namespace Orange_HRM_Pages
{
    public class PerformancePage
    {
        private IWebDriver _driver;
        private By ConfirureTabLocator => By.XPath("//*[@aria-label='Topbar Menu']//*[text()='Configure ']");
        private By KPIsLocator => By.XPath("//*[@aria-label='Topbar Menu']//ul//*[text()='KPIs']");
       // private Button AddEmployee => new(By.XPath("//a[text()='Add Employee']/parent::*"));
        private Button ConfirureTab => new(ConfirureTabLocator);
        private Button KPIsTab => new(KPIsLocator);


        //private TextBox FirstName => new(By.XPath("//*[@name='firstName']"));
        //private TextBox MiddleName => new(By.XPath("//*[@name='middleName']"));
        //private TextBox LastName => new(By.XPath("//*[@name='lastName']"));
        //private Button SaveButton => new(By.XPath("//*[text()=' Save ']"));
        //private Button EmployeeList => new(By.XPath("//*[text()='Employee List']/parent::*"));
        

        public PerformancePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickConfigureTab() => ConfirureTab.ClickWhenClicable(ConfirureTabLocator);

        public AddKPIForm ClickKPIsTab()
        {
            KPIsTab.ClickWhenClicable(KPIsLocator);
            return new AddKPIForm(_driver);
        }

        //public void AddEmployFullName(string firstName, string middleName, string lastName)
        //{
        //    FirstName.SendKeys(firstName);
        //    MiddleName.SendKeys(middleName);
        //    LastName.SendKeys(lastName);
        //    SaveButton.Click();
        //}

        ////public bool IsNameDisplayedCorrectly(string name)
        ////{
        ////    var element = EmployeeName.GetTextToBePresentInElement(EmployeeName, name);
        ////    return element.Equals(name);
        ////}

        //public bool IsEmployeeListTabOpen() => IsTabOpen(EmployeeList);
        //private bool IsTabOpen(HrmWebElement element)
        //{
        //    var value = element.GetAttribute("class");
        //    return value.Contains("visited");
        //}
    }
}
