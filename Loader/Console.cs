using System;

namespace Loader
{
	internal unsafe class Console
	{
		private static EFI_SYSTEM_TABLE* ST;
		public static void Init(EFI_SYSTEM_TABLE* st)
		{
			ST = st;
		}

		public static void Clear()
		{
			ST->ConOut->ClearScreen();
		}

		public static void Write(string msg)
		{
			ST->ConOut->OutputString(msg);
		}

		public static void WriteLine(string msg = "")
		{
			Write(msg);
			Write("\r\n");
		}
	}
}
