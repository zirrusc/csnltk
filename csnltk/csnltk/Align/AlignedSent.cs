using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csnltk.Align
{
	/// <summary>
	/// nltk.Alignment
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
					if (!(0 <= value[i][0] && value[i][0] < Words.Length))
						throw new IndexOutOfRangeException("Alignment is outside boundary of words");
					if (!(0 <= value[i][0] && value[i][0] < Mots.Length))
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

		string encoding;

		public AlignedSent(string[] words, string[] mots, Alignment alignment, string encoding = Info.Encoding)
		{
			this.Words = words;
			this.Mots = mots;
			this.Alignment = alignment;
			this.encoding = encoding;
		}

		string repr()
		{
			StringBuilder words = new StringBuilder();
			StringBuilder mots = new StringBuilder();

			foreach (var w in Words)
			{
				words.Append("[");
				for (int i = 0; i < w.Length; i++)
				{
					words.Append(string.Format("'%s'", words[i]));
				}
				words.Append("]");
			}
			foreach (var m in Mots)
			{
				mots.Append("[");
				for (int i = 0; i < m.Length; i++)
				{
					mots.Append(string.Format("'%s'", mots[i]));
				}
				mots.Append("]");
			}

			return string.Format("AlignedSent(%s, %s, %s, %r", words.ToString(), mots.ToString(), Alignment.ToString());
		}

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

			return string.Format("<AlignedSent: '%s' -> '%s'>", source.ToString(), target.ToString());
		}

		public float? GetErrorRate(Alignment reference, Alignment possible)
		{
			if (possible == null)
				possible = reference;

			return (1.0 - ((Alignment & reference) + (Alignment & possible)) / (Alignment.ToString().Length + reference.ToString().Length));
		}

		public AlignedSent Invert()
		{
			return new AlignedSent(Mots, Words, Alignment.Invert());
		}

		public float? Precision(Alignment reference)
		{
			
		}

		public float? Recall(Alignment reference)
		{

		}

		public string UnicodeRepresentation()
		{

		}
	}
}