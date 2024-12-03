using Constants.Html;
using Constants.LeftNavigation;
using NUnit.Framework;

namespace Orange_HRM_Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DashboardTest : BaseTest
    {
        [Test]
        public void DashboardAccessValidation()
        {
            LeftPanelNavigationPage.ClickDashboard();
            var headerTextDashboard = LeftPanelNavigationPage.GetDashboardHeader();
            var areDashboardElementsDisplayed = LeftPanelNavigationPage.AreDashboardElementsDisplayed();
            var isQuickLaunchAvailable = LeftPanelNavigationPage.IsQuickLaunchAvailable();
            Assert.Multiple(() =>
            {
                Assert.That(headerTextDashboard, Is.EqualTo(LeftNavigationMenuNames.Dashboard),
                    "Dashoboard header is not shown");
                Assert.That(Driver.Url, Does.Contain(UrlPartsExisting.Dashboard),
                    "User was not redirected to a dashboard");
                Assert.That(areDashboardElementsDisplayed, Is.True, "All Dashboard elements are not displayed");
                Assert.That(isQuickLaunchAvailable, Is.True, "Quick Launch element is not displayed");
            });
        }
    }
}