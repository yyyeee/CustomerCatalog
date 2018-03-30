﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace yyyeee.CustomerCatalog.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CustomerDetailsFeature : Xunit.IClassFixture<CustomerDetailsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CustomerDetails.feature"
#line hidden
        
        public CustomerDetailsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customer details", "\tIn order to have customer updated\r\n\tAs a user\r\n\tI want to be able to edit custom" +
                    "er", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(CustomerDetailsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Edit customer details")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer details")]
        [Xunit.TraitAttribute("Description", "Edit customer details")]
        [Xunit.TraitAttribute("Category", "customerDetails")]
        public virtual void EditCustomerDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit customer details", new string[] {
                        "customerDetails"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Status",
                        "CreationTime",
                        "Id"});
            table1.AddRow(new string[] {
                        "Customer1",
                        "1",
                        "2018-03-27 11:00",
                        "b14bf7f2-c66d-4927-a322-42eb4f5b40e1"});
#line 8
 testRunner.Given("The following customers exist", ((string)(null)), table1, "Given ");
#line 11
 testRunner.When("I open customer \'b14bf7f2-c66d-4927-a322-42eb4f5b40e1\' view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.When("I change name to \'New name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.When("I change status to \'Current\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.When("I click save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.When("I open customers list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Status",
                        "CreationTime"});
            table2.AddRow(new string[] {
                        "New name",
                        "Prospective",
                        "Mar 27th 18"});
#line 16
 testRunner.Then("the following customers appear in the list", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="See customer details")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer details")]
        [Xunit.TraitAttribute("Description", "See customer details")]
        [Xunit.TraitAttribute("Category", "customerDetails")]
        public virtual void SeeCustomerDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("See customer details", new string[] {
                        "customerDetails"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="See notes for customer")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer details")]
        [Xunit.TraitAttribute("Description", "See notes for customer")]
        [Xunit.TraitAttribute("Category", "customerDetails")]
        public virtual void SeeNotesForCustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("See notes for customer", new string[] {
                        "customerDetails"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Add note for customer")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer details")]
        [Xunit.TraitAttribute("Description", "Add note for customer")]
        [Xunit.TraitAttribute("Category", "customerDetails")]
        public virtual void AddNoteForCustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add note for customer", new string[] {
                        "customerDetails"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Edit note for customer")]
        [Xunit.TraitAttribute("FeatureTitle", "Customer details")]
        [Xunit.TraitAttribute("Description", "Edit note for customer")]
        [Xunit.TraitAttribute("Category", "customerDetails")]
        public virtual void EditNoteForCustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit note for customer", new string[] {
                        "customerDetails"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CustomerDetailsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CustomerDetailsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
