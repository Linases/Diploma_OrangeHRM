using Constants;
using FactoryPattern;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class BasePage
    {
        protected static IWebDriver Driver => BrowserFactory.GetDriver(BrowserType.Chrome);
        protected By SpinnerLocator = By.XPath("//*[@class='oxd-loading-spinner']");
        protected  By SaveButtonLocator => By.XPath("//button[text()=' Save ']");
        protected  By AddButtonLocator => By.XPath("//button[text()=' Add ']");
        protected  By VerifyDelete => By.XPath("//*[@class='oxd-icon bi-trash oxd-button-icon']");
        protected  Button AddButton => new Button(AddButtonLocator);
        protected  Button SaveButton => new Button(SaveButtonLocator);
        protected  Button VerifyDeleteButton => new Button(VerifyDelete);
        protected HrmWebElement Spinner => new HrmWebElement(SpinnerLocator);

        public void ClickAdd()
        {
            AddButton.Click();
            Driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(AddButtonLocator));
        }

        public void Save()
        {
            SaveButton.Click();
            Driver.GetWait().Until(ExpectedConditions.InvisibilityOfElementLocated(SaveButtonLocator));
        }

        public void WaitForSpinnerIsNotVisible() => Spinner.WaitForElementIsNotDisplayed(SpinnerLocator);

        public void VerifyDeleteToaster()
        {
            Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(VerifyDelete));
            VerifyDeleteButton.ClickWhenClicable(VerifyDelete);
        }
    }
}
