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

namespace HumanResSystem.Web.admin.jgxx
{
    public partial class jgxxgl_look : System.Web.UI.Page
    {
        Model.gxjg0101 M_gxjg0101 =null;
        BLL.gxjg0101 B_gxjg0101 = new BLL.gxjg0101();
        Model.jgyhkxx M_jgyhkxx = null;
        BLL.jgyhkxx B_jgyhkxx = new BLL.jgyhkxx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    string uid = Request.QueryString["uid"].ToString();
                    ViewState["uid"] = uid;
                    M_gxjg0101 = B_gxjg0101.GetModel(uid);
                    M_jgyhkxx = B_jgyhkxx.GetModel(uid);
                    if (M_jgyhkxx == null)
                    {
                        M_jgyhkxx = new Model.jgyhkxx();
                    }
                    DropDownList_dw_databind(M_gxjg0101.DWH);
                    DropDownList_xb_databind(M_gxjg0101.XBM);
                    DropDownList_mz_databind(M_gxjg0101.MZM);
                    DropDownList_dw_databind(M_gxjg0101.DWH);
                    DropDownList_gj_databind(M_gxjg0101.GJDQM);
                    DropDownList_sfzlx_databind(M_gxjg0101.SFZJLXM);
                    DropDownList_zzmm_databind(M_gxjg0101.ZZMMM);
                    DropDownList_jkzk_databind(M_gxjg0101.JKZKM);
                    DropDownList_ryxz_databind(M_gxjg0101.XJRYXZ);
                    DropDownList_dqzt_databind(M_gxjg0101.DQZTM);
                    DropDownList_yh_databind(M_jgyhkxx.YHM);
                    dp_setvalue(DropDownList_ly, M_gxjg0101.XJRYLY);
                    TextBox_gh.Text = M_gxjg0101.GH;
                    TextBox_xm.Text = M_gxjg0101.XM;
                    TextBox_py.Text = M_gxjg0101.XMPY;
                    TextBox_sfzjh.Text = M_gxjg0101.SFZJH;
                    DatePicker_jxsj.Text = M_gxjg0101.LXRQ;
                    TextBox_lxdh.Text = M_gxjg0101.XJLXDH;
                    TextBox_yb.Text = M_gxjg0101.XJLXYB;
                    TextBox_lxdz.Text = M_gxjg0101.XJLXDZ;
                    TextBox_yhkh.Text = M_jgyhkxx.YHKH;
                    TextBox_khxm.Text = M_jgyhkxx.KHXM;
                    TextArea_bz.Text = M_gxjg0101.XJBZ;
                    DatePicker_csrq.Text = M_gxjg0101.CSRQ.ToString();

                }
                //else
                //{

