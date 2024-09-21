using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    public class LoginTest : BaseTest
    {
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage(Driver);
        }

        [Test]
        public void SuccessfulLogin()
        {
            _loginPage.Login(ValidCredentials.userName, ValidCredentials.password);
            Assert.That(Driver.Url.Contains("dashboard"), Is.True, "User was not redirected to it's dashboard");
        }
    }
}