using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using Maticsoft.DBUtility;
namespace HumanResSystem.Web.admin
{
    public partial class check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ReadOrWriteExcel rw = new ReadOrWriteExcel(Server.MapPath(@"..\admin\upload\") + "\\数据.xlsx");
            //ReadOrWriteExcel rw1 = new ReadOrWriteExcel(Server.MapPath(@"..\admin\upload\") + "\\数据1.xls");
            //DataTable dt_excel = rw.BeginRead("A2", "BF659", "Sheet1");
            //DataTable dt_sqlserver = rw1.BeginRead("A2", "BF659", "gxjg0101");
            DataTable dt_sqlserver = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select * from gxjg0101 ORDER BY GH").Tables[0];
            DataTable dt_mysql = DbHelperMySQL.Query("select * from gxjg0101 where XJRYXZ!=95 and XJRYXZ!=96 ORDER BY GH").Tables[0];
            for (int i = 0; i < dt_mysql.Rows.Count; i++)
            {
                for (int j = 0; j < dt_mysql.Columns.Count; j++)
                {
                    if (dt_mysql.Columns[j].ColumnName.Trim() == "XJCJSJ")
                    {

                        if (dt_mysql.Rows[i][j].ToString().Trim() != dt_sqlserver.Rows[i][j].ToString().Trim())
                        {
                            assist.WebMessageBox(this, dt_mysql.Rows[i]["XM"].ToString().Trim() + "||" + dt_mysql.Columns[j].ColumnName);
                            return;
                        }
                    }
                }
            }
            assist.WebMessageBox(this, "数据一致" + dt_mysql.Rows.Count);
        }
    }
}