﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;


namespace Wrappers
{
    public class DropDown : HrmWebElement
    {
        public DropDown(By locator) : base(locator)
        {
        }

        public void SelectByText(string text)
        {
            var selectElement = new SelectElement(Element);
            selectElement.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            var selectElement = new SelectElement(Element);
            selectElement.SelectByValue(value);
        }

        public void SelectByIndex(int index)
        {
            var selectElement = new SelectElement(Element);
            selectElement.SelectByIndex(index);
        }

        public IList<IWebElement> GetOptions()
        {
            var selectElement = new SelectElement(Element);
            var allElements = selectElement.Options;
            return allElements;
        }

        public void SelectFromListByValue(By locator, string value)
        {
            var list = WaitHelper.GetWait(Driver).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            if (list.Count > 0)
            {
                var elementValue = list.Select(element => new SelectElement(Element)).ToList();
                elementValue[0].SelectByValue(value);
            }
        }
    }
}
