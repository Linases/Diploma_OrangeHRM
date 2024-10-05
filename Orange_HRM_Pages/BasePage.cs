using Constants;
using FactoryPattern;
using OpenQA.Selenium;
using Wrappers;

namespace Orange_HRM_Pages
{
    public class BasePage
    {
        protected Button AddButton = new Button(By.XPath("//button[text()=' Add ']"));
        protected Button SaveButton = new Button(By.XPath("//button[text()=' Save ']"));

        public void ClickAddButton() => AddButton.Click();

        public void ClickSaveButton() => SaveButton.Click();
    }
}
