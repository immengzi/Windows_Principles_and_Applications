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

namespace SenderA
{
    public partial class SenderA : Form
    {
        public const int WM_COPYDATA = 0x004A;
        public SenderA()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        int hWnd, // handle to destination window
        int Msg, // message
        int wParam, // first message parameter
        ref COPYDATASTRUCT lParam // second message parameter
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string
        lpWindowName);

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            int WINDOW_HANDLER = 0;
            if (str == "B")
            {
                WINDOW_HANDLER = FindWindow(null, @"ReceiverB");
            }
            else if (str == "C")
            {
                WINDOW_HANDLER = FindWindow(null, @"MainWindow");
            }
            else
            {
                MessageBox.Show("请输入正确的接收者！");
            }
            
            if (WINDOW_HANDLER == 0)
            {
            }
            else
            {
                byte[] sarr = Encoding.Default.GetBytes(textBox1.Text);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = textBox1.Text;
                cds.cbData = len + 1;
                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref cds);
                MessageBox.Show("发送成功！");
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
