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

namespace HumanResSystem.Web.admin.jgxx
{
    public partial class jgxxgl_manage_view : System.Web.UI.Page
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

            sqlstr = "  select uid,XM,GH,b.text as xb,c.text as xz,d.DWMC from (select GUID as uid,XM,XBM,GH,DWH,XJRYXZ,Version from gxjg0101 as n where Version = (select MAX(Version) from gxjg0101 where GH = n.GH and XJSFSC!=1 and XJSFYX=1)) as a  left join [HumanResSystemCode].[dbo].[xbm] as b on a.XBM=b.code left join [HumanResSystemCode].[dbo].xjryxzm as c on a.XJRYXZ=c.code left join jctb0103 as d on a.DWH=d.DWH";
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
            string addUrl = "jgxxgl_add.aspx";

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加教工信息"));
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

                string addUrl = "jgxxgl_up.aspx?uid="+uid;

                PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "修改教工信息"));
               
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

                string sqlstr = "update gxjg0101 set XJSFSC='1',XJSCRY='" + pb.GetIdentityId() + "',XJSCSJ='"+DateTime.Now+"' where GUID='" + uid + "'";
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
    }
}