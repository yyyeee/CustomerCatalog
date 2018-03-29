using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace yyyeee.CustomerCatalog.AcceptanceTests.Pages
{
    internal class CustomerListPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "customer-table")]
        public IWebElement Table { get; set; }

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