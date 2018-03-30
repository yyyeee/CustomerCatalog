using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace yyyeee.CustomerCatalog.AcceptanceTests.Pages
{
    internal class CustomerDetailsPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "customerNameInput")]
        private IWebElement NameInput { get; set; }

        [FindsBy(How = How.Id, Using = "customerStatusSelect")]
        private IWebElement StatusSelect { get; set; }

        [FindsBy(How = How.Id, Using = "saveButton")]
        private IWebElement SaveButton { get; set; }

        public CustomerDetailsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ChangeName(string value)
        {
            NameInput.Clear();
            NameInput.SendKeys(value);
        }

        public void ClickSave()
        {
            SaveButton.Click();
            Thread.Sleep(1000);
        }

        public void ChangeStatus(string status)
        {
            var selectElement = new SelectElement(StatusSelect);
            selectElement.SelectByText(status);
        }
    }
}