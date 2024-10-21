using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage;
       
        [SetUp]
        public void Setup()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage();
        }

        [Test]
        public void ValidateSearchFunctionality()
        {
            const string keyword = LeftNavigationMenuNames.Time;
            var menuItemsBeforeSearch = _leftPanelNavigationPage.GetAllMenuItems();
            Assert.That(menuItemsBeforeSearch, Has.Count.EqualTo(LeftNavigationMenuNames.GetAllLeftNavigationMenuNames().Count));
            _leftPanelNavigationPage.EnterSearchText(keyword);
            var menuItemsAfterSearch = _leftPanelNavigationPage.GetAllMenuItems();
            Assert.That(menuItemsAfterSearch, Is.EqualTo(new List<string> { keyword }).AsCollection);
        }
    }
}
