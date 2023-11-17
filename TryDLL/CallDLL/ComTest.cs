using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CreateCOM;

namespace CallDLL
{
    class ComTest
    {
        public static IExpress CreateExpress(string _guid)
        {
            IExpress iExpress = null;
            try
            {
                Guid guid = new Guid(_guid);
                Type expressType = Type.GetTypeFromCLSID(guid);
                if (expressType == null)
                {
                    throw new ArgumentException("无法根据提供的CLSID找到匹配的类型。", nameof(_guid));
                }
                object express = Activator.CreateInstance(expressType);
                iExpress = express as IExpress;
                if (iExpress == null)
                {
                    throw new InvalidCastException("创建的COM对象不能转换为IExpress接口。");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw; // 重新抛出异常以允许调用者处理。
            }
            return iExpress;
        }


        public static string divide(string guid, int a, int b)
        {
            IExpress express = CreateExpress(guid);
            if (express == null)
            {
                throw new InvalidOperationException("无法创建IExpress对象。");
            }
            return express.divide(a, b);
        }

        public static string minus(string guid, int a, int b)
        {
            IExpress express = CreateExpress(guid);
            if (express == null)
            {
                throw new InvalidOperationException("无法创建IExpress对象。");
            }
            return express.minus(a, b);
        }

    }
}
