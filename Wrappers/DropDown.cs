using OpenQA.Selenium;
using Utilities;

namespace Wrappers
{
    public class DropDown : HrmWebElement
    {
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
            Driver.GetWaitForElementsVisible(By);
            var list = Driver.FindElements(By).ToList();
            if (list.Count > 0)
            {
                var element = list.Last();
                Driver.GetWait().Until(driver => element.Displayed && element.Enabled);
                element.Click();
            }
        }
    }
}