using System;
using Internal.TypeSystem;

namespace Internal.Runtime.CompilerHelpers
{
	public static class ThrowHelpers
	{
		public static void ThrowInvalidProgramException(ExceptionStringID id)
		{
			Console.WriteLine("ThrowInvalidProgramException");
		}
		public static void ThrowInvalidProgramExceptionWithArgument(ExceptionStringID id, string methodName)
		{
			Console.WriteLine("ThrowInvalidProgramExceptionWithArgument");
			Console.WriteLine(methodName);
		}
		public static void ThrowOverflowException()
		{
			Console.WriteLine("ThrowOverflowException");
		}
		public static void ThrowIndexOutOfRangeException()
		{
			Console.WriteLine("ThrowIndexOutOfRangeException");
		}
		public static void ThrowTypeLoadException(ExceptionStringID id, string className, string typeName) 
		{
			Console.WriteLine("ThrowIndexOutOfRangeException");
			Console.WriteLine(className);
			Console.WriteLine(typeName);
		}
	}
}
