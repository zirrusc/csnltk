using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csnltk
{
	public static class Info
	{
		public const string Copyright = 
			@"Copyright (C) 2001-2013 NLTK Project.

			Distributed and Licensed under the Apache License, Version 2.0,
			which is included by reference.";

		public const string License = "Apache License, Version 2.0";


		public const string LongDescription =
			@"The Natural Language Toolkit for C# (csnltk) is a C# library for
natural language processing.  NLTK requires .NET Framework 4.0 or higher";

		public const string[] Keywords = { 
			"NLP", "CL", "natural language processing",
            "computational linguistics", "parsing", "tagging",
            "tokenizing", "syntax", "linguistics", "language",
            "natural language", "text analytics" };

		public const string Url = "http://github.com/zirrusc/csnltk/";

		public const string Maintainer = "zirrusc";
		
		public const string MaintainerEmail = "none";

		public const string Author = Maintainer;

		public const string AuthorEmail = MaintainerEmail;

		public const string Encoding = "utf-8";
	}
}
