using System;
namespace UITesting.Framework.UI
{
	[AttributeUsage(AttributeTargets.Field)]
	public class FindBy : Attribute
	{
		private readonly String locator;
		public String Locator
		{ 
			get
			{
				return locator;
			}
		}
		public FindBy(String locatorString)
		{
			locator = locatorString;
		}
	}
}
