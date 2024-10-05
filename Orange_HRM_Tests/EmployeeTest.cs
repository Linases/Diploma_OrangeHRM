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
        private LeftPanelNavigationPage _leftPanelNavigationPage;
        private EmployeePage _employeePage;

        public EmployeeTest() : base(isLogoutNeeded: false)
        {
        }

        [Test]
        public void AddNewEmployee()
        {
            var firstName = $"{RandomHelper.RandomGenerate(6)}";
            var middleName = $"{RandomHelper.RandomGenerate(5)}";
            var lastName = $"{RandomHelper.RandomGenerate(7)}";
            _leftPanelNavigationPage = new LeftPanelNavigationPage(Driver);
            _employeePage = _leftPanelNavigationPage.ClickPIM();
            _employeePage.ClickAddEmployee();
            var headerTextAddEmployee = _leftPanelNavigationPage.GetAddEmployeeHeader();
            Assert.That(headerTextAddEmployee.Equals(PIMHeadersNames.AddEmployee), Is.True);
            _employeePage.AddEmployFullName(firstName, middleName, lastName);
            Driver.GetWait().Until(ExpectedConditions.UrlContains("PersonalDetails"));
            var isEmployeeListTabOpen = _employeePage.IsEmployeeListTabOpen();
            var isNameCorrect = _employeePage.IsNameDisplayedCorrectly($"{firstName} {lastName}");
            Assert.Multiple(() =>
            {
                Assert.That(isEmployeeListTabOpen, Is.True, "Employee List tab is not opened");
                Assert.That(isNameCorrect, Is.True, $"Employee name is not {firstName} {lastName}");
            });
        }
    }
}
