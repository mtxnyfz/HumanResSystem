<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bmxxgl_manage.aspx.cs" Inherits="HumanResSystem.Web.admin.bmxx.bmxxgl_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Grid1"></f:PageManager>
          <f:Panel ID="Panel7" runat="server" BodyPadding="5px"
            Title="人员基本信息管理" ShowBorder="false" ShowHeader="True"  Layout="VBox">
            <Items>

       
                
               <f:Grid ID="Grid1" Title="Grid1" PageSize="20" ShowBorder="true" BoxFlex="1" AllowPaging="true"
                    ShowHeader="false" runat="server" 
                    DataKeyNames="GUID" OnPageIndexChange="Grid1_PageIndexChange" EnableCheckBoxSelect="true" EnableMultiSelect="false"  OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="DWMC" OnRowDataBound="Grid1_RowDataBound">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                             
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                              
                                <f:Button ID="btn_add" Text="新增部门" runat="server" OnClick="btn_add_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" Text="修改选中" runat="server" OnClick="Button1_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                               <f:Button ID="Button2" Text="删除选中" runat="server" ConfirmText="确定删除？"  OnClick="Button2_Click">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                </f:ToolbarSeparator>
                                
                               
                             
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                      
                        
                         <f:BoundField Width="150px" DataField="DWH" HeaderText="部门编号" ID="BoundField7" SortField="DWH"/>
                         <f:BoundField Width="250px" DataField="DWMC" HeaderText="部门名称" ID="BoundField1" SortField="DWMC"/>
                        <%--  <f:TemplateField HeaderText="部门类别"  ColumnID="Panel7_Grid2_ylfw_ctl17" SortField="dwlb" Width="150px">
                    <ItemTemplate >
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("dwlb")%>'></asp:Label>
                    </ItemTemplate>

                </f:TemplateField  >--%>
                          <f:TemplateField HeaderText="部门是否有效"  ColumnID="Panel7_Grid2_ylfw_ctl18" SortField="DWYXBS" Width="180px">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("DWYXBS")%>'></asp:Label>
                    </ItemTemplate>

                </f:TemplateField >
                        <f:BoundField Width="150px" DataField="XJBZ" HeaderText="备注" ID="BoundField2"/>
                     
                     
                    </Columns>
                </f:Grid>

               
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="450px" Height="500px" >
          
        </f:Window>
    </form>
</body>
</html>
