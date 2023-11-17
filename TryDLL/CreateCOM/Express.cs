using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CreateCOM
{
    [Guid("FD8BA821-DB63-42DC-80D5-E0F46B23CFD4")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class Express : IExpress
    {
        public string divide(int a, int b)
        {
            if (b == 0)
            {
                return "除零错误";
            }
            else
            {
                return String.Concat(a, " = ", a / b, " * ", b);
            }
        }

        public string minus(int a, int b)
        {
            return String.Concat(a, " = ", a - b, " + ", b);
        }
    }
}
