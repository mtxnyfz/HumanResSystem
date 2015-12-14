<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role_user.aspx.cs" Inherits="XMGL.Web.admin.role_user" %>


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
                        OnRowClick="Grid1_RowClick" EnableMultiSelect="false" EnableRowClickEvent="true">
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
                   
                    <f:Grid ID="Grid2" DataKeyNames="user_uid,RoleId" runat="server"  BoxFlex="1" 
                 ShowBorder="true" ShowHeader="false"
                
               
               Title="用户信息" AllowPaging="True" OnRowCommand="Grid2_RowCommand" 
                        OnPreDataBound="Grid2_PreDataBound" OnPageIndexChange="Grid2_PageIndexChange" 
               >
                        <Toolbars>
                            <f:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                   
                                    <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </f:ToolbarFill>
                                    <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnNew_Click"
                                        Text="添加用户到当前角色">
                                    </f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>

                        <Columns>
                          <%--  <f:BoundField DataField="UserId" Width="100px" HeaderText="教工号" />--%>
                            <f:BoundField DataField="Name"  Width="100px" HeaderText="登录名" />
                           <%-- <f:BoundField DataField="ActualName"  Width="100px" HeaderText="姓名" />--%>
                            <f:BoundField DataField="ActualName"  Width="300px" HeaderText="姓名" />
                           

                         <f:WindowField ColumnID="xm_set" TextAlign="Center" Text="查看或设置用户可访问项目"  Title="查看或设置用户可访问项目"
                        WindowID="Window1" DataIFrameUrlFields="user_uid,RoleId" DataIFrameUrlFormatString="~/admin/Xmqx_add.aspx?UserId={0}&RoleId={1}"
                        Width="200"  />
                            <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="从当前角色中移除此用户"
                                ConfirmText="确定从当前角色中移除此用户？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
        Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="700px" Height="500px" OnClose="Window1_Close">
    </f:Window>
    </form>
</body>
</html>
