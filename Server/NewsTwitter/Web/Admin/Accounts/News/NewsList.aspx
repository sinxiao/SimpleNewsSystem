<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.News.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div style="font-size:small" >
    <dir style="font-size:small" align="left" >
  

              新闻类型<asp:DropDownList 
                  ID="drdItem" runat="server" DataSourceID="ObjectDataSource2"
                    DataTextField="name" DataValueField="iditem" AutoPostBack="True">
                    <asp:ListItem Selected="True">全部</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <select id="drpStatus" runat="server">
                    <option selected="selected" value ="2">全部</option>
                    <option  value ="1">已审核</option>
                    <option value="0" >未审核</option>
                </select>&nbsp;
                <asp:Button ID="btnSearch" runat="server" CssClass="input" 
                    Text="搜索" BackColor="#E0E0E0" onclick="btnSearch_Click1" />
                <asp:Button ID="btnSelect" runat="server" CssClass="input" OnClick="btnSelect_Click"
                    Text="全部新闻类型搜" BackColor="#E0E0E0" />
                <asp:Button ID="Button2" runat="server" 
            PostBackUrl="EditNews.aspx?List=List" Text="增加新闻" CssClass="input" 
            ForeColor="DarkGreen" BackColor="#E0E0E0" onclick="Button2_Click"  />
          <asp:Label ID="labTip" runat="server"></asp:Label>
                <hr />
                发布者：<asp:DropDownList ID="dropUsername" runat="server" DataSourceID="ObjectDataSource1"
                    DataTextField="Username" DataValueField="Userid">
                </asp:DropDownList>
                <asp:DropDownList ID="dropState2" runat="server">
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                    <asp:ListItem Value="0">未审核</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSelectByUserName" runat="server" BackColor="#E0E0E0" CssClass="input"
                    OnClick="btnSelectByUserName_Click" Text="搜索" />
                <hr />
               <asp:Label ID="Label1" runat="server">新闻关键字：</asp:Label>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="100px" BorderStyle="Groove"></asp:TextBox>
                                                <asp:Button ID="BtnSearchKeyWord" 
                  runat="server" CssClass="input" 
                    Text="搜索" BackColor="#E0E0E0" onclick="BtnSearchKeyWord_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp;<a href="EditNews.aspx?List=List">【添加新闻】</a>
    </dir>
                                                
     <asp:GridView ID="gvOrder" runat="server" 
         BackColor="White" BorderColor="#DEDFDE"
      BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
         GridLines="Vertical" Width="98%" DataSourceID="ObjectDataSource1" 
         AllowPaging="True" onrowdatabound="gvOrder_RowDataBound" AutoGenerateColumns="False" 
                                                    onrowcommand="gvOrder_RowCommand">
        <Columns>

            <asp:BoundField DataField="idnews" HeaderText="编号" 
                SortExpression="idnews"  />
            <asp:BoundField DataField="title" HeaderText="标题"   SortExpression="title" />

            <asp:TemplateField HeaderText="版块" SortExpression="itemid" >
                <ItemTemplate>
                    <asp:Label ID="labItem" runat="server" Text='<%# GetItemById(Eval("itemid")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
          
            <asp:TemplateField HeaderText="发布者" SortExpression="writer" >
                <ItemTemplate>
                    <asp:Label ID="labPublish" runat="server" Text='<%# GetWriterById(Eval("writer")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="gen_time" HeaderText="发布时间" 
                SortExpression="gen_time" />
            <asp:BoundField DataField="default_news" HeaderText="主页推荐" 
                SortExpression="default_news" />
                 
            
            <asp:TemplateField HeaderText="审核状态" SortExpression="verify" >
                <ItemTemplate>
                    <asp:Label ID="labVertify" runat="server" Text='<%# GetNewsVerifyStatus(Eval("verify")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

          <asp:TemplateField HeaderText="Y/N审核">
             <ItemTemplate>
                 <asp:LinkButton ID="lbtnstate" runat="server" CommandArgument='<%# Eval("idnews") %>'
                       CommandName="modify">LinkButton</asp:LinkButton>
                 </ItemTemplate>
           </asp:TemplateField>

            <asp:TemplateField HeaderText="审核人" SortExpression="verify_id" >
                <ItemTemplate>
                    <asp:Label ID="labVertifyer" runat="server" Text='<%# GetNewsVerifyAdmin(Eval("verify_id")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

            

            <asp:TemplateField HeaderText="审核日期" SortExpression="verify_date" >
                <ItemTemplate>
                    <asp:Label ID="labVertifyDate" runat="server" Text='<%# GetNewsVerifyDate(Eval("verify_date")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>
     
            <asp:TemplateField HeaderText="预览图" SortExpression="image_url" >
                <ItemTemplate>
                    <asp:Image Width="60px" Height="60px" ID="imageNews" runat="server" ImageUrl='<%# GetNewsImage(Eval("image_url")) %>'  />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="comment_sum" HeaderText="评论数" 
                SortExpression="comment_sum" />
            
            <asp:TemplateField ShowHeader="false"  SortExpression="news_url" >
                <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnView" runat="server" CommandName="View" Text="详细" CommandArgument='<%# Eval("idnews") %>'></asp:LinkButton>
                 </ItemTemplate>
            </asp:TemplateField>

        </Columns>
         <FooterStyle BackColor="#CCCC99" />
         <RowStyle BackColor="#F7F7DE" />
         <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" />
     </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
        SelectMethod="GetModelList" TypeName="WoeMobile.BLL.ItemManager">
        <SelectParameters>
            <asp:Parameter DefaultValue="item_parent is null" Name="strWhere" 
                Type="String" />
        </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
         SelectMethod="GetModelList" TypeName="WoeMobile.BLL.NewsManager" 
         >
         <SelectParameters>
             <asp:Parameter DefaultValue="" Name="strWhere" Type="String" />
         </SelectParameters>
     </asp:ObjectDataSource>
    </form>
</body>
</html>
