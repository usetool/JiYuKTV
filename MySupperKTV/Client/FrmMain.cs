using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {

        private bool isOut = true;//向外
        private bool isShowList = true;//是否展示已点列表 
        private int mouseX;//鼠标按下位置
        private int mouseXNow;//鼠标当前位置
        private bool isListenerMove;//是否监听鼠标移动
        private int count;//按下时长
        private int pageCount;//总页数
        private int pageNow=1;//现在的页数
        /// <summary>
        /// 获取总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                int countPage = PlayList.songList.Count % 5 == 0 ? PlayList.songList.Count / 5 : PlayList.songList.Count / 5 + 1;
                return countPage;
            }
        }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageNow
        {
            get
            {
                return pageNow;
            }

            set
            {
                if (value<=1)
                {
                    pageNow = 1;
                }
                if (value>PageCount)
                {
                    pageNow = PageCount;
                }
                pageNow = value;
            }
        }

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
            //防止闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = new Cursor(new Bitmap(Properties.Resources.png_0380, 35, 35).GetHicon());//设置鼠标图标
            plPlayer.Left = 1366 - plPlayer.Width;//设置播放器停靠位置
            plWillPlayerList.Top = plWillPlayerList.Top + (plWillPlayerList.Height / 2);
            plWillPlayerList.Height = 0;
            Song song = new Song();
            song.SongName = "aaa";
            song.SingerName = "战三";
            Song song1 = new Song();
            song1.SongName = "bbb";
            song1.SingerName = "李四";
            Song song2 = new Song();
            song2.SongName = "bbb";
            song2.SingerName = "李四";
            Song song3 = new Song();
            song3.SongName = "bbb";
            song3.SingerName = "李四";
            Song song4 = new Song();
            song4.SongName = "bbb";
            song4.SingerName = "李四";
            Song song5 = new Song();
            song5.SongName = "bbb";
            song5.SingerName = "李四";
            Song song6 = new Song();
            song6.SongName = "bbb";
            song6.SingerName = "李四";
            Song song7 = new Song();
            song7.SongName = "bbb";
            song7.SingerName = "李四";
            PlayList.songList.Add(song);
            PlayList.songList.Add(song1);
            PlayList.songList.Add(song2);
            PlayList.songList.Add(song3);
            PlayList.songList.Add(song4);
            PlayList.songList.Add(song5);
            //PlayList.songList.Add(song6);
            //PlayList.songList.Add(song7);
            //InitialPlayList();
            EachBindPlayList();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 遍历绑定播放列表，初始化
        /// </summary>
        private void EachBindPlayList()
        {
            lblPlayListSingerNow.Text = PlayList.songList[0].SingerName;
            lblPlayListSongNow.Text = PlayList.songList[0].SongName;
            lblPlayListSingerNow.Tag = PlayList.songList[0];
            for (int i = 1; i < PlayList.songList.Count; i++)
            {
                //添加序号
                Label no = (Label)(this.Controls.Find("lblNo" + i, true)[0]);
                no.Visible = true;
                no.Text = i.ToString();
                //添加歌曲名称
                Label song = (Label)(this.Controls.Find("lblPlayListSong" + i, true)[0]);
                song.Visible = true;
                song.Text = PlayList.songList[i].SongName;
                //添加歌手名称
                Label singer = (Label)(this.Controls.Find("lblPlayListSinger" + i, true)[0]);
                singer.Visible = true;
                singer.Text = PlayList.songList[i].SingerName;
                //显示删除按钮
                Label delete= (Label)(this.Controls.Find("lblPlayListDelete" + i, true)[0]);
                delete.Visible = true;
                //显示顶按钮
                Label top = (Label)(this.Controls.Find("lblPlayListTop" + i, true)[0]);
                top.Visible = true;
            }
            //分页
            lblPageText.Text = PageNow + "/" + PageCount;
            
            
        }
        /// <summary>
        /// 隐藏所有列表
        /// </summary>
        private void HidePlayList()
        {
            for (int i = 1; i < PlayList.songList.Count; i++)
            {
                Label no = (Label)(this.Controls.Find("lblNo" + i, true)[0]);
                no.Visible = false;
                Label song = (Label)(this.Controls.Find("lblPlayListSong" + i, true)[0]);
                song.Visible = false;
                Label singer = (Label)(this.Controls.Find("lblPlayListSinger" + i, true)[0]);
                singer.Visible = false;
                singer.Text = PlayList.songList[i].SingerName;
                //显示删除按钮
                Label delete = (Label)(this.Controls.Find("lblPlayListDelete" + i, true)[0]);
                delete.Visible = false;
                //显示顶按钮
                Label top = (Label)(this.Controls.Find("lblPlayListTop" + i, true)[0]);
                top.Visible = false;
            }
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
            if (plWillPlayerList.Height <= 0 && plWillPlayerList.Top >= 400 + 140)
            {
                timerHidePlayList.Enabled = false;
                isShowList = true;
            }
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            count = 0;
            //记录鼠标当前位置
            mouseX = e.X;
            //计算鼠标移动多少
            isListenerMove = true;
            //移动容器
            //计时
            timerCountDownTime.Enabled = true;
        }

        /// <summary>
        /// 窗体的鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isListenerMove)
            {
                panel2.Left += (e.X - mouseX);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            isListenerMove = false;
            timerCountDownTime.Enabled = false;
        }
        /// <summary>
        /// 新歌榜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNewMusicOrder_Click(object sender, EventArgs e)
        {
            if (count > 5)
            {
                return;
            }
            MessageBox.Show("新歌榜");
        }

        private void timerCountDownTime_Tick(object sender, EventArgs e)
        {
            count++;
        }
    }
}
