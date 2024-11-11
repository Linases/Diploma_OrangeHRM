using Constants;
using Constants.Admin.Job;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class AdminPage : BasePage
    {
        private By AllNationalities => By.XPath("//*[@class='oxd-table-body']/div");
        private By JobTitleTableList => By.XPath("//*[@class='oxd-table-card']");
        private By TopBarMenuItems => By.XPath("//*[@aria-label='Topbar Menu']//li");
        private By Options => By.XPath("//*[@class='oxd-dropdown-menu']/li/a");
        private By JobsTitles => By.XPath("//*[@class='oxd-dropdown-menu']/li/a[text()='Job Titles']");
        private TextBox JobTitleInput => new TextBox(By.XPath("//*[@class='oxd-form-row']//input[contains(@class,'oxd-input')]"));
        private Button Nationalities => new Button(By.XPath("//*[text()='Nationalities']"));
        private Button UserManagementButton => new Button(By.XPath("//*[text()='User Management ']"));
        private Button JobButton => new Button(By.XPath("//*[text()='Job ']"));
        private DropDown OptionsAvailable => new DropDown(Options);
        private TextBox NationalityNameInput => new(NationalityName);
        private By NationalityName => By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']");
        private new Button SaveButton => new(By.XPath("//button[@type='submit']"));
        private Button AdminOptions => new Button(TopBarMenuItems);
        private Button JobTitles => new(JobsTitles);

        public void ClickNationalities() => Nationalities.Click();

        public bool IsAnyNationalitiesDisplayed()
        {
            var list = Driver.GetWaitForElementsVisible(AllNationalities).Where(x => x.Displayed).ToList();
            return list.Count > 0;
        }

        public void ClickEditButton(string _title)
        {
            By editButton = By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')and(contains(@style, 'flex-basis'))]/div[text()='{_title}']/parent::*/following-sibling::*//i[@class='oxd-icon bi-pencil-fill']");
            var button = new Button(editButton);
            button.Click();
        }

        public void ClickDeleteButton(string title)
        {
            var button = new Button(By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')]/div[text()='{title}']/parent::*/following-sibling::*//i[@class='oxd-icon bi-trash']"));
            button.Click();
            VerifyDeleteToaster();
        }

        public void EditName(string text)
        {
            NationalityNameInput.DeleteAndEnterText(text, NationalityName);
            SaveButton.Click();
        }

        public string GetChangedName(string changedName) => GetText(changedName);

        private string GetText(string text)
        {
            By newName = By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')and(contains(@style, 'flex-basis'))]/div[text()='{text}']");
            var value = new TextBox(newName);
            return value.WaitToGetText(newName);
        }

        public bool AreAdministrationOptionsDisplayed() => AdminOptions.AllElementsAreDisplayed(TopBarMenuItems);

        public void ClickUserManagement() => UserManagementButton.Click();

        public void ClickJob() => JobButton.Click();

        public bool AreOptionsDisplayed() => OptionsAvailable.AllElementsAreDisplayed(Options);

        public bool IsJobTitleAvailable() => IsOptionAvailable(JobTabNames.JobTitles);

        public void SelectJobTitlesButton()
        {
            JobTitles.Click();
            _ = Driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(JobsTitles));
        }
        public bool AreJobTitilesItemsVisible()
        {
            var table = new DropDown(JobTitleTableList);
            var areVisible = table.AllElementsAreDisplayed(JobTitleTableList);
            return areVisible;
        }

        public void ClickAddJobTitle() => AddButton.Click();

        public void AddJobTitleName(string text)
        {
            JobTitleInput.EnterText(text);
            SaveButton.Click();
        }

        public bool IsAddedJobTitleDisplayed(string text)
        {
            var list = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(JobTitleTableList)).ToList();

            foreach (var item in list)
            {
                var elementValue = item.Text;
                if (item.Displayed && elementValue.Equals(text))
                {
                    return true;
                }
            }
            return false;
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
