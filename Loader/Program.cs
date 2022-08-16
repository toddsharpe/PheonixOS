using System;
using System.Runtime;

namespace Loader
{
	unsafe static class Program
	{
		static void Main() { }

		[RuntimeExport("EfiMain")]
		static long EfiMain(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
		{
			Platform.Init(systemTable);
			Console.Clear();
			
			Console.WriteLine("Hello world from C#!");
			Console.WriteLine("PhoenixOS.Loader");

			int n = Native.cpuid();
			if (n == 1)
			{
				Console.WriteLine("yay");
			}

			string v = Native.GetVendor();
			Console.WriteLine(v);

			while (true) ;
		}
	}
}