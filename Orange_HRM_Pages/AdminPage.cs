using Constants.Admin;
using Constants.Admin.Job;
using OpenQA.Selenium;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class AdminPage : BasePage
    {
        private const string JobsTabLocator = "//*[text()='Job ']";
        private const string UserManagementTabLocator = "//*[text()='User Management ']";

        private TextBox JobTitleTextBox => new(By.XPath("//*[@class='oxd-form-row']//input[contains(@class,'oxd-input')]"));
        private Button Nationalities => new(By.XPath("//*[text()='Nationalities']"));
        private Button UserManagementButton => new(By.XPath($"{UserManagementTabLocator}"));
        private Button JobButton => new(By.XPath($"{JobsTabLocator}"));
        private TextBox NationalityNameInput => new(By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']"));
        private new Button SaveButton => new(By.XPath("//button[@type='submit']"));
        private Button AdminOptions => new(By.XPath("//*[@aria-label='Topbar Menu']//li"));
        private DropDown JobDropdownMenu => new(By.XPath($"{JobsTabLocator}/following-sibling::*/li/a"));

        public void ClickNationalities() => Nationalities.Click();

        public bool IsAnyNationalitiesDisplayed()
        {
            var list = Driver.GetWaitForElementsVisible(By.XPath("//*[@class='oxd-table-body']/div"))
                .Where(x => x.Displayed).ToList();

            return list.Count > 0;
        }

        public void EditName(string text)
        {
            NationalityNameInput.DeleteAndEnterText(text);
            SaveButton.Click();
        }

        public bool AreAdministrationOptionsDisplayed() => AdminOptions.AllElementsAreDisplayed();

        public void ClickUserManagement() => UserManagementButton.Click();

        public void ClickJob() => JobButton.Click();

        public bool AreOptionsDisplayed(string option)
        {
            var options = GetOptionsDisplayed(option);
            if (options.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool IsJobTitleAvailable() => IsOptionAvailable(AdminTabNames.Job, JobTabNames.JobTitles);

        public void SelectJobTitlesButton() => JobDropdownMenu.SelectByTextValue(JobTabNames.JobTitles);

        public bool AreJobTitlesItemsVisible()
        {
            var table = new DropDown(By.XPath($"{TableListLocator}"));
            var areVisible = table.AllElementsAreDisplayed();

            return areVisible;
        }

        public void ClickAddJobTitle() => AddButton.Click();

        public void AddJobTitleName(string text)
        {
            JobTitleTextBox.EnterText(text);
            SaveButton.Click();
        }

        private List<string> GetOptionsDisplayed(string option)
        {
            var optionsAvailable = Driver.FindElements(By.XPath($"//*[text()='{option} ']/following-sibling::*/li/a"));
            var optionsDisplayed = optionsAvailable.Where(x => x.Enabled).Select(x => x.Text).ToList();

            return optionsDisplayed;
        }

        private bool IsOptionAvailable(string option, string text) => GetOptionsDisplayed(option).Contains(text);
    }
}