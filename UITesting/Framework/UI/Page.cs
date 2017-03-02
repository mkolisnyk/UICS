using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;
using NUnit.Framework;

namespace UITesting.Framework.UI
{
	public class Page
	{
		private IWebDriver driver;

		public IWebDriver Driver
		{
			get
			{
				return driver;
			}
		}
		public Page(IWebDriver driverValue)
		{
			driver = driverValue;
		}
		public Page Navigate()
		{
			return this;
		}
		public bool IsTextPresent(String text) 
		{
			String locatorText = String.Format("//*[text()='{0}' or contains(text(), '{1}')]", text, text);
			Control element = new Control(this, By.XPath(locatorText));
			return element.Exists();
		}
		public byte[] CaptureScreenShot()
		{
			Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
			return screen.AsByteArray;
		}
		public void CaptureScreenShot(String path)
		{
			Screenshot screen = ((ITakesScreenshot)Driver).GetScreenshot();
			screen.SaveAsFile(path,System.Drawing.Imaging.ImageFormat.Png);
		}
		public bool IsCurrent(int timeout)
		{
			foreach (FieldInfo field in this.GetType().GetFields())
			{
				if (typeof(Control).IsAssignableFrom(field.FieldType))
				{
					Control control = (Control)field.GetValue(this);
					if (!control.Exists(timeout))
					{
						return false;
					}
				}
			}
			return true;
		}
		public bool IsCurrent()
		{
			return IsCurrent(Configuration.Timeout);
		}
	}
}
