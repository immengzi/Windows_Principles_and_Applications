using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiverB
{
    public partial class ReceiverB : Form
    {
        public const int WM_COPYDATA = 0x004A;
        public ReceiverB()
        {
            InitializeComponent();
        }
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                    string myText = mystr.lpData;
                    listBox1.Items.Add(myText);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
    }
    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public int cbData;
        [MarshalAs(UnmanagedType.LPStr)] public string lpData;
    }
}
