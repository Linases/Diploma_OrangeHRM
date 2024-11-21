using System.Collections.ObjectModel;
using System.Drawing;
using Constants.TestSettings.Enum;
using FactoryPattern;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class HrmWebElement : IWebElement
    {
        protected By By;
        protected readonly IWebDriver Driver = BrowserFactory.GetDriver(BrowserType.Chrome);
        protected IWebElement? Element;

        public HrmWebElement(By by)
        {
            By = by;
            Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            var elements = Driver.FindElements(by);
            Element = elements.Count > 0
                ? elements.FirstOrDefault()
                : throw new NoSuchElementException("Element not found.");
        }

        public string Text => Element.Text;

        public bool Enabled => Element.Enabled;

        public bool Selected => Element.Selected;

        public bool Displayed => Element.Displayed;

        public string TagName => Element.TagName;

        public Point Location => Element.Location;

        public Size Size => Element.Size;

        public void Clear() => Element.Clear();

        public void Click() => Element.Click();

        public void SendKeys(string text) => Element.SendKeys(text);

        public void Submit() => Element.Submit();

        public string GetAttribute(string attributeName) => Element.GetAttribute(attributeName);

        public string GetDomAttribute(string attributeName) => Element.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => Element.GetDomProperty(propertyName);

        public string GetCssValue(string propertyName) => Element.GetCssValue(propertyName);

        public ISearchContext GetShadowRoot() => Element.GetShadowRoot();

        public IWebElement FindElement(By by)
        {
            Element.FindElement(by);
            var myWebElement = new HrmWebElement(by);

            return myWebElement;
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var seleniumWebElements = Element.FindElements(by);
            var myWebElements = seleniumWebElements
                .Select(element => (IWebElement)new HrmWebElement(by))
                .ToList();

            return myWebElements.AsReadOnly();
        }

        private bool IsElementDisplayed()
        {
            try
            {
                var isDisplayed = Driver.GetWait().Until(ExpectedConditions.ElementIsVisible(By)).Displayed;

                return isDisplayed;
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found.");

                return false;
            }
        }

        public bool AllElementsAreDisplayed()
        {
            var list = Driver.GetWaitForElementsVisible(By);
            var displayedList = list.All(x => x.Displayed);

            return displayedList;
        }

        public string GetTextToBePresentInElement(string text)
        {
            Driver.GetWait(30, 10).Until(ExpectedConditions.TextToBePresentInElementLocated(By, text));

            return Element.Text;
        }

        public void WaitForElementIsDisplayed() => Driver.GetWait().Until(x => IsElementDisplayed());
    }
}