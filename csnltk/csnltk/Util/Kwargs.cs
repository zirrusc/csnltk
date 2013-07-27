using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace csnltk
{
	public class Kwargs : KeyedCollection<string, object>
	{
		public Kwargs()
			: base()
		{
		}

		public Kwargs(IEqualityComparer<string> comparer)
			: base(comparer)
		{
		}

		public Kwargs(IEqualityComparer<string> comparer, int dictionaryCreationThreshold)
			: base(comparer, dictionaryCreationThreshold)
		{
		}

		protected override string GetKeyForItem(object item)
		{
			
		}
	}
}
