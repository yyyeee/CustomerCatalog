using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace yyyeee.CustomerCatalog.AcceptanceTests.Pages
{
    internal class CustomerListPage
    {
        private readonly IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Filter Name']")]
        private IWebElement NameFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[contains(@class,'sorting')]/span[text() = 'Name']")]
        private IWebElement NameColumnHeader { get; set; }

        public CustomerListPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ICollection<CustomerRow> GetRows()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 0, 5));

            var tableRows = _driver.FindElements(By.XPath("//table/tbody/tr"));
            var values = new List<CustomerRow>();
            foreach (var row in tableRows)
            {
                wait.Until(driver => row.FindElement(By.XPath("td[2]/span")));
                var name = row.FindElement(By.XPath("td[2]/span")).Text;
                var status = row.FindElement(By.XPath("td[4]/span")).Text;
                var date = row.FindElement(By.XPath("td[3]/span")).Text;
                values.Add(new CustomerRow(name, status, date));
            }

            return values;
        }

        public void FillNameFilter(string value)
        {
            NameFilter.SendKeys(value);
            Thread.Sleep(1000);
        }

        public void ClickNameColumnHeader()
        {
            NameColumnHeader.Click();
            Thread.Sleep(1000);
        }
    }

    internal class CustomerRow
    {
        public CustomerRow(string name, string status, string date)
        {
            Name = name;
            Status = status;
            CreationDate = date;
        }

        public string Name { get; }
        public string Status { get; }
        public string CreationDate { get; }
    }
}