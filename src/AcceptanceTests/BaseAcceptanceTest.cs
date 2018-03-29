using System;
using OpenQA.Selenium.Chrome;

namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    public abstract class BaseAcceptanceTest : IDisposable
    {
        protected readonly ChromeDriver Driver;

        protected BaseAcceptanceTest()
        {
            Driver = new ChromeDriver
            {
                Url = ConfigurationProvider.ApplicationAddress
            };
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Context = new CustomerContext();
        }

        protected readonly CustomerContext Context;

        public void Dispose()
        {
            Context.Cleanup();
            Driver.Dispose();
        }
    }
}