using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class EmployeeTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        private EmployeePage _employeePage => new EmployeePage(Driver);

        [Test]
        public void AddNewEmployee()
        {
            var firstName = $"{RandomHelper.RandomGenerate(6)}";
            var middleName = $"{RandomHelper.RandomGenerate(5)}";
            var lastName = $"{RandomHelper.RandomGenerate(7)}";
            _leftPanelNavigationPage.ClickPIM();
            var headerTextPIM = _leftPanelNavigationPage.GetPIMHeader();
            Assert.That(headerTextPIM.Equals(LeftNavigationMenuNames.PIM), Is.True);
            _employeePage.ClickAddEmployee();
            var headerTextAddEmployee = _leftPanelNavigationPage.GetAddEmployeeHeader();
            Assert.That(headerTextAddEmployee.Equals(PIMHeadersNames.AddEmployee), Is.True);
            _employeePage.AddEmployFullName(firstName, middleName, lastName);
            Driver.GetWait().Until(ExpectedConditions.UrlContains("PersonalDetails"));
            var isNameCorrect = _employeePage.IsNameCorrect($"{firstName} {lastName}");
            Assert.That(isNameCorrect, Is.True, $"Employee name is not {firstName} {lastName}");
            var isEmployeeListTabOpen = _employeePage.IsEmployeeListTabOpen();
            Assert.That(isEmployeeListTabOpen, Is.True, "Employee List tab is not opened");
        }
    }
}
