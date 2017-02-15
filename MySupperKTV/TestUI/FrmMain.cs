using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

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
            //Thread th = new Thread(Loop);
            //th.Start();//择机启动线程
            //转换图片
            //Graphics g = panel1.CreateGraphics();
            //TextureBrush myBrush = new TextureBrush(Properties.Resources._37800287_p2_master1200);
            //panel1.Refresh();
            //myBrush.WrapMode=WarpMode.
            //myBrush.RotateTransform();
            //myBrush.ScaleTransform(0.2f,0.2f);
            //panel1.Right
            //g.FillRectangle(myBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            timer1.Enabled = true;
        }

        private void Loop()
        {
            for (int i = 0; i < 10000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Left += 5;
            panel1.Width -= 10;
            if (panel1.Width<=-300)
            {
                timer1.Enabled = false;
            }
        }
    }
}
