using System;
using OpenQA.Selenium.Remote;
using UITesting.Framework.Core;
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
	}
}