                //    string uid = "e3bf51c1-5e1a-47e0-a91f-60cf04ff589c";
                //    ViewState["uid"] = uid;
                //    M_gxjg0101 = B_gxjg0101.GetModel(uid);
                //    M_jgyhkxx = B_jgyhkxx.GetModel(uid);
                //    DropDownList_dw_databind(M_gxjg0101.DWH);
                //    DropDownList_xb_databind(M_gxjg0101.XBM);
                //    DropDownList_mz_databind(M_gxjg0101.MZM);
                //    DropDownList_dw_databind(M_gxjg0101.DWH);
                //    DropDownList_gj_databind(M_gxjg0101.GJDQM);
                //    DropDownList_sfzlx_databind(M_gxjg0101.SFZJLXM);
                //    DropDownList_zzmm_databind(M_gxjg0101.ZZMMM);
                //    DropDownList_jkzk_databind(M_gxjg0101.JKZKM);
                //    DropDownList_ryxz_databind(M_gxjg0101.XJRYXZ);
                //    DropDownList_dqzt_databind(M_gxjg0101.DQZTM);
                //    DropDownList_yh_databind(M_jgyhkxx.YHM);
                //    dp_setvalue(DropDownList_ly, M_gxjg0101.XJRYLY);
                //    TextBox_gh.Text = M_gxjg0101.GH;
                //    TextBox_xm.Text = M_gxjg0101.XM;
                //    TextBox_py.Text = M_gxjg0101.XMPY;
                //    TextBox_sfzjh.Text = M_gxjg0101.SFZJH;
                //    DatePicker_jxsj.Text = M_gxjg0101.LXRQ;
                //    TextBox_lxdh.Text = M_gxjg0101.XJLXDH;
                //    TextBox_yb.Text = M_gxjg0101.XJLXYB;
                //    TextBox_lxdz.Text = M_gxjg0101.XJLXDZ;
                //    TextBox_yhkh.Text = M_jgyhkxx.YHKH;
                //    TextBox_khxm.Text = M_jgyhkxx.KHXM;
                //    TextArea_bz.Text = M_gxjg0101.XJBZ;
                //}
            }
        }

        protected void DropDownList_dw_databind(string text)
        {
            DropDownList_dw.Items.Clear();
            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select text,code from [xbm] order by text").Tables[0];
            DataTable dt = DbHelperSQL.Query("select [DWH],[DWMC] from [jctb0103] order by DWMC").Tables[0];
            DropDownList_dw.DataSource = dt;
            DropDownList_dw.DataTextField = "DWMC";
            DropDownList_dw.DataValueField = "DWH";
            DropDownList_dw.DataBind();


        

            dp_setvalue(DropDownList_dw, text);
        }

        protected void DropDownList_xb_databind(string text)
        {
            DropDownList_xb.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select text,code from [xbm] order by text").Tables[0];
            DropDownList_xb.DataSource = dt;
            DropDownList_xb.DataTextField = "text";
            DropDownList_xb.DataValueField = "code";
            DropDownList_xb.DataBind();


          

            dp_setvalue(DropDownList_xb,  text);
        }

        protected void DropDownList_mz_databind(string text)
        {
            DropDownList_mz.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [mzm] order by text").Tables[0];
            DropDownList_mz.DataSource = dt;
            DropDownList_mz.DataTextField = "text";
            DropDownList_mz.DataValueField = "code";
            DropDownList_mz.DataBind();


            //DropDownList_xb.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_mz,  text);
        }

        protected void DropDownList_gj_databind(string text)
        {
            DropDownList_gj.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [gjhdqm] order by text").Tables[0];
            DropDownList_gj.DataSource = dt;
            DropDownList_gj.DataTextField = "text";
            DropDownList_gj.DataValueField = "code";
            DropDownList_gj.DataBind();




            dp_setvalue(DropDownList_gj, text);
        }


        protected void DropDownList_sfzlx_databind(string text)
        {
            DropDownList_sfzlx.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [sfzjlxm] order by text").Tables[0];
            DropDownList_sfzlx.DataSource = dt;
            DropDownList_sfzlx.DataTextField = "text";
            DropDownList_sfzlx.DataValueField = "code";
            DropDownList_sfzlx.DataBind();




            dp_setvalue(DropDownList_sfzlx,  text);
        }

        //protected void DropDownList_hyzk_databind()
        //{
        //    DropDownList_hyzk.Items.Clear();
        //    DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [hyzkm] order by text").Tables[0];
        //    DropDownList_hyzk.DataSource = dt;
        //    DropDownList_hyzk.DataTextField = "text";
        //    DropDownList_hyzk.DataValueField = "code";
        //    DropDownList_hyzk.DataBind();
        //    DropDownList_hyzk.Items.Add("请选择", "请选择");



        //    dp_setvalue(DropDownList_hyzk, "请选择");
        //}

        //protected void DropDownList_gatqw_databind()
        //{
        //    DropDownList_gatqw.Items.Clear();
        //    DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [gatqwm] order by text").Tables[0];
        //    DropDownList_gatqw.DataSource = dt;
        //    DropDownList_gatqw.DataTextField = "text";
        //    DropDownList_gatqw.DataValueField = "code";
        //    DropDownList_gatqw.DataBind();




        //    dp_setvalue(DropDownList_gatqw, "99  其他");
        //}

        protected void DropDownList_zzmm_databind(string text)
        {
            DropDownList_zzmm.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [zzmmm] order by text").Tables[0];
            DropDownList_zzmm.DataSource = dt;
            DropDownList_zzmm.DataTextField = "text";
            DropDownList_zzmm.DataValueField = "code";
            DropDownList_zzmm.DataBind();
          



            dp_setvalue(DropDownList_zzmm,text);
        }

        protected void DropDownList_jkzk_databind(string text)
        {
            DropDownList_jkzk.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [jkzkm] order by text").Tables[0];
            DropDownList_jkzk.DataSource = dt;
            DropDownList_jkzk.DataTextField = "text";
            DropDownList_jkzk.DataValueField = "code";
            DropDownList_jkzk.DataBind();




            dp_setvalue(DropDownList_jkzk, text);
        }

        protected void DropDownList_ryxz_databind(string text)
        {
            DropDownList_ryxz.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [xjryxzm] where text not like '%校外%'").Tables[0];
            DropDownList_ryxz.DataSource = dt;
            DropDownList_ryxz.DataTextField = "text";
            DropDownList_ryxz.DataValueField = "code";
            DropDownList_ryxz.DataBind();
          



            dp_setvalue(DropDownList_ryxz, text);
        }

        protected void DropDownList_dqzt_databind(string text)
        {
            DropDownList_dqzt.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [jzgdqztm] order by text").Tables[0];
            DropDownList_dqzt.DataSource = dt;
            DropDownList_dqzt.DataTextField = "text";
            DropDownList_dqzt.DataValueField = "code";
            DropDownList_dqzt.DataBind();




            dp_setvalue(DropDownList_dqzt, text);
        }

        protected void DropDownList_yh_databind(string text)
        {
            DropDownList_yh.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [yhlxm] order by code").Tables[0];
            DropDownList_yh.DataSource = dt;
            DropDownList_yh.DataTextField = "text";
            DropDownList_yh.DataValueField = "code";
            DropDownList_yh.DataBind();
            //DropDownList_yh.Items.Add("请选择", "请选择");
            //dp_setvalue(DropDownList_yh, "请选择");



            dp_setvalue(DropDownList_yh, text);
        }
        protected void dp_setvalue(FineUI.DropDownList ddl, string value)
        {
            int flag = 0;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Trim() == value)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.
                    flag = 1;
                    break;        //选中一条后,跳出循环.
                }
            }
            if (flag == 0)

                ddl.SelectedItem.Text = "";
        }


        protected void dp_setvalue_text(FineUI.DropDownList ddl, string text)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uid = ViewState["uid"].ToString();
            M_gxjg0101 = B_gxjg0101.GetModel(uid);
            M_jgyhkxx = B_jgyhkxx.GetModel(uid);

           
            if (DropDownList_dw.SelectedValue == "请选择")
            {
                Alert.Show("请选择所属部门");
                return;
            }
            if (DropDownList_xb.SelectedValue == "请选择")
            {
                Alert.Show("请选择性别");
                return;
            }
            if (DropDownList_zzmm.SelectedValue == "请选择")
            {
                Alert.Show("请选择政治面貌");
                return;
            }

            if (DropDownList_yh.SelectedValue == "请选择")
            {
                Alert.Show("请选择开户行");
                return;
            }

            string useruid = "123";
            DateTime optime = System.DateTime.Now;
          
            int res = 0;
            string jxsj_n = DatePicker_jxsj.Text.Trim().Substring(0, 4);
            string jxsj_m = DatePicker_jxsj.Text.Trim().Substring(5, 2);
           
          
          
          
          
            M_gxjg0101.XM = TextBox_xm.Text.Trim();
            M_gxjg0101.XMPY = TextBox_py.Text.Trim();
            M_gxjg0101.XJRYLY = DropDownList_ly.SelectedValue.Trim();
            M_gxjg0101.DWH = DropDownList_dw.SelectedValue;
            M_gxjg0101.XBM = DropDownList_xb.SelectedValue;
            M_gxjg0101.MZM = DropDownList_mz.SelectedValue;
            M_gxjg0101.GJDQM = DropDownList_gj.SelectedValue;
            M_gxjg0101.SFZJLXM = DropDownList_sfzlx.SelectedValue;
            M_gxjg0101.SFZJH = TextBox_sfzjh.Text.Trim();
            M_gxjg0101.ZZMMM = DropDownList_zzmm.SelectedValue;
            M_gxjg0101.JKZKM = DropDownList_jkzk.SelectedValue;
            M_gxjg0101.LXRQ = DatePicker_jxsj.Text.Trim();
            M_gxjg0101.DQZTM = DropDownList_dqzt.SelectedValue;
            M_gxjg0101.XJLXDH = TextBox_lxdh.Text.Trim();
            M_gxjg0101.XJLXYB = TextBox_yb.Text.Trim();
            M_gxjg0101.XJLXDZ = TextBox_lxdz.Text.Trim();
           
            M_jgyhkxx.GH = M_gxjg0101.GH;
            M_jgyhkxx.YHM = DropDownList_yh.SelectedValue.Trim();
            M_jgyhkxx.YHKH = TextBox_yhkh.Text.Trim();
            M_jgyhkxx.KHXM = TextBox_khxm.Text.Trim();
            M_gxjg0101.XJBZ = TextArea_bz.Text.Trim();

            M_gxjg0101.XJXGSJ = optime;
            M_gxjg0101.XJXGRY = useruid;
            if (B_gxjg0101.Update(M_gxjg0101))
            {
                if (B_jgyhkxx.Update(M_jgyhkxx))
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
                else
                    Alert.Show("保存失败");

            }
            else
            {
                Alert.Show("保存失败");
            }
        }

    }
}