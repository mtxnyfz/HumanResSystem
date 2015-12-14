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
    public partial class Role_module : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid1_databind();
                Grid1.SelectedRowIndex = 0;

                //object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
                //string roleid = values[0].ToString().Trim();
                //string sqlstr = "SELECT *  FROM  RoleModule where RoleId!='" + roleid + "'";
                //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, sqlstr).Tables[0];
                //ViewState["dt"] = dt;

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
            object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
            string roleid = values[0].ToString().Trim();
            string sqlstr1 = "SELECT *  FROM  RoleModule where RoleId='" + roleid + "'";
            DataTable dt1 = DbHelperSQL.Query(sqlstr1).Tables[0];
            ViewState["dt"] = dt1;

            //string jgh = pb.GetIdentityId();

            string sqlstr = "SELECT *  FROM  Menu where Title!='用户菜单'";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            // for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i]["Title"].ToString().Trim() == "用户菜单")
            //        dt.Rows[i].Delete();
            //}
            Grid2.DataSource = dt;
            Grid2.DataBind();
        }

        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {

            Grid2_databind();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
            string roleid = values[0].ToString().Trim();

            string sqlstr = "delete RoleModule where RoleId='" + roleid + "'";
            DbHelperSQL.ExecuteSql(sqlstr);

            foreach (GridRow row in Grid2.Rows)
            {
                int rowIndex = row.RowIndex;
                int isread = 0;
                string others = "";
                object[] dataKeys = Grid2.DataKeys[rowIndex];
                // 当前行对应的模块名称
                //int moduleId = Convert.ToInt32(dataKeys[0]);
                string moduleName = dataKeys[0].ToString();
                AspNet.CheckBox ck_read = (AspNet.CheckBox)row.FindControl("CheckBox1");
                if (ck_read.Checked == true)
                {
                    isread = 1;
                }
                AspNet.CheckBoxList ddlOthers = (AspNet.CheckBoxList)row.FindControl("ddlOthers");
                JObject otherPowerObj = new JObject();
                foreach (AspNet.ListItem item in ddlOthers.Items)
                {
                    if (item.Selected)
                    {
                        otherPowerObj.Add(item.Value, true);
                    }
                    else
                    {
                        otherPowerObj.Add(item.Value, false);
                    }


                }
                //if (isread == 0)
                //{
                //    otherPowerObj.Property("New").Value = false;
                //    otherPowerObj.Property("Edit").Value = false;
                //    otherPowerObj.Property("Del").Value = false;
                //}


                if (otherPowerObj.Property("New").Value.ToString() == "True" || otherPowerObj.Property("Edit").Value.ToString() == "True" || otherPowerObj.Property("Del").Value.ToString() == "True")
                {
                    isread = 1;
                }
                sqlstr = "insert into RoleModule(RoleId,ModuleName,IsCanRead,Others) values('" + roleid + "','" + moduleName + "'," + isread + ",'" + otherPowerObj.ToString() + "')";
                int state = DbHelperSQL.ExecuteSql(sqlstr);

            }

            Grid2_databind();
            Alert.Show("更新成功！", "提示", Alert.DefaultMessageBoxIcon);
        }
        protected void Grid2_RowDataBound(object sender, GridRowEventArgs e)
        {
            object[] values = Grid1.DataKeys[Grid1.SelectedRowIndex];
            string roleid = values[0].ToString().Trim();

            object[] values1 = Grid2.DataKeys[e.RowIndex];
            string ModuleName = values1[0].ToString().Trim();

            AspNet.CheckBox ck_read = (AspNet.CheckBox)Grid2.Rows[e.RowIndex].FindControl("CheckBox1");
            AspNet.CheckBoxList ddlOthers = (AspNet.CheckBoxList)Grid2.Rows[e.RowIndex].FindControl("ddlOthers");
            DataTable dt = ViewState["dt"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (roleid == dt.Rows[i]["RoleId"].ToString().Trim() && ModuleName == dt.Rows[i]["ModuleName"].ToString().Trim())
                {
                    if (dt.Rows[i]["IsCanRead"].ToString().Trim() == "0")
                        ck_read.Checked = false;
                    else
                        ck_read.Checked = true;
                    //JObject otherPowerObj = new JObject(dt.Rows[i]["Others"]);
                    JObject otherPowerObj = JObject.Parse(dt.Rows[i]["Others"].ToString().Trim());
                    JProperty jp1 = otherPowerObj.Property("New");
                    if (jp1 != null)
                    {
                        if (jp1.Value.ToString() == "True")
                            ddlOthers.Items[0].Selected = true;
                        else
                            ddlOthers.Items[0].Selected = false;
                    }

                    jp1 = otherPowerObj.Property("Edit");
                    if (jp1 != null)
                    {
                        if (jp1.Value.ToString() == "True")
                            ddlOthers.Items[1].Selected = true;
                        else
                            ddlOthers.Items[1].Selected = false;
                    }


                    jp1 = otherPowerObj.Property("Del");
                    if (jp1 != null)
                    {
                        if (jp1.Value.ToString() == "True")
                            ddlOthers.Items[2].Selected = true;
                        else
                            ddlOthers.Items[2].Selected = false;
                    }

                    break;
                }
            }

        }
        protected void Grid2_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {

        }
        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            Grid2_databind();
        }
    }
}