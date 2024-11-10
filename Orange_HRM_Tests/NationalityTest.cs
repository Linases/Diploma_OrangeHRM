using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class NationalityTest : BaseTest
    {
        private AdminPage _adminPage;
        private readonly string _nationality = Nationalities.Afghan;
        private string _editedNationality;
        private LeftPanelNavigationPage _leftPanelNavigationPage;

        [SetUp]
        public void Setup()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage();
        }

        [Test]
        public void ChangeNationality()
        {
            _adminPage = _leftPanelNavigationPage.ClickAdmin();
            _adminPage.ClickNationalities();
            var isAnyNationalitiesDisplayed = _adminPage.IsAnyNationalitiesDisplayed();
            Assert.That(isAnyNationalitiesDisplayed, Is.True, "Nationalities are not displayed");
            _adminPage.ClickEditButton(_nationality);
            _editedNationality = _nationality.Substring(0, _nationality.Length - 1);
            _adminPage.EditName(_editedNationality);
            var newName = _adminPage.GetChangedName(_editedNationality);
            Assert.That(newName, Is.EqualTo(_editedNationality));
        }

        [TearDown]
        public void TearDownNationalities()
        {
            RestoreNationality();
        }

        private void RestoreNationality()
        {
            _adminPage.ClickEditButton(_editedNationality);
            _adminPage.EditName(_nationality);
            var newName = _adminPage.GetChangedName(_nationality);
            Assert.That(newName, Is.EqualTo(_nationality));
        }
    }
}
