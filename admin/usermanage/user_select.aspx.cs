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
    public partial class user_select : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        string roleid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["id"] != null)
                //{
                //    roleid = Request.QueryString["id"].ToString().Trim();
                //    ViewState["roleid"] = roleid;
                //    Grid1_databind();
                //}
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                Grid1_databind();

            }
        }

        protected void Grid1_databind()
        {

            //string jgh = pb.GetIdentityId();

            //DataTable dt = DbHelperSQL.Query("select * FROM Users where  NOT exists (select user_uid from RoleUser where RoleId='" + ViewState["roleid"].ToString() + "' and  Users.user_uid=RoleUser.UserId)  order by ActualName").Tables[0];
            DataTable dt = DbHelperSQL.Query(" select uid,XM,GH,b.text as xb,c.text as xz,d.DWMC from (select GUID as uid,XM,XBM,GH,DWH,XJRYXZ,Version from gxjg0101 as n where Version = (select MAX(Version) from gxjg0101 where GH = n.GH and XJSFSC!=1 and XJSFYX=1)) as a  left join [HumanResSystemCode].[dbo].[xbm] as b on a.XBM=b.code left join [HumanResSystemCode].[dbo].xjryxzm as c on a.XJRYXZ=c.code left join jctb0103 as d on a.DWH=d.DWH where a.GH not in(select name FROM Users)").Tables[0];
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            //Grid1.DataSource = dt;
            Grid1.DataBind();
            pb.UpdateSelectedRowIndexArray(hfSelectedIDS, Grid1);
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {

            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            Grid1_databind();


        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            //SyncSelectedRowIndexArrayToHiddenField();
            //List<string> ids = pb.GetSelectedIDsFromHiddenField(hfSelectedIDS);

            //string sqlstr = "";
            //if (ViewState["roleid"].ToString().Trim() == "1")
            //{
            //    for (int i = 0; i < ids.Count; i++)
            //    {
            //        sqlstr = "insert into RoleUser(RoleId,UserId,Hd_ids) values('" + ViewState["roleid"].ToString() + "','" + ids[i].ToString() + "','self')";
            //        DbHelperSQL.ExecuteSql(sqlstr);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < ids.Count; i++)
            //    {
            //        sqlstr = "insert into RoleUser(RoleId,UserId) values('" + ViewState["roleid"].ToString() + "','" + ids[i].ToString() + "')";
            //        DbHelperSQL.ExecuteSql(sqlstr);
            //    }
            //}
            string gh = "",xm="";
            int selectedCount = Grid1.SelectedRowIndexArray.Length;
            if (selectedCount > 0 && selectedCount < 2)
            {
                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = Grid1.SelectedRowIndexArray[i];
                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (Grid1.AllowPaging && !Grid1.IsDatabasePaging)
                    {
                        rowIndex = Grid1.PageIndex * Grid1.PageSize + rowIndex;//获取翻页后的行号
                    }
                    gh += Grid1.DataKeys[rowIndex][0].ToString() + ",";
                    xm += Grid1.DataKeys[rowIndex][1].ToString() + ",";

                }
                gh = gh.TrimEnd(',');//去掉最后一个，号
                xm = xm.TrimEnd(',');//去掉最后一个，号
                //string addUrl = "jgxxgl_up.aspx?uid=" + uid;

                //PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "修改教工信息"));
                PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(gh, xm) + ActiveWindow.GetHideReference());

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
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