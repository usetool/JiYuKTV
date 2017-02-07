using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Server
{
    public class DBHelper
    {
        private static string connStr = "DataSource=.;Initial Catalog=MyKTV;user=sa;pwd=sa";
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public static SqlConnection conn = new SqlConnection(connStr);
    }
}
