using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using csnltk;
using csnltk.Align;

namespace csnltk_unittest
{
	[TestClass]
	public class Align
	{
		[TestMethod]
		public void AlignedSent()
		{
			var alignment = new Alignment();
			alignment.Add("0-2 1-3 2-1 3-0");

			AlignedSent align = new AlignedSent(
				new string[] { "klein", "ist", "das", "Haus" },
				new string[] { "The", "house", "is", "small" },
				alignment);

			Assert.AreEqual("0-2 1-3 2-1 3-0", align.Alignment.ToString());

		}
	}
}
