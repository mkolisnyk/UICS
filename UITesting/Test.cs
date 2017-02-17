using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;

namespace UITesting
{
	[TestFixture()]
	public class Test
	{
		private IWebDriver driver;
		private String baseURL;

		[SetUp]
		public void SetUp()
		{
			baseURL = Configuration.Get("BaseURL");
			DesiredCapabilities capabilities = new DesiredCapabilities();
			Driver.Add(Configuration.Get("Browser"), Path.GetFullPath("."), capabilities);
			driver = Driver.Current();
			driver.Navigate().GoToUrl(baseURL);
		}
		[TearDown]
		public void TearDown()
		{
			Driver.Quit();
		}
		static Object[] SearchData =
		{
			new Object[] {"London", true, 1},
			new Object[] {"Manchester", false, 2},
		};
		[Test(), TestCaseSource("SearchData")]
		public void TestValidSearch(String destination, Boolean isLeisure, int adults)
		{
			Edit editDestination = new Edit(driver, By.Id("ss"));
			Control autoCompleteItem = new Control(driver, 
			                                       By.XPath("(//li[contains(@class, 'autocomplete__item')])[1]"));
			//Control checkoutDayExpand = new Control(driver,
            //                            	By.CssSelector("i.sb-date-field__chevron.bicon-downchevron"));
			Control checkoutDayToday = new Control(driver,
											By.XPath("//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]"));
			Control radioLeisure = new Control(driver, By.XPath("(//input[@name='sb_travel_purpose'])[2]"));
			Control radioBusiness = new Control(driver, By.XPath("(//input[@name='sb_travel_purpose'])[1]"));
			SelectList selectAdultsNumber = new SelectList(driver, By.Id("group_adults"));
			Control buttonSubmit = new Control(driver, By.XPath("//button[@type='submit']"));

			editDestination.Text = destination;
			autoCompleteItem.Click();
			//checkoutDayExpand.Click();
			checkoutDayToday.Click();
			if (isLeisure)
			{
				radioLeisure.Click();
			}
			else 
			{ 
				radioBusiness.Click();
			}
			selectAdultsNumber.Text = "" + adults;
			buttonSubmit.Click();
			editDestination.Click();
		}
	}
}
