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
    public partial class role_user : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid1_databind();
                Grid1.SelectedRowIndex = 0;
                Grid2_databind();
            }

        }

        protected void Grid1_databind()
        {

            //string jgh = pb.GetIdentityId();

            DataTable dt = DbHelperSQL.Query("select distinct RoleId,Name FROM Role").Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void Grid2_databind()
        {

            //string jgh = pb.GetIdentityId();
            object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
            string roleid = values[0].ToString().Trim();
            string sqlstr = "select * FROM Users,RoleUser where RoleUser.RoleId='" + roleid + "' and Users.user_uid=RoleUser.UserId";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            Grid2.DataSource = dt;
            Grid2.DataBind();
        }
        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {
            Grid2_databind();
            //Alert.Show(values[0].ToString(), "提示", Alert.DefaultMessageBoxIcon);
        }
        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
            string user_uid = values[0].ToString().Trim();
            string RoleId = values[1].ToString().Trim();


            if (e.CommandName == "Delete")
            {
                string sqlstr = "delete RoleUser where UserId='" + user_uid + "' and RoleId='" + RoleId + "'";
                int state = DbHelperSQL.ExecuteSql(sqlstr);
                if (state != 0)
                {
                    Grid2_databind();
                    Alert.Show("删除成功！", "提示", Alert.DefaultMessageBoxIcon);
                }
                else
                {
                    Alert.Show("删除失败！", "提示", Alert.DefaultMessageBoxIcon);
                    return;
                }
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            List<int> ids = pb.GetSelectedDataKeyIDs(Grid1);
            string addUrl = String.Format("role_user_addnew.aspx?id={0}", ids[0]);

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加用户到当前角色"));
        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Grid2_databind();
            Alert.Show("设置成功！", "提示", Alert.DefaultMessageBoxIcon);
        }
        protected void Grid2_PreDataBound(object sender, EventArgs e)
        {
            object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
            string roleid = values[0].ToString().Trim();
            //if (roleid == "1" || roleid == "7")
            pb.CheckPower_GridLinkWindowField(Grid2, "xm_set", false);
            //else
            //    pb.CheckPower_GridLinkWindowField(Grid2, "xm_set", true);
        }
        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            Grid2_databind();
        }
    }
}