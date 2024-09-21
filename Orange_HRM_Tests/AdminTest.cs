using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Orange_HRM_Tests
{
    public class AdminTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        private AdminPage _adminPage => new AdminPage(Driver);
        private string _newTitle;
        private string _jobTitleName => $"{RandomHelper.RandomGenerate(5)}";
        private bool needToDelete;

        [Test]
        public void AdminFunctionValidation()
        {
            _leftPanelNavigationPage.ClickAdmin();
            var headerTextAdmin = _leftPanelNavigationPage.GetAdminHeader();
            Assert.That(headerTextAdmin.Equals(LeftNavigationMenuNames.Admin), Is.True);
            Assert.That(_adminPage.AreAdministrationOptionsDisplayed(), Is.True, "Admin options are not displayed");
            _adminPage.ClickUserManagement();
            Assert.That(_adminPage.AreOptionsDisplayed(), Is.True, "User Management options are not displayed");
            _adminPage.ClickJob();
            Assert.That(_adminPage.AreOptionsDisplayed(), Is.True, "Job options are not displayed");
            Assert.That(_adminPage.IsJobTitleAvailable(), Is.True, "'Job Titles' link is not available");
        }

        [Test]
        public void AddJobTitle()
        {
            _leftPanelNavigationPage.ClickAdmin();
            _adminPage.ClickJob();
            Assert.That(_adminPage.AreOptionsDisplayed(), Is.True, "Job options are not displayed");
            _adminPage.SelectJobTitle();
            Assert.That(_adminPage.AreJobTitilesItemsVisible(), Is.True, "Job Titles table is not visible");
            _adminPage.ClickAddJobTitle();
            _newTitle = _jobTitleName;
            _adminPage.AddJobTitleName(_newTitle);
            Assert.That(_adminPage.IsAddedJobTitleDisplayed(_newTitle), Is.True);
            needToDelete = true;
        }

        [TearDown]
        public void TearDown()
        {
            if(needToDelete)
            {
                _adminPage.ClickDeleteButton(_newTitle);
            }
        }

    }
}
