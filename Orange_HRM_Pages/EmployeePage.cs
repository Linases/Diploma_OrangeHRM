using OpenQA.Selenium;
using Orange_HRM_Modules;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class EmployeePage
    {
        private Button AddEmployee => new(By.XPath("//a[text()='Add Employee']/parent::*"));
        private TextBox FirstName => new(By.XPath("//*[@name='firstName']"));
        private TextBox MiddleName => new(By.XPath("//*[@name='middleName']"));
        private TextBox LastName => new(By.XPath("//*[@name='lastName']"));
        private Button SaveButton => new(By.XPath("//*[text()=' Save ']"));
        private Button EmployeeList => new(By.XPath("//*[text()='Employee List']/parent::*"));
        private TextBox EmployeeName => new(By.XPath("//*[@class='orangehrm-edit-employee-name']/h6"));

        public void ClickAddEmployee() => AddEmployee.Click();

        public Employee AddEmployeeData(Employee employee)
        {
            FirstName.SendKeys(employee.FirstName);
            MiddleName.SendKeys(employee.MiddleName);
            LastName.SendKeys(employee.Lastname);
            SaveButton.Click();

            return employee;
        }

        public bool IsNameDisplayedCorrectly(string name)
        {
            var textValue = EmployeeName.GetTextToBePresentInElement(name);

            return textValue.Equals(name);
        }

        public bool IsEmployeeListTabOpen() => IsTabOpen(EmployeeList);

        private bool IsTabOpen(HrmWebElement element)
        {
            var value = element.GetAttribute("class");

            return value.Contains("visited");
        }
    }
}

