using System;
using System.Reflection;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using UITesting.Framework.Core;
using UITesting.Framework.UI.Controls;

namespace UITesting.Framework.UI
{
	public class PageFactory
	{
		public PageFactory()
		{
		}

		private static By toLocator(String input)
		{
			if (Regex.IsMatch(input, "^(xpath=|/)(.*)"))
			{
				return By.XPath(new Regex("^xpath=").Replace(input, ""));
			}
			else if (Regex.IsMatch(input, "^id=(.*)"))
			{
				return By.Id(input.Substring("id=".Length));
			}
			else if (Regex.IsMatch(input, "^name=(.*)"))
			{
				return By.Name(input.Substring("name=".Length));
			}
			else if (Regex.IsMatch(input, "^css=(.*)"))
			{
				return By.CssSelector(input.Substring("css=".Length));
			}
			else if (Regex.IsMatch(input, "^class=(.*)"))
			{
				return By.ClassName(input.Substring("class=".Length));
			}
			else
			{
				return By.Id(input);
			}
		}

		public static T Init<T>(IWebDriver driver)
		{
			T page = (T) typeof(T).GetConstructor(new Type[] { typeof(IWebDriver) })
								  .Invoke(new Object[] { driver });
			foreach (FieldInfo field in typeof(T).GetFields())
			{
				FindBy locator = (FindBy) field.GetCustomAttribute(typeof(FindBy));
				if (locator != null)
				{
					Control control = (Control) field.FieldType
										 .GetConstructor(new Type[] { typeof(Page), typeof(By) })
										 .Invoke(new Object[] { page, toLocator(locator.Locator) });
					field.SetValue(page, control);
				}
			}
			return page;
		}
	}
}
