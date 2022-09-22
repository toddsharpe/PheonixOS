using System;
using System.Runtime.CompilerServices;

namespace System
{
	public unsafe class IntPtr
	{
		void* _value;

		[Intrinsic]
		public static readonly IntPtr Zero;

		public IntPtr(void* value) { _value = value; }

		public static explicit operator void*(IntPtr value) => value._value;

		public static explicit operator IntPtr(void* value) => new IntPtr(value);

		public bool Equals(IntPtr ptr)
			=> _value == ptr._value;
	}
}
