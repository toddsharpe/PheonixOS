using System;
using System.Runtime.InteropServices;

namespace CoreLib
{
	internal class Platform
	{
		[DllImport("*")]
		public static extern IntPtr Allocate(ulong size);

		[DllImport("*")]
		public static extern void CopyMemory(IntPtr dst, IntPtr src, ulong len);

		[DllImport("*")]
		public static extern unsafe void ZeroMemory(IntPtr ptr, ulong len);

		[DllImport("*")]
		public static extern void ClearConsole();

		[DllImport("*")]
		public static extern void Write(string msg);


		[DllImport("*")]
		public static extern void WriteLine(string msg = "");
	}
}
