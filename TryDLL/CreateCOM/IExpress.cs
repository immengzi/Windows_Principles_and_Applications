using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CreateCOM
{
    [Guid("26EA8661-BE0D-408C-BCDB-1E330E719A72")]
    [ComVisible(true)]
    public interface IExpress
    {
        string minus(int a, int b);//返回值形如“9 = 23 - 14”
        string divide(int a, int b);//若b为零，则返回“除零错误”；若b不为0，则返回整除表达式，形如“4 = 33 / 8”
    }
}
