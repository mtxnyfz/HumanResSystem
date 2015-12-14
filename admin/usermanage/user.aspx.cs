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
using AspNet = System.Web.UI.WebControls;

namespace XMGL.Web.admin
{
    public partial class user : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        string ModuleName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ModuleName = pb.GetModuleName()["用户信息管理"].ToString();
                ViewState["dt_Power"] = pb.GetIdentityRolePower(pb.GetIdentityId(), pb.GetIdentityRoleId(), ModuleName);

                Grid1_databind();


            }
        }

        protected void Grid1_databind()
        {

            //string jgh = pb.GetIdentityId();

            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select * FROM Users  order by Name").Tables[0];


            string sqlstr = "";
            DataTable dt_Power = ViewState["dt_Power"] as DataTable;
            if (pb.GetIdentityRoleId().Trim() != "1")
                sqlstr = "select * FROM Users where user_uid='" + pb.GetIdentityId() + "'  order by Name";
            else

                sqlstr = "select * FROM Users  order by Name";

            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            //dt = pb.GetnewDataTable(dt, dt_Power, "xm_id");
            Grid1.DataSource = dt;
            Grid1.DataBind();

        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string addUrl = "~/admin/usermanage/user_add.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加用户"));
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            Grid1_databind();
        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Grid1_databind();
            Alert.Show("操作成功！", "提示", Alert.DefaultMessageBoxIcon);
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid1.DataKeys[e.RowIndex];
            string user_uid = values[0].ToString().Trim();



            if (e.CommandName == "Delete")
            {
                string sqlstr = "SELECT   Users.user_uid, Users.Name, Users.mobile, Users.Ssxb_dm, Users.Ssxb_mc, RoleUser.RoleId FROM      Users INNER JOIN RoleUser ON Users.user_uid = RoleUser.UserId where Users.user_uid='" + user_uid + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                string RoleId = "";
                if (sdr.Read())
                {
                    RoleId = sdr["RoleId"].ToString().Trim();
                }
                sdr.Dispose();
                if (RoleId == "1")
                {
                    Alert.Show("此账号是系统管理员，无法删除！", "警告", Alert.DefaultMessageBoxIcon);
                    return;
                }

               
                 sqlstr = "delete Users where user_uid='" + user_uid + "'";
                int state = DbHelperSQL.ExecuteSql(sqlstr);
                if (state != 0)
                {
                    Grid1_databind();
                    Alert.Show("删除成功！", "提示", Alert.DefaultMessageBoxIcon);
                }
                else
                {
                    Alert.Show("删除失败！", "提示", Alert.DefaultMessageBoxIcon);
                    return;
                }
            }
        }
        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            DataTable dt = ViewState["dt_Power"] as DataTable;
            if (dt.Rows.Count != 0)
            {
                JObject otherPowerObj = JObject.Parse(dt.Rows[0]["Others"].ToString().Trim());
                JProperty jp1 = otherPowerObj.Property("Del");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", true);
                    }
                    else
                    {
                        pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", false);
                    }
                }
                else
                {
                    pb.CheckPower_GridLinkButtonField(Grid1, "deleteField", false);
                }

                jp1 = otherPowerObj.Property("Edit");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPower_GridLinkWindowField(Grid1, "upuser", true);
                    }
                    else
                    {
                        pb.CheckPower_GridLinkWindowField(Grid1, "upuser", false);
                    }
                }
                else
                {
                    pb.CheckPower_GridLinkWindowField(Grid1, "upuser", false);
                }


                jp1 = otherPowerObj.Property("New");
                if (jp1 != null)
                {
                    if (jp1.Value.ToString() == "True")
                    {
                        pb.CheckPowerWithButton(btnNew, true);
                    }
                    else
                    {
                        pb.CheckPowerWithButton(btnNew, false);
                        //pb.CheckPowerWithButton(Button1, false);
                    }
                }
                else
                {
                    pb.CheckPowerWithButton(btnNew, false);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserId = "", Name = "", Password = "", xxmc = "", xxdm = "", user_uid = "", tel = "", ActualName = "";

            string sqlstr = "select XXDM,XXMC,LXRXM,LXRSJ from XXJBQKB where XXMC!='市教委'";
            DataTable dt=DbHelperSQL.Query(sqlstr).Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sqlstr = "delete from Users where xxdm='" + dt.Rows[i]["XXDM"].ToString().Trim() + "' and Name='" + dt.Rows[i]["LXRXM"].ToString().Trim() + "'";
            //    DbHelperSQL.ExecuteSql(sqlstr);
            //    user_uid = Guid.NewGuid().ToString();
            //    Password = "111111";
            //    if (Password == "")
            //    {
            //        Password = "111111";
            //    }
            //    sqlstr = "insert into Users(user_uid,UserId,Name,Password,xxdm,xxmc,tel,ActualName) values('" + user_uid + "','yxgl" + dt.Rows[i]["XXDM"].ToString().Trim() + "','yxgl" + dt.Rows[i]["XXDM"].ToString().Trim() + "','" + Password + "','" + dt.Rows[i]["XXDM"].ToString().Trim() + "','" + dt.Rows[i]["XXMC"].ToString().Trim() + "','" + tel + "','" + ActualName + "')";
            //    int state = DbHelperSQL.ExecuteSql(sqlstr);
            //}
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlstr = "select * from Users where xxdm='" + dt.Rows[i]["XXDM"].ToString().Trim() + "' and Name='yxgl" + dt.Rows[i]["XXDM"].ToString().Trim() + "'";
                SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
                if (sdr.Read())
                {
                  
                    sdr.Dispose();
                    //sdr.Close();

                }
                else
                {
                    sdr.Dispose();

                    user_uid = Guid.NewGuid().ToString();
                    Password = "111111";
                    if (Password == "")
                    {
                        Password = "111111";
                    }
                    sqlstr = "insert into Users(user_uid,UserId,Name,Password,xxdm,xxmc,tel,ActualName) values('" + user_uid + "','yxgl" + dt.Rows[i]["XXDM"].ToString().Trim() + "','yxgl" + dt.Rows[i]["XXDM"].ToString().Trim() + "','" + Password + "','" + dt.Rows[i]["XXDM"].ToString().Trim() + "','" + dt.Rows[i]["XXMC"].ToString().Trim() + "','" + tel + "','" + ActualName + "')";
                    int state = DbHelperSQL.ExecuteSql(sqlstr);
                  
                }
              
              
            }
            Grid1_databind();
            Alert.Show("操作成功！", "提示", Alert.DefaultMessageBoxIcon);

        }
    }
}