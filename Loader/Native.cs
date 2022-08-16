using System;
using System.Runtime.InteropServices;

namespace Loader
{
	internal class Native
	{
		/*
		[StructLayout(LayoutKind.Sequential)]
		public struct Buffer
		{
			public IntPtr Data;
			public nuint Length;

			public Buffer()
			{
				Data = IntPtr.Zero;
				Length = 0;
			}

			public Buffer(IntPtr data, nuint length)
			{
				Data = data;
				Length = length;
			}
		}
		*/

		//[DllImport("*")]
		//public static extern int sprintf(IntPtr _Buffer, IntPtr _Format, __arglist);

		[DllImport("*")]
		public static extern int cpuid();

		[DllImport("*")]
		////internal static extern bool cpuid_GetVendor(ref Buffer buffer);
		private static unsafe extern bool cpuid_GetVendor(byte* data, nuint length);

		[DllImport("*")]
		private static extern nuint mbstowcs(IntPtr _Dest, IntPtr _Source, nuint _MaxCount);

		public static unsafe string GetVendor()
		{
			//byte* c_str = stackalloc byte[13];
			//cpuid_GetVendor(c_str, 13);

			//char* buffer = stackalloc char[13];
			//mbstowcs((IntPtr)buffer, (IntPtr)c_str, 13);
			char* buffer = stackalloc char[13];
			buffer[0] = 'a';
			return new string(buffer);
		}
	}
}
