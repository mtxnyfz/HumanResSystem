using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using HumanResSystem;
using AppBox;
namespace HumanResSystem.Web.admin.bmxx
{
    public partial class bmxxgl_add : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList_bmlb_databind();
                dp_setvalue(DropDownList_bmsfyx, "是");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bmbh = TextBox_bmdm.Text.Trim();
            string bmmc = TextBox_bmmc.Text.Trim();
            
            if (DropDownList_bmlb.SelectedValue == "请选择")
            {
                Alert.Show("请选择部门类别");
                return;
            }
            if (DropDownList_bmsfyx.SelectedValue == "请选择")
            {
                Alert.Show("请选择部门是否有效");
                return;
            }
            string sqlstr = "select DWH from jctb0103 where (DWH='" + bmbh + "' or DWMC='" + bmmc + "') and  XJSFSC!='1' ";
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sqlstr);
         
            if (sdr.Read())
            {
                sdr.Dispose();
                Alert.Show("部门编号或部门名称在数据库中已存在，无法保存");
                return;
            }
            sdr.Dispose();
            string useruid = pb.GetIdentityId();
            DateTime optime = System.DateTime.Now;
            Model.jctb0103 M_jctb0103 = new Model.jctb0103();
            BLL.jctb0103 B_jctb0103 = new BLL.jctb0103();
            string uid = Guid.NewGuid().ToString();
            M_jctb0103.GUID = uid;
            M_jctb0103.DWH = bmbh;
            M_jctb0103.DWMC = bmmc;
            M_jctb0103.DWLBM = DropDownList_bmlb.SelectedValue.Trim();
            M_jctb0103.DWYXBS = DropDownList_bmsfyx.SelectedValue.Trim();
            M_jctb0103.XJSFSC =0;
            M_jctb0103.XJCJSJ = optime;
            M_jctb0103.XJCJRY = useruid;
            M_jctb0103.XJBZ = TextArea_bz.Text.Trim();

            if (B_jctb0103.Add(M_jctb0103))
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
                Alert.Show("保存失败");


        }

        protected void DropDownList_bmlb_databind()
        {
            DropDownList_bmlb.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [dwlbm] order by code").Tables[0];
            DropDownList_bmlb.DataSource = dt;
            DropDownList_bmlb.DataTextField = "text";
            DropDownList_bmlb.DataValueField = "code";
            DropDownList_bmlb.DataBind();



            DropDownList_bmlb.Items.Add("请选择", "请选择");
            dp_setvalue(DropDownList_bmlb, "请选择");
        }
        protected void dp_setvalue(FineUI.DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.Trim() == value)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.

                    break;        //选中一条后,跳出循环.
                }
            }

        }
    }
}