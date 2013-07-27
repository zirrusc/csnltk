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
			var list = new List<Tuple<int, int>>();
			list.Add(new Tuple<int, int>(0, 0));
			list.Add(new Tuple<int, int>(0, 1));
			list.Add(new Tuple<int, int>(1, 2));
			list.Add(new Tuple<int, int>(2, 2));

			Alignment a = new Alignment(list);
			
			var r = a.Range();
			string b = "";
			foreach (var item in r)
			{
				b += item.ToString() + ", ";
			}
			b.TrimEnd(',', ' ');
			Console.WriteLine(b);
			Console.ReadKey();
		}
	}
}
