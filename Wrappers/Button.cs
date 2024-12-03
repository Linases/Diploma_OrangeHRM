using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class Button : HrmWebElement
    {
        public Button(By by) : base(by)
        {
        }

        public void ClickWhenClicable() => Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(By)).Click();
    }
}