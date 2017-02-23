using System;
using System.Threading;
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
		private static Dictionary<String, IWebDriver> driverThreadMap = new Dictionary<String, IWebDriver>();
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

		private static String _getThreadName()
		{
			return Thread.CurrentThread.Name + Thread.CurrentThread.ManagedThreadId;
		}

		public static void Add(String browser, String path, ICapabilities capabilities)
		{
			Type driverType = driverMap[browser];
			DriverOptions options = (DriverOptions) optionsMap[browser].GetConstructor(new Type[] { }).Invoke(new Object[] { });
			IWebDriver driver;
			if (browser == "firefox")
			{
				driver = new FirefoxDriver((FirefoxOptions)options);
			}
			else
			{
				driver = (IWebDriver)driverType.GetConstructor(new Type[] { typeof(String), optionsMap[browser] }).Invoke(new Object[] { path, options });
			}
			String threadName = _getThreadName();
			if (driverThreadMap.ContainsKey(threadName))
			{
				driverThreadMap.Remove(threadName);
			}
			driverThreadMap.Add(threadName, driver);
		}
		public static IWebDriver Current()
		{
			String threadName = _getThreadName();
			return driverThreadMap[threadName];
		}
		public static void Quit()
		{
			String threadName = _getThreadName();
			Current().Quit();
			driverThreadMap.Remove(threadName);
		}
	}
}
