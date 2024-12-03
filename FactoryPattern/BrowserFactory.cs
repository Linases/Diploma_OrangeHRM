using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using BrowserType = Constants.TestSettings.Enum.BrowserType;

namespace FactoryPattern
{
    public static class BrowserFactory
    {
        private static ThreadLocal<IWebDriver> _driver = new(() => CreateDriverInstance(BrowserType.Chrome));

        public static IWebDriver GetDriver(BrowserType browserType)
        {
            if (!_driver.IsValueCreated)
            {
                _driver.Value = CreateDriverInstance(browserType);
            }

            return _driver.Value;
        }

        private static IWebDriver CreateDriverInstance(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Chrome => new ChromeDriver(),
                _ => throw new NotSupportedException($"Browser type '{browserType}' is not supported."),
            };
        }

        public static void CloseDriver()
        {
            if (_driver.IsValueCreated && _driver.Value != null)
            {
                _driver.Value.Quit();
                _driver.Dispose();
                _driver = new ThreadLocal<IWebDriver>(() => CreateDriverInstance(BrowserType.Chrome));
            }
        }
    }
}