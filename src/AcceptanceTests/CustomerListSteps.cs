using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using yyyeee.CustomerCatalog.AcceptanceTests.Pages;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    [Binding]
    public class CustomerListSteps : BaseAcceptanceTest
    {
        private CustomerListPage _customerListPage;
        private CustomerListPage CustomerListPage
        {
            get
            {
                _customerListPage = _customerListPage ?? new CustomerListPage(Driver);
                return _customerListPage;
            }
        }

        [Given(@"The following customers exist")]
        public void GivenTheFollowingCustomersExist(Table table)
        {
            var customers = table.Rows.Select(row => new Customer
            {
                Id = Guid.NewGuid(),
                Name = row["Name"],
                Status = int.Parse(row["Status"]),
                CreationTime = DateTime.Parse(row["CreationTime"])
            });
            Context.AddCustomers(customers);
        }
        
        [When(@"I open the list of customers")]
        public void WhenIOpenTheListOfCustomers()
        {
            Driver.Navigate().Refresh();
            Assert.NotNull(CustomerListPage);
        }

        [When(@"I filter the list by name with value '(.*)'")]
        public void WhenIFilterTheListByNameWithValue(string filterValue)
        {
            CustomerListPage.FillNameFilter(filterValue);
        }

        [When(@"I sort by name")]
        public void WhenISortByName()
        {
            CustomerListPage.ClickNameColumnHeader();
        }

        [Then(@"the following customers appear in the list")]
        public void ThenTheFollowingCustomersAppearInTheList(Table table)
        {
            var customers = CustomerListPage.GetRows().ToArray();
            Assert.Equal(table.RowCount, customers.Length);

            for (int i = 0; i < table.RowCount; i++)
            {
                var expected = table.Rows[i];
                var actual = customers[i];
                Assert.Equal(expected["Name"], actual.Name);
                Assert.Equal(expected["Status"], actual.Status);
                Assert.Equal(expected["CreationTime"], actual.CreationDate);
            }
        }
    }
}
