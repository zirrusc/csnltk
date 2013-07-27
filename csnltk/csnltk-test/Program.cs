using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csnltk;
using csnltk.Align;

namespace csnltk_test
{
	class Program
	{
		static void Main(string[] args)
		{
			var alignment = new Alignment();
			alignment.Add("0-2 1-3 2-1 3-0");

			AlignedSent align = new AlignedSent(
				new string[] { "klein", "ist", "das", "Haus" },
				new string[] { "The", "house", "is", "small" },
				alignment);

			Console.WriteLine(align.Alignment.ToString());

			
			//var r = a.Range();
			//string b = "";
			//foreach (var item in r)
			//{
			//	b += item.ToString() + ", ";
			//}
			//b.TrimEnd(',', ' ');
			//Console.WriteLine(b);
			Console.ReadKey();
		}
	}
}
