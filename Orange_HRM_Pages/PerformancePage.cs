using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class PerformancePage : BasePage
    {
        private By ConfirureTabLocator => By.XPath("//*[@aria-label='Topbar Menu']//*[text()='Configure ']");
        private By KPIsLocator => By.XPath("//*[@aria-label='Topbar Menu']//ul//*[text()='KPIs']");
        private DropDown JobTitleDropdown => new(By.XPath("//*[contains(@class,'select-text-input')]"));
        private HrmWebElement DropdownArrowUp => new(By.XPath("//*[@class='oxd-select-text oxd-select-text--focus']"));
        private HrmWebElement DropdownArrowDown => new(By.XPath("//*[@class='oxd-select-text oxd-select-text--active']"));
        private HrmWebElement Records => new(By.XPath("(//*[@class ='oxd-text oxd-text--span'])[1]"));

        private TextBox KpiInput =>
            new TextBox(By.XPath("(//label['Key Performance Indicator']/parent::*/following-sibling::*/input)[1]"));
        private Button ConfirureTab => new(ConfirureTabLocator);
        private Button KPIsTab => new(KPIsLocator);

        public void ClickConfigureTab() => ConfirureTab.ClickWhenClicable();

        public void ClickKPIsTab() => KPIsTab.ClickIfDisplayed();

        public void ClickAddKpi() => ClickAdd();

        public void AddKpItext(string text) => KpiInput.SendKeys(text);

        public void SelectJobTitle()
        {
            JobTitleDropdown.Click();
            DropdownArrowUp.WaitForElementIsDisplayed();
            JobTitleDropdown.SendKeys(Keys.ArrowDown);
            JobTitleDropdown.SendKeys(Keys.Enter);
        }

        public void ClickSaveButton() => Save();

        public string GetKPIRecords()
        {
            string numbers = new string(Records.Text.Where(char.IsDigit).ToArray());

            return numbers;
        }

    }
}
