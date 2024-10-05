﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class PerformancePage
    {
            private IWebDriver _driver;
            private By ConfirureTabLocator => By.XPath("//*[@aria-label='Topbar Menu']//*[text()='Configure ']");
            private By KPIsLocator => By.XPath("//*[@aria-label='Topbar Menu']//ul//*[text()='KPIs']");

            private By JobTitleSelect => By.XPath("//*[contains(@class,'select-text-input')]");
            private Button AddKPIButton => new(By.XPath("//*[text()=' Add ']"));
            private Button SaveKpIButton => new(By.XPath("//*[text()=' Save ']"));
            private TextBox KpiInput = new TextBox(By.XPath("(//label['Key Performance Indicator']/parent::*/following-sibling::*/input)[1]"));
            private Button ConfirureTab => new(ConfirureTabLocator);
            private Button KPIsTab => new(KPIsLocator);

            public PerformancePage(IWebDriver driver)
            {
                _driver = driver;
            }

            public void ClickConfigureTab() => ConfirureTab.ClickWhenClicable(ConfirureTabLocator);

            public void ClickKPIsTab() => KPIsTab.ClickWhenClicable(KPIsLocator);

            public void ClickAddKpi() => AddKPIButton.Click();

            public void AddKpItext(string text) => KpiInput.SendKeys(text);

            public void SelectJobTitle()
            {
                var selectDropdown = new HrmWebElement(JobTitleSelect);
                selectDropdown.Click();
                selectDropdown.SendKeys(Keys.ArrowDown);
            }

            public void ClickSaveButton() => SaveKpIButton.Click();
        }
    }
}

