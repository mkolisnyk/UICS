using System;
using OpenQA.Selenium;
using UITesting.Framework.Core;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;

namespace UITesting.Pages
{
	public class SearchPage : Page
	{
		public Edit editDestination;
		public Control autoCompleteItem;
		public Control checkoutDayToday;
		public Control radioLeisure;
		public Control radioBusiness;
		public SelectList selectAdultsNumber;
		public Control buttonSubmit;

		public SearchPage(IWebDriver driver) : base(driver)
		{
			editDestination = new Edit(this, By.Id("ss"));
			autoCompleteItem = new Control(this,
												   By.XPath("(//li[contains(@class, 'autocomplete__item')])[1]"));
			//Control checkoutDayExpand = new Control(driver,
			//                            	By.CssSelector("i.sb-date-field__chevron.bicon-downchevron"));
			checkoutDayToday = new Control(this,
											By.XPath("//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]"));
			radioLeisure = new Control(this, By.XPath("(//input[@name='sb_travel_purpose'])[2]"));
			radioBusiness = new Control(this, By.XPath("(//input[@name='sb_travel_purpose'])[1]"));
			selectAdultsNumber = new SelectList(this, By.Id("group_adults"));
			buttonSubmit = new Control(this, By.XPath("//button[@type='submit']"));

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
