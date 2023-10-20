using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Win_Event_Handle.MainWindow;
using System.Windows;

namespace Win_Event_Handle
{
    internal class FireWatcherClass //用于处理事件的类2：FireWatcherClass
    {
        //事件处理类的构造函数使用事件源类作为参数
        public FireWatcherClass(FireAlarm fireAlarm)
        {
            //将事件处理的代理(函数指针) 添加到FireAlarm 类的FireEvent 事件中，当事件发生时，
            //就会执行指定的函数；
            fireAlarm.FireEvent += new FireAlarm.FireEventHandler(WatchFire);
        }
        //当起火事件发生时，用于处理火情的事件
        internal void WatchFire(object sender, FireEventArgs fe)
        {
            MessageBox.Show(sender.ToString() + " 对象调用，群众发现火情WatchFire 函数.");
            //根据火情状况，输出不同的信息.
            if (fe.ferocity < 2)
            {
                MessageBox.Show(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
            }
            else
            {
                MessageBox.Show(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
            }
        }
    }
}
