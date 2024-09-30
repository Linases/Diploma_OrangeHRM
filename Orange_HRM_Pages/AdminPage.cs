using Constants;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class AdminPage
    {
        private IWebDriver _driver;

        private By AllNationalities => By.XPath("//*[@class='oxd-table-body']/div");
        private By JobTitleTableList => By.XPath("//*[@class='oxd-table-card']");
        private By JobsTitles => By.XPath("//*[@class='oxd-dropdown-menu']/li/a[text()='Job Titles']");
        private Button Nationalities => new Button(By.XPath("//*[text()='Nationalities']"));
        private Button UserManagementButton => new Button(By.XPath("//*[text()='User Management ']"));
        private Button JobButton => new Button(By.XPath("//*[text()='Job ']"));
        private By Options => By.XPath("//*[@class='oxd-dropdown-menu']/li/a");
        private DropDown OptionsAvailable => new DropDown(Options);
        private TextBox NationalityNameInput => new(NationalityName);
        private By NationalityName => By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']");
        private Button SaveButton => new(By.XPath("//button[@type='submit']"));
        private By TopBarMenuItems => By.XPath("//*[@aria-label='Topbar Menu']//li");
        private Button AdminOptions => new Button(TopBarMenuItems);
        private Button AddJobTitleButton => new(By.XPath("//button[text()=' Add ']"));
        private Button JobTitles => new(JobsTitles);
        private By JobTitleInput => By.XPath("//*[@class='oxd-form-row']//input[contains(@class,'oxd-input')]");
        private By VerifyDeleteButton => By.XPath("//*[@class='oxd-icon bi-trash oxd-button-icon']");
        public AdminPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ClickNationalities() => Nationalities.Click();

        public bool IsAnyNationalitiesDisplayed()
        {
            var list = _driver.GetWaitForElementsVisible(AllNationalities).Where(x => x.Displayed).ToList();
            return list.Count > 0;
        }

        public void ClickEditButton(string _title)
        {
            By editButton = By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')and(contains(@style, 'flex-basis'))]/div[text()='{_title}']/parent::*/following-sibling::*//i[@class='oxd-icon bi-pencil-fill']");
            var button = new Button(editButton);
            button.Click();
        }

        public void ClickDeleteButton(string _title)
        {
            By deleteButton = By.XPath($"//div[(@class= 'oxd-table-cell oxd-padding-cell')]/div[text()='{_title}']/parent::*/following-sibling::*//i[@class='oxd-icon bi-trash']");
            var button = new Button(deleteButton);
            button.Click();
            var verifyDelete = new Button(_driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(VerifyDeleteButton)));
            verifyDelete.ClickWhenClicable(VerifyDeleteButton);
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
            _ = _driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(JobsTitles));
        }
        public bool AreJobTitilesItemsVisible()
        {
            var table = new DropDown(JobTitleTableList);
            var areVisible = table.AllElementsAreDisplayed(JobTitleTableList);
            return areVisible;
        }

        public void ClickAddJobTitle() => AddJobTitleButton.Click();

        public void AddJobTitleName(string text)
        {
            var title = new TextBox(JobTitleInput);
            title.WaitoToEnterText(text, JobTitleInput);
            SaveButton.Click();
        }

        public bool IsAddedJobTitleDisplayed(string text)
        {
            var list = _driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(JobTitleTableList)).ToList();

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
            var list = _driver.FindElements(Options).ToList();

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
