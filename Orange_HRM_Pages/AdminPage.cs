using Constants.Admin.Job;
using OpenQA.Selenium;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class AdminPage : BasePage
    {
        private By TopBarMenuItems => By.XPath("//*[@aria-label='Topbar Menu']//li");
        private By Options => By.XPath("//*[@class='oxd-dropdown-menu']/li/a");
        private By NationalityName => By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']");
        private TextBox JobTitleTextBox => new(By.XPath("//*[@class='oxd-form-row']//input[contains(@class,'oxd-input')]"));
        private Button Nationalities => new(By.XPath("//*[text()='Nationalities']"));
        private Button UserManagementButton => new(By.XPath("//*[text()='User Management ']"));
        private Button JobButton => new(By.XPath("//*[text()='Job ']"));
        private DropDown OptionsAvailable => new(Options);
        private TextBox NationalityNameInput => new(NationalityName);
        private new Button SaveButton => new(By.XPath("//button[@type='submit']"));
        private Button AdminOptions => new(TopBarMenuItems);
        private Button JobTitles => new(By.XPath("//*[@class='oxd-dropdown-menu']/li/a[text()='Job Titles']"));

        public void ClickNationalities() => Nationalities.Click();

        public bool IsAnyNationalitiesDisplayed()
        {
            var list = Driver.GetWaitForElementsVisible(By.XPath("//*[@class='oxd-table-body']/div")).Where(x => x.Displayed).ToList();

            return list.Count > 0;
        }

        public void EditName(string text)
        {
            NationalityNameInput.DeleteAndEnterText(text, NationalityName);
            SaveButton.Click();
        }

        public bool AreAdministrationOptionsDisplayed() => AdminOptions.AllElementsAreDisplayed();

        public void ClickUserManagement() => UserManagementButton.Click();

        public void ClickJob() => JobButton.Click();

        public bool AreOptionsDisplayed() => OptionsAvailable.AllElementsAreDisplayed();

        public bool IsJobTitleAvailable() => IsOptionAvailable(JobTabNames.JobTitles);

        public void SelectJobTitlesButton() => JobTitles.Click();

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

        private bool IsOptionAvailable(string text)
        {
            var list = Driver.FindElements(Options).ToList();

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
    }
}
