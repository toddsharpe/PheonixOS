using System;
using System.Runtime.InteropServices;
using Internal.Runtime.CompilerServices;

namespace Loader
{
	using UINTN = System.UInt64;
	using EFI_VIRTUAL_ADDRESS = System.UInt64;
	using EFI_PHYSICAL_ADDRESS = System.UInt64;

	public enum EFI_STATUS : ulong
	{
		EFI_SUCCESS = 0,

		EFI_ERROR = 0x8000000000000000,
		EFI_LOAD_ERROR = 1 | EFI_ERROR,
		EFI_INVALID_PARAMETER = 2 | EFI_ERROR,
		EFI_UNSUPPORTED = 3 | EFI_ERROR,
		EFI_BAD_BUFFER_SIZE = 4 | EFI_ERROR,
		EFI_BUFFER_TOO_SMALL = 5 | EFI_ERROR,
		EFI_NOT_READY = 6 | EFI_ERROR,
	}

	public enum EFI_MEMORY_TYPE
	{
		EfiReservedMemoryType,
		EfiLoaderCode,
		EfiLoaderData,
		EfiBootServicesCode,
		EfiBootServicesData,
		EfiRuntimeServicesCode,
		EfiRuntimeServicesData,
		EfiConventionalMemory,
		EfiUnusableMemory,
		EfiACPIReclaimMemory,
		EfiACPIMemoryNVS,
		EfiMemoryMappedIO,
		EfiMemoryMappedIOPortSpace,
		EfiPalCode,
		EfiPersistentMemory,
		EfiMaxMemoryType
	}

	public enum EFI_ALLOCATE_TYPE
	{
		AllocateAnyPages,
		AllocateMaxAddress,
		AllocateAddress,
		MaxAllocateType
	}

	[StructLayout(LayoutKind.Sequential)]
	readonly struct EFI_MEMORY_DESCRIPTOR
	{
		public readonly uint Type;
		public readonly uint Pad;
		public readonly EFI_PHYSICAL_ADDRESS PhysicalStart;
		public readonly EFI_VIRTUAL_ADDRESS VirtualStart;
		public readonly ulong NumberOfPages;
		public readonly ulong Attribute;
	}

	class Efi
	{
		public static bool EFI_ERROR(EFI_STATUS status)
		{
			return status != EFI_STATUS.EFI_SUCCESS;
		}


	}

