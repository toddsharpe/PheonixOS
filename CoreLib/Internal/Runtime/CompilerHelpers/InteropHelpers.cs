using System;

namespace Internal.Runtime.CompilerHelpers
{
	internal class InteropHelpers
	{

		internal static unsafe byte* StringToAnsiString(string str, bool bestFit, bool throwOnUnmappableChar)
		{
			//String will become char* if we use DllImport
			//No Ansi support, Return unicode
			fixed (char* ptr = str) return (byte*)ptr;
		}

		internal unsafe static void CoTaskMemFree(void* p)
		{
			//TO-DO
		}
	}
}
