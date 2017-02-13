using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace TestUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //使用跨线程，简单、暴力，不建议复杂情况使用
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Loop);
            th.Start();//择机启动线程
        }

        private void Loop()
        {
            for (int i = 0; i < 10000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }
    }
}
