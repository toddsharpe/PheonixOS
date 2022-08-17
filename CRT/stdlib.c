#include <stdint.h>
#include <string.h>

size_t mbstowcs(wchar_t* _Dest, char const* _Source, size_t _MaxCount)
{
	size_t len = strlen(_Source);
	if (_MaxCount < len)
		len = _MaxCount;

	for (size_t i = 0; i < len; i++)
	{
		_Dest[i] = (wchar_t)_Source[i];
	}

	return len;
}
