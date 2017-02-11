using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            wmplayer.Ctlcontrols.play();//歌曲播放
        }
        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "暂停")
            {
                wmplayer.Ctlcontrols.pause();//歌曲播放
                button2.Text = "播放";
            }
            else if (button2.Text == "播放")
            {
                wmplayer.Ctlcontrols.play();//暂停
                button2.Text = "暂停";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wmplayer.URL = @"E:\KTVWorkSpace\Song\Psy - Gentleman.mkv";
        }
        /// <summary>
        /// 增加音量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            wmplayer.settings.volume++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wmplayer.settings.volume--;
            this.label1.Text = wmplayer.settings.volume.ToString();
        }
        /// <summary>
        /// 重播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            wmplayer.Ctlcontrols.stop();//停止
            wmplayer.Ctlcontrols.play();//播放
        }

        private void button7_Click(object sender, EventArgs e)
        {
            wmplayer.settings.mute = true;//静音
        }

        private void button5_Click(object sender, EventArgs e)
        {
            wmplayer.fullScreen = true;//全屏
        }
    }
}
