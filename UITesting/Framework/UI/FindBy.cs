using System;
namespace UITesting.Framework.UI
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class FindBy : Attribute
	{
		private readonly String locator;
		private TargetPlatform platform = TargetPlatform.ANY;
		public String Locator
		{ 
			get
			{
				return locator;
			}
		}
		public TargetPlatform Platform
		{
			get 
			{
				return platform;	
			}
			set
			{
				platform = value;
			}
		}
		public FindBy(String locatorString)
		{
			locator = locatorString;
		}
	}
}
