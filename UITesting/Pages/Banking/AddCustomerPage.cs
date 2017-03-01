using System;
using OpenQA.Selenium;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;
namespace UITesting.Pages.Banking
{
	public class AddCustomerPage : BankManagerCommonPage
	{
	    [FindBy("//input[@type='text']")]
		public Edit editFirstName;

		[FindBy("xpath=(//input[@type='text'])[2]")]
		public Edit editLastName;

		[FindBy("xpath=(//input[@type='text'])[3]")]
		public Edit editPostCode;

		[FindBy("//button[text() = 'Add Customer']")]
		public Control buttonSubmit;

		public AddCustomerPage(IWebDriver driver) : base(driver)
		{
		}
	}
}
