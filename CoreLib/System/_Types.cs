using System;
using System.Runtime.InteropServices;

namespace System
{
	public struct Void { }

	public struct Char { }

	public struct SByte { }

	public struct UInt16 { }

	public struct Int16 { }

	[StructLayout(LayoutKind.Sequential)]
	public struct UInt32
	{

		private uint _value;

		public const uint MaxValue = (uint)0xffffffff;
		public const uint MinValue = 0;

		//public unsafe override string ToString()
		//{
		//	var val = this;
		//	char* x = stackalloc char[11];
		//	var i = 9;

		//	x[10] = '\0';

		//	do
		//	{
		//		var d = val % 10;
		//		val /= 10;

		//		d += 0x30;
		//		x[i--] = (char)d;
		//	} while (val > 0);

		//	i++;

		//	return new string(x + i, 0, 10 - i);
		//}
	}

	public struct UInt64 { }

	public struct Int64 { }

	public abstract class Delegate { }

	public unsafe struct UIntPtr
	{
		void* _value;
	}

	public class Attribute { }

	public abstract class ValueType { }

	[StructLayout(LayoutKind.Sequential)]
	public struct Int32
	{
		private int _value;

		// TODO: ToString for all other primitives
		//public unsafe override string ToString()
		//{
		//	var val = this;
		//	bool isNeg = BitHelpers.IsBitSet(val, 31);
		//	char* x = stackalloc char[12];
		//	var i = 10;

		//	x[11] = '\0';

		//	do
		//	{
		//		var d = val % 10;
		//		val /= 10;

		//		d += 0x30;
		//		x[i--] = (char)d;
		//	} while (val > 0);

		//	if (isNeg)
		//		x[i] = '-';
		//	else
		//		i++;

		//	return new string(x + i, 0, 11 - i);
		//}

		public static int Parse(string val)
		{
			// TODO: Throw an error on incorrect format
			int r = 0;

			for (var i = 0; i < val.Length; i++)
			{
				r *= 10;
				r += val[i] - 48;
			}

			return r;
		}

		public const int MaxValue = 0x7fffffff;
		public const int MinValue = unchecked((int)0x80000000);
	}

	public struct Byte { }

	public struct Boolean
	{

	}

	public abstract class Enum : ValueType
	{
		public bool HasFlag(Enum flag)
		{
			return false;
		}
	}

	//public struct Nullable<T> where T : struct { }

	public abstract class MulticastDelegate : Delegate { }
}
