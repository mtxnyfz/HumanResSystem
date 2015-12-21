<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jgxxgl_manage.aspx.cs" Inherits="HumanResSystem.Web.admin.jgxx.jgxxgl_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="../../res/jqueryuiautocomplete/jquery-ui.min.css" />
    <link rel="stylesheet" href="../../res/jqueryuiautocomplete/theme-start/theme.css" />
     <style>
        .ui-autocomplete-loading {
            background: white url('../../res/images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .autocomplete-item-title
    {
        font-weight: bold;
    }
     .ui-autocomplete {
            max-height: 80%;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }

        .auto-style1 {
            width: 100%;
        }

        .wz {
            margin: 0 auto;
        }
    </style>
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
                    <Toolbars>
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
                                   <f:TextBox ID="TextBox_key" Label=""  EmptyText="请输入教工号或姓名或部门等关键字搜索" Width="300px"   runat="server" ShowLabel="false">
                                </f:TextBox>
                                <f:Button ID="Button3" Text="搜索" runat="server"  OnClick="Button3_Click">
                                </f:Button>
                                <f:Button ID="Button4" Text="显示所有" runat="server"   OnClick="Button4_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
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

      <script src="../../res/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../res/jqueryuiautocomplete/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var textbox1ID = '<%= TextBox_key.ClientID %>';
      
        v = '<%= TextBox_key.Text.Trim() %>'

        F.ready(function () {

            var cache = {};

           

                $('#' + textbox1ID + ' input').autocomplete({
                    minLength: 1,
                    source: function (request, response) {
                        var term1 = request.term;
                      

                        $.getJSON("search_jgxx.ashx?timestamp=" + new Date().getTime(), request, function (data, status, xhr) {
                            cache[term1] = data;
                         
                            response(cache[term1]);


                        });

                    },
                    select: function (event, ui) {
                        var $this = $(this);
                        $this.val(ui.item.gh);

                        //$('#' + TextBox_fzr + ' input').val(ui.item.fzr);
                        //$('#' + NumberBox_jfye + ' input').val(ui.item.ye);
                        //$('#' + HiddenField_xmbh + ' input').val(ui.item.xmbh);
                        //$('#' + HiddenField_id + ' input').val(ui.item.id);
                        cache = {};
                        return false;
                    }
                }).autocomplete("instance")._renderItem = function (ul, item) {
                   
                   
                        return $("<li>")
                            .append("<a><span class='autocomplete-item-title'>姓名：</span>" + item.xm + "&nbsp;&nbsp;&nbsp;&nbsp;<span class='autocomplete-item-title'>教工号：</span>" + item.gh + "<br/><span class='autocomplete-item-title'>部门 ：</span>" + item.dwmc + "</a>")
                            .appendTo(ul);
                   
                };
            

        });

    </script>
</body>
</html>
