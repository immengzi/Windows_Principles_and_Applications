using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Win_Event_Handle.MainWindow;

namespace Win_Event_Handle
{
    internal class FireAlarm //事件源（发起者）类定义
    {
        //将火情处理定义为FireEventHandler代理(delegate)类型，代理声明事件的参数列表
        public delegate void FireEventHandler(object sender, FireEventArgs fe);
        //定义FireEvent 为FireEventHandler delegate 事件(event) 类型.
        public event FireEventHandler FireEvent;
        //激活事件的方法，创建了FireEventArgs 对象，发起事件，并传递事件参数对象
        public void ActivateFireAlarm(string room, int ferocity)
        {
            FireEventArgs fireArgs = new FireEventArgs(room, ferocity);
            //执行对象事件处理函数指针，必须保证处理函数要和声明代理时的参数列表相同
            FireEvent(this, fireArgs);
        }
    }
}
