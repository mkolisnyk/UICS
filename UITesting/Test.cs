using NUnit.Framework;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;

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
			driver.Quit();
		}
		static Object[] SearchData =
		{
			new Object[] {"London", true, 1},
			new Object[] {"Manchester", false, 2},
		};
		[Test(), TestCaseSource("SearchData")]
		public void TestValidSearch(String destination, Boolean isLeisure, int adults)
		{
			driver.FindElement(By.Id("ss")).Click();
			driver.FindElement(By.Id("ss")).Clear();
			driver.FindElement(By.Id("ss")).SendKeys(destination);
			//System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.XPath("(//li[contains(@class, 'autocomplete__item')])[1]")).Click();
			//System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("i.sb-date-field__chevron.bicon-downchevron")).Click();
			driver.FindElement(By.XPath("//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]")).Click();
			if (isLeisure)
			{
				driver.FindElement(By.XPath("(//input[@name='sb_travel_purpose'])[2]"))
					.Click();
			}
			else 
			{ 
				driver.FindElement(By.XPath("(//input[@name='sb_travel_purpose'])[1]"))
					.Click();
			}
			new SelectElement(driver.FindElement(By.Id("group_adults"))).SelectByText("" + adults);
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();
			driver.FindElement(By.Id("ss")).Click();
		}
	}
}
