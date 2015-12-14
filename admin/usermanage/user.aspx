<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="XMGL.Web.admin.user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Layout="Fit">
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items>
                   
                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </f:ToolbarSeparator>
                     <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnNew_Click"
                                        Text="添加用户">
                                    </f:Button>
                     <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </f:ToolbarSeparator>
                    
                    <f:ToolbarFill ID="ToolbarFill1" runat="server">
                    </f:ToolbarFill>
                   
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false"
                DataKeyNames="user_uid" 
               AllowPaging="True" 
                OnPageIndexChange="Grid1_PageIndexChange" PageSize="20" 
                OnRowCommand="Grid1_RowCommand" OnPreDataBound="Grid1_PreDataBound">
                <Columns>
                <%--<f:BoundField DataField="UserId" Width="100px" HeaderText="教工号" />--%>
                 <f:BoundField DataField="Name" Width="120px" HeaderText="用户名" />
                 <f:BoundField DataField="ActualName" Width="100px" HeaderText="姓名" />
                 <%--  <f:BoundField DataField="zrbm" Width="300px" HeaderText="责任部门" />--%>
                   <%-- <f:BoundField DataField="tel" Width="100px" HeaderText="联系电话" />
                     <f:BoundField DataField="mobile" Width="100px" HeaderText="手机号码" />--%>
                      <f:WindowField ColumnID="upuser" TextAlign="Center" Text="修改"  Title="用户资料修改"
                        WindowID="Window1" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="~/admin/usermanage/user_up.aspx?Id={0}"
                        Width="150px"  />
               
                 <f:LinkButtonField ColumnID="deleteField" TextAlign="Center"  Text="删除" 
                        ConfirmText="确定删除此用户？" ConfirmTarget="Top" CommandName="Delete" Width="100px" />
                </Columns>
              
            </f:Grid>
        </Items>
    </f:Panel>
    <f:HiddenField ID="hfSelectedIDS" runat="server">
    </f:HiddenField>


    <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
        Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="700px" Height="500px" OnClose="Window1_Close">
    </f:Window>
    </form>
</body>
</html>
