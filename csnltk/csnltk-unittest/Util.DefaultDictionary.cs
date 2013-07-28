using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csnltk;
using System.Collections.Generic;

namespace csnltk_unittest
{
	[TestClass]
	public class DefaultDictionary
	{
		[TestMethod]
		public void DefaultDictionaryTest()
		{
			DefaultDictionary<string, int> dd = new DefaultDictionary<string, int>();
			dd.Add("hello", 34);
			dd.Add("goodbye", 41);
			dd.Add("hello", 1);
			dd.Add("hello", -3);
			dd.Add("hello", 34);
			dd.Remove("helloa", -3);
			dd.Add("foo", 4);
			dd.Add("hello", 77);
			dd.Add("darts", 64);
			dd.Add("darts", 99);

			string a = "";
			foreach (var item in dd["hello"])
			{
				a += item.ToString() + " ";
			}

			Assert.AreEqual("34 1 34 77 ", a);
		}
	}
}
