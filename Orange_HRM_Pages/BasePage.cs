using Constants.TestSettings.Enum;
using FactoryPattern;
using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class BasePage
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected const string TableListLocator = "//*[@class='oxd-table-card']";
        private const string ElementInTableLocator = "//*[text()='{0}']/parent::*/following-sibling::*//i";

        protected Button AddButton => new(By.XPath("//button[text()=' Add ']"));
        private Button SaveButton => new(By.XPath("//button[text()=' Save ']"));
        private Button VerifyDeleteButton => new(By.XPath("//*[@class='oxd-icon bi-trash oxd-button-icon']"));

        public bool IsDisplayedInTable(string itemName)
        {
            try
            {
                var itemInTable = new HrmWebElement(By.XPath($"{TableListLocator}//*[text()='{itemName}']"));

                return itemInTable.Text.Equals(itemName);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected void ClickAdd() => AddButton.ClickWhenClicable();

        protected void Save()
        {
            SaveButton.ClickWhenClicable();
            SaveButton.WaitForElementIsDisplayed();
        }

        public void ClickEditButton(string title)
        {
            var editButton = new Button(By.XPath(
                    $"{string.Format(ElementInTableLocator, title)}[@class='oxd-icon bi-pencil-fill']"));
            editButton.Click();
        }

        public void ClickTrashIcon(string title)
        {
            var trashIcon = new Button(By.XPath($"{string.Format(ElementInTableLocator, title)}[@class='oxd-icon bi-trash']"));
            trashIcon.ClickWhenClicable();
            VerifyDeleteToaster();
        }

        private void VerifyDeleteToaster() => VerifyDeleteButton.ClickWhenClicable();
    }
}