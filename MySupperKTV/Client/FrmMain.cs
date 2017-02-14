using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {

        private bool isOut = true;//向外
        private bool isShowList = true;//是否展示已点列表 
        public FrmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(new Bitmap(Properties.Resources.png_0380, 35, 35).GetHicon());//设置鼠标图标
            plPlayer.Left = 1366 - plPlayer.Width;//设置播放器停靠位置
            plWillPlayerList.Top = plWillPlayerList.Top + (plWillPlayerList.Height / 2);
            plWillPlayerList.Height = 0;
        }
        /// <summary>
        /// 榜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrders_Click(object sender, EventArgs e)
        {
            //先不实现排行榜单
        }
        /// <summary>
        /// 点歌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMusicList_Click(object sender, EventArgs e)
        {
            lblMusicList.BackColor = Color.OrangeRed;
        }
        #region 顶部工具条悬浮
        /// <summary>
        /// 头部工具条通用鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMusicList_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                ((Label)sender).BackColor = Color.YellowGreen;
            }
        }
        /// <summary>
        /// 头部工具条通用鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMusicList_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                ((Label)sender).BackColor = Color.Yellow;
            }
        }
        #endregion
        #region 底部按钮悬浮
        /// <summary>
        /// 底部按钮进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToning_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                ((Label)sender).BackColor = Color.YellowGreen;
            }
        }
        /// <summary>
        /// 底部按钮通用离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToning_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                ((Label)sender).BackColor = Color.FromArgb(255, 128, 0);
            }
        }
        #endregion
        /// <summary>
        /// 让包含播放器的面板进去或出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPlayInOut_Click(object sender, EventArgs e)
        {
            //如果面板在窗体里面
            if (isOut)
            {
                timerPlayerOut.Enabled = true;
            }
            else
            {
                timerForPlayerIn.Enabled = true;
            }
        }
        #region 视频播放控件动画
        /// <summary>
        /// 进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerForPlayerIn_Tick(object sender, EventArgs e)
        {
            plPlayer.Left -= 40;
            if (plPlayer.Left <= 1366 - plPlayer.Width)
            {
                timerForPlayerIn.Enabled = false;
                lblPlayInOut.Text = "你给我出去";
                isOut = true;
            }
        }
        /// <summary>
        /// 出去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPlayerOut_Tick(object sender, EventArgs e)
        {
            plPlayer.Left += 40;
            if (plPlayer.Left >= 1366 - 45)
            {
                timerPlayerOut.Enabled = false;
                lblPlayInOut.Text = "你给我进来";
                isOut = false;
            }
        }
        #endregion
        #region 主控按钮组事件
        /// <summary>
        /// 已点列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblWillPlayList_Click(object sender, EventArgs e)
        {
            if (isShowList)
            {
                timerShowPlayList.Enabled = true;
            }
            else
            {
                timerHidePlayList.Enabled = true;
            }
        }

        /// <summary>
        /// 静音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMute_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 减小播放音量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVolumeMinish_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 增大播放音量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVolumeAdd_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 重唱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReplay_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPause_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 切歌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNextMusic_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 调音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToning_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 气氛
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAtmosphere_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 原唱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOriginSong_Click(object sender, EventArgs e)
        {

        }
        #endregion
        /// <summary>
        /// 展示已点列表动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerShowPlayList_Tick(object sender, EventArgs e)
        {
            //动画效果，从中间向上下扩散
            plWillPlayerList.Height += 20;
            plWillPlayerList.Top -= 10;
            if (plWillPlayerList.Height >= 280 && plWillPlayerList.Top >= 400)
            {
                timerShowPlayList.Enabled = false;
                isShowList = false;
            }
        }
        /// <summary>
        /// 隐藏已点列表动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerHidePlayList_Tick(object sender, EventArgs e)
        {
            //动画效果，从上下往中间缩小
            plWillPlayerList.Height -= 20;
            plWillPlayerList.Top += 10;
            if (plWillPlayerList.Height <= 0 && plWillPlayerList.Top >= 400+140)
            {
                timerHidePlayList.Enabled = false;
                isShowList = true;
            }
        }
    }
}
