using OpenQA.Selenium;
using Orange_HRM_Modules;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class LoginPage
    {
        private By UserName = By.XPath("//*[@name='username']");
        private By Password = By.XPath("//*[@name='password']");
        private Button LoginButton => new Button(By.XPath("//*[@type='submit']"));
        private TextBox UserNameTextBox => new TextBox(UserName);
        private TextBox PasswordTextBox => new TextBox(Password);

        public void LoginAsAdministrator(User user)
        {
            UserNameTextBox.ClearAndEnterText(user.UserName, UserName);
            PasswordTextBox.ClearAndEnterText(user.Password, Password);
            LoginButton.Click();
        }

        public bool IsLoginButtonDisplayed() => LoginButton.Displayed;
    }
}