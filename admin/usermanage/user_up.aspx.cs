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
using System.Text.RegularExpressions;

namespace XMGL.Web.admin
{
    public partial class user_up : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                //if(pb.GetIdentityRoleId()!="1")
                //    DropDownList_xb.Enabled=false;
                //if (pb.GetIdentityRoleId() == "1")
                //    TextBox_name.Enabled = true;
                //databind();
                int Id = 0;
                if (Request.QueryString["Id"] != null)
                {
                    //if (pb.GetIdentityRoleId() == "2" || pb.GetIdentityRoleId() == "5")
                    //    Response.Redirect("user_up_yx.aspx?Id=" + Request.QueryString["Id"].ToString().Trim());
                    Id = Convert.ToInt32(Request.QueryString["Id"].ToString().Trim());
                    string sqlstr = "select * from Users where Id=" + Id;
                    SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);

                    if (sdr.Read())
                    {
                        //TextBox_jgh.Text = sdr["UserId"].ToString().Trim();
                        TextBox_name.Text = sdr["ActualName"].ToString().Trim();
                        TextBox_lgname.Text = sdr["Name"].ToString().Trim();
                        //TextBox_tel.Text = sdr["tel"].ToString().Trim();
                        //TextBox_mobile.Text = sdr["mobile"].ToString().Trim();
                        TextBox_pwd.Text = sdr["Password"].ToString().Trim();
                        TextBox_rpwd.Text = sdr["Password"].ToString().Trim();
                        //if (sdr["zrbm"].ToString().Trim()!="")
                        //dp_setvalue(DropDownList_xb, sdr["zrbm"].ToString().Trim());
                        //else
                        //    dp_setvalue(DropDownList_xb, "请选择");

                        HiddenField_id.Text = Id.ToString().Trim();
                    }
                    sdr.Dispose();


                }


            }
        }
        //protected void databind()
        //{
        //    DropDownList_xb.Items.Clear();

        //    //DataTable dt = DataExecute.ExecuteDataset(DataExecute.CONN_DataSTRING, CommandType.Text, "select  xb_dm,xb_mc  FROM xb  order by xb_mc asc").Tables[0];
        //    DataTable dt = DbHelperSQL.Query("select  *  FROM ZRBM     order by ZRBM asc").Tables[0];
        //    DropDownList_xb.DataSource = dt;
        //    DropDownList_xb.DataTextField = "ZRBM";
        //    DropDownList_xb.DataValueField = "ID";
        //    DropDownList_xb.DataBind();
        //    DropDownList_xb.Items.Add("请选择", "请选择");
           



        //    //Grid1.DataSource = dt;
        //    //Grid1.DataBind();
        //}

        protected void dp_setvalue(FineUI.DropDownList ddl, string text)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.Trim() == text)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.

                    break;        //选中一条后,跳出循环.
                }
            }

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string UserId = "", Name = "", Password = "", rPassword = "", Ssxb_mc = "", Ssxb_dm = "", user_uid = "", tel = "", ActualName = "", mobile = "";
            user_uid = Guid.NewGuid().ToString();
            //UserId = TextBox_jgh.Text.Trim();
            Name = TextBox_lgname.Text.Trim();
            ActualName = TextBox_name.Text.Trim();
            Password = TextBox_pwd.Text.Trim();
            rPassword = TextBox_rpwd.Text.Trim();
            //Ssxb_mc = DropDownList_xb.SelectedText.Trim();
            //Ssxb_dm = DropDownList_xb.SelectedValue.Trim();
            //tel = TextBox_tel.Text.Trim();
            //mobile = TextBox_mobile.Text.Trim();
            //if (UserId == "")
            //{
            //    Alert.Show("教工号为必填项！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}
            //if (mobile == "")
            //{
            //    Alert.Show("手机号码为必填项！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}
            //else
            //{
            //    if (IsMobile(mobile) == false)
            //    {
            //        Alert.Show("手机号码不合法！", "提示", Alert.DefaultMessageBoxIcon);
            //        return;
            //    }
            //}
            if (Password == "")
            {
                Alert.Show("密码为必填项！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }

            if (Password != rPassword)
            {
                Alert.Show("两次输入密码不一致！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }

            if (Name == "")
            {
                Alert.Show("登录名为必填项！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }

            //if (ActualName == "")
            //{
            //    Alert.Show("姓名为必填项！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}
            //if (Ssxb_mc == "请选择" || Ssxb_mc == "")
            //{
            //    Alert.Show("责任部门为必填项！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}


            //string sqlstr = "delete  Users where Id="+Convert.ToInt32(HiddenField_id.Text.Trim());
            //DataExecute.ExecuteNonQuery(DataExecute.CONN_DataSTRING, CommandType.Text, sqlstr);
            //string sqlstr = "select * from Users where UserId='" + UserId + "' and Id!=" + Convert.ToInt32(HiddenField_id.Text.Trim());
            //SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            //if (sdr.Read())
            //{
            //    sdr.Dispose();
            //    Alert.Show("教工号已存在！", "提示", Alert.DefaultMessageBoxIcon);
            //    return;
            //}
            //sdr.Dispose();

            string sqlstr = "select * from Users where Name='" + Name + "' and Id!=" + Convert.ToInt32(HiddenField_id.Text.Trim());
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
            if (sdr.Read())
            {
                sdr.Dispose();
                Alert.Show("登录名已存在！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
            sdr.Dispose();

            //sqlstr = "insert into Users(user_uid,UserId,Name,Password,Ssxb_dm,Ssxb_mc,tel) values('" + user_uid + "','" + UserId + "','" + Name + "','" + Password + "','" + Ssxb_dm + "','" + Ssxb_mc + "','" + tel + "')";

            sqlstr = "update Users set Name='" + Name + "',Password='" + Password + "',zrbm='" + Ssxb_mc + "',ActualName='"+ActualName+"'  where Id=" + Convert.ToInt32(HiddenField_id.Text.Trim());
            int state = DbHelperSQL.ExecuteSql(sqlstr);
            if (state != 0)
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("修改失败！", "提示", Alert.DefaultMessageBoxIcon);
                return;
            }
        }

        public bool IsMobile(string val)
        {
            return Regex.IsMatch(val, @"^1[358]\d{9}$", RegexOptions.IgnoreCase);
        }
    }
}