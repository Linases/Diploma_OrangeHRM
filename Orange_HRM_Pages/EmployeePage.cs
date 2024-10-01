using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class EmployeePage
    {
        private IWebDriver _driver;
        private By Employee => By.XPath("//*[@class='orangehrm-edit-employee-name']/h6");
        private Button AddEmployee => new(By.XPath("//a[text()='Add Employee']/parent::*"));
        private TextBox FirstName => new(By.XPath("//*[@name='firstName']"));
        private TextBox MiddleName => new(By.XPath("//*[@name='middleName']"));
        private TextBox LastName => new(By.XPath("//*[@name='lastName']"));
        private Button SaveButton => new(By.XPath("//*[text()=' Save ']"));
        private Button EmployeeList => new(By.XPath("//*[text()='Employee List']/parent::*"));
        private TextBox EmployeeName => new(Employee);
        public EmployeePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAddEmployee()
        {
            AddEmployee.Click();
        }

        public void AddEmployFullName(string firstName, string middleName, string lastName)
        {
            FirstName.SendKeys(firstName);
            MiddleName.SendKeys(middleName);
            LastName.SendKeys(lastName);
            SaveButton.Click();
        }

        public bool IsNameCorrect(string name)
        {
           var element = EmployeeName.GetTextToBePresentInElement(EmployeeName, name);
            return element.Equals(name);
        }

        public bool IsEmployeeListTabOpen() => IsTabOpen(EmployeeList);
        private bool IsTabOpen(HrmWebElement element)
        {
            var value = element.GetAttribute("class");
            if (value.Contains("visited"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

