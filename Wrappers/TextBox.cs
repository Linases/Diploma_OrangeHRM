using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

using Utilities;

namespace Wrappers
{
    public class TextBox : HrmWebElement
    {
        public TextBox(IWebElement element) : base(element)
        {
        }

        public TextBox(By locator) : base(locator)
        {
        }

        public void ClearAndEnterText(string text, By locator)
        {
            WaitHelper.GetWait(Driver).Until(ExpectedConditions.ElementIsVisible(locator));
            Element.Clear();
            Element.SendKeys(text);
        }

        public void WaitoToEnterText(string text, By locator)
        {
            WaitHelper.GetWait(Driver).Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);
        }

        public void EnterText(string text) => Element.SendKeys(text);

        public void DeleteAllTextWithKey()
        {
            Element.SendKeys(Keys.Control + "a");
            Element.SendKeys(Keys.Backspace);
        }

        public void DeleteAndEnterText(string text, By locator)
        {
            WaitHelper.GetWait(Driver).Until(ExpectedConditions.ElementToBeClickable(locator));
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
    }
}
