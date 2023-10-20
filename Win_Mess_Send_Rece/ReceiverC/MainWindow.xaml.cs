using System;
using System.Collections.Generic;
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

namespace ReceiverC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int WM_COPYDATA = 0x004A;
        public MainWindow()
        {
            InitializeComponent();
        }

        //钩子函数，处理所收到的消息
        private IntPtr MainWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_COPYDATA:
                    CopyDataStruct.COPYDATASTRUCT mystr = new CopyDataStruct.COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    CopyDataStruct.COPYDATASTRUCT MyKeyboardHookStruct =
                    (CopyDataStruct.COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(CopyDataStruct.COPYDATASTRUCT));
                    string myText = MyKeyboardHookStruct.lpData;
                    ListBox1.Items.Add(myText);
                    break;
                default:
                    break;
            }
            return hwnd;
        }

        //页面加载时，添加消息处理钩子函数
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            //添加处理程序
            hWndSource.AddHook(MainWindowProc);
        }
    }
}
