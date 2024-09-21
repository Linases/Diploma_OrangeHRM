using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class NationalityTest: BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        private AdminPage _adminPage => new AdminPage(Driver);
        private static string _nationality = "Afghan";
        private string _editnationality = _nationality.Substring(0, _nationality.Length - 1);


        public void ChangeNationality()
        {
            _leftPanelNavigationPage.ClickAdmin();
            var headerTextAdmin = _leftPanelNavigationPage.GetAdminHeader();
            Assert.That(headerTextAdmin.Equals(LeftNavigationMenuNames.Admin), Is.True);
            _adminPage.ClickNationalities();
            Assert.That(_adminPage.IsAnyNationalitiesDisplayed, Is.True);
            _adminPage.ClickEditButton(_nationality);
            _adminPage.EditName(_editnationality);
            var newName = _adminPage.GetChangedName(_editnationality);
            Assert.That(newName, Is.EqualTo(_editnationality));
        }

        [TearDown]
        public void RestoreNationality()
        {
            _adminPage.ClickEditButton(_editnationality);
            _adminPage.EditName(_nationality);
            var newName = _adminPage.GetChangedName(_nationality);
            Assert.That(newName, Is.EqualTo(_nationality));
        }
    }
}
