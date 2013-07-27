/*
 * nltk.align.Alignment
 * created: 2013-07-27
 * version: 1
 */

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
	public class Alignment : ObservableCollection<Tuple<int, int>>
	{
		Dictionary<int, List<Tuple<int, int>>> index;

		public int Length { get; private set; }

		public Alignment()
			: base()
		{
			Init();
		}

		public Alignment(IList<Tuple<int, int>> list)
			: base(list)
		{
			Init();
		}

		public Alignment(IEnumerable<Tuple<int,int>> list)
			:base(list)
		{
			Init();
		}

		void Init()
		{
			base.CollectionChanged += (sender, e) =>
				{
					SetLength();
					BuildIndex();
				};

			SetLength();	
		}

		private void SetLength()
		{
			// self._len = (max(p[0] for p in self) if self != frozenset([]) else 0)
			int max = int.MinValue;
			for (int i = 0; i < this.Count; i++)
			{
				if (max < this[i].Item1)
					max = this[i].Item1;
			}
			Length = max;
		}

		public List<Tuple<int, int>> Invert()
		{
			var result = CloneList();
			for (int i = 0; i < result.Count; i++)
			{
				result[i] = new Tuple<int, int>(result[i].Item2, result[i].Item1);
			}
			return result;
		}

		public List<int> Range(List<int> positions = null)
		{
			var image = new List<int>();

			if (index == null || index.Count == 0)
				BuildIndex();

			int max = positions == null ? index.Count : positions.Count;

			for (int p = 0; p < max; p++)
			{
				for (int f = 0; f < index[p].Count; f++)
				{
					image.Add(index[p][f].Item1);
					image.Add(index[p][f].Item2);
				}
			}
			image.Sort(); 
			var r = image.Distinct();
			var result = new List<int>();
			result.AddRange(r);
			return result;
		}

		public void BuildIndex()
		{
			index = new Dictionary<int, List<Tuple<int, int>>>();
			for (int i = 0; i < this.Count; i++)
			{
				int key = this[i].Item1;
				if (index.ContainsKey(key))
					index[key].Add(this[i]);
				else
				{
					index.Add(key, new List<Tuple<int, int>>());
					index[key].Add(this[i]);
				}
			}
		}


		public Alignment Clone()
		{
			var result = new Alignment(CloneList());
			return result;
		}

		public List<Tuple<int, int>> CloneList()
		{
			var list = new List<Tuple<int, int>>();
			for (int i = 0; i < this.Count; i++)
			{
				var t = new Tuple<int, int>(this[i].Item1, this[i].Item2);
				list.Add(t);
			}
			return list;
		}

		public override string ToString()
		{
			var r = CloneList();
			r.Sort();

			StringBuilder s = new StringBuilder();
			for (int i = 0; i < r.Count; i++)
			{
				s.AppendFormat("{0}-{1} ", r[i].Item1, r[i].Item2);
			}
			return s.ToString().TrimEnd();
		}

		public void Add(int a, int b)
		{
			base.Add(new Tuple<int, int>(a, b));
		}

	}
}

