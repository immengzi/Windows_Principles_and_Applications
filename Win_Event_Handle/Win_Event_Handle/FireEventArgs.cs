using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Event_Handle
{
    internal class FireEventArgs : EventArgs //事件参数类
    {
        public FireEventArgs(string room, int ferocity)
        {
            this.room = room;
            this.ferocity = ferocity;
        }
        public string room; //火情发生地
        public int ferocity; //火情凶猛程度
    }
}
