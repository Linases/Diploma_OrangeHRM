using Constants;
using Constants.Html;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class DashboardTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage;

        [SetUp]
        public void Setup()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage();
        }

        [Test]
        public void DashboardAccessValidation()
        {
            _leftPanelNavigationPage.ClickDashboard();
            var headerTextDashboard = _leftPanelNavigationPage.GetDashboradHeader();
            var areDashboardElementsDisplayed = _leftPanelNavigationPage.AreDashboardElementsDisplayed();
            var isQuickLaunchAvailable = _leftPanelNavigationPage.IsQuickLaunchAvailable();
            Assert.Multiple(() =>
            {
                Assert.That(headerTextDashboard, Is.EqualTo(LeftNavigationMenuNames.Dashboard), "Dashoboard header is not shown");
                Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Dashboard), "User was not redirected to a dashboard");
                Assert.That(areDashboardElementsDisplayed, Is.True, "All Dashboard elements are not displayed");
                Assert.That(isQuickLaunchAvailable, Is.True, "Quick Launch element is not displayed");
            });
        }
    }
}
