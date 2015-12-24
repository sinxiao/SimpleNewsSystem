<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTrace.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Picture.AddTrace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 99px;
        }
        .style2
        {
            width: 220px;
        }
        .style3
        {
            text-align: center;
            width: 220px;
        }
        .style4
        {
            width: 99px;
        }
        .style5
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style5">
    <table align="center">
    <tr>
    <td class="style4" >添加种类</td>
   
    </tr>
    <tr>
    <td class="style1">名字</td>
    <td class="style2">
        <asp:TextBox ID="txtName" runat="server" Width="190px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td class="style1">介绍</td>
    <td class="style2">
        <asp:TextBox ID="txtDemo" runat="server" Width="188px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td class="style1">创建日期：</td>
    <td class="style3">&nbsp;</td>
    </tr>
    <tr>
    <td class="style4"></td>
    <td class="style2">
        <asp:Button ID="btnAdd" runat="server" Text="保存" onclick="btnAdd_Click" /></td>
    </tr>
    </table>
        <br />
        <table>
        <tr>
        <td></td>
        </tr>
        </table>
        <div>
        <br />
        </div>
        <table align="center">
        <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="名字:"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtLname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="介绍："></asp:Label></td>
        <td>
            <asp:TextBox ID="txtLDemo" runat="server"></asp:TextBox></td>
        </tr>
    
        <tr>
        <td></td>
        <td>
        <asp:Button ID="btnAddLoaction" runat="server" Text="添加图集" 
                onclick="btnAddLoaction_Click" />
            </td>
        </tr>
        </table>
    </div>

    </form>
</body>
</html>
