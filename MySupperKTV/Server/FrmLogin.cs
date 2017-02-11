using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                if (Login())
                {
                    this.timer1.Enabled = true;//启用时钟
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            }

        }
        /// <summary>
        /// 登录数据操作方法
        /// </summary>
        /// <returns></returns>
        private bool Login()
        {

            //StringBuilder sql = new StringBuilder();
            //sql.AppendLine("select count(*) from admin_info ");
            //sql.AppendFormat("where admin_name='{0}'", txtAccount.Text);
            //sql.AppendFormat(" and admin_pwd='{0}'", txtPwd.Text);
            //防止SQL注入
            string sql = @"select count(*) from admin_info where 
                admin_name=@name and admin_pwd=@pwd";
            DBHelper.conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(),DBHelper.conn);
                //防止SQL注入
                cmd.Parameters.AddWithValue("@name", txtAccount.Text);
                cmd.Parameters.AddWithValue("@pwd", txtPwd.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    return true;
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
            return false;
        }
        /// <summary>
        /// 检查空
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                    {
                        item.Focus();
                        MessageBox.Show("文本框不能为空！");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// timer1时钟周期操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Height -= 30;//减小高度
            this.Width -= 30;//减小宽度
            this.Opacity -= 0.1;//透明度
            this.Left += 15;
            this.Top += 15;
            if (this.Opacity <= 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //keyChar代表的意思 http://www.cnblogs.com/linji/archive/2012/10/24/2737407.html
            if (e.KeyChar == 13)
            {
                button2_Click(sender, e);
            }
        }
    }
}
