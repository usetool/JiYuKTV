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
    public partial class FrmSingerList : Form
    {
        /// <summary>
        /// 是否是选择歌手
        /// </summary>
        public bool isChooseSinger;
        /// <summary>
        /// 编辑歌手窗体
        /// </summary>
        public FrmEditSong frmEditSong;
        DataSet ds;
        public FrmSingerList()
        {
            InitializeComponent();
            
        }
        public void chooseSinger(object sender,EventArgs e)
        {
            int id =Convert.ToInt32( dataGridView1.SelectedRows[0].Cells["singer_id"].Value);
            string name = dataGridView1.SelectedRows[0].Cells["singer_name"].Value.ToString();
            frmEditSong.txtSinger.Text = name;
            frmEditSong.txtSinger.Tag = id;
            this.Close();
        }
        /// <summary>
        /// 右键菜单点击编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            FrmEditSinger editSinger = new FrmEditSinger();
            editSinger.isEdit = true;
            editSinger.frmSingerList = this;
            editSinger.singer_id =(int) dataGridView1.SelectedRows[0].Cells["singer_id"].Value;
            editSinger.Show();
        }
        /// <summary>
        /// 右键菜单点击删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("确定要删除吗？不可恢复！","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (dia==DialogResult.Cancel)
            {
                return;
            }
            string sql = "delete from singer_info where singer_id="+dataGridView1.SelectedRows[0].Cells["singer_id"].Value;
            DBHelper.conn.Open();
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                result=cmd.ExecuteNonQuery();
                object path=this.dataGridView1.SelectedRows[0].Cells["singer_photo_url"].Value;
                if (path != null&& path.ToString() != "")
                {
                    File.Delete(KTVUtil.singerPhotoPath + dataGridView1.SelectedRows[0].Cells["singer_photo_url"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }
            if (result == 1)
            {
                MessageBox.Show("删除成功!");
                this.BindAllInfo();
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSingerList_Load(object sender, EventArgs e)
        {
            BindAllInfo();
            dataGridView1.AutoGenerateColumns = false;
            if (isChooseSinger)
            {
                ToolStripMenuItem ts = new ToolStripMenuItem("选择歌手");
                ts.Name = "chooseSinger";
                ts.Click += chooseSinger;//绑定事件
                contextMenuStrip1.Items.Add(ts);
            }
        }
        /// <summary>
        /// 更新绑定所有信息（可以给其他窗体用）
        /// </summary>
        public void BindAllInfo()
        {
            BindSingerType();
            BindSingerInfo("", 0);
        }

        /// <summary>
        /// 绑定数据到歌手信息
        /// </summary>
        /// <param name="singer_name">歌手名字</param>
        /// <param name="singertype_id">歌手类型</param>
        private void BindSingerInfo(string singer_name,int singertype_id)
        {
            StringBuilder sql =new StringBuilder(@"select singer_id,singer_name,singer_sex,singer_description,singer_photo_url from singer_info i,singer_type t
where i.singertype_id = t.singertype_id");
            if (singer_name!="")
            {
                sql.AppendFormat(" and singer_name like '%{0}%'", singer_name);
            }
            if (singertype_id!=0)
            {
                sql.AppendFormat(" and t.singertype_id={0}", singertype_id);
            }
            DBHelper.conn.Open();
            ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), DBHelper.conn);
            adapter.Fill(ds, "singer");
            dataGridView1.DataSource = ds.Tables["singer"];
            DBHelper.conn.Close();

        }
        /// <summary>
        /// 绑定数据到歌手类型
        /// </summary>
        private void BindSingerType()
        {
            string sql = "select singertype_id,singertype_name from singer_type";
            DBHelper.conn.Open();
            ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.conn);
            adapter.Fill(ds, "singer_type");
            cboSingerType.DisplayMember = "singertype_name";
            cboSingerType.ValueMember = "singertype_id";
            cboSingerType.DataSource = ds.Tables["singer_type"];
            DBHelper.conn.Close();
        }
        /// <summary>
        /// 下拉框选中一项后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSingerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindSingerInfo(txtSingerName.Text, (int)cboSingerType.SelectedValue);
        }
    }
}
