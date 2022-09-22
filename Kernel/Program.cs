using System;
using System.Runtime;

namespace Kernel
{
	internal class Program
	{
		[RuntimeExport("KernelMain")]
		static void Main()
		{
			//Console.WriteLine("Hello, World!");
		}
	}
}