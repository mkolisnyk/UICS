using System;
using OpenQA.Selenium;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;
namespace UITesting.Pages.Banking
{
	public class BankManagerCommonPage : Page
	{
	    [FindBy("//button[contains(text(),'Add Customer')]")]
		public Control buttonAddCustomer;

		[FindBy("//button[contains(text(),'Open Account')]")]
		public Control buttonOpenAccount;

		[FindBy("//button[contains(text(),'Customers')]")]
		public Control buttonCustomers;

		public BankManagerCommonPage(IWebDriver driver) : base(driver)
		{
		}
	}
}
