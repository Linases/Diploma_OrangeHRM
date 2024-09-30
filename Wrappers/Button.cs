using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class Button : HrmWebElement
    {
        public Button(IWebElement element) : base(element)
        {
        }

        public Button(By locator) : base(locator)
        {
        }

        public void ClickWhenClicable(By locator)
        {
            Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        public void ClickIfDisplayed(By locator)
        {
            try
            {
                _ = WaitHelper.GetWait(Driver, 10, 200).Until(ExpectedConditions.ElementIsVisible(locator));
                if (Element.Displayed)
                {
                    Click();
                }
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with {locator} did not appear within the specified time.");
            }
        }
    }
}
