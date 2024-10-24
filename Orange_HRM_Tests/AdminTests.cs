﻿using NUnit.Framework;
using Orange_HRM_Pages;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class AdminTests : BaseTest
    {
        private string _newTitle;
        private bool _needToDelete;
        private AdminPage _adminPage;
        private LeftPanelNavigationPage _leftPanelNavigationPage;

        [SetUp]
        public void AdminSetup()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage();
            _adminPage = _leftPanelNavigationPage.ClickAdmin();
        }

        [Test]
        public void ValidateAdminFunction()
        {
            var administrationOptionsDisplayed = _adminPage.AreAdministrationOptionsDisplayed();
            Assert.That(administrationOptionsDisplayed, Is.True, "Admin options are not displayed");
            _adminPage.ClickUserManagement();
            var userManagementOptionsDisplayed = _adminPage.AreOptionsDisplayed();
            Assert.That(userManagementOptionsDisplayed, Is.True, "User Management options are not displayed");
            _adminPage.ClickJob();
            var areJobOptionsDisplayed = _adminPage.AreOptionsDisplayed();
            var isJobTitlesLinkAvailable = _adminPage.IsJobTitleAvailable();
            Assert.That(areJobOptionsDisplayed, Is.True, "Job options are not displayed");
            Assert.That(isJobTitlesLinkAvailable, Is.True, "'Job Titles' link is not available");
        }

        [Test]
        public void AddJobTitle()
        {
            _newTitle = $"{RandomHelper.RandomGenerate(5)}_Name";
            _adminPage.ClickJob();
            _adminPage.SelectJobTitlesButton();
            var isJobTitlesTableVisible = _adminPage.AreJobTitilesItemsVisible();
            Assert.That(isJobTitlesTableVisible, Is.True, "Job Titles table is not visible");
            _adminPage.ClickAddJobTitle();
            _adminPage.AddJobTitleName(_newTitle);
            var isAddedJobDisplayed = _adminPage.IsAddedJobTitleDisplayed(_newTitle);
            Assert.That(isAddedJobDisplayed, Is.True);
            _needToDelete = true;
        }

        [TearDown]
        public void AdminTestsTearDown()
        {
            if (_needToDelete)
            {
                _needToDelete = false;
                _adminPage.ClickDeleteButton(_newTitle);
            }
        }
    }
}
