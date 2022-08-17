using Loader;
using System;
using System.Runtime;

internal static unsafe class Platform
{
	private static EFI_SYSTEM_TABLE* ST;
	public static void Init(EFI_SYSTEM_TABLE* st)
	{
		ST = st;
	}

	[RuntimeExport("ClearConsole")]
	public static void ClearConsole()
	{
		ST->ConOut->ClearScreen();

		ST->ConIn->Reset();
	}

	[RuntimeExport("Write")]
	public static void Write(string msg)
	{
		ST->ConOut->OutputString(msg);
	}

	[RuntimeExport("WriteLine")]
	public static void WriteLine(string msg = "")
	{
		Write(msg);
		Write("\r\n");
	}

	[RuntimeExport("Allocate")]
	public static unsafe IntPtr Allocate(ulong size)
	{
		IntPtr pointer = IntPtr.Zero;
		ST->BootServices->AllocatePool(EFI_MEMORY_TYPE.EfiLoaderData, size, &pointer);
		return pointer;
	}

	[RuntimeExport("ZeroMemory")]
	public static unsafe void ZeroMemory(IntPtr ptr, UInt64 len)
	{
		ST->BootServices->SetMem(ptr, len, 0);
	}

	[RuntimeExport("CopyMemory")]
	public static unsafe void CopyMemory(IntPtr dst, IntPtr src, ulong len)
	{
		ST->BootServices->CopyMem(dst, src, len);
	}
}
