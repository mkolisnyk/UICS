using System;
using OpenQA.Selenium;
using UITesting.Framework.Core;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;

namespace UITesting.Pages
{
	public class SearchPage : Page
	{
		[FindBy("ss")]
		public Edit editDestination;
		[FindBy("xpath=(//li[contains(@class, 'autocomplete__item')])[1]")]
		public Control autoCompleteItem;
		[FindBy("xpath=//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]")]
		public Control checkoutDayToday;
		[FindBy("xpath=(//input[@name='sb_travel_purpose'])[2]")]
		public Control radioLeisure;
		[FindBy("xpath=(//input[@name='sb_travel_purpose'])[1]")]
		public Control radioBusiness;
		[FindBy("group_adults")]
		public SelectList selectAdultsNumber;
		[FindBy("xpath=//button[@type='submit']")]
		public Control buttonSubmit;

		public SearchPage(IWebDriver driver) : base(driver)
		{
		}

		public new Page Navigate()
		{
			String baseURL = Configuration.Get("BaseURL");
			this.Driver.Navigate().GoToUrl(baseURL);
			return this;
		}
		public void SelectTravelFor(bool isLeisure)
		{
			if (isLeisure)
			{
				radioLeisure.Click();
			}
			else
			{
				radioBusiness.Click();
			}
		}
	}
}
