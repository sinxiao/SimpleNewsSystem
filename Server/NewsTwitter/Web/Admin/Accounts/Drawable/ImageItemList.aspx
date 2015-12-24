<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageItemList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Drawable.ImageItemList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:small" >
    <dir style="font-size:small" align="left" >
  

              图片类型<asp:DropDownList 
                  ID="drdItem" runat="server" DataSourceID="ObjectDataSource2"
                    DataTextField="name" DataValueField="iditem">
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
                    Text="全部图片类型搜" BackColor="#E0E0E0" />
                <asp:Button ID="Button2" runat="server" 
            PostBackUrl="EditNews.aspx?List=List" Text="增加图片类型" CssClass="input" 
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
               <asp:Label ID="Label1" runat="server">图片类型关键字：</asp:Label>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="100px" BorderStyle="Groove"></asp:TextBox>
                                                <asp:Button ID="BtnSearchKeyWord" 
                  runat="server" CssClass="input" 
                    Text="搜索" BackColor="#E0E0E0" onclick="BtnSearchKeyWord_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp;<a href="EditNews.aspx?List=List">【添加图片类型】</a>
    </dir>
    </div>
    <listview
    </form>
</body>
</html>
