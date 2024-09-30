using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private By UserName = By.XPath("//*[@name='username']");
        private By Password = By.XPath("//*[@name='password']");
        private Button LoginButton => new Button(By.XPath("//*[@type='submit']"));
        private TextBox UserNameTextBox => new TextBox(UserName);
        private TextBox PasswordTextBox => new TextBox(Password);
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Login(string userName, string userPassword)
        {
            UserNameTextBox.ClearAndEnterText(userName, UserName);
            PasswordTextBox.ClearAndEnterText(userPassword, Password);
            LoginButton.Click();
        }

        public bool IsLoginButtonDisplayed()
        {
            var isDisplayed = LoginButton.Displayed;
            return isDisplayed;
        }
    }
}