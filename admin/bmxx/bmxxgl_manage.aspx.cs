using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AppBox;
using FineUI;
using Maticsoft.DBUtility;

namespace HumanResSystem.Web.admin.bmxx
{
    public partial class bmxxgl_manage : System.Web.UI.Page
    {
        PageBase1 pb = new PageBase1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                databind();
            }
        }

        protected void databind()
        {

            DataTable dt = null;
            string sqlstr = "";

            //sqlstr = "select GUID,DWH,DWMC,XJBZ from jctb0103 where XJSFSC!=1 and XJSFYX!=0";
            //sqlstr = "select GUID,DWH,DWMC,XJBZ,Version from jctb0103 as a where Version in (select max(version) from jctb0103  where XJSFSC!=1 and XJSFYX=1 and a.DWH=jctb0103.DWH) order by DWMC";
            sqlstr = "select  GUID,DWH,DWMC,c.text as dwlb,DWYXBS,XJBZ from ( select GUID,DWH,DWMC,DWLBM,DWYXBS,XJBZ,Version from jctb0103 as a where Version in (select max(version) from jctb0103  where XJSFSC!=1 and XJSFYX=1 and a.DWH=jctb0103.DWH)) as b left join HumanResSystemCode.dbo.dwlbm  as c on b.DWLBM=c.code";
            dt = DbHelperSQL.Query(sqlstr).Tables[0];
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataView view1 = dt.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            Grid1.DataSource = view1;
            //Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string addUrl = "bmxxgl_add.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加部门信息"));
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {

            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            databind();


        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {

            Grid1.PageIndex = e.NewPageIndex;
            Grid1.DataBind();
            databind();

        }
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            databind();
            Alert.Show("操作成功");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uid = "";
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
                    uid += Grid1.DataKeys[rowIndex][0].ToString() + ",";

                }
                uid = uid.TrimEnd(',');//去掉最后一个，号

                string addUrl = "bmxxgl_up.aspx?uid=" + uid;

                PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "修改部门信息"));

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string uid = "";
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
                    uid += Grid1.DataKeys[rowIndex][0].ToString() + ",";

                }
                uid = uid.TrimEnd(',');//去掉最后一个，号

                string sqlstr = "update jctb0103 set XJSFSC='1',XJSCRY='" + pb.GetIdentityId() + "',XJSCSJ='" + DateTime.Now + "' where GUID='" + uid + "'";
                if (DbHelperSQL.ExecuteSql(sqlstr) > 0)
                {
                    databind();
                    Alert.Show("删除成功");
                }
                else
                {
                    Alert.Show("删除失败");
                }

            }
            else
            {
                Alert.Show("请选中一条数据！", "系统提示", MessageBoxIcon.Warning);
                Grid1.SelectedRowIndexArray = null; // 清空当前选中的项
            }
        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            System.Web.UI.WebControls.Label lb = (System.Web.UI.WebControls.Label)Grid1.Rows[e.RowIndex].FindControl("Label2");
            string DWYXBS = lb.Text.Trim();
            if (DWYXBS =="1")
            {
                lb.Text = "是";
            }
            else
            {
                lb.Text = "否";
            }
        }
    }
}