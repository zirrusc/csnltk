/*
 * nltk.align.Alignment
 * 
 * created: 2013-07-28
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
	/// A storage class for representing alignment between two sequences, s1, s2. 
	/// In general, an alignment is a set of tuples of the form (i, j, ...) 
	/// representing an alignment between the i-th element of s1 and the j-th element of s2. 
	/// Tuples are extensible (they might contain additional data, 
	/// such as a boolean to indicate sure vs possible alignments).
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

		/// <summary>
		/// Return an Alignment object, being the inverted mapping.
		/// </summary>
		/// <returns></returns>
		public List<Tuple<int, int>> Invert()
		{
			var result = CloneList();
			for (int i = 0; i < result.Count; i++)
			{
				result[i] = new Tuple<int, int>(result[i].Item2, result[i].Item1);
			}
			return result;
		}

		/// <summary>
		/// Work out the range of the mapping from the given positions. 
		/// If no positions are specified, compute the range of the entire mapping.
		/// </summary>
		/// <param name="positions"></param>
		/// <returns></returns>
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

		public void Add(string text)
		{
			var item = text.Split(' ');
			for (int i = 0; i < item.Length; i++)
			{
				var value = item[i].Split('-');
				if (value.Length != 2)
					throw new ArgumentException("Argument required integer-interger format.");
				int a, b;
				if (int.TryParse(value[0], out a) && int.TryParse(value[1], out b))
					Add(a, b);
				else
					throw new ArgumentException("Arguments must be integer-interger format.");
			}
		}

		public Alignment And(Alignment target)
		{
			return And(this, target);
		}

		public static Alignment And(Alignment a, Alignment b)
		{
			Alignment r = new Alignment();
			for (int i = 0; i < b.Length; i++)
			{
				if (a.IndexOf(b[i]) >= 0)
					r.Add(b[i]);
			}
			return r;
		}
	}
}

