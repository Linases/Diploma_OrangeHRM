using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;

namespace Orange_HRM_Tests
{
    public class DashboardTest : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
        
        [Test]
        public void DashboardAccessValidation()
        {
            _leftPanelNavigationPage.ClickDashboard();
            var headerTextDashboard = _leftPanelNavigationPage.GetDashboradHeader();
            Assert.That(headerTextDashboard.Equals(LeftNavigationMenuNames.Dashboard), Is.True, "Dashoboard header is not shown");
            Assert.That(Driver.Url.Contains("dashboard"), Is.True, "User was not redirected to a dashboard");
            Assert.That(_leftPanelNavigationPage.AreDashboardElementsDisplayed(), Is.True, "All Dashboard elements are not displayed");
            Assert.That(_leftPanelNavigationPage.IsQuickLaunchAvailable(), Is.True, "Quick Launch element is not displayed");
        }
    }
}
