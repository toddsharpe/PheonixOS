using CoreLib;
using System;

namespace System
{
	public static class Console
	{
		public static unsafe void Clear()
		{
			Platform.ClearConsole();
		}

		public static unsafe void Write(string s)
		{
			Platform.Write(s);
		}

		public static unsafe void WriteLine(string s = "")
		{
			Platform.WriteLine(s);
		}
	}
}
