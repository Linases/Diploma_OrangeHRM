using Constants.TestSettings.Enum;
using FactoryPattern;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class BasePage
    {
        protected By TableList => By.XPath("//*[@class='oxd-table-card']");
        private const string ElementInTableLocator = "//*[text()='{0}']/parent::*/following-sibling::*//i";

        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected By SpinnerLocator = By.XPath("//*[@class='oxd-loading-spinner']");

        protected  Button AddButton => new(By.XPath("//button[text()=' Add ']"));
        protected  Button SaveButton => new(By.XPath("//button[text()=' Save ']"));
        protected  Button VerifyDeleteButton => new(By.XPath("//*[@class='oxd-icon bi-trash oxd-button-icon']"));
        protected HrmWebElement Spinner => new HrmWebElement(SpinnerLocator);

        public bool IsDisplayedInTable(string itemName)
        {
            try
            {
               var itemInTable = new HrmWebElement( By.XPath($"//*[@class='oxd-table-card']//*[text()='{itemName}']"));
                return itemInTable.Text.Equals(itemName);
            }
            catch (WebDriverTimeoutException)
            {
               return false;
            }
        }

        public void ClickAdd() => AddButton.Click();

        public void Save()
        {
            SaveButton.Click();
            SaveButton.WaitForElementIsDisplayed();
        }

        public void ClickEditButton(string title)
        {
            var editButton = new Button(By.XPath($"{string.Format(ElementInTableLocator, title)}[@class='oxd-icon bi-pencil-fill']"));
            editButton.Click();
        }

        public void ClickTrashIcon(string title)
        {
            var trashIcon = new Button(By.XPath($"{string.Format(ElementInTableLocator, title)}[@class='oxd-icon bi-trash']"));
            trashIcon.Click();
            VerifyDeleteToaster();
        }

        public void WaitForSpinnerIsNotVisible() => Spinner.WaitForElementIsNotDisplayed();

        public void VerifyDeleteToaster()
        {
            //Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(VerifyDelete));
            VerifyDeleteButton.ClickWhenClicable();
        }
    }
}
