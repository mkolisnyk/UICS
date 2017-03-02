using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using NUnit.Framework;

         
namespace UITesting.Framework.UI.Controls
{
	public class Control
	{
		private Page page;
		private By locator;

		public Page Page
		{ 
			get 
			{ 
				return page; 
			} 
		}
		public IWebDriver Driver
		{
			get
			{
				return page.Driver;
			}
		}
		public By Locator
		{ 
			get
			{
				return locator;
			}
		}
		public String ItemLocator
		{
			get; set;
		}
		public SubItem[] SubItems
		{
			get; set;
		}
		public IWebElement Element
		{ 
			get
			{
				return this.Driver.FindElement(locator);
			}
		}
		public String Text
		{ 
			get
			{ 
				Assert.True(this.Exists(), "Unable to find element: " + this.Locator);
				return this.Element.Text;
			}
		}
		public bool ExcludeFromSearch 
		{ 
			get; set;
		}
		public Control(Page pageValue, By locatorValue)
		{
			this.page = pageValue;
			this.locator = locatorValue;
			this.ExcludeFromSearch = false;
		}
		public bool Exists(int timeout)
		{
			try
			{
				new WebDriverWait(this.Driver, TimeSpan.FromSeconds(timeout))
					.Until(ExpectedConditions.ElementExists(this.Locator));
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
			return true;
		}
		public bool Exists()
		{ 
			return Exists(Configuration.Timeout);
		}
		public bool Visible(int timeout)
		{
			try
			{
				new WebDriverWait(this.Driver, TimeSpan.FromSeconds(timeout))
					.Until(ExpectedConditions.ElementIsVisible(this.Locator));
			}
			catch (WebDriverTimeoutException)
			{
				return false;
			}
			return true;
		}
		public bool Visible()
		{
			return Visible(Configuration.Timeout);
		}
		public void Click()
		{
			Assert.True(this.Exists(), "Unable to find element: " + this.Locator);
			Assert.True(this.Visible(), "Unable to wait for visibility of element: " + this.Locator);
			this.Element.Click();
		}
		public T ClickAndWaitFor<T>() where T : Page
		{
			this.Click();
			T pageValue = PageFactory.Init<T>();
			Assert.True(pageValue.IsCurrent(),
			            String.Format("The page '{0}' didn't appear during specified timeout", page.GetType().FullName));
			return pageValue;
		}
	}
}
