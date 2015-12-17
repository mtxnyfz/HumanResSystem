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
using System.Text.RegularExpressions;
namespace HumanResSystem.Web.admin.jgxx
{
    public partial class jgxxgl_up : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
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


                    if (DropDownList_sfzlx.SelectedText.Trim() != "居民身份证")
                    {
                        DatePicker_csrq.Hidden = false;
                    }
                    else
                        DatePicker_csrq.Hidden = true;

                }
                else
                {
                    Alert.Show("非法访问");
                    return;
                    //string uid = "e3bf51c1-5e1a-47e0-a91f-60cf04ff589c";
                    //ViewState["uid"] = uid;
                    //M_gxjg0101 = B_gxjg0101.GetModel(uid);
                    //M_jgyhkxx = B_jgyhkxx.GetModel(uid);
                    //DropDownList_dw_databind(M_gxjg0101.DWH);
                    //DropDownList_xb_databind(M_gxjg0101.XBM);
                    //DropDownList_mz_databind(M_gxjg0101.MZM);
                    //DropDownList_dw_databind(M_gxjg0101.DWH);
                    //DropDownList_gj_databind(M_gxjg0101.GJDQM);
                    //DropDownList_sfzlx_databind(M_gxjg0101.SFZJLXM);
                    //DropDownList_zzmm_databind(M_gxjg0101.ZZMMM);
                    //DropDownList_jkzk_databind(M_gxjg0101.JKZKM);
                    //DropDownList_ryxz_databind(M_gxjg0101.XJRYXZ);
                    //DropDownList_dqzt_databind(M_gxjg0101.DQZTM);
                    //DropDownList_yh_databind(M_jgyhkxx.YHM);
                    //dp_setvalue(DropDownList_ly, M_gxjg0101.XJRYLY);
                    //TextBox_gh.Text = M_gxjg0101.GH;
                    //TextBox_xm.Text = M_gxjg0101.XM;
                    //TextBox_py.Text = M_gxjg0101.XMPY;
                    //TextBox_sfzjh.Text = M_gxjg0101.SFZJH;
                    //DatePicker_jxsj.Text = M_gxjg0101.LXRQ;
                    //TextBox_lxdh.Text = M_gxjg0101.XJLXDH;
                    //TextBox_yb.Text = M_gxjg0101.XJLXYB;
                    //TextBox_lxdz.Text = M_gxjg0101.XJLXDZ;
                    //TextBox_yhkh.Text = M_jgyhkxx.YHKH;
                    //TextBox_khxm.Text = M_jgyhkxx.KHXM;
                    //TextArea_bz.Text = M_gxjg0101.XJBZ;
                }
            }
        }

        protected void DropDownList_dw_databind(string text)
        {
            DropDownList_dw.Items.Clear();
            //DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select text,code from [xbm] order by text").Tables[0];
            DataTable dt = DbHelperSQL.Query("select [DWH],[DWMC] from [jctb0103] where XJSFSC!='1' and XJSFYX=1 and DWYXBS='1' order by DWMC").Tables[0];
            DropDownList_dw.DataSource = dt;
            DropDownList_dw.DataTextField = "DWMC";
            DropDownList_dw.DataValueField = "DWH";
            DropDownList_dw.DataBind();



            DropDownList_dw.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_dw, "请选择");

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



            DropDownList_xb.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_xb, "请选择");
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

            DropDownList_mz.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_mz, "请选择");
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


            DropDownList_gj.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_gj, "请选择");

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


            DropDownList_sfzlx.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_sfzlx, "请选择");

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


            DropDownList_zzmm.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_zzmm, "请选择");

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

            DropDownList_jkzk.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_jkzk, "请选择");


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

            DropDownList_ryxz.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_ryxz, "请选择");


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


            DropDownList_dqzt.Items.Add("请选择", "请选择");

            dp_setvalue(DropDownList_dqzt, "请选择");

            dp_setvalue(DropDownList_dqzt, text);
        }

        protected void DropDownList_yh_databind(string text)
        {
            DropDownList_yh.Items.Clear();
            DataTable dt = DataExecute.ExecuteDataset(DataExecute.ConnectionString2, CommandType.Text, "select [text],[code] from [yhlxm] where  code=12 or code=13 order by code").Tables[0];
            DropDownList_yh.DataSource = dt;
            DropDownList_yh.DataTextField = "text";
            DropDownList_yh.DataValueField = "code";
            DropDownList_yh.DataBind();

            DropDownList_yh.Items.Add("请选择", "请选择");
            dp_setvalue(DropDownList_yh, "请选择");


            dp_setvalue(DropDownList_yh, text);
        }
        protected void dp_setvalue(FineUI.DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.Trim() == value)    //与数据库中查询出来的那条一样.
                {

                    ddl.SelectedIndex = i;      //这样就可以显示出来了.

                    break;        //选中一条后,跳出循环.
                }
            }

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
            if (M_jgyhkxx == null)
            {
                M_jgyhkxx = new Model.jgyhkxx();
            }

            if (DropDownList_ly.SelectedValue == "请选择")
            {
                Alert.Show("请选择来源");
                return;
            }
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

            string csrq = "";
            string csrq_temp = "";

            if (DropDownList_sfzlx.SelectedText.Trim() == "居民身份证")
            {
                if ((!Regex.IsMatch(TextBox_sfzjh.Text.Trim(), @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
                {
                    Alert.Show("请输入正确的身份证号码！");
                    return;

                }
                if (TextBox_sfzjh.Text.Trim().Length == 18)
                {
                    try
                    {
                        csrq = TextBox_sfzjh.Text.Trim().Substring(6, 8);
                        csrq = csrq.Substring(0, 4) + "-" + csrq.Substring(4, 2) + "-" + csrq.Substring(6, 2);
                        csrq_temp = Convert.ToDateTime(csrq).ToString("yyyy-MM-dd"); 
                    }
                    catch
                    {
                        Alert.Show("请输入正确的身份证号码！");
                        return;
                    }
                }
                else if (TextBox_sfzjh.Text.Trim().Length == 15)
                {
                    try
                    {
                        csrq = "19" + TextBox_sfzjh.Text.Trim().Substring(6, 6);
                        csrq = csrq.Substring(0, 4) + "-" + csrq.Substring(4, 2) + "-" + csrq.Substring(6, 2);
                        csrq_temp = Convert.ToDateTime(csrq).ToString("yyyy-MM-dd"); 
                    }
                    catch
                    {
                        Alert.Show("请输入正确的身份证号码！");
                        return;
                    }
                }
            }
            else
            {
                csrq = DatePicker_csrq.Text.Trim();
            }

            string useruid = pb.GetIdentityId();
            DateTime optime = System.DateTime.Now;
          
            int res = 0;
            //string jxsj_n = DatePicker_jxsj.Text.Trim().Substring(0, 4);
            //string jxsj_m = DatePicker_jxsj.Text.Trim().Substring(5, 2);


            M_gxjg0101.XJSFYX = 0;

            if (B_gxjg0101.Update(M_gxjg0101))
            {
               

            }
            else
            {
                Alert.Show("保存失败");
                return;
            }


            string guid = Guid.NewGuid().ToString();
            M_gxjg0101.XJSFYX = 1;
            M_gxjg0101.Version = M_gxjg0101.Version + 1;
            M_gxjg0101.GUID = guid;
            M_gxjg0101.CSRQ = csrq;
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

            M_jgyhkxx.GUID = guid;
            M_jgyhkxx.GH = M_gxjg0101.GH;
            M_jgyhkxx.YHM = DropDownList_yh.SelectedValue.Trim();
            M_jgyhkxx.YHKH = TextBox_yhkh.Text.Trim();
            M_jgyhkxx.KHXM = TextBox_khxm.Text.Trim();
            M_gxjg0101.XJBZ = TextArea_bz.Text.Trim();

            M_gxjg0101.XJXGSJ = optime;
            M_gxjg0101.XJXGRY = useruid;
            if (B_gxjg0101.Add(M_gxjg0101))
            {
                if (B_jgyhkxx.Add(M_jgyhkxx)>0)
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

        protected void DropDownList_sfzlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList_sfzlx.SelectedText.Trim() != "居民身份证")
            {
                DatePicker_csrq.Hidden = false;
            }
            else
                DatePicker_csrq.Hidden = true;
        }
       

    }
}