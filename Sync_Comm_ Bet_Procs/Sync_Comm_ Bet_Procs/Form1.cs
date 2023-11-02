using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sync_Comm__Bet_Procs
{
    public partial class Sync : Form
    {
        public Sync()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            // 是否使用外壳程序
            process.StartInfo.UseShellExecute = false;
            // 是否在新窗口中启动该进程的值
            process.StartInfo.CreateNoWindow = true;
            // 重定向输入流
            process.StartInfo.RedirectStandardInput = true;
            // 重定向输出流
            process.StartInfo.RedirectStandardOutput = true;
            string strCmd;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                strCmd = "ping www.sohu.com -n 10";
            }
            else
            {
                strCmd = "ping " + textBox1.Text + " -n 10";
            }
            process.Start();
            process.StandardInput.WriteLine(strCmd);
            process.StandardInput.WriteLine("exit");
            // 获取输出信息
            richTextBox1.Text = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
        }
    }
}
