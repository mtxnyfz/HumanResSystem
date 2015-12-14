<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jgxxgl_manage_view.aspx.cs" Inherits="HumanResSystem.Web.admin.jgxx.jgxxgl_manage_view" %>

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
                    DataKeyNames="uid" OnPageIndexChange="Grid1_PageIndexChange" EnableCheckBoxSelect="true" EnableMultiSelect="false"  OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="XM">
                   <%-- <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                              
                                

                             
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                              
                                <f:Button ID="btn_add" Text="新增人员" runat="server" OnClick="btn_add_Click">
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
                    </Toolbars>--%>
                    <Columns>
                      
                        
                         <f:BoundField Width="150px" DataField="XM" HeaderText="姓名" ID="BoundField7" SortField="XM"/>
                         <f:BoundField Width="150px" DataField="GH" HeaderText="教工号" ID="BoundField1" SortField="GH"/>
                       
                          
                         <f:TemplateField HeaderText="性别"  ColumnID="Panel7_Grid2_ylfw_ctl17" SortField="xb">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("xb")%>'></asp:Label>
                    </ItemTemplate>

                </f:TemplateField >
                          <f:TemplateField Width="250px" HeaderText="所属部门"  ColumnID="Panel7_Grid2_ylfw_ctl18" SortField="DWMC">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("DWMC")%>'></asp:Label>
                    </ItemTemplate>

                </f:TemplateField>
                         <f:TemplateField HeaderText="教师性质"  ColumnID="Panel7_Grid2_ylfw_ctl19" SortField="xz">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("xz")%>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                           <f:WindowField ColumnID="xq" TextAlign="Center" Text="详情"  Title="教工信息详情"
                        WindowID="Window1" DataIFrameUrlFields="uid" DataIFrameUrlFormatString="jgxxgl_look.aspx?uid={0}"
                        Width="100px" />
                     
                    </Columns>
                </f:Grid>

               
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close"
            IsModal="true" Width="620px" Height="700px" >
          
        </f:Window>
    </form>
</body>
</html>
