using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

using Utilities;

namespace Wrappers
{
    public class TextBox : HrmWebElement
    {
        private TextBox TextBoxElement => new(By);

        public TextBox(By by) : base(by)
        {
        }

        public void ClearAndEnterText(string text, By locator)
        {
            TextBoxElement.WaitForElementIsDisplayed();
            TextBoxElement.Clear();
            TextBoxElement.SendKeys(text);
        }

        public void EnterText(string text) => TextBoxElement.SendKeys(text);

        public void DeleteAndEnterText(string text)
        {
            Driver.GetWait().Until(ExpectedConditions.ElementToBeClickable(By));
            Click();
            if (Element.GetAttribute("value").Length > 0)
            {
                DeleteAllTextWithKey();
            }
            if (Element.Enabled)
            {
                SendKeys(text);
            }
        }

        private void DeleteAllTextWithKey()
        {
            Element.SendKeys(Keys.Control + "a");
            Element.SendKeys(Keys.Backspace);
        }
    }
}
