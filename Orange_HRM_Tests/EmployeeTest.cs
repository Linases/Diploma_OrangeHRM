using Constants;
using Constants.Html;
using Constants.PIM;
using NUnit.Framework;
using Orange_HRM_Modules;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class EmployeeTest : BaseTest
    {
        private EmployeePage _employeePage;
        private LeftPanelNavigationPage _leftPanelNavigationPage;

        [SetUp]
        public void Setup()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage();
        }

        [Test]
        public void AddNewEmployee()
        {
            _employeePage = _leftPanelNavigationPage.ClickPIM();
            _employeePage.ClickAddEmployee();
            var headerTextAddEmployee = _leftPanelNavigationPage.GetAddEmployeeHeader();
            Assert.That(headerTextAddEmployee, Is.EqualTo(PimTabNames.AddEmployee));
            var employee = _employeePage.AddEmployeeData(Employee.Default);
            _ = Driver.GetWait().Until(ExpectedConditions.UrlContains(UrlPartsExisting.PersonalDetails));
            var isEmployeeListTabOpen = _employeePage.IsEmployeeListTabOpen();
            var isNameCorrect = _employeePage.IsNameDisplayedCorrectly($"{employee.FirstName} {employee.Lastname}");
            Assert.Multiple(() =>
            {
                Assert.That(isEmployeeListTabOpen, Is.True, "Employee List tab is not opened");
                Assert.That(isNameCorrect, Is.True, $"Employee name is not {employee.FirstName} {employee.FirstName}");
            });
        }
    }
}
