using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace csnltk.Util
{
	public enum LoggingStream
	{
		Default, Console, Disk
	}

	public static class Logging
	{
		public static int StartCount = Environment.TickCount;

		public static void SetStream(LoggingStream stream)
		{
			if (stream == LoggingStream.Default)
			{

			}

			if (stream == LoggingStream.Console)
			{
				Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			}

		}
		public static LoggingStream Stream
		{
			set
			{
				switch (value)
				{
					case LoggingStream.Default:
						break;
					case LoggingStream.Console:
						break;
					case LoggingStream.Disk:
						defaultTraceListener = (DefaultTraceListener)Debug.Listeners["Default"];
						defaultTraceListener.
						break;
					default:
						throw new InvalidOperationException();
				}

				

				_Stream = value;
			}
		}

		private static LoggingStream _Stream = LoggingStream.Default;

		private static DefaultTraceListener defaultTraceListener;

		public static void WriteInfo(string text, string from = "")
		{
			Write(string.Format("info: csnltk: {0}: {1}", from, text));
		}

		public static void WriteEror(string text, string from = "")
		{
			Write(string.Format("error: csnltk: {0}: {1}", from, text));
		}

		public static void WriteFatal(string text, string from = "")
		{
			Write(string.Format("fatal: csnltk: {0}: {1}", from, text));
		}

		private static void Write(string format, params string[] args)
		{
			defaultTraceListener.WriteLine(
				string.Format(Environment.TickCount - StartCount + format, args));
		}
	}
}
