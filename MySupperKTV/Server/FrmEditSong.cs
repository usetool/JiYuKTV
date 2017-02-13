using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmEditSong : Form
    {
        public FrmEditSong()
        {
            InitializeComponent();
        }

        private void s_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string song_name = txtSongName.Text;
            string song_ab = txtAb.Text;
            string song_word_count =txtSongName.Text.Count().ToString();
            string songtype_id = cboType.SelectedValue.ToString();
            string singer_id = txtSinger.Tag.ToString();
            string song_url =txtSongPath.Text;
            string song_play_count = numCount.Value.ToString();
            string sql = string.Format("insert into song_info values('{0}','{1}',{2},{3},{4},'{5}',{6})", song_name, song_ab, song_word_count, songtype_id, singer_id, song_url.Substring(song_url.IndexOf("\\")+1), song_play_count);
            DBHelper.conn.Open();
            int result = 0;
            File.Copy(song_url, KTVUtil.songPath + song_url.Substring(song_url.LastIndexOf("\\") + 1));
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
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
                MessageBox.Show("添加成功！");
            }

        }
        /// <summary>
        /// 浏览文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBroswe_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSongPath.Text = openFileDialog1.FileName;
            }
        }
        /// <summary>
        /// 点击后选择歌手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSinger_MouseClick(object sender, MouseEventArgs e)
        {
            FrmSingerList list = new FrmSingerList();
            list.isChooseSinger = true;
            list.frmEditSong = this;
            list.Show();
        }

        private void numCount_ValueChanged(object sender, EventArgs e)
        {
            if (numCount.Value < 0)
            {
                return;
            }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditSong_Load(object sender, EventArgs e)
        {
            BindType();
        }
        /// <summary>
        /// 绑定类型
        /// </summary>
        private void BindType()
        {
            DataSet ds = new DataSet();
            string sql = "select songtype_id, songtype_name from song_type";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.conn);
            adapter.Fill(ds, "song");
            cboType.ValueMember = "songtype_id";
            cboType.DisplayMember = "songtype_name";
            cboType.DataSource = ds.Tables["song"];
        }
        /// <summary>
        /// 更改文本的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSongName_TextChanged(object sender, EventArgs e)
        {
            txtAb.Text= PinYin.GetCodstring(txtSongName.Text);
        }
    }
}
