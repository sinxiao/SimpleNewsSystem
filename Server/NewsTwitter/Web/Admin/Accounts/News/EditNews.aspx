<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="EditNews.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.News.EditNews" %>

<%@Register TagPrefix="dntb" Namespace="DotNetTextBox" Assembly="DotNetTextBox"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 106%;
            height: 87px;
        }
        .style2
        {
            width: 38%;
        }
        .style3
        {
            width: 38%;
            height: 115px;
        }
        .style4
        {
            width: 120%;
            height: 115px;
        }
        .style5
        {
            height: 115px;
        }
        .style6
        {
            width: 120%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <
<table width="100%" border="0" cellspacing="0">
  <tr>
    <td class="style2" ><div align="right" style="width: 53px">标
        题</div></td>
    <td class="style6"><label>
      &nbsp;<asp:TextBox ID="tbxTitle" runat="server" 
            Width="688px" Font-Size="20px" Height="29px"></asp:TextBox>
    </label></td>
    <td width="11%">&nbsp;</td>
  </tr>
  <tr>
    <td height="26" class="style2"><div align="right">版块</div></td>
    <td class="style6"><label>
      &nbsp;<asp:DropDownList ID="drpItemParent" runat="server" 
            onselectedindexchanged="drpItemParent_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="drpItem" runat="server" 
             DataTextField="name" 
            DataValueField="iditem">
        </asp:DropDownList>
        </label></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
   <td class="style2"></td>
    <td class="style1" colspan="2"><label>
    
        <DNTB:WebEditor id="notContent" systemfolder="/system_dntb/" Skin="/skin/default/" 
            runat="server" Height="300px" Width="1000px" ></DNTB:WebEditor> 
    </label>

    
   
    </td>
    
  </tr>
  <tr>
    <td class="style3">摘要:</td>
    <td class="style4">
        <asp:TextBox ID="tbxIntro" runat="server" Height="112px" Width="683px"></asp:TextBox>
      </td>
    <td class="style5"></td>
  </tr>
  <tr>
    <td class="style2"><div align="right">关键字</div></td>
    <td class="style6">
        <asp:TextBox ID="tbkKeyWord" runat="server" Width="293px"></asp:TextBox>
      </td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td class="style2"><div align="right">操作</div></td>
    <td class="style6">
      &nbsp;<asp:CheckBox ID="CheckBox1" Text="置顶 " runat="server"  />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="加亮" />
        <asp:CheckBox ID="CheckBox3" runat="server" />
    </label></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td height="127" class="style2"><div align="right">封面</div></td>
    <td class="style6">
        &nbsp;<asp:FileUpload ID="fileUploadImg" runat="server" Width="219px" 
            ToolTip="选择图片" />
                <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
            Text="上传" />
            &nbsp;</td>
    <td>
        <asp:Image ID="imgPre" runat="server" Height="114px" style="margin-left: 0px" 
            Width="142px" />
      </td>
  </tr>
  <tr>
    <td class="style2">&nbsp;</td>
    <td class="style6">
<asp:Button ID="btnPublish" runat="server" Text="发布" onclick="btnPublish_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnFirstSee" runat="server" Text="预览" onclick="btnFirstSee_Click" />
<br />
        <asp:Button ID="btnPublishAtTime" runat="server" Text="定时发布" onclick="btnPublishAtTime_Click" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
            ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
      </td>
    <td>&nbsp;</td>
  </tr>
</table>
    </form>
</body>
</html>
