/*
 * nltk.align.AlignedSent
 * 
 * created: 2013-07-28
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csnltk.Metrics;

namespace csnltk.Align
{
	/// <summary>
	/// nltk.align.AlignedSent<br />
	/// Return an aligned sentence object, which encapsulates two sentences along 
	/// with an Alignment between them.
	/// </summary>
	public class AlignedSent : Alignment
	{
		public string[] Words { private set; get; }

		public string[] Mots { private set; get; }

		public Alignment Alignment
		{
			set
			{
				for (int i = 0; i < value.Length; i++)
				{
					if (!(0 <= value[i].Item1 && value[i].Item1 < Words.Length))
						throw new IndexOutOfRangeException("Alignment is outside boundary of words");
					if (!(0 <= value[i].Item1 && value[i].Item1 < Mots.Length))
						throw new IndexOutOfRangeException("Alignment is outside boundary of mots");
				}

				_alignment = value;
			}

			get
			{
				return _alignment;
			}
		}

		Alignment _alignment;

		/// <summary>
		/// Return an aligned sentence object, which encapsulates two sentences along with an Alignment between them.
		/// </summary>
		/// <param name="words">source language words</param>
		/// <param name="mots">target language words</param>
		/// <param name="alignment">the word-level alignments between the source and target language</param>
		public AlignedSent(string[] words, string[] mots, Alignment alignment)
		{
			this.Words = words;
			this.Mots = mots;
			this.Alignment = alignment;
		}

		//string Representation()
		//{
		//	StringBuilder words = new StringBuilder();
		//	StringBuilder mots = new StringBuilder();

		//	foreach (var w in Words)
		//	{
		//		words.Append("[");
		//		for (int i = 0; i < w.Length; i++)
		//		{
		//			words.Append(string.Format("'{0}'", words[i]));
		//		}
		//		words.Append("]");
		//	}
		//	foreach (var m in Mots)
		//	{
		//		mots.Append("[");
		//		for (int i = 0; i < m.Length; i++)
		//		{
		//			mots.Append(string.Format("'{0}' ", mots[i]));
		//		}
		//		mots.Append("]");
		//	}

		//	return string.Format("AlignedSent({0}, {1}, {2}, {3}", words.ToString(), mots.ToString(), Alignment.ToString());
		//}

		public override string ToString()
		{
			StringBuilder source = new StringBuilder();
			StringBuilder target = new StringBuilder();
			int wordsmax = Math.Min(20, Words.Length);
			int targetmax = Math.Min(20, Mots.Length);

			for (int i = 0; i < wordsmax; i++)
			{
				source.Append(" " + Words[i]);
			}
			source.Append("...");

			for (int i = 0; i < targetmax; i++)
			{
				target.Append(" " + Mots[i]);
			}
			target.Append("...");

			return string.Format("<AlignedSent: '{0}' -> '{1}'>", source.ToString(), target.ToString());
		}

		/// <summary>
		/// Return the Alignment Error Rate (AER) of an aligned sentence with respect to a “gold standard” reference AlignedSent.
		/// </summary>
		/// <param name="reference">A “gold standard” reference aligned sentence.</param>
		/// <param name="possible">A “gold standard” reference of possible alignments (defaults to reference if None)</param>
		/// <returns>Return an error rate between 0.0 (perfect alignment) and 1.0 (no alignment).</returns>
		public double? ErrorRate(Alignment reference, Alignment possible)
		{
			if (possible == null)
				possible = reference;

			return 1.0 - ((Alignment.And(Alignment, reference).Length) +
				(Alignment.And(Alignment, possible)).Length) / 
				(Alignment.ToString().Length + reference.ToString().Length);
		}

		/// <summary>
		/// Return the precision of an aligned sentence with respect to a “gold standard” reference AlignedSent.
		/// </summary>
		/// <param name="reference">A “gold standard” reference aligned sentence.</param>
		/// <returns></returns>
		public double? Precision(Alignment reference)
		{
			if (reference == null)
				throw new ArgumentNullException("reference");

			return Scopes.Precision<Tuple<int, int>>(reference, Alignment);
		}

		/// <summary>
		/// Return the recall of an aligned sentence with respect to a “gold standard” reference AlignedSent.
		/// </summary>
		/// <param name="reference">A “gold standard” reference aligned sentence.</param>
		/// <returns></returns>
		public double? Recall(Alignment reference)
		{
			return Scopes.Recall<Tuple<int, int>>(reference, Alignment);
		}
	}
}