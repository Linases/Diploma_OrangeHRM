using Constants.Html;
using Constants.Performance;
using NUnit.Framework;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    public class PerformanceTests : BaseTest
    {
        private PerformancePage _performancePage;

        [Test]
        public void ValidatePerformanceManagementFunctionality()
        {
            _performancePage = LeftPanelNavigationPage.ClickPerformance();
            _performancePage.ClickConfigureTab();
            _performancePage.ClickKPIsTab();
            Driver.GetWait().Until(ExpectedConditions.UrlContains(UrlPartsExisting.Kpi));
            var existingRecords = _performancePage.GetKPIRecords();
            _performancePage.ClickAddKpi();
            _performancePage.AddKpItext(KpiNames.Analyze);
            _performancePage.SelectJobTitle();
            _performancePage.ClickSaveButton();
            var existingRecordsAfterAdd = _performancePage.GetKPIRecords();
            Assert.That(existingRecordsAfterAdd, Is.Not.EqualTo(existingRecords));
            var isKpiAdded = _performancePage.IsDisplayedInTable(KpiNames.Analyze);
            Assert.That(isKpiAdded, Is.True, $"{KpiNames.Analyze} was not added to the records");
            _performancePage.ClickTrashIcon(KpiNames.Analyze);
            var isKpiDeleted = _performancePage.IsDisplayedInTable(KpiNames.Analyze);
            Assert.That(isKpiDeleted, Is.False, $"{KpiNames.Analyze} was not removed from the records");
        }
    }
}
