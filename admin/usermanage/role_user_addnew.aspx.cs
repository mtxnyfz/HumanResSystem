using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using AppBox;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace XMGL.Web.admin
{
    public partial class role_user_addnew : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        string roleid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    roleid = Request.QueryString["id"].ToString().Trim();
                    ViewState["roleid"] = roleid;
                    Grid1_databind();
                }

            }
        }

        protected void Grid1_databind()
        {

            //string jgh = pb.GetIdentityId();

            DataTable dt = DbHelperSQL.Query("select * FROM Users where  NOT exists (select user_uid from RoleUser where RoleId='" + ViewState["roleid"].ToString() + "' and  Users.user_uid=RoleUser.UserId)  order by ActualName").Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS, Grid1);
        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            List<string> ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS);

            string sqlstr = "";
            if (ViewState["roleid"].ToString().Trim() == "1")
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    sqlstr = "insert into RoleUser(RoleId,UserId,Hd_ids) values('" + ViewState["roleid"].ToString() + "','" + ids[i].ToString() + "','self')";
                    DbHelperSQL.ExecuteSql(sqlstr);
                }
            }
            else
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    sqlstr = "insert into RoleUser(RoleId,UserId) values('" + ViewState["roleid"].ToString() + "','" + ids[i].ToString() + "')";
                    DbHelperSQL.ExecuteSql(sqlstr);
                }
            }

            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            // 重新绑定表格数据之前，将当前表格页选中行的数据同步到隐藏字段中
            pb.SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS, Grid1);
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            Grid1.PageIndex = e.NewPageIndex;
            Grid1_databind();
        }
    }
}