using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Pages.Banking;
using UITesting.Framework.Core;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;

namespace UITesting
{
	[TestFixture()]
	public class TestBanking
	{
		protected HomePage home;
		protected BankManagerCommonPage bankManagerMenu;
		protected AddCustomerPage addCustomer;
		protected CustomersPage customers;

		[SetUp]
		public void SetUp()
		{
			DesiredCapabilities capabilities = new DesiredCapabilities();
			Driver.Add(Configuration.Platform, Configuration.DriverPath, capabilities);
			home = PageFactory.Init<HomePage>();
			home.Navigate();
		}
		[TearDown]
		public void TearDown()
		{
			Driver.Quit();
		}
		[Test()]
		public void TestAddNewCustomer()
		{ 
	        home.buttonBankManagerLogin.Click();
	        bankManagerMenu = PageFactory.Init<BankManagerCommonPage>();
	        bankManagerMenu.buttonCustomers.Click();
	        
	        customers = PageFactory.Init<CustomersPage>();
	        customers.buttonAddCustomer.Click();
	        
	        addCustomer = PageFactory.Init<AddCustomerPage>();
			System.Threading.Thread.Sleep(1000);
	        addCustomer.editFirstName.Text = "Test";
	        addCustomer.editLastName.Text = "User";
	        addCustomer.editPostCode.Text = "WWW99";
	        addCustomer.buttonSubmit.Click();
	        addCustomer.Driver.SwitchTo().Alert().Accept();
			addCustomer.buttonCustomers.Click();

	        customers = PageFactory.Init<CustomersPage>();
		}
	}
}
