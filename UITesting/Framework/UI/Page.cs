using System;
using System.Linq;
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
		public static Page Screen(String name)
		{
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			Type pageType = types.Where<Type>(t => (typeof(Page).IsAssignableFrom(t)
			                                        && t.GetCustomAttribute<AliasAttribute>() != null
			                                        && t.GetCustomAttribute<AliasAttribute>().Name.Equals("name"))).First<Type>();
			return null;//PageFactory.Init<pageType>();
		}
		public virtual Page Navigate()
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
			screen.SaveAsFile(path, System.Drawing.Imaging.ImageFormat.Png);
		}
		public bool IsCurrent(int timeout)
		{
			foreach (FieldInfo field in this.GetType().GetFields())
			{
				if (typeof(Control).IsAssignableFrom(field.FieldType))
				{
					Control control = (Control)field.GetValue(this);
					if (!control.ExcludeFromSearch && !control.Exists(timeout))
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
		protected bool AllElementsAre(Control[] elements, String state)
		{
			foreach (Control element in elements)
			{
				if (!(bool)element.GetType().GetMethod(state, new Type[] {}).Invoke(element, new Object[] { }))
				{
					return false;
				}
			}
			return true;
		}
		protected bool AnyOfElementsIs(Control[] elements, String state)
		{
			foreach (Control element in elements)
			{
				if ((bool)element.GetType().GetMethod(state, new Type[] { typeof(int) }).Invoke(element, new Object[] { 1 }))
				{
					return true;
				}
			}
			return false;
		}
		public bool AllElementsExist(Control[] elements)
		{
			return AllElementsAre(elements, "Exists");
		}
		public bool AllElementsAreVisible(Control[] elements)
		{
			return AllElementsAre(elements, "Visible");
		}
		public bool AllElementsAreInvisible(Control[] elements)
		{
			return AllElementsAre(elements, "Invisible");
		}
		public bool AllElementsAreEnabled(Control[] elements)
		{
			return AllElementsAre(elements, "Enabled");
		}
		public bool AllElementsAreDisabled(Control[] elements)
		{
			return AllElementsAre(elements, "Disabled");
		}

		public bool AnyOfElementsExist(Control[] elements)
		{
			return AnyOfElementsIs(elements, "Exists");
		}
		public bool AnyOfElementsIsVisible(Control[] elements)
		{
			return AnyOfElementsIs(elements, "Visible");
		}
		public bool AnyOfElementsIsInvisible(Control[] elements)
		{
			return AnyOfElementsIs(elements, "Invisible");
		}
		public bool AnyOfElementsIsEnabled(Control[] elements)
		{
			return AnyOfElementsIs(elements, "Enabled");
		}
		public bool AnyOfElementsIsDisabled(Control[] elements)
		{
			return AnyOfElementsIs(elements, "Disabled");
		}
	}
}
