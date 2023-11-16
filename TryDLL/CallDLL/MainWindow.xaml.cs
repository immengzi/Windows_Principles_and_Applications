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

namespace CallDLL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string strText1 = textBox1.Text.Trim();
            int numText1;
            bool isNumber = int.TryParse(strText1, out numText1);
            if (isNumber)
            {
                int resulTestFac = DllTest.testFac(numText1);
                textBox2.Text = String.Concat(resulTestFac);
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string strText3 = textBox3.Text.Trim();
            string strText4 = textBox4.Text.Trim();
            int numText1;
            int numText2;
            bool isNumber1 = int.TryParse(strText3, out numText1);
            bool isNumber2 = int.TryParse(strText4, out numText2);
            if (isNumber1 && isNumber2)
            {
                int resultTestMinus = DllTest.testMinus(numText1, numText2);
                textBox5.Text = String.Concat(resultTestMinus);
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }
    }
}
