using System;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using UITesting.Framework.Core;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;
using TechTalk.SpecFlow;

namespace UITesting.KDTSteps
{
	[Binding]
	public class BasicKDTSteps
	{
		public BasicKDTSteps()
		{
		}
		[Before]
		public void SetUp()
		{
			DesiredCapabilities capabilities = new DesiredCapabilities();
			Driver.Add(Configuration.Platform, Configuration.DriverPath, capabilities);
		}
		[After]
		public void TearDown()
		{
			Driver.Quit();
		}
		[Given("^the banking application has been started$")]
		public void StartBankingApplication()
		{
			Driver.Current().Navigate().GoToUrl("http://www.globalsqa.com/angularJs-protractor/BankingProject/#/login");
		}

	   	[Given("^I am on the \"(.*)\" (?:page|screen)$")]
		[When("^(?:I |)go to the \"(.*)\" (?:page|screen)$")]
		public void NavigateToPage(String name)
		{
			Page target = Page.Screen(name);
			Assert.NotNull(target, "Unable to find the '" + name + "' page.");
			target.Navigate();
			VerifyCurrentPage(name);
		}

		[When("^(?:I |)(?:click|tap) on the \"(.*)\" (?:button|element|control)$")]
		public void ClickOnTheButton(String name)
		{
			Control control = Page.Current[name];
			Assert.NotNull(control, "Unable to find the '" + name + "' element on current page.");
			control.Click();
		}

		[Then("^I should see the \"(.*)\" (?:page|screen)$")]
		public void VerifyCurrentPage(String name)
		{
			Page target = Page.Screen(name);
			Assert.True(target.IsCurrent(), "The '" + name + "' screen is not current");
			Page.Current = target;
		}

	    [Then("^(?:I should see |)the \"(.*)\" field is available$")]
		public Control verifyElementExists(String fieldName)
		{
			Control control = Page.Current[fieldName];
			Assert.NotNull(control, "Unable to find the '" + fieldName + "' element on current page.");
        	return control;
		}

		[When("^(?:I |)enter \"(.*)\" text into the \"(.*)\" field$")]
		public void enterText(String text, String fieldName)
		{
			Edit control = (Edit) verifyElementExists(fieldName);
			control.Text = text;
		}

		[Then("^(?:I should see |)the \"(.*)\" field contains the \"(.*)\" text$")]
		public void verifyFieldText(String fieldName, String text)
		{
			Control control = (Control) verifyElementExists(fieldName);
			String actualText = control.Text;
			Assert.True(
				text.Equals(actualText) || actualText.Contains(text),
				String.Format("The '{0}' field has unexpected text. Expected: '{1}', Actual: '{2}'",
                fieldName,
                text,
                actualText
            ));
		}
	}
}
