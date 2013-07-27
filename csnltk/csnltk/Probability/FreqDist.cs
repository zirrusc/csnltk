using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csnltk.Probability
{
	class FreqDist<T> : Dictionary<T, int>
	{
		public int N { get; private set; }
		
		public int B
		{
			get { return this.Count; }
		}

		public FreqDist(object samples)
			: base()
		{
			ResetCaches();
			if (samples != null)
				Update(samples);
		}

		public void Increment(T sample, int count = 1)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException("count");

			this[sample] = Get(sample, 0) + count;
		}

		public void SetItem(T sample, int value)
		{
			N += value - Get(sample, 0);
			SetItem(sample, value);
			ResetCaches();		
		}

		public void Samples()
		{
			return GetKeys();
		}

		public List<T> Hapaxes()
		{
			List<T> result = new List<T>();
			foreach (var item in this)
			{
				if (item.Value == 1)
					result.Add(item.Key);
			}
			return result;
		}

		public int Nr(int r, int bins = default(int))
		{
			if (r < 0)
				throw new ArgumentOutOfRangeException("r");

			// special case
			if (r == 0)
				return bins != default(int) ? bins - B : 0;

			if (NrCache == null)
				CacheNrValues();

			return NrCache.Get(r, 0);
		}


	}
}
