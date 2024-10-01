using Constants;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Utilities;
using Wrappers;

namespace Orange_HRM_Forms
{
    public class AddKPIForm
    {
        private IWebDriver _driver;
       
        public AddKPIForm(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}