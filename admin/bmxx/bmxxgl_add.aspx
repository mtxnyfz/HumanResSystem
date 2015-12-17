<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bmxxgl_add.aspx.cs" Inherits="HumanResSystem.Web.admin.bmxx.bmxxgl_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
         <f:Form ID="Form2" MessageTarget="Qtip" Width="420px" BodyPadding="5px" Title="添加部门信息" ShowHeader="false"  ShowBorder="false" runat="server"  LabelAlign="Left">
            <items>
                <f:Panel ID="Panel1" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                          <f:TextBox ID="TextBox_bmdm"  Label="部门编号" Required="true" ShowRedStar="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="70%">
                        </f:TextBox>
                      
                        
                        
                        
                       
                    </Items>
                </f:Panel>
                 <f:Panel ID="Panel2" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                       
                        
                          <f:TextBox ID="TextBox_bmmc"  Label="部门名称" Required="true" ShowRedStar="true"   CssClass="formitem" runat="server"  Margin="10 15 0 15" ColumnWidth="70%" >
                        </f:TextBox> 
                    
                        
                       
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel3" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                       
                        
                          <f:DropDownList ID="DropDownList_bmlb" runat="server" Label="部门类别" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="70%">
                          
                        </f:DropDownList>
                    
                        
                       
                    </Items>
                </f:Panel>
                 <f:Panel ID="Panel4" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                       
                        
                          <f:DropDownList ID="DropDownList_bmsfyx" runat="server" Label="部门是否有效" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="70%" Enabled="false">
                                <f:ListItem Text="请选择" Value="请选择" />
                              <f:ListItem Text="是" Value="1" />
                                <f:ListItem Text="否" Value="0" />
                          
                        </f:DropDownList>
                    
                        
                       
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel11" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                      
                       <%--  <f:TextBox ID="TextBox1"  Label="备注"     CssClass="formitem" runat="server" Margin="10 15 0 0" ColumnWidth="80%">
                        </f:TextBox>--%>
                        
                        <f:TextArea ID="TextArea_bz" runat="server" Height="80px" Label="备注" Text="" Margin="10 15 0 15" ColumnWidth="70%"></f:TextArea>
                    </Items>
                </f:Panel>
                  </items>
              <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" ValidateForms="Form2"></f:Button>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
