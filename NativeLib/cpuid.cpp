#include "NativeLib.h"
#include <intrin.h>

enum Regs
{
	EAX,
	EBX,
	ECX,
	EDX
};

struct CpuId
{
	uint32_t Eax;
	uint32_t Ebx;
	uint32_t Ecx;
	uint32_t Edx;
};

extern "C" void cpuid(CpuId* cpuid, int index)
{
	__cpuid((int*)cpuid, index);
}

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
	c_buffer[12] = '\0';

	return true;
}
