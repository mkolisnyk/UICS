﻿using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
			baseURL = "http://booking.com";
			ChromeOptions options = new ChromeOptions();
			driver = new ChromeDriver("/Users/mykolak/Downloads/", options);
			driver.Navigate().GoToUrl(baseURL);
		}
		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}
		[Test()]
		public void TestValidSearch()
		{
			//driver.FindElement(By.Id("ss")).Click();
			driver.FindElement(By.Id("ss")).Clear();
			driver.FindElement(By.Id("ss")).SendKeys("London");
			driver.FindElement(By.XPath("(//li[contains(@class, 'autocomplete__item')])[1]")).Click();
			driver.FindElement(By.CssSelector("i.sb-date-field__chevron.bicon-downchevron")).Click();
			driver.FindElement(By.XPath("//table[@class='c2-month-table']//td[contains(@class, 'c2-day-s-today')]")).Click();
			driver.FindElement(By.XPath("(//input[@name='sb_travel_purpose'])[2]"))
				.Click();
			new SelectElement(driver.FindElement(By.Id("group_adults"))).SelectByText("1");
			driver.FindElement(By.XPath("//button[@type='submit']")).Click();
			driver.FindElement(By.Id("ss")).Click();
		}
	}
}