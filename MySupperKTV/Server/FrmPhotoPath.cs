using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;

namespace Server
{
    public partial class FrmPhotoPath : Form
    {
        public bool isSinger;//true就是歌手，false就是歌曲

        public FrmPhotoPath()
        {
            InitializeComponent();
            //禁止编译器对跨线程访问做检查
            Control.CheckForIllegalCrossThreadCalls = false;
            if (isSinger)
            {
                Text = "设置歌手路径";
                txtNow.Text = KTVUtil.singerPhotoPath;
            }
            else
            {
                Text = "设置歌曲路径";
                txtNow.Text = KTVUtil.songPath;
            }
        }
        /// <summary>
        /// 打开目录选择对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtNew.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void FrmPhotoPath_Load(object sender, EventArgs e)
        {
            txtNow.Text = KTVUtil.singerPhotoPath;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 按钮修改目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text == null || txtNew.Text == "")
            {
                txtNew.Focus();
                MessageBox.Show("路径不能为空！");
                return;
            }
            else if (txtNow.Text == null || txtNow.Text == "")
            {
                txtNow.Focus();
                MessageBox.Show("路径不能为空！");
                return;
            }
            Thread th = new Thread(test);
            th.Start();
        }
        private void test()
        {
            btnSave.Enabled = false;
            txtNew.Enabled = false;
            txtNow.Enabled = false;
            btnBrowser.Enabled = false;
            btnCancle.Enabled = false;
            progressBar1.Visible = true;
            IOUtil util = new IOUtil(txtNew.Text);
            util.GetDirFilesNum(txtNow.Text);
            //复制和删除操作各占50%
            util.CopyDirectory(txtNow.Text, txtNew.Text, progressBar1);
            util.DeleteDirectory(txtNow.Text, progressBar1);
            progressBar1.Visible = false;
            UpdatePath();
            btnSave.Enabled = true;
            txtNew.Enabled = true;
            txtNow.Enabled = true;
            btnBrowser.Enabled = true;
            btnCancle.Enabled = true;

        }
        /// <summary>
        /// 更新数据库中路径
        /// </summary>
        private void UpdatePath()
        {
            StringBuilder sql =new StringBuilder();
            sql.AppendFormat("update resource_path set resource_path='{0}' ",txtNew.Text+"\\");
            int result = 0;
            if (isSinger)
            {
                sql.AppendFormat("where resource_type='{0}'", "singer");
            }
            else
            {
                sql.AppendFormat("where resource_type='{0}'", "song");
            }
            DBHelper.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(),DBHelper.conn);
                 result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }
            if (result==1)
            {
                txtNow.Text = txtNew.Text;
                txtNew.Text = "";
                MessageBox.Show("数据库更新成功!");
            }
            else
            {
                MessageBox.Show("数据库更新失败！");
            }
        }
    }
}
