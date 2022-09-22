using System;
using System.Runtime.CompilerServices;

namespace Internal.Runtime.CompilerServices
{
	// Signatures: https://github.com/dotnet/runtimelab/blob/feature/NativeAOT/src/libraries/System.Private.CoreLib/src/Internal/Runtime/CompilerServices/Unsafe.cs
	// Implementations: https://github.com/dotnet/runtimelab/blob/feature/NativeAOT/src/libraries/System.Runtime.CompilerServices.Unsafe/src/System.Runtime.CompilerServices.Unsafe.il
	public static unsafe class Unsafe
	{
		[Intrinsic]
		public static extern ref T Add<T>(ref T source, int elementOffset);

		[Intrinsic]
		public static extern ref TTo As<TFrom, TTo>(ref TFrom source);

		[Intrinsic]
		public static extern void* AsPointer<T>(ref T value);

		[Intrinsic]
		public static extern ref T AsRef<T>(void* pointer);

		//public static ref T AsRef<T>(IntPtr pointer) => ref AsRef<T>((void*)pointer);

		[Intrinsic]
		public static extern int SizeOf<T>();

		[Intrinsic]
		public static extern ref T AddByteOffset<T>(ref T source, IntPtr byteOffset);

		[Intrinsic]
		public static extern ref T AddByteOffset<T>(ref T source, UIntPtr byteOffset);
	}
}
