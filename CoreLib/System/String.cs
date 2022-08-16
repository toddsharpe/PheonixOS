using CoreLib;
using Internal.Runtime.CompilerHelpers;
using Internal.Runtime.CompilerServices;
using System;
using System.Runtime.CompilerServices;

namespace System
{
	public sealed class String
	{
		[Intrinsic]
		public static readonly string Empty = "";

		// The layout of the string type is a contract with the compiler.
		int _length;
		internal char _firstChar;

		public int Length
		{
			[Intrinsic]
			get { return _length; }
			internal set { _length = value; }
		}

		public unsafe char this[int index]
		{
			[Intrinsic]
			get
			{
				return Unsafe.Add(ref _firstChar, index);
			}
		}

#pragma warning disable 824
		public extern unsafe String(char* ptr);
		public extern String(IntPtr ptr);
		public extern String(char[] buf);
		public extern unsafe String(char* ptr, int index, int length);
		public extern unsafe String(char[] buf, int index, int length);
#pragma warning restore 824


		static unsafe string Ctor(char* ptr)
		{
			var i = 0;

			while (ptr[i++] != '\0') { }

			return Ctor(ptr, 0, i - 1);
		}

		static unsafe string Ctor(IntPtr ptr) => Ctor((char*)ptr);

		static unsafe string Ctor(char[] buf)
		{
			fixed (char* _buf = buf)
				return Ctor(_buf, 0, buf.Length);
		}

		static unsafe string Ctor(char[] ptr, int index, int length)
		{
			fixed (char* _ptr = ptr)
				return Ctor(_ptr, index, length);
		}

		static unsafe string Ctor(char* ptr, int index, int length)
		{
			var et = EETypePtr.EETypePtrOf<string>();

			var start = ptr + index;
			var data = StartupCodeHelpers.RhpNewArray(et.Value, length);
			var s = Unsafe.As<object, string>(ref data);

			fixed (char* c = &s._firstChar)
			{
				Platform.CopyMemory((IntPtr)c, (IntPtr)start, (ulong)length * sizeof(char));
				c[length] = '\0';
			}

			return s;
		}
	}
}
