using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmLoading : Form
    {
        private int time = 0;
        public FrmLoading()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoading_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            switch (time)   
            {
                case 5:
                    this.lblProgress.Text = "正在登录，请稍后……";
                    break;
                case 10:
                    BindPath();
                    this.lblProgress.Text = "正在加载后台……";
                    break;
                case 15:
                    this.lblProgress.Text = "正在加载图片……";
                    break;
                case 18:
                    this.lblProgress.Text = "正在加载图片1/10";
                    break;
                case 22:
                    this.lblProgress.Text = "正在加载图片3/10";
                    break;
                case 26:
                    this.lblProgress.Text = "正在加载图片6/10";
                    break;
                case 32:
                    this.lblProgress.Text = "加载完成！";
                    break;
                case 42:
                    this.timer1.Enabled = false;
                    FrmAdmin admin = new FrmAdmin();
                    admin.Show();
                    this.Hide();
                    break;
            }
        }
        /// <summary>
        /// 绑定路径到帮助类
        /// </summary>
        private void BindPath()
        {
            string sql = "select resource_type,resource_path from resource_path";
            DBHelper.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type=reader["resource_type"].ToString();
                    if (type== "singer")
                    {
                        KTVUtil.singerPhotoPath = reader["resource_path"].ToString();
                    }
                    else
                    {
                        KTVUtil.songPath = reader["resource_path"].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }
        }
    }
}
