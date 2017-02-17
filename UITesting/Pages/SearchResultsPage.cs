using System;
using OpenQA.Selenium;
using UITesting.Framework.UI;
using UITesting.Framework.UI.Controls;

namespace UITesting.Pages
{
	public class SearchResultsPage : Page
	{
		public Edit editDestination;

		public SearchResultsPage(IWebDriver driver) : base(driver)
		{
			editDestination = new Edit(this, By.Id("ss"));
		}
	}
}
