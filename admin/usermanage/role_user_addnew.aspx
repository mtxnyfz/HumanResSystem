<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role_user_addnew.aspx.cs" Inherits="XMGL.Web.admin.role_user_addnew" %>

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
                    <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </f:Button>
                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </f:ToolbarSeparator>
                    <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="选择后关闭">
                    </f:Button>
                    <f:ToolbarFill ID="ToolbarFill1" runat="server">
                    </f:ToolbarFill>
                   
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="true"
                DataKeyNames="user_uid,Name" 
               ClearSelectedRowsAfterPaging="false" AllowPaging="True" 
                OnPageIndexChange="Grid1_PageIndexChange" PageSize="20">
                <Columns>
                <f:BoundField DataField="Name" Width="100px" HeaderText="教工号" />
                 <f:BoundField DataField="Name" Width="100px" HeaderText="用户名" />
                  <f:BoundField DataField="ActualName" Width="100px" HeaderText="姓名" />
                   <f:BoundField DataField="Ssxb_mc" Width="100px" HeaderText="所属部门" />
                </Columns>
              
            </f:Grid>
        </Items>
    </f:Panel>
    <f:HiddenField ID="hfSelectedIDS" runat="server">
    </f:HiddenField>
    </form>
</body>
</html>
