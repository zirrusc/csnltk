using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csnltk.Probability
{
	class ConditionalFreqDist<T> : List<T>
	{
		public int N()
		{
			throw new NotImplementedException();

		}

		public List<T> Conditions()
		{
			throw new NotImplementedException();

		}

		public void Plot(IEnumerable<string> args, IEnumerable<string> kwargs)
		{
			// PlotForm
		}

		public void Tabulate(IEnumerable<string> args, IEnumerable<string> kwargs)
		{
			// PlotForm
		}

		void SortKeysByValue()
		{

		}

		public List<T> GetKeys()
		{
			throw new NotImplementedException();
		}

		public List<T> GetValues()
		{
			throw new NotImplementedException();

		}

	}
}
