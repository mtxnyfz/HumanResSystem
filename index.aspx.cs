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

namespace XMGL.Web
{
    public partial class index : System.Web.UI.Page
    {

        PageBase1 pb = new PageBase1();
        protected void Page_Init(object sender, EventArgs e)
        {



            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(mainTabStrip);
            //ids.Add("userName", User.Identity.Name);
            //ids.Add("userIP", Request.UserHostAddress);
            //ids.Add("onlineUserCount", GetOnlineCount());


            //Accordion accordionMenu = InitAccordionMenu(menus);
            //ids.Add("treeMenu", ad_Main.ClientID);
            //ids.Add("menuType", "accordion");



            if (!Page.IsPostBack)
            {

                string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                PageContext.RegisterStartupScript(idsScriptStr);

                Label_user.Text = pb.GetIdentityName() + "，欢迎您登录本平台，今天是：" + DateTime.Now.ToString("yyyy年M月dd日");
                //Label_user.Text = "欢迎您登录本平台，今天是：" + DateTime.Now.ToString("yyyy年M月dd日");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            if (!Page.IsPostBack)
            {
                databind();
            }

        }


        protected void databind()
        {
            //DropDownList_role.Items.Clear();
           

            string jgh = pb.GetIdentityId();

            string sqlstr = "SELECT   Role.RoleId, Role.Name, RoleUser.UserId, RoleUser.Hd_ids FROM    Role INNER JOIN RoleUser ON Role.RoleId = RoleUser.RoleId WHERE   (RoleUser.UserId = '" + jgh + "')";
            DataTable dt = DbHelperSQL.Query(sqlstr).Tables[0];
            //Session["page_Addxmqk_dt"] = dt;
            DropDownList_role.DataSource = dt;
            DropDownList_role.DataTextField = "Name";
            DropDownList_role.DataValueField = "RoleId";
            DropDownList_role.DataBind();
            //DropDownList_role.Items.Add("请选择", "请选择");
            dp_setvalue(DropDownList_role, pb.GetIdentityRoleId());
            //DataTable dt_ModuleName = pb.GetIdentityRoleInfo(jgh, pb.GetIdentityRoleId());
            string DefaultPage_roleid = "";
            DataTable dt_ModuleName = null, dt_ModuleName_temp = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (dt.Rows[i]["RoleId"].ToString().Trim() == "2")
                //    DefaultPage_roleid = "2";
                //else if (dt.Rows[i]["RoleId"].ToString().Trim() == "3")
                //    DefaultPage_roleid = "3";
                //else if (dt.Rows[i]["RoleId"].ToString().Trim() == "5")
                //    DefaultPage_roleid = "5";

                dt_ModuleName_temp = pb.GetIdentityRoleInfo(jgh, dt.Rows[i]["RoleId"].ToString().Trim());
                if (i == 0)
                    dt_ModuleName = dt_ModuleName_temp.Clone();
                foreach (DataRow dr in dt_ModuleName_temp.Rows)
                    dt_ModuleName.Rows.Add(dr.ItemArray);

            }

            //DataView dv = dt_ModuleName.DefaultView;
            //dv.Sort = "ModuleName Asc";
            //dt_ModuleName = dv.ToTable();

            sqlstr = "select distinct ModuleName,SortIndex from Menu order by SortIndex asc";
            DataTable all_dt_ModuleName = DbHelperSQL.Query(sqlstr).Tables[0];
            DataTable dt_ModuleName_new = dt_ModuleName.Clone();
            DataRow[] drs = null;
            for (int i = 0; i < all_dt_ModuleName.Rows.Count; i++)
            {

                drs = dt_ModuleName.Select("ModuleName='" + all_dt_ModuleName.Rows[i]["ModuleName"].ToString().Trim() + "'");
                if (drs.Length >= 1)
                    dt_ModuleName_new.ImportRow(drs[0]);

            }
            int index=0;
            for (int i = 0; i < dt_ModuleName_new.Rows.Count; i++)
            {
                if(dt_ModuleName_new.Rows[i]["ModuleName"].ToString().Trim().Contains("("))
                {
                    index=dt_ModuleName_new.Rows[i]["ModuleName"].ToString().Trim().IndexOf("(");
                    dt_ModuleName_new.Rows[i]["ModuleName"] = dt_ModuleName_new.Rows[i]["ModuleName"].ToString().Trim().Substring(0, index);
                }
            }

                BindTree(dt_ModuleName_new, null, "1");
                ShowDefaultPage(DefaultPage_roleid);
           

        }


