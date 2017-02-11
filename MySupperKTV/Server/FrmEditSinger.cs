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
    public partial class FrmEditSinger : Form
    {
        /// <summary>
        /// 是否是编辑,true为编辑,fal]se为新增
        /// </summary>
        public bool isEdit;
        /// <summary>
        /// 歌手编号
        /// </summary>
        public int singer_id;
        /// <summary>
        /// 歌手列表窗体
        /// </summary>
        public FrmSingerList frmSingerList;
        public FrmEditSinger()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditSinger_Load(object sender, EventArgs e)
        {

            BindSingerTypeList();
            if (isEdit)
            {
                //加载信息
                string sql = @"select singer_name,singertype_id,singer_sex,singer_photo_url,singer_description 
from singer_info where singer_id=" + singer_id;
                DBHelper.conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                    SqlDataReader reader=cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtSingerName.Text = reader["singer_name"].ToString();
                        txtPhotoPath.Text = KTVUtil.singerPhotoPath + reader["singer_photo_url"];
                        txtDescription.Text = reader["singer_description"].ToString();
                        pictureBox1.ImageLocation = txtPhotoPath.Text;
                        int singertype_id = (int)reader["singertype_id"];
                        string sex = reader["singer_sex"].ToString();
                        switch (sex)
                        {
                            case "男":
                                rdoMan.Checked = true;
                                break;
                            case "女":
                                rdoGril.Checked = true;
                                break;
                            case "组合":
                                rdoGroup.Checked = true;
                                break;
                        }
                        //设置选中项
                        for (int i = 0; i < cboType.Items.Count; i++)
                        {
                            cboType.SelectedIndex = i;
                            if ((int)cboType.SelectedValue == singertype_id)
                            {
                                break;
                            }
                        }
                        //for (int i = 0; i < cboType.Items.Count; i++)
                        //{
                        //    MessageBox.Show(cboType.GetItemText(cboType.Items[i]));
                        //}

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

            }
        }
        /// <summary>
        /// 绑定歌手类型列表
        /// </summary>
        public void BindSingerTypeList()
        {
            string sql = "select singertype_id,singertype_name from singer_type";
            DBHelper.conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.conn);
            adapter.Fill(ds, "singer_type");
            cboType.DisplayMember = "singertype_name";
            cboType.ValueMember = "singertype_id";
            cboType.DataSource = ds.Tables["singer_type"];
            DBHelper.conn.Close();
        }
        /// <summary>
        /// 浏览图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件|*.bmp;*.jpg;*gif;*png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.ImageLocation = openFileDialog1.FileName;
                txtPhotoPath.Text = openFileDialog1.FileName;
            }
        }
        /// <summary>
        /// 保存歌手信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                SaveInfo();
            }
        }
        /// <summary>
        /// 空信息检测
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            foreach (Control ctl in Controls)
            {
                if (ctl is TextBox || ctl is ComboBox)
                {
                    if (ctl.Text.Length == 0&&ctl.Name!= "txtPhotoPath")
                    {
                        ctl.Focus();
                        MessageBox.Show("内容不能为空！");
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        private void SaveInfo()
        {
            string singer_name = txtSingerName.Text;
            int singertype_id = (int)cboType.SelectedValue;
            string singer_sex = "";
            string singer_photo_url = txtPhotoPath.Text.Substring(txtPhotoPath.Text.LastIndexOf('\\') + 1);
            string singer_description = txtDescription.Text;
            if (rdoGril.Checked)
            {
                singer_sex = "女";
            }
            else if (rdoMan.Checked)
            {
                singer_sex = "男";
            }
            else
            {
                singer_sex = "组合";
            }
            if (isEdit)
            {
                //修改操作
                UpdateSingerInfo(singer_name, singertype_id, singer_sex, singer_photo_url, singer_description);
            }
            else
            {
                //新增操作
                AddSingerInfo(singer_name, singertype_id, singer_sex, singer_photo_url, singer_description);
            }
        }
        /// <summary>
        /// 添加歌手信息
        /// </summary>
        /// <param name="singer_name"></param>
        /// <param name="singertype_id"></param>
        /// <param name="singer_sex"></param>
        /// <param name="singer_photo_url"></param>
        private void AddSingerInfo(string singer_name, int singertype_id, string singer_sex, string singer_photo_url, string singer_description)
        {
            string sql = string.Format(@"insert into singer_info 
values('{0}',{1},'{2}','{3}','{4}')", singer_name, singertype_id, singer_sex, singer_photo_url, singer_description);
            DBHelper.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    if (txtPhotoPath.Text!="")
                    {
                        //复制文件到指定路径
                        File.Copy(txtPhotoPath.Text, KTVUtil.singerPhotoPath + singer_photo_url);
                    }
                    MessageBox.Show("添加成功！");
                    ClearInfo();
                }
                else
                {
                    MessageBox.Show("添加失败！！");
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
        }
        /// <summary>
        /// 清空所有信息
        /// </summary>
        private void ClearInfo()
        {
            foreach (Control ctl in Controls)
            {
                if (ctl is TextBox || ctl is ComboBox)
                {
                    ctl.Text = "";
                }
            }
            rdoMan.Checked = true;
            //设置图片为资源中的图片
            pictureBox1.Image = Properties.Resources.normal;
        }
        /// <summary>
        /// 更新歌手信息
        /// </summary>
        /// <param name="singer_name"></param>
        /// <param name="singertype_id"></param>
        /// <param name="singer_sex"></param>
        /// <param name="singer_photo_url"></param>
        private void UpdateSingerInfo(string singer_name, int singertype_id, string singer_sex, string singer_photo_url, string singer_description)
        {
           
            try
            {
                File.Copy(txtPhotoPath.Text, KTVUtil.singerPhotoPath + singer_photo_url);
                UpdateSingerInfoData(singer_name, singertype_id, singer_sex, singer_photo_url, singer_description);
            }
            catch (Exception ex)
            {
                //处理修改头像
                if (ex.Message.IndexOf("存在")>0)
                {
                    UpdateSingerInfoData(singer_name, singertype_id, singer_sex, singer_photo_url, singer_description);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        /// <summary>
        /// 在数据库中更新数据
        /// </summary>
        /// <param name="singer_name"></param>
        /// <param name="singertype_id"></param>
        /// <param name="singer_sex"></param>
        /// <param name="singer_photo_url"></param>
        /// <param name="singer_description"></param>
        private void UpdateSingerInfoData(string singer_name, int singertype_id, string singer_sex, string singer_photo_url, string singer_description)
        {
            string sql = string.Format(@"update singer_info set singer_name='{0}',
singertype_id={1},singer_sex='{2}',singer_photo_url='{3}',singer_description='{4}'
where singer_id = {5}", singer_name, singertype_id,
singer_sex, singer_photo_url, singer_description, singer_id);
            DBHelper.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DBHelper.conn);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {

                    MessageBox.Show("修改成功！");
                    frmSingerList.BindAllInfo();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception exl)
            {
                MessageBox.Show(exl.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInfo();
        }
    }
}
