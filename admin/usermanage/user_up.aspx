<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_up.aspx.cs" Inherits="XMGL.Web.admin.user_up" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    
    <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="SimpleForm" LabelWidth="100px" Width="300px" >
        
        <Rows>
       <%--   <f:FormRow ID="FormRow2" runat="server">--%>
          <%--  <Items>
                   
                <f:TextBox ID="TextBox_jgh" runat="server" Label="登录帐号" Text="" Required="true" ShowRedStar="true" Readonly="true" Enabled="false">
                </f:TextBox>
                   
                  
             </Items>--%>
          <%--  </f:FormRow>--%>
             <%-- <f:FormRow ID="FormRow3" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_name" runat="server" Label="姓名" Text="" Required="true" ShowRedStar="true" Readonly="true" Enabled="false">
                </f:TextBox>
                  
             </Items>
            </f:FormRow>--%>

               <f:FormRow ID="FormRow4" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_lgname" runat="server" Label="登录帐号" Text="" Required="true" ShowRedStar="true" Enabled="false">
                </f:TextBox>
                  
             </Items>
            </f:FormRow>
            <f:FormRow ID="FormRow3" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_name" runat="server" Label="姓名" Text="" Required="true" ShowRedStar="true">
                </f:TextBox>
                  
             </Items>
            </f:FormRow>
             <f:FormRow ID="FormRow1" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_pwd" runat="server" Label="登录密码" Text="" Required="true" 
                         ShowRedStar="true" TextMode="Password">
                </f:TextBox>
                  
             </Items>
            </f:FormRow>

             <f:FormRow ID="FormRow6" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_rpwd" runat="server" Label="确认密码" Text="" 
                         Required="true" ShowRedStar="true" TextMode="Password">
                </f:TextBox>
                  
             </Items>
              </f:FormRow>
         <%--   <f:FormRow ID="FormRow7" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_tel" runat="server" Label="联系电话" Text="">
                </f:TextBox>
                  
             </Items>
             </f:FormRow>
              <f:FormRow ID="FormRow8" runat="server">
            <Items>
                 
                     <f:TextBox ID="TextBox_mobile" runat="server" Label="手机号码" Text="">
                </f:TextBox>
                  
             </Items>
             </f:FormRow>--%>
            <%-- <f:FormRow ID="FormRow5" runat="server">
            <Items>
                 
                <f:DropDownList ID="DropDownList_xb" runat="server" Label="责任部门" 
                    >
                     
                </f:DropDownList>
               
            </Items>
                
            </f:FormRow>--%>

          


             

        </Rows>
         <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items>
                  
                 
                    <f:Button ID="btnSaveClose" ValidateForms="Form2" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="保存修改">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
    </f:Form>
   <f:HiddenField ID="HiddenField_id" runat="server">
    </f:HiddenField>
   
    </form>
</body>
</html>
