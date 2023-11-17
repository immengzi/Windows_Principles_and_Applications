using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string strText6 = textBox6.Text.Trim();
            string strText7 = textBox7.Text.Trim();
            int numText1;
            int numText2;
            bool isNumber1 = int.TryParse(strText6, out numText1);
            bool isNumber2 = int.TryParse(strText7, out numText2);
            if (isNumber1 && isNumber2)
            {
                string resultMinus = ComTest.minus("FD8BA821-DB63-42DC-80D5-E0F46B23CFD4", numText1, numText2);
                textBox8.Text = String.Concat(resultMinus);
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string strText9 = textBox9.Text.Trim();
            string strText10 = textBox10.Text.Trim();
            int numText1;
            int numText2;
            bool isNumber1 = int.TryParse(strText9, out numText1);
            bool isNumber2 = int.TryParse(strText10, out numText2);
            if (isNumber1 && isNumber2)
            {
                string resultDivide = ComTest.divide("FD8BA821-DB63-42DC-80D5-E0F46B23CFD4", numText1, numText2);
                textBox11.Text = String.Concat(resultDivide);
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }
    }
}
