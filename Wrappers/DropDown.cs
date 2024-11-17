using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Wrappers
{
    public class DropDown : HrmWebElement
    {
        private DropDown DropDownElement => new(By);

        public DropDown(By by) : base(by)
        {
            By = by;
        }

        public void SelectFromListByValue(string value)
        {
            var list = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By));
            if (list.Count > 0)
            {
                var elementValue = list.Select(element => new SelectElement(Element)).ToList();
                elementValue[0].SelectByValue(value);
            }
        }
    }
}
