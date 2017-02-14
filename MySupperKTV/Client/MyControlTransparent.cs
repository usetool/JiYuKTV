using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Client
{
    public class MyControlTransparent:Control
    {
        public MyControlTransparent()
        {
            //设置Style支持透明背景色
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.FromArgb(125, 100, 0, 0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("test", new Font("Tahoma", 8.25f), Brushes.Red, new PointF(20, 20));
        }

    }
}
