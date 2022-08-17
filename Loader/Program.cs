using CoreLib.System.Text;
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

			//Native.Printf("test %d", 1);


			string v = Native.GetVendor();
			Console.WriteLine(v);

			StringBuilder sb = new StringBuilder();

			Console.Write("Press any key to continue...");
			systemTable->ConIn->Reset();
			EFI_STATUS status;
			EFI_INPUT_KEY key;
			while ((status = systemTable->ConIn->ReadKeyStroke(out key)) == EFI_STATUS.EFI_NOT_READY);
			systemTable->ConIn->Reset();
			Console.WriteLine();

			while (true) ;
		}
	}
}