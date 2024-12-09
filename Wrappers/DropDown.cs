using OpenQA.Selenium;

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
    }
}