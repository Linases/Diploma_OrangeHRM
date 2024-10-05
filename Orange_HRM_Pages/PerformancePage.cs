using Constants;
using FactoryPattern;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class PerformancePage
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        private By ConfirureTabLocator => By.XPath("//*[@aria-label='Topbar Menu']//*[text()='Configure ']");
        private By KPIsLocator => By.XPath("//*[@aria-label='Topbar Menu']//ul//*[text()='KPIs']");
        private By JobTitleSelect => By.XPath("//*[contains(@class,'select-text-input')]");
        private By SaveKPI => (By.XPath("//*[text()=' Save ']"));
        private By KPIList => By.XPath($"//*[@class='oxd-table-card']//*[text() ='{0}']");
        private By RecordsLocator => By.XPath("(//*[@class ='oxd-text oxd-text--span'])[1]");
        private Button AddKPIButton => new(By.XPath("//*[text()=' Add ']"));
        private Button SaveKpIButton => new(SaveKPI);

        private TextBox KpiInput => new TextBox(By.XPath("(//label['Key Performance Indicator']/parent::*/following-sibling::*/input)[1]"));
        private Button ConfirureTab => new(ConfirureTabLocator);
        private Button KPIsTab => new(KPIsLocator);

        //public PerformancePage(IWebDriver driver)
        //{
        //    _driver = driver;
        //}

        public void ClickConfigureTab() => ConfirureTab.ClickWhenClicable(ConfirureTabLocator);

        public void ClickKPIsTab() => KPIsTab.ClickIfDisplayed(KPIsLocator);

        public void ClickAddKpi() => AddKPIButton.Click();

        public void AddKpItext(string text) => KpiInput.SendKeys(text);

        public void SelectJobTitle()
        {
            var selectDropdown = Driver.FindElement(JobTitleSelect);
            selectDropdown = new HrmWebElement(selectDropdown);
            if (selectDropdown.Enabled)
            {
                selectDropdown.Click();
            };

            selectDropdown.SendKeys(Keys.ArrowDown);
            selectDropdown.SendKeys(Keys.Enter);
        }

        public void ClickSaveButton()
        {
            SaveKpIButton.Click();
            Driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(SaveKPI));
        }

            public string GetKPIRecords ()
        {
            var records = new HrmWebElement(RecordsLocator);
            string numbers = new string(records.Text.Where(char.IsDigit).ToArray());
            
            return numbers;
        }

        public void WaitForSpinnerIsNotVisible ()
        {

            By spinnerLocator = By.XPath("//*[@class='oxd-loading-spinner']");
            var spinner = Driver.FindElement(spinnerLocator);
            var element = Driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(spinnerLocator));
        }

        public bool IsAddedKPIDisplayed(string text)
        {
           
            var addedKPI = Driver.FindElement(By.XPath($"//*[@class='oxd-table-card']//*[text() ='{text}']"));

            return addedKPI.Displayed;

            //var list = _driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(KPIList)).ToList();
            //var item
            //foreach (var item in list)
            //{
            //    var elementValue = item.Text;
            //    if (item.Displayed && elementValue.Equals(text))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
    }
}

