using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace csnltk.Align
{
	/// <summary>
	/// nltk.align.Alignment
	/// </summary>
	public class Alignment<T> : List<IEnumerable<T>>
	{
		public Alignment()
			: base()
		{
			
		}

		public Alignment(int capacity)
			: base(capacity)
		{
		}

		public Alignment(IEnumerable<IEnumerable<T>> collection)
			: base(collection)
		{ 
		}

		public void Invert()
		{
			foreach (var item in this)
			{
				item.Reverse();
			}
		}

		public List<IEnumerable<T>> Range()
		{

		}

		public void BuildIndex()
		{

		}

	}
}

