using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class EmployeeTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        private EmployeePage _employeePage => new EmployeePage(Driver);

        private string _firstName = $"{RandomHelper.RandomGenerate(6)}";
        private string _middleName = $"{RandomHelper.RandomGenerate(5)}";
        private string _lastName = $"{RandomHelper.RandomGenerate(7)}";
        private LoginPage _loginPage;
        
        [SetUp]
        public void Login()
        {
            _loginPage = new LoginPage(Driver);
            _loginPage.Login(ValidCredentials.userName, ValidCredentials.password);
            Assert.That(Driver.Url.Contains("dashboard"), Is.True, "User was not redirected to it's dashboard");
        }

        [Test]
        public void AddNewEmployee()
        {
            _leftPanelNavigationPage.ClickPIM();
            var headerTextPIM = _leftPanelNavigationPage.GetPIMHeader();
            Assert.That(headerTextPIM.Equals(LeftNavigationMenuNames.PIM), Is.True);
            _employeePage.ClickAddEmployee();
            var headerTextAddEmployee = _leftPanelNavigationPage.GetAddEmployeeHeader();
            Assert.That(headerTextAddEmployee.Equals(PIMHeadersNames.AddEmployee), Is.True);
            _employeePage.AddEmployFullName(_firstName, _middleName, _lastName);
            Driver.GetWait().Until(ExpectedConditions.UrlContains("PersonalDetails"));
            var isNameCorrect = _employeePage.IsNameCorrect($"{_firstName} {_lastName}");
            Assert.That(isNameCorrect, Is.True, $"Employee name is not {_firstName} {_lastName}");// errow when run not debug
            Assert.That(_employeePage.IsEmployeeListTabOpen(), Is.True, "Employee List tab is not opened");
        }
    }
}
