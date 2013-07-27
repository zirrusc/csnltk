using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csnltk;
using csnltk.Align;

namespace csnltk_unittest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var list = new List<Tuple<int, int>>();
			list.Add(new Tuple<int, int>(0, 0));
			list.Add(new Tuple<int, int>(0, 1));
			list.Add(new Tuple<int, int>(1, 2));
			list.Add(new Tuple<int, int>(2, 2));

			Alignment a = new Alignment(list);

			a.Add(3, 4);

			var r = a.Range();
			string b = "";
			foreach (var item in r)
			{
				b += item.ToString() + ", ";
			}
			string z = b.TrimEnd(' ', ',');
			Assert.AreEqual("0, 1, 2, 3, 4", z);

		}
	}
}
