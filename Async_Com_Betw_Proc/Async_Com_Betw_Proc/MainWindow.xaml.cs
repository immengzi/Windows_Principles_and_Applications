using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Async_Com_Betw_Proc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Process cmdP;
        public static StreamWriter cmdStreamInput;
        private static StringBuilder cmdOutput = null;

        public static IntPtr main_whandle;
        public static IntPtr text_whandle;

        #region 定义常量消息值

        public const int TRAN_FINISHED = 0x500;
        public const int WM_COPYDATA = 0x004A;

        #endregion

        #region 定义结构体

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)] public string lpData;
        }

        #endregion

        //动态链接库引入
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            IntPtr hWnd, // handle to destination window 
            int Msg, // message 
            int wParam, // first message parameter 
            ref COPYDATASTRUCT lParam // second message parameter 
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass,
            string lpszWindow);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            //添加处理程序 
            hWndSource.AddHook(MainWindowProc);
        }

        //钩子函数，处理所收到的消息
        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_COPYDATA:
                    try
                    {
                        COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                        Type mytype = mystr.GetType();

                        COPYDATASTRUCT MyKeyboardHookStruct =
                            (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                        showComment(MyKeyboardHookStruct.lpData);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                case TRAN_FINISHED:
                {
                    showComment(cmdOutput.ToString());
                    break;
                }
                default:
                {
                    break;
                }
            }

            return hwnd;
        }

        private void clearComments()
        {
            listBox1.Items.Clear();
        }

        private void showComment(String comment)
        {
            if (MyStringUtil.isEmpty(comment))
            {
                listBox1.Items.Add("");
                return;
            }

            listBox1.Items.Add(comment);
        }

        //定义回调
        private delegate void updateDelegate(object comment);

        public void update(object comment)
        {
            //showComment((string)comment);
            if (!listBox1.Dispatcher.CheckAccess())
            {
                //声明，并实例化回调
                updateDelegate d = update;
                //使用回调
                listBox1.Dispatcher.Invoke(d, comment);
            }
            else
            {
                showComment((string)comment);
            }
        }

        private void runCMD(object sender, RoutedEventArgs e)
        {
            clearComments();
            string strCmd = "ping www.sohu.com -n 10";
            if (!MyStringUtil.isEmpty(textBox1.Text))
                strCmd = "ping " + textBox1.Text.Trim() + " -n 10";

            cmdOutput = new StringBuilder("");

            cmdP = new Process();
            cmdP.StartInfo.FileName = "cmd.exe";
            cmdP.StartInfo.CreateNoWindow = true;
            cmdP.StartInfo.UseShellExecute = false;
            cmdP.StartInfo.RedirectStandardOutput = true;
            cmdP.StartInfo.RedirectStandardInput = true;

            cmdP.OutputDataReceived += new DataReceivedEventHandler(strOutputHandler);
            cmdP.Start();

            cmdStreamInput = cmdP.StandardInput;
            cmdStreamInput.WriteLine(strCmd);
            cmdStreamInput.WriteLine("exit");
            cmdP.BeginOutputReadLine();
        }

        //如果有输出，则重定向至输出对象，并向窗口对象发送特定的消息WM_COPYDATA和封装数据COPYDATASTRUCT
        private void strOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {

            //通过触发event，封装数据，并启动线程来异步更新控件
            //fireEvent(outLine.Data);

            cmdOutput.AppendLine(outLine.Data);

            //通过查找窗口，封装数据，发送消息的方式来异步更新控件
            //通过FindWindow API的方式找到目标进程句柄，然后发送消息
            IntPtr WINDOW_HANDLER = FindWindow(null, "MainWindow");

            if (WINDOW_HANDLER != IntPtr.Zero)
            {
                //IntPtr hwndThree = FindWindowEx(WINDOW_HANDLER, 0, null, "");

                COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                mystr.dwData = (IntPtr)0;
                if (MyStringUtil.isEmpty(outLine.Data))
                {
                    mystr.cbData = 0;
                    mystr.lpData = "";
                }
                else
                {
                    byte[] sarr = System.Text.Encoding.Unicode.GetBytes(outLine.Data);
                    mystr.cbData = sarr.Length + 1;
                    mystr.lpData = outLine.Data;
                }

                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref mystr);
            }
        }

        private void closeCMD(object sender, RoutedEventArgs e)
        {
            cmdP.Close();
        }
    }
}
