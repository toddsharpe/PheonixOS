using System;

namespace System
{
	public struct Void { }

	public struct Char { }

	public struct UInt16 { }
	public struct UInt32 { }

	public struct UInt64 { }

	public struct Int64 { }

	public abstract class Delegate { }

	public unsafe struct UIntPtr
	{
		void* _value;
	}

	public class Attribute { }

	public abstract class ValueType { }

	public struct Int32
	{
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

	public abstract class MulticastDelegate : Delegate { }
}
