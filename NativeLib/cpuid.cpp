#include "NativeLib.h"
#include <intrin.h>

enum Regs
{
	EAX,
	EBX,
	ECX,
	EDX
};

extern "C" int cpuid()
{
	return 1;
}

//extern "C" bool cpuid_GetVendor(Buffer * buffer)
//{
//	if (buffer->Length < 13)
//		return false;
//
//	int registers[4] = { 0 };
//	__cpuid(registers, 0);
//
//	char* c_buffer = static_cast<char*>(buffer->Data);
//	*((uint32_t*)c_buffer) = (uint32_t)registers[Regs::EBX];
//	*((uint32_t*)(c_buffer + sizeof(uint32_t))) = (uint32_t)registers[Regs::EDX];
//	*((uint32_t*)(c_buffer + sizeof(uint32_t) * 2)) = (uint32_t)registers[Regs::ECX];
//
//	return true;
//}

extern "C" bool cpuid_GetVendor(char* buffer, size_t length)
{
	if (length < 13)
		return false;

	int registers[4] = { 0 };
	__cpuid(registers, 0);

	char* c_buffer = static_cast<char*>(buffer);
	*((uint32_t*)c_buffer) = (uint32_t)registers[Regs::EBX];
	*((uint32_t*)(c_buffer + sizeof(uint32_t))) = (uint32_t)registers[Regs::EDX];
	*((uint32_t*)(c_buffer + sizeof(uint32_t) * 2)) = (uint32_t)registers[Regs::ECX];

	return true;
}
