using System;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    [Binding]
    public class StartStopHooks
    {
        private ChromeDriver _driver;
        private CustomerContext _context;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver
            {
                Url = ConfigurationProvider.ApplicationAddress
            };
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            ScenarioContext.Current.Set(_driver, "Driver");
            _context = new CustomerContext();
            ScenarioContext.Current.Set(_context, "Context");
        }

        [AfterScenario]
        public void Teardown()
        {
            _context.Cleanup();
            _driver.Dispose();
        }
    }
}