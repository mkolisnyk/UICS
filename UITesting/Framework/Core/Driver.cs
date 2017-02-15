using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using System.Collections.Generic;

namespace UITesting.Framework.Core
{
	public class Driver
	{
		private static IWebDriver driver;
		private static Dictionary<String, Type> driverMap = new Dictionary<string, Type>()
		{
			{"chrome", typeof(ChromeDriver)},
			{"firefox", typeof(FirefoxDriver)},
			{"ie", typeof(InternetExplorerDriver)},
			{"safari", typeof(SafariDriver)},
			{"opera", typeof(OperaDriver)}
		};
		private static Dictionary<String, Type> optionsMap = new Dictionary<string, Type>()
		{
			{"chrome", typeof(ChromeOptions)},
			{"firefox", typeof(FirefoxOptions)},
			{"ie", typeof(InternetExplorerOptions)},
			{"safari", typeof(SafariOptions)},
			{"opera", typeof(OperaOptions)}
		};
		private Driver()
		{
		}

		public static void Add(String browser, String path, ICapabilities capabilities)
		{
			Type driverType = driverMap[browser];
			DriverOptions options = (DriverOptions) optionsMap[browser].GetConstructor(new Type[] { }).Invoke(new Object[] { });
			if (browser == "firefox")
			{
				driver = new FirefoxDriver((FirefoxOptions)options);
			}
			else
			{
				driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(String), optionsMap[browser] }).Invoke(new Object[] { path, options });
			}
		}
		public static IWebDriver Current()
		{
			return driver;
		}
	}
}
