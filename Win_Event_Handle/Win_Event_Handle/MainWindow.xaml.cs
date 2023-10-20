using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Win_Event_Handle
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private FireAlarm myFireAlarm;
        private FireHandlerClass myFireHandler1;
        private FireWatcherClass myWatcher1;

        public MainWindow()
        {
            InitializeComponent();
            myFireAlarm = new FireAlarm();  //定义一个火情发生源类对象；
        }

        private void Bind1(object sender, RoutedEventArgs e)
        {
            try
            {
                myFireHandler1 = new FireHandlerClass(myFireAlarm);
                MessageBox.Show("绑定成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bind2(object sender, RoutedEventArgs e)
        {
            try
            {
                myWatcher1 = new FireWatcherClass(myFireAlarm);
                MessageBox.Show("绑定成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Unbind1(object sender, RoutedEventArgs e)
        {
            try
            {
                myFireAlarm.FireEvent -= myFireHandler1.ExtinguishFire;
                myFireAlarm.FireEvent -= myFireHandler1.ExtinguishFire2;
                MessageBox.Show("解绑成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Unbind2(object sender, RoutedEventArgs e)
        {
            try
            {
                myFireAlarm.FireEvent -= myWatcher1.WatchFire;
                MessageBox.Show("解绑成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FireAlarm(object sender, RoutedEventArgs e)
        {
            try
            {
                myFireAlarm.ActivateFireAlarm("Kitchen", 1);
                //myFireAlarm.ActivateFireAlarm("Kitchen", 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
