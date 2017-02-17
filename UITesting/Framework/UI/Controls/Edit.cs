using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;

namespace UITesting.Framework.UI.Controls
{
	public class Edit : Control
	{
		public new String Text
		{ 
			get
			{
				return base.Text;
			}
			set
			{
				this.Click();
				this.Element.Clear();
				this.Element.SendKeys(value);
			}
		}
		public Edit(IWebDriver driverValue, By locatorValue) : base(driverValue, locatorValue)
		{
		}
	}
}
