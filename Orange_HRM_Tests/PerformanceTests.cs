using Constants;
using NUnit.Framework;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class PerformanceTests : BaseTest
    {
        private LeftPanelNavigationPage? _leftPanelNavigationPage;
        private PerformancePage? _performancePage;

        [Test]
        public void ValidatePerformanceManagementFunctionality()
        {
            _leftPanelNavigationPage = new LeftPanelNavigationPage(Driver);
            _performancePage = _leftPanelNavigationPage.ClickPerformance();
            _performancePage.ClickConfigureTab();
            _performancePage.ClickKPIsTab();
            Driver.GetWait().Until(ExpectedConditions.UrlContains("Kpi"));
            var existingRecords = _performancePage.GetKPIRecords();
            _performancePage.ClickAddKpi();
            _performancePage.AddKpItext(KPINames.Analyze);
            _performancePage.SelectJobTitle();
            _performancePage.ClickSaveButton();
            var existingRecordsAfterAdd = _performancePage.GetKPIRecords();
            Assert.That(existingRecordsAfterAdd, Is.Not.EqualTo(existingRecords));
            var isKPIWasAdded = _performancePage.IsAddedKPIDisplayed(KPINames.Analyze);
            Assert.That(isKPIWasAdded, Is.True, $"{KPINames.Analyze} was not added to the records");
        }
    }
}
