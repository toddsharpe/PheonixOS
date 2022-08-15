using System;
using System.Runtime;

namespace Loader
{
	internal unsafe class Platform
	{
		private static EFI_SYSTEM_TABLE* ST;
		public static void Init(EFI_SYSTEM_TABLE* st)
		{
			ST = st;
		}

		[RuntimeExport("Allocate")]
		public static unsafe IntPtr Allocate(ulong size)
		{
			IntPtr pointer = IntPtr.Zero;
			//ST->BootServices->AllocatePool(EFI_MEMORY_TYPE.EfiLoaderCode, size, &pointer);
			return pointer;
		}

		[RuntimeExport("ZeroMemory")]
		public static unsafe void ZeroMemory(IntPtr ptr, UInt64 len)
		{
			//ST->BootServices->SetMem(ptr, len, 0);
		}

		[RuntimeExport("CopyMemory")]
		public static unsafe void CopyMemory(IntPtr dst, IntPtr src, ulong len)
		{
			//ST->BootServices->CopyMem(dst, src, len);
		}
	}
}