	[StructLayout(LayoutKind.Sequential)]
	struct EFI_HANDLE
	{
		private IntPtr _handle;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct EFI_INPUT_KEY
	{
		private readonly ushort ScanCode;
		public readonly char UnicodeChar;

		public EFI_INPUT_KEY(char unicodeChar)
		{
			ScanCode = 0;
			UnicodeChar = unicodeChar;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe readonly struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL
	{
		private readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_PROTOCOL*, bool, EFI_STATUS> _Reset;
		private readonly delegate* unmanaged<EFI_SIMPLE_TEXT_INPUT_PROTOCOL*, EFI_INPUT_KEY*, EFI_STATUS> _ReadKeyStroke;
		private readonly IntPtr _WaitForKey;

		public EFI_STATUS Reset(bool ExtendedVerification = false)
		{
			fixed (EFI_SIMPLE_TEXT_INPUT_PROTOCOL* _this = &this)
				return _Reset(_this, ExtendedVerification);
		}

		public EFI_STATUS ReadKeyStroke(out EFI_INPUT_KEY Key)
		{
			fixed (EFI_SIMPLE_TEXT_INPUT_PROTOCOL* _this = &this)
			fixed (EFI_INPUT_KEY* _key = &Key)
				return _ReadKeyStroke(_this, _key);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe readonly struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
	{
		private readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, bool, EFI_STATUS> _Reset;
		private readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, char*, EFI_STATUS> _OutputString;
		private readonly IntPtr _TestString;
		private readonly IntPtr _QueryMode;
		private readonly IntPtr _SetMode;
		private readonly IntPtr _SetAttribute;
		private readonly delegate* unmanaged<EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL*, EFI_STATUS> _ClearScreen;
		private readonly IntPtr _SetCursorPosition;
		private readonly IntPtr _EnableCursor;
		private readonly IntPtr* _Mode;

		public EFI_STATUS Reset(bool ExtendedVerification)
		{
			fixed (EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* _this = &this)
				return _Reset(_this, ExtendedVerification);
		}

		public EFI_STATUS OutputString(string String)
		{
			fixed (EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* _this = &this)
			fixed (char* _string = String)
				return _OutputString(_this, _string);
		}

		public EFI_STATUS ClearScreen()
		{
			fixed (EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* _this = &this)
				return _ClearScreen(_this);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	readonly struct EFI_TABLE_HEADER
	{
		public readonly ulong Signature;
		public readonly uint Revision;
		public readonly uint HeaderSize;
		public readonly uint Crc32;
		public readonly uint Reserved;
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe readonly struct EFI_BOOT_SERVICES
	{
		private readonly EFI_TABLE_HEADER Hdr;
		private readonly IntPtr _RaiseTPL;
		private readonly IntPtr _RestoreTPL;

		public readonly delegate* unmanaged<EFI_ALLOCATE_TYPE, EFI_MEMORY_TYPE, UINTN, EFI_PHYSICAL_ADDRESS*, EFI_STATUS> AllocatePages;
		public readonly delegate* unmanaged<EFI_PHYSICAL_ADDRESS, UINTN, EFI_STATUS> FreePages;
		public readonly delegate* unmanaged<UINTN*, EFI_MEMORY_DESCRIPTOR*, UINTN*, UINTN*, UInt32*, EFI_STATUS> GetMemoryMap;
		public readonly delegate* unmanaged<EFI_MEMORY_TYPE, UINTN, IntPtr*, EFI_STATUS> AllocatePool;
		public readonly delegate* unmanaged<void*, EFI_STATUS> FreePool;

		private readonly IntPtr _CreateEvent;
		private readonly IntPtr _SetTimer;
		private readonly IntPtr _WaitForEvent;
		private readonly IntPtr _SignalEvent;
		private readonly IntPtr _CloseEvent;
		private readonly IntPtr _CheckEvent;

		private readonly IntPtr _InstallProtocolInterface;
		private readonly IntPtr _ReinstallProtocolInterface;
		private readonly IntPtr _UninstallProtocolInterface;
		private readonly IntPtr _HandleProtocol;
		private readonly void* Reserved;
		private readonly IntPtr _RegisterProtocolNotify;
		private readonly IntPtr _LocateHandle;
		private readonly IntPtr _LocateDevicePath;
		private readonly IntPtr _InstallConfigurationTable;

		private readonly IntPtr _LoadImage;
		private readonly IntPtr _StartImage;
		private readonly IntPtr _Exit;
		private readonly IntPtr _UnloadImage;
		private readonly IntPtr _ExitBootServices;

		private readonly IntPtr _GetNextMonotonicCount;
		private readonly IntPtr _Stall;
		private readonly IntPtr _SetWatchdogTimer;

		private readonly IntPtr _ConnectController;
		private readonly IntPtr _DisconnectController;

		private readonly IntPtr _OpenProtocol;
		private readonly IntPtr _CloseProtocol;
		private readonly IntPtr _OpenProtocolInformation;

		private readonly IntPtr _ProtocolsPerHandle;
		private readonly IntPtr _LocateHandleBuffer;
		private readonly IntPtr _LocateProtocol;
		private readonly IntPtr _InstallMultipleProtocolInterfaces;
		private readonly IntPtr _UninstallMultipleProtocolInterfaces;

		private readonly IntPtr _CalculateCrc32;

		public readonly delegate* unmanaged<IntPtr, IntPtr, UINTN, void> CopyMem;
		public readonly delegate* unmanaged<IntPtr, UINTN, byte, void> SetMem;
	}


	[StructLayout(LayoutKind.Sequential)]
	unsafe readonly struct EFI_SYSTEM_TABLE
	{
		public readonly EFI_TABLE_HEADER Hdr;
		public readonly char* FirmwareVendor;
		public readonly uint FirmwareRevision;
		public readonly EFI_HANDLE ConsoleInHandle;
		public readonly EFI_SIMPLE_TEXT_INPUT_PROTOCOL* ConIn;
		public readonly EFI_HANDLE ConsoleOutHandle;
		public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* ConOut;
		public readonly EFI_HANDLE StandardErrorHandle;
		public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* StdErr;
		public readonly IntPtr* _RuntimeServices;
		public readonly EFI_BOOT_SERVICES* BootServices;
		public readonly ulong NumberOfTableEntries;
		public readonly IntPtr* _ConfigurationTable;
	}
}
