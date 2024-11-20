using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class Button : HrmWebElement
    {
        private Button ButtonElement => new(By);

        public Button(By by) : base(by)
        {
        }

        public void ClickWhenClicable() => Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(By)).Click();

        public void ClickIfDisplayed()
        {
            WaitForElementIsDisplayed();
            ButtonElement.Click();
        }
    }
}