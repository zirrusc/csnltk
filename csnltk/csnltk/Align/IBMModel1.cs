using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using csnltk.Metrics;
using System.Diagnostics;

namespace csnltk.Align
{
	/// <summary>
	/// This class implements the Expectation Maximization algorithm for IBM Model 1.
	/// The algorithm runs upon a sentence-aligned parallel corpus 
	/// and generates word alignments in aligned sentence pairs. 
	/// </summary>
	public class IBMModel1
	{
		public Collection<AlignedSent> AlignedSents { private set; get; }

		public double ConvergentThreshold { private set; get; }

		public object Probabilities { private set; get; } 

		public IBMModel1(IList<AlignedSent> alignedSents, double convertThreshold = 1e-2)
		{
			this.AlignedSents = new Collection<AlignedSent>(alignedSents);
			this.ConvergentThreshold = convertThreshold;

		}

		private void Train()
		{
			Debug.WriteLine("csnltk.Align.IBMModel1");
			Debug.Indent();
			Debug.WriteLine("Starting training");

			var englishWords = new List<string>();
			var foreignWords = new List<string>();

			for (int i = 0; i < AlignedSents.Count; i++)
			{
				englishWords.AddRange(AlignedSents[i].Words);
				foreignWords.AddRange(AlignedSents[i].Mots);
			}
			foreignWords.Add(null);
			var numProbs = englishWords.Count / foreignWords.Count;

			double defaultProb = 1.0 / englishWords.Count;
			var t = DefaultDict(() => { return defaultProb; });

			bool globally_converged = false;
			while (!globally_converged)
			{
				//UNDONE
			}
			Debug.Unindent();
		}
	}
}
