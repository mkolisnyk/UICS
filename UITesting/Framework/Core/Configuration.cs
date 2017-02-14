using System;
namespace UITesting.Framework.Core
{
	public class Configuration
	{
		private Configuration()
		{
		}

		public static String Get(String option)
		{
			return System.Configuration.ConfigurationManager.AppSettings[option];
		}
	}
}
