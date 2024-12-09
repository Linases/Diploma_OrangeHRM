using Constants.Performance;
using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class PerformancePage : BasePage
    {
        private const string ConfigureTabLocation = "//*[.='Configure ']";

        private DropDown JobTitleInput => new(By.XPath("//*[contains(@class,'select-text-input')]"));
        private HrmWebElement Records => new(By.XPath("(//*[@class ='oxd-text oxd-text--span'])[1]"));
        private TextBox KpiInput => new(By.XPath("(//label['Key Performance Indicator']/parent::*/following-sibling::*/input)[1]"));
        private Button ConfigureTab => new(By.XPath($"{ConfigureTabLocation}"));
        private DropDown ConfigureDropdownMenu => new(By.XPath($"{ConfigureTabLocation}/./following-sibling::*/li/a"));

        public void ClickConfigureTab() => ConfigureTab.ClickWhenClicable();

        public void ClickKPIsTab() => ConfigureDropdownMenu.SelectByTextValue(ConfigureMenuNames.KPIs);

        public void ClickAddKpi() => ClickAdd();

        public void AddKpItext(string text) => KpiInput.SendKeys(text);

        public void SelectJobTitle()
        {
            JobTitleInput.ClickIfDisplayed();
            JobTitleInput.SendKeys(Keys.ArrowDown);
            JobTitleInput.SendKeys(Keys.Enter);
        }

        public void ClickSaveButton() => Save();

        public string GetKPIRecords()
        {
            var numbers = new string(Records.Text.Where(char.IsDigit).ToArray());

            return numbers;
        }
    }
}