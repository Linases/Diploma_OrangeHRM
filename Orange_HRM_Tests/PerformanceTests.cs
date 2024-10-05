using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Orange_HRM_Pages;
using SeleniumExtras.WaitHelpers;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
   public class PerformanceTests : BaseTest
    {
        private LeftPanelNavigationPage _leftPanelNavigationPage;
        private PerformancePage _performancePage;

        [Test]
        public void ValidatePerformanceManagementFunctionality()
        {
            var firstName = $"{RandomHelper.RandomGenerate(6)}";
            var middleName = $"{RandomHelper.RandomGenerate(5)}";
            var lastName = $"{RandomHelper.RandomGenerate(7)}";
            _leftPanelNavigationPage = new LeftPanelNavigationPage(Driver);
             _leftPanelNavigationPage.ClickPerformance();
            _performancePage = new PerformancePage(Driver);
            _performancePage.ClickConfigureTab();
            _performancePage.ClickKPIsTab();
            Driver.GetWait().Until(ExpectedConditions.UrlContains("Kpi"));
            _performancePage.ClickAddKpi();
           _performancePage.AddKpItext(firstName);
        }
    }
}
