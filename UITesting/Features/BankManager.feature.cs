// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UITesting.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Bank Manager")]
    public partial class BankManagerFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BankManager.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bank Manager", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new customer")]
        public virtual void AddNewCustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new customer", ((string[])(null)));
#line 2
  this.ScenarioSetup(scenarioInfo);
#line 3
    testRunner.Given("the banking application has been started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 4
    testRunner.And("I am on the \"Banking Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 5
    testRunner.When("I click on the \"Banking Manager Login\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
    testRunner.Then("I should see the \"Banking Manager Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 7
    testRunner.When("I go to the \"Customers\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
    testRunner.Then("I should see the \"Customers\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
    testRunner.And("the \"Customer List\" table is not empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.When("I note the \"Customer List\" table row count as \"Initial Count\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.And("go to the \"Add Customer\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.Then("I should see the \"Add Customer\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field"});
            table1.AddRow(new string[]
                {
                        "First Name"});
            table1.AddRow(new string[]
                {
                        "Last Name"});
            table1.AddRow(new string[]
                {
                        "Post Code"});
#line 13
    testRunner.And("the following fields are shown:", ((string)(null)), table1, "And ");
#line 18
    testRunner.And("the \"Submit\" field is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table2.AddRow(new string[]
                {
                        "First Name",
                        "Test"});
            table2.AddRow(new string[]
                {
                        "Last Name",
                        "User"});
            table2.AddRow(new string[]
                {
                        "Post Code",
                        "WWW99"});
#line 19
    testRunner.When("I populate current page with the following data:", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "First Name",
                        "Test"});
            table3.AddRow(new string[]
                {
                        "Last Name",
                        "User"});
            table3.AddRow(new string[]
                {
                        "Post Code",
                        "WWW99"});
#line 24
    testRunner.Then("I should see the page contains the following data:", ((string)(null)), table3, "Then ");
#line 29
    testRunner.When("I click on the \"Submit\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
    testRunner.And("accept the alert message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
    testRunner.Then("I should see the \"Add Customer\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
    testRunner.When("I go to the \"Customers\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
    testRunner.Then("I should see the \"Customers\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Label"});
            table4.AddRow(new string[]
                {
                        "Test"});
            table4.AddRow(new string[]
                {
                        "User"});
            table4.AddRow(new string[]
                {
                        "WWW99"});
#line 34
    testRunner.And("the following labels are shown:", ((string)(null)), table4, "And ");
#line 39
    testRunner.And("the \"Customer List\" table has \"Initial Count + 1\" rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
    testRunner.And("the \"Customer List\" table has \"100 * (Initial Count + 1) / 100\" rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "First Name",
                        "Last Name",
                        "Post Code"});
            table5.AddRow(new string[]
                {
                        "Test",
                        "User",
                        "WWW99"});
#line 41
   testRunner.And("the last row of the \"Customer List\" table contains the following data:", ((string)(null)), table5, "And ");
#line 44
    testRunner.When("I click on the last \"Delete Customer\" element of the \"Customer List\" table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
    testRunner.Then("I should see the \"Customer List\" table has \"Initial Count\" rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
