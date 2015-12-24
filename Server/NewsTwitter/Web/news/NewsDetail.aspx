<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="WoeMobile.Web.news.NewsDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <style type="text/css">

.tit {color: #000000; font-size: 18px; line-height: 22px; font-weight:bold}

td {font-family: "Verdana", "Helvetica", "sans-serif";font-size: 12px;	color: #000000;text-decoration: none;line-height: 140%;}

        .style1
        {
            color: #000000;
            font-size: 18px;
            line-height: 22px;
            font-weight: bold;
            height: 55px;
        }
.wenzhang {
	FONT-SIZE: 12px; 
	LINE-HEIGHT: 26px; 
	FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif
}
    </style>
</head>
<body style="height: 1261px">
    
    
    <form id="form1" runat="server">
    
    
    <div style="height: auto" id="body">
        <div style="height: auto" id="head">
           
            <table align="center" border="0" cellpadding="0" cellspacing="0" 
                style="height: 94px" width="100%">
                <tr>
                    <td align="center" class="style1" colspan="2">
                        <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    
                    <td align="right" style="border-bottom: #666666 1px solid" width="100%">
                        &nbsp; 发布者： 
                        <asp:Label ID="user" runat="server" Text="Label"></asp:Label>
                        &nbsp; 发布时间：<asp:Label ID="time" runat="server" Text="Label"></asp:Label>
                        &nbsp; 阅读：<asp:Label ID="click" runat="server" Text="Label"></asp:Label>
                        次</td>
                </tr>
            </table>
           
        </div>
         <div style="height: auto" id="content">
             <span id="BodyLabel" class="wenzhang"></span>
             <br />
             <br />
             <asp:Label ID="content" runat="server" Text="Label"></asp:Label>
         </div>
          <div style="height: 141px" id ="foot">
         </div>
    </div>
    
    
    </form>
    
    
</body>
</html>
