using System;
using System.Runtime.InteropServices;

namespace Loader
{
	internal class Native
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct CPUID
		{
			public uint EAX;
			public uint EBX;
			public uint ECX;
			public uint EDX;
		}

		[DllImport("*")]
		public static extern int sprintf(IntPtr _Buffer, IntPtr _Format, __arglist);

		[DllImport("*")]
		public static extern void cpuid(ref CPUID cpuid, int index);

		[DllImport("*")]
		private static unsafe extern bool cpuid_GetVendor(byte* data, nuint length);


		[DllImport("*")]
		private static extern nuint mbstowcs(IntPtr _Dest, IntPtr _Source, nuint _MaxCount);

		public static unsafe string GetVendor()
		{
			byte* c_str = stackalloc byte[13];
			cpuid_GetVendor(c_str, 13);

			char* buffer = stackalloc char[13];
			mbstowcs((IntPtr)buffer, (IntPtr)c_str, 13);
			return new string(buffer);
		}

		public static unsafe void Printf(string format, params object[] args)
		{
			byte* c_buffer = stackalloc byte[256];
			fixed (char* c_format = format)
				sprintf((IntPtr)c_buffer, (IntPtr)c_format, __arglist(args));

			char* buffer = stackalloc char[256];
			mbstowcs((IntPtr)buffer, (IntPtr)c_buffer, 256);

			string s = new string(buffer);
			Console.Write(s);
		}
	}
}
