using System;

namespace Internal.TypeSystem
{
	public enum ExceptionStringID
	{
		// TypeLoadException
		ClassLoadGeneral,
		ClassLoadExplicitGeneric,
		ClassLoadBadFormat,
		ClassLoadExplicitLayout,
		ClassLoadValueClassTooLarge,
		ClassLoadRankTooLarge,

		// MissingMethodException
		MissingMethod,

		// MissingFieldException
		MissingField,

		// FileNotFoundException
		FileLoadErrorGeneric,

		// InvalidProgramException
		InvalidProgramDefault,
		InvalidProgramSpecific,
		InvalidProgramVararg,
		InvalidProgramCallVirtFinalize,
		InvalidProgramCallAbstractMethod,
		InvalidProgramCallVirtStatic,
		InvalidProgramNonStaticMethod,
		InvalidProgramGenericMethod,
		InvalidProgramNonBlittableTypes,
		InvalidProgramMultipleCallConv,

		// BadImageFormatException
		BadImageFormatGeneric,
		BadImageFormatSpecific,

		// MarshalDirectiveException
		MarshalDirectiveGeneric,
	}
}
