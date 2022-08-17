using Internal.Runtime;
using System;

namespace System
{
    public class Object
    {
        // The layout of object is a contract with the compiler.
        internal unsafe EEType* m_pEEType;
    }
}
