using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class Button : HrmWebElement
    {
        public Button(By locator) : base(locator)
        {
        }

        public void ClickWhenClicable()
        {
            Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(By)).Click();
        }

        public void ClickIfDisplayed()
        {
            try
            {
                WaitHelper.GetWait(Driver, 10, 200).Until(ExpectedConditions.ElementIsVisible(By));
                if (Element.Displayed)
                {
                    Click();
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with {By} did not appear within the specified time.");
            }
        }
    }
}