        private void ShowDefaultPage(string roleid)
        {
            //if (roleid == "3")
            //{
            //    Tab tb = new Tab();
            //    tb.Layout = FineUI.Layout.Fit;
            //    tb.EnableClose = true;
            //    tb.IFrameUrl = "~/admin/jfys_sh.aspx";
            //    tb.EnableIFrame = true;
            //    tb.Title = "经费预算审核";
            //    mainTabStrip.Tabs.Add(tb);
            //}
           
            //else if (roleid == "2")
            //{
            //    Tab tb = new Tab();
            //    tb.Layout = FineUI.Layout.Fit;
            //    tb.EnableClose = true;
            //    tb.IFrameUrl = "~/admin/jfys_manage.aspx";
            //    tb.EnableIFrame = true;
            //    tb.Title = "经费预算管理";
            //    mainTabStrip.Tabs.Add(tb);
            //}
        }

        private void InitMenu(DataTable dt)
        {
            FineUI.TreeNode node = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                node = new FineUI.TreeNode();
                node.Text = dt.Rows[i]["ModuleName"].ToString();
                node.NavigateUrl = dt.Rows[i]["NavigateUrl"].ToString();
                leftMenuTree.Nodes.Add(node);
            }

            string userid = pb.GetIdentityId();
            if (userid == "1b5b12ae-cd19-4408-9b6e-839d58a6ce29" || userid == "f3ff2b70-3ca0-4625-847c-6d6ceafe5ea0")
            {
                node = new FineUI.TreeNode();
                node.Text = "统计表";
                node.NavigateUrl = "~/admin/Tjfx.aspx";
                leftMenuTree.Nodes.Add(node);
            }



        }

        private void BindTree(DataTable dtSource, FineUI.TreeNode parentNode, string parentID)
        {
            DataRow[] rows = dtSource.Select(string.Format("ParentMenuId={0}", parentID));
            foreach (DataRow row in rows)
            {
                FineUI.TreeNode node = new FineUI.TreeNode();
                node.Text = row["ModuleName"].ToString();
                node.NavigateUrl = row["NavigateUrl"].ToString();
                BindTree(dtSource, node, row["MenuId"].ToString());
                if (parentNode == null)
                {
                    leftMenuTree.Nodes.Add(node);
                }
                else
                {
                    parentNode.Nodes.Add(node);

                }
            }
        }


        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }
        protected void DropDownList_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            leftMenuTree.Nodes.Clear();


            string roleid = DropDownList_role.SelectedValue.Trim();

            string sqlstr = "SELECT   Users.tel, Users.Ssxb_dm, Users.Ssxb_mc  FROM      Users  where Users.user_uid='" + pb.GetIdentityId() + "'";
            string tel = "", Ssxb_dm = "", Ssxb_mc = "";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);


            if (sdr.Read())
            {
                tel = sdr["tel"].ToString().Trim();
                Ssxb_dm = sdr["Ssxb_dm"].ToString().Trim();
                Ssxb_mc = sdr["Ssxb_mc"].ToString().Trim();
                sdr.Dispose();



            }
            else
            {
                sdr.Dispose();
                Alert.Show("用户不存在！");
                return;
            }


            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                pb.GetIdentityName(),
                DateTime.Now,
                DateTime.Now.AddMinutes(120),
                true,
                pb.GetIdentityId() + "," + roleid + "," + tel + "," + Ssxb_dm + "," + Ssxb_mc,
                FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            userCookie.HttpOnly = true;
            userCookie.Expires = DateTime.Now.AddMinutes(120);
            Response.Cookies.Add(userCookie);


            string userid = pb.GetIdentityId();
            DataTable dt_ModuleName = pb.GetIdentityRoleInfo(userid, roleid);
            BindTree(dt_ModuleName, null, "1");

            PageContext.RegisterStartupScript("var mainTabStrip1 = Ext.getCmp(IDS.mainTabStrip); mainTabStrip1.items.each(function(item){if(item.id!=IDS.Tab1){mainTabStrip1.remove(item);}})");
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
           
            //string roleid = pb.GetIdentityRoleId();
            //if (roleid == "2" || roleid == "5")
            //{
            //    FormsAuthentication.SignOut();
            //    Response.Redirect("login_yx.aspx");
            //}
            //else if (roleid == "4" || roleid == "1")
            //{
            //    FormsAuthentication.SignOut();
            //    Response.Redirect("login_sjw.aspx");
            //}
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            //assist.WebMessageBoxClose(this.Page, "已成功提交,系统将自动关闭此页面");
            //PageContext.RegisterStartupScript("<script language=javascript>alert('已成功提交,系统将自动关闭此页面');CloseWebPage();</script>");
            Response.Redirect("http://192.168.252.32:8280/cas/login");
            
        }

        protected void dp_setvalue(FineUI.DropDownList ddl, string roleid)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Trim() == roleid)
                {

                    ddl.SelectedIndex = i;
                    break;        //选中一条后,跳出循环.
                }
            }

        }

       
    }
}