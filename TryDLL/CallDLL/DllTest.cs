using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CallDLL
{
    internal class DllTest
    {
        [DllImport(@"../../../Debug/CreateDLL.dll", EntryPoint = "testFac", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testFac(int a);

        [DllImport(@"../../../Debug/CreateDLL.dll", EntryPoint = "testMinus", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int testMinus(int a, int b);
    }
}
