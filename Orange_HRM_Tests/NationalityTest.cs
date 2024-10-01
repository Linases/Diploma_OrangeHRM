using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class NationalityTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        private AdminPage _adminPage;
        private static string _nationality = "Afghan";
        private string? _editNationality;

        [Test]
        public void ChangeNationality()
        {
            _editNationality = _nationality.Substring(0, _nationality.Length - 1);
            _adminPage = _leftPanelNavigationPage.ClickAdmin();
            _ = _leftPanelNavigationPage.GetAdminHeader();
            _adminPage.ClickNationalities();
            var isAnyNationalitiesDisplayed = _adminPage.IsAnyNationalitiesDisplayed();
            Assert.That(isAnyNationalitiesDisplayed, Is.True, "Nationalities are not displayed");
            _adminPage.ClickEditButton(_nationality);
            _adminPage.EditName(_editNationality);
            var newName = _adminPage.GetChangedName(_editNationality);
            Assert.That(newName, Is.EqualTo(_editNationality));
        }

        [TearDown]
        public void TearDownNationalities()
        {
            RestoreNationality();
        }

        private void RestoreNationality()
        {
            _adminPage.ClickEditButton(_editNationality);
            _adminPage.EditName(_nationality);
            var newName = _adminPage.GetChangedName(_nationality);
            Assert.That(newName, Is.EqualTo(_nationality));
        }
    }
}
