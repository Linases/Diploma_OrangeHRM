using Constants.TestSettings.Enum;
using FactoryPattern;
using OpenQA.Selenium;
using Utilities;

namespace Wrappers
{
    public class DropDown : HrmWebElement
    {
        private static IWebDriver CurrentDriver => BrowserFactory.GetDriver(BrowserType.Chrome);
        public DropDown(By by) : base(by)
        {
            By = by;
        }

        public void SelectByTextValue(string text)
        {
            var options = Driver.FindElements(By);
            foreach (var option in options)
            {
                if (option.Text.Equals(text))
                {
                    option.Click();

                    return;
                }
            }

            throw new Exception($"Option with text '{text}' not found in the dropdown.");
        }

        public void SelectLastOption()
        {
            var list = Driver.FindElements(By).ToList();
            if (list.Count == 0)
            {
                throw new NoSuchElementException("No elements found matching the criteria.");
            }

            var element = list.Last();
            ScrollToElement(element);
            Driver.GetWait().Until(driver => element.Displayed &element.Enabled );
            element.Click();
        }

        private  void ScrollToElement( IWebElement element)
        {
            ((IJavaScriptExecutor)CurrentDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
