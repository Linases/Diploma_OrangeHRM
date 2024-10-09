using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        private static LeftPanelNavigationPage LeftPanelNavigationPage => new();

        [Test]
        public void ValidateSearchFunctionality()
        {
            const string keyword = LeftNavigationMenuNames.Time;
            var menuItemsBeforeSearch = LeftPanelNavigationPage.GetAllMenuItems();
            Assert.That(menuItemsBeforeSearch, Has.Count.EqualTo(LeftNavigationMenuNames.GetAllLeftNavigationMenuNames().Count));
            LeftPanelNavigationPage.EnterSearchText(keyword);
            var menuItemsAfterSearch = LeftPanelNavigationPage.GetAllMenuItems();
            Assert.That(menuItemsAfterSearch, Is.EqualTo(new List<string> { keyword }).AsCollection);
        }
    }
}
