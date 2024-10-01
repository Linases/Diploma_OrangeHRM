using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Orange_HRM_Pages;
using Utilities;

namespace Orange_HRM_Tests
{
    [TestFixture]
    class PerformanceTests : BaseTest
    {
            private LeftPanelNavigationPage _leftPanelNavigationPage => new LeftPanelNavigationPage(Driver);
            
            [Test]
            public void ValidatePerformanceManagementFunctionality()
            {
                var firstName = $"{RandomHelper.RandomGenerate(6)}";
                var middleName = $"{RandomHelper.RandomGenerate(5)}";
                var lastName = $"{RandomHelper.RandomGenerate(7)}";
                var performancePage = _leftPanelNavigationPage.ClickPerformance();
                performancePage.ClickConfigureTab();
                performancePage.ClickKPIsTab();

            }
}
