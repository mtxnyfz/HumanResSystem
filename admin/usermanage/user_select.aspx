<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_select.aspx.cs" Inherits="XMGL.Web.admin.user_select" %>

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
            <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="true" EnableMultiSelect="false" 
                DataKeyNames="GH,XM" 
               ClearSelectedRowsAfterPaging="false" AllowPaging="True" 
                OnPageIndexChange="Grid1_PageIndexChange" PageSize="20" OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" SortField="XM">
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
                </Columns>
              
            </f:Grid>
        </Items>
    </f:Panel>
    <f:HiddenField ID="hfSelectedIDS" runat="server">
    </f:HiddenField>
    </form>
</body>
</html>
