using System.Threading;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Xunit;
using yyyeee.CustomerCatalog.AcceptanceTests.Pages;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    [Binding]
    public class CustomerDetailsSteps
    {
        private static ChromeDriver Driver => ScenarioContext.Current.Get<ChromeDriver>("Driver");

        private CustomerDetailsPage _customerDetailsPage;
        private CustomerDetailsPage CustomerDetailsPage
        {
            get
            {
                _customerDetailsPage = _customerDetailsPage ?? new CustomerDetailsPage(Driver);
                return _customerDetailsPage;
            }
        }

        [When(@"I open customer '(.*)' view")]
        public void WhenIOpenCustomerView(string customerId)
        {
            Driver.Navigate().GoToUrl($"{ConfigurationProvider.ApplicationAddress}/#/customer/{customerId}");
            Driver.Navigate().Refresh();
            Assert.NotNull(CustomerDetailsPage);
        }
        
        [When(@"I change name to '(.*)'")]
        public void WhenIChangeNameTo(string name)
        {
            CustomerDetailsPage.ChangeName(name);
        }
        
        [When(@"I change status to '(.*)'")]
        public void WhenIChangeStatusTo(string status)
        {
            CustomerDetailsPage.ChangeStatus(status);
        }
        
        [When(@"I click save")]
        public void WhenIClickSave()
        {
            CustomerDetailsPage.ClickSave();
            Driver.SwitchTo().Alert().Accept();
        }
        
        [When(@"I open customers list")]
        public void WhenIOpenCustomersList()
        {
            Driver.Navigate().GoToUrl(ConfigurationProvider.ApplicationAddress);
        }
    }
}
