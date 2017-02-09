using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void tsmiWebSite_Click(object sender, EventArgs e)
        {
            //使用默认浏览器打开网页
            System.Diagnostics.Process.Start("http://www.dtblog.cn");
        }
        /// <summary>
        /// 新增歌手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddSinger_Click(object sender, EventArgs e)
        {
            FrmEditSinger editSinger = new FrmEditSinger();
            editSinger.MdiParent = this;
            editSinger.Show();
        }
        /// <summary>
        /// 歌手信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSingerInfo_Click(object sender, EventArgs e)
        {
            FrmSingerList singerList = new FrmSingerList();
            singerList.MdiParent = this;
            singerList.Show();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 添加歌曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddSong_Click(object sender, EventArgs e)
        {
            FrmEditSong editSong = new FrmEditSong();
            editSong.MdiParent = this;
            editSong.Show();
        }
        /// <summary>
        /// 歌曲信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSongInfo_Click(object sender, EventArgs e)
        {
            FrmSongList songList = new FrmSongList();
            songList.MdiParent = this;
            songList.Show();
        }
        /// <summary>
        /// 歌手图片路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSingerPhoto_Click(object sender, EventArgs e)
        {
            FrmPhotoPath photoPath = new FrmPhotoPath();
            photoPath.MdiParent = this;
            photoPath.Show();
        }
        /// <summary>
        /// 歌曲路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSongPath_Click(object sender, EventArgs e)
        {
            FrmSongPath songPath = new FrmSongPath();
            songPath.MdiParent = this;
            songPath.Show();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.MdiParent = this;
            about.Show();
        }
    }
}
