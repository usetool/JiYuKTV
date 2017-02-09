namespace Server
{
    partial class FrmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.歌手管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.歌曲管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置资源路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiWebSite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSinger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSingerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSongInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSingerPhoto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSongPath = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.歌手管理ToolStripMenuItem,
            this.歌曲管理ToolStripMenuItem,
            this.设置资源路径ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 歌手管理ToolStripMenuItem
            // 
            this.歌手管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSinger,
            this.tsmiSingerInfo,
            this.tsmiExit});
            this.歌手管理ToolStripMenuItem.Name = "歌手管理ToolStripMenuItem";
            this.歌手管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.歌手管理ToolStripMenuItem.Text = "歌手管理(&S)";
            // 
            // 歌曲管理ToolStripMenuItem
            // 
            this.歌曲管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSong,
            this.tsmiSongInfo});
            this.歌曲管理ToolStripMenuItem.Name = "歌曲管理ToolStripMenuItem";
            this.歌曲管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.歌曲管理ToolStripMenuItem.Text = "歌曲管理(&O)";
            // 
            // 设置资源路径ToolStripMenuItem
            // 
            this.设置资源路径ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSingerPhoto,
            this.tsmiSongPath});
            this.设置资源路径ToolStripMenuItem.Name = "设置资源路径ToolStripMenuItem";
            this.设置资源路径ToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.设置资源路径ToolStripMenuItem.Text = "设置资源路径(&R)";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout,
            this.toolStripMenuItem2,
            this.tsmiWebSite});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "关于我们(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiWebSite
            // 
            this.tsmiWebSite.Name = "tsmiWebSite";
            this.tsmiWebSite.Size = new System.Drawing.Size(152, 22);
            this.tsmiWebSite.Text = "官方网站(&W)";
            this.tsmiWebSite.Click += new System.EventHandler(this.tsmiWebSite_Click);
            // 
            // tsmiAddSinger
            // 
            this.tsmiAddSinger.Name = "tsmiAddSinger";
            this.tsmiAddSinger.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddSinger.Text = "新增歌手(&N)";
            this.tsmiAddSinger.Click += new System.EventHandler(this.tsmiAddSinger_Click);
            // 
            // tsmiSingerInfo
            // 
            this.tsmiSingerInfo.Name = "tsmiSingerInfo";
            this.tsmiSingerInfo.Size = new System.Drawing.Size(163, 22);
            this.tsmiSingerInfo.Text = "查询歌手信息(&S)";
            this.tsmiSingerInfo.Click += new System.EventHandler(this.tsmiSingerInfo_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(163, 22);
            this.tsmiExit.Text = "退出(&X)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiAddSong
            // 
            this.tsmiAddSong.Name = "tsmiAddSong";
            this.tsmiAddSong.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddSong.Text = "新增歌曲(&N)";
            this.tsmiAddSong.Click += new System.EventHandler(this.tsmiAddSong_Click);
            // 
            // tsmiSongInfo
            // 
            this.tsmiSongInfo.Name = "tsmiSongInfo";
            this.tsmiSongInfo.Size = new System.Drawing.Size(163, 22);
            this.tsmiSongInfo.Text = "查询歌曲信息(&S)";
            this.tsmiSongInfo.Click += new System.EventHandler(this.tsmiSongInfo_Click);
            // 
            // tsmiSingerPhoto
            // 
            this.tsmiSingerPhoto.Name = "tsmiSingerPhoto";
            this.tsmiSingerPhoto.Size = new System.Drawing.Size(163, 22);
            this.tsmiSingerPhoto.Text = "歌手照片路径(&S)";
            this.tsmiSingerPhoto.Click += new System.EventHandler(this.tsmiSingerPhoto_Click);
            // 
            // tsmiSongPath
            // 
            this.tsmiSongPath.Name = "tsmiSongPath";
            this.tsmiSongPath.Size = new System.Drawing.Size(163, 22);
            this.tsmiSongPath.Text = "歌曲路径(&O)";
            this.tsmiSongPath.Click += new System.EventHandler(this.tsmiSongPath_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 443);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmAdmin";
            this.Text = "技宇KTV管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 歌手管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 歌曲管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置资源路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiWebSite;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSinger;
        private System.Windows.Forms.ToolStripMenuItem tsmiSingerInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSong;
        private System.Windows.Forms.ToolStripMenuItem tsmiSongInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiSingerPhoto;
        private System.Windows.Forms.ToolStripMenuItem tsmiSongPath;
    }
}