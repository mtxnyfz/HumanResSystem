<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role_module.aspx.cs" Inherits="XMGL.Web.admin.Role_module" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
a:link,a:visited{
 text-decoration:none;  /*超链接无下划线*/
}
a:hover{
 text-decoration:underline;  /*鼠标放上去有下划线*/
}
</style>
 <style>
        .x-grid-tpl .others input
        {
            vertical-align: middle;
        }
        .x-grid-tpl .others label
        {
            margin-left: 5px;
            margin-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" />
    <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="Region1" ShowBorder="false" ShowHeader="false" Split="true" 
                 Width="200px" Position="Left" Layout="Fit"
                BodyPadding="5px 0 5px 5px"  runat="server">
                <Items>
                    <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" 
                       DataKeyNames="RoleId"  AllowPaging="false" 
                       EnableMultiSelect="false" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick">
                        <Columns>
                            <f:BoundField DataField="Name" SortField="Name" ExpandUnusedSpace="true" HeaderText="角色名称" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
            <f:Region ID="Region2" ShowBorder="false" ShowHeader="false" Position="Center" Layout="VBox"
                BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 0"
                runat="server">
                <Items>
                   
                    <f:Grid ID="Grid2" DataKeyNames="ModuleName" runat="server"  BoxFlex="1" 
                 ShowBorder="true" ShowHeader="false"
                
               
               Title="模块信息" AllowPaging="True" OnPreRowDataBound="Grid2_PreRowDataBound" 
                        OnRowDataBound="Grid2_RowDataBound" 
                        OnPageIndexChange="Grid2_PageIndexChange" PageSize="50" 
               >
                        <Toolbars>
                            <f:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                   
                                   
                                    <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnNew_Click"
                                        Text="更新当前角色的模块权限">
                                    </f:Button>
                                     <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </f:ToolbarFill>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>

                        <Columns>
                            <f:BoundField DataField="Title" Width="200px" HeaderText="菜单名称" />
                            <f:BoundField DataField="ModuleName"  Width="200px" HeaderText="模块名称" />
                          
                            <f:TemplateField  ColumnID="ck_read" HeaderText="查看" Width="100px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="查看" Width="100px" CssClass="others"/>
                                </ItemTemplate>
                            </f:TemplateField>
                              
                            <f:TemplateField  ExpandUnusedSpace="true" ColumnID="Others" HeaderText="其他权限">
                                <ItemTemplate>
                                    <asp:CheckBoxList ID="ddlOthers" CssClass="others" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Text="添加" Value="New"></asp:ListItem>
                                     <asp:ListItem Text="修改" Value="Edit"></asp:ListItem>
                                      <asp:ListItem Text="删除" Value="Del"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </ItemTemplate>
                            </f:TemplateField>

                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
        Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="700px" Height="500px" >
    </f:Window>
    </form>
</body>
</html>
