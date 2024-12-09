using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Utilities
{
    public static class WaitHelper
    {
        public static WebDriverWait GetWait(
            this IWebDriver driver,
            int timeOutSeconds = 10,
            int pollingIntervalMilliseconds = 200,
            Type[]? exceptionsToIgnore = null)
        {
            var timeOut = TimeSpan.FromSeconds(timeOutSeconds);
            var pollingInterval = TimeSpan.FromMilliseconds(pollingIntervalMilliseconds);
            var clock = new SystemClock();
            var wait = new WebDriverWait(clock, driver, timeOut, pollingInterval);

            var exceptionsToIgnoreByDefault = new[]
            {
                typeof(StaleElementReferenceException),
                typeof(NoSuchElementException),
                typeof(ElementClickInterceptedException),
                typeof(ElementNotInteractableException),
                typeof(WebDriverException),
                typeof(InvalidOperationException),
                typeof(ArgumentNullException),
            };
            var exceptions = exceptionsToIgnore ?? exceptionsToIgnoreByDefault;
            wait.IgnoreExceptionTypes(exceptions);

            return wait;
        }

        public static IList<IWebElement> GetWaitForElementsVisible(this IWebDriver driver, By locator)
        {
            var wait = driver.GetWait();

            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
    }
}