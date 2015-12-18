<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jgxxgl_up.aspx.cs" Inherits="HumanResSystem.Web.admin.jgxx.jgxxgl_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"></f:PageManager>
         <f:Form ID="Form2" MessageTarget="Qtip" Width="600px" BodyPadding="5px" Title="修改教工信息" ShowHeader="false"  ShowBorder="false" runat="server"  LabelAlign="Top">
            <items>
                <f:Panel ID="Panel1" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:TextBox ID="TextBox_gh"  Label="工号"   CssClass="formitem" runat="server" Enabled="false" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                        
                          <f:DropDownList ID="DropDownList_dw" runat="server" Label="所属部门" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                        
                       
                    </Items>
                </f:Panel>
                 <f:Panel ID="Panel2" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                         <f:TextBox ID="TextBox_xm"  Label="姓名" Required="true" ShowRedStar="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox_py"  Label="姓名拼音（首字母）" Required="true" ShowRedStar="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                         
                       
                      <%--   <f:TextBox ID="TextBox_xmpy"  Label="姓名拼音" Required="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>--%>
                     <%--   <f:TextBox ID="TextBox_ywxm"  Label="英文姓名"   CssClass="formitem" runat="server"  Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>--%>
                        
                       
                    </Items>
                </f:Panel>
                  <f:Panel ID="Panel9" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                          <f:DropDownList ID="DropDownList_ryxz" Required="true" ShowRedStar="true" runat="server" Label="人员性质"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%" Enabled="false">
                          
                        </f:DropDownList>
                          <f:DropDownList ID="DropDownList_ly" Required="true" ShowRedStar="true" runat="server" Label="来源"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                               <f:ListItem Text="请选择" Value="请选择" />
                              <f:ListItem Text="行健" Value="行健" />
                                <f:ListItem Text="中专" Value="中专" />
                          
                        </f:DropDownList>
                       
                   
                        
                       
                    </Items>
                </f:Panel>
               <%-- <f:Panel ID="Panel3" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                      
                         <f:TextBox ID="TextBox_cym"  Label="曾用名"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                       
                    </Items>
                </f:Panel>--%>
                 <f:Panel ID="Panel4" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:DropDownList ID="DropDownList_xb" runat="server" Label="性 别" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                          <f:DropDownList ID="DropDownList_mz" runat="server" Label="民族" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                       <%--   <f:TextBox ID="TextBox_csd"  Label="出生地"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>--%>
                     <%--   <f:DatePicker runat="server" Required="true" EnableEdit="false" Label="出生日期" EmptyText="系统自动生成"
                    ID="DatePicker_csrq" ShowRedStar="True" Margin="10 15 0 15" ColumnWidth="50%" Enabled="false">
                </f:DatePicker>--%>
                       
                    </Items>
                </f:Panel>
                  <f:Panel ID="Panel5" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:DropDownList ID="DropDownList_gj" runat="server" Label="国籍" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="25%">
                          
                        </f:DropDownList>
                          <f:DropDownList ID="DropDownList_sfzlx" runat="server" Label="身份证件类型" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="25%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_sfzlx_SelectedIndexChanged" >
                          
                        </f:DropDownList>
                      <f:TextBox ID="TextBox_sfzjh"  Label="证件号码" Required="true" ShowRedStar="true"    CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%" >
                        </f:TextBox>
                     
                    </Items>
                </f:Panel>
                  <f:Panel ID="Panel8" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        <f:DatePicker runat="server" Required="true" EnableEdit="false" Label="出生日期" 
                    ID="DatePicker_csrq" ShowRedStar="True" Margin="10 15 0 15" ColumnWidth="50%"  Hidden="true" DateFormatString="yyyy-MM-dd">
                </f:DatePicker>
                          </Items>
                       </f:Panel>
                <%--  <f:Panel ID="Panel6" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:DropDownList ID="DropDownList_hyzk" runat="server" Label="婚姻状况"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                          <f:DropDownList ID="DropDownList_gatqw" runat="server" Label="港澳台侨外"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                    
                       
                    </Items>
                </f:Panel>--%>
                 <f:Panel ID="Panel7" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:DropDownList ID="DropDownList_zzmm" runat="server" Label="政治面貌" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                          <f:DropDownList ID="DropDownList_jkzk" runat="server" Label="健康状况" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%">
                          
                        </f:DropDownList>
                    
                       
                    </Items>
                </f:Panel>
                 <f:Panel ID="Panel6" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                        <f:DatePicker runat="server" Required="true" EnableEdit="false" Label="进校时间(年月)" EmptyText="请选择时间"
                    ID="DatePicker_jxsj" ShowRedStar="True" Margin="10 15 0 15" ColumnWidth="50%"  DateFormatString="yyyy-MM-dd" >
                </f:DatePicker>
                          <f:DropDownList ID="DropDownList_dqzt" runat="server" Label="当前状态"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="50%" Enabled="true">
                          
                        </f:DropDownList>
                    
                       
                    </Items>
                </f:Panel>
                 <f:Panel ID="Panel3" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                      
                         <f:TextBox ID="TextBox_lxdh"  Label="联系电话或手机" Required="true" ShowRedStar="true"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="25%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox_yb"  Label="邮编"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="25%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox_lxdz"  Label="联系地址" Required="true" ShowRedStar="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                       
                    </Items>
                </f:Panel>
              <%--  <f:Panel ID="Panel9" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                      
                         <f:TextBox ID="TextBox1"  Label="联系电话"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="25%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox2"  Label="邮编"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="25%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox3"  Label="联系地址"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="50%">
                        </f:TextBox>
                       
                    </Items>
                </f:Panel>--%>
                 <f:Panel ID="Panel10" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                          <f:DropDownList ID="DropDownList_yh" runat="server" Label="开户行" Required="true" ShowRedStar="true"  CssClass="formitem" Margin="10 15 0 15" ColumnWidth="30%">
                          
                        </f:DropDownList>
                         <f:TextBox ID="TextBox_yhkh"  Label="银行卡号" Required="true" ShowRedStar="true"  CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="40%">
                        </f:TextBox>
                         <f:TextBox ID="TextBox_khxm"  Label="开户姓名" Required="true" ShowRedStar="true"   CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="30%">
                        </f:TextBox>
                       
                    </Items>
                </f:Panel>
             <%--    <f:Panel ID="Panel8" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                         <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server"   EnableCollapse="true"
            ShowBorder="True" Title="照片" ColumnWidth="100%" Margin="10 15 15 0"  >
            <Items>
                <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="../images/user-pic.jpg" ShowEmptyLabel="true" runat="server" ImageHeight="150px">
                </f:Image>
              
 
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:FileUpload runat="server" ID="filePhoto" ButtonText="上传照片" AcceptFileTypes="image/*" ButtonOnly="true"
                            AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                        </f:FileUpload>
                      
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:SimpleForm>
                      
                    
                       
                    </Items>
                </f:Panel>--%>
                 <f:Panel ID="Panel11" ShowHeader="false" CssClass="formitem" ShowBorder="false"
                    Layout="Column" runat="server">
                    <Items>
                        
                      
                       <%--  <f:TextBox ID="TextBox1"  Label="备注"     CssClass="formitem" runat="server" Margin="10 15 0 15" ColumnWidth="80%">
                        </f:TextBox>--%>
                        
                        <f:TextArea ID="TextArea_bz" runat="server" Height="80px" Label="备注" Text="" Margin="10 15 0 15" ColumnWidth="50%"></f:TextArea>
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
