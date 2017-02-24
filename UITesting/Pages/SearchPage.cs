using System;
using OpenQA.Selenium;
using UITesting.Framework.Core;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;

namespace UITesting.Pages
{
	public class SearchPage : Page
	{
		[FindBy("ss", Platform = TargetPlatform.ANY_WEB)]
        public Edit editDestination;
		[FindBy("xpath=(//li[contains(@class, 'autocomplete__item')])[1]", Platform = TargetPlatform.ANY_WEB)]
		public Control autoCompleteItem;
		[FindBy("xpath=//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]", Platform = TargetPlatform.ANY_WEB)]
		public Control checkoutDayToday;
		[FindBy("xpath=(//input[@name='sb_travel_purpose'])[2]", Platform = TargetPlatform.ANY_WEB)]
		public Control radioLeisure;
		[FindBy("xpath=(//input[@name='sb_travel_purpose'])[1]", Platform = TargetPlatform.ANY_WEB)]
		public Control radioBusiness;
		[FindBy("group_adults", Platform = TargetPlatform.ANY_WEB)]
		public SelectList selectAdultsNumber;
		[FindBy("xpath=//button[@type='submit']", Platform = TargetPlatform.ANY_WEB)]
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
