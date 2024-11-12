using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class PerformancePage : BasePage
    {
        private By ConfirureTabLocator => By.XPath("//*[@aria-label='Topbar Menu']//*[text()='Configure ']");
        private By KPIsLocator => By.XPath("//*[@aria-label='Topbar Menu']//ul//*[text()='KPIs']");
        private By JobTitleSelect => By.XPath("//*[contains(@class,'select-text-input')]");
        private HrmWebElement Records => new HrmWebElement(By.XPath("(//*[@class ='oxd-text oxd-text--span'])[1]"));
        private TextBox KpiInput => new TextBox(By.XPath("(//label['Key Performance Indicator']/parent::*/following-sibling::*/input)[1]"));
        private Button ConfirureTab => new(ConfirureTabLocator);
        private Button KPIsTab => new(KPIsLocator);

        public void ClickConfigureTab() => ConfirureTab.ClickWhenClicable(ConfirureTabLocator);

        public void ClickKPIsTab() => KPIsTab.ClickIfDisplayed(KPIsLocator);

        public void ClickAddKpi() => ClickAdd();

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

        public void ClickSaveButton() => Save();

        public string GetKPIRecords()
        {
            string numbers = new string(Records.Text.Where(char.IsDigit).ToArray());

            return numbers;
        }

        public bool IsAddedKPIDisplayed(string text)
        {
            try
            {
                var addedKPI = Driver.FindElement(By.XPath($"//*[@class='oxd-table-card']//*[text() ='{text}']"));

                return addedKPI.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void DeleteKPI(string KPIname)
        {
            var button = new Button(By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')]/div[text()='{KPIname}']/parent::*/following-sibling::*//i[@class='oxd-icon bi-trash']"));
            button.Click();
            VerifyDeleteToaster();
        }
    }
}
