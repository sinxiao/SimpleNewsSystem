<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="../Controls/CheckRight.ascx" %>
<%@ Page language="c#" Codebehind="Left.aspx.cs" AutoEventWireup="True" Inherits="Maticsoft.Web.Admin.Left" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Left</title>
				
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgColor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>' 
	text=#000000 leftMargin=0 topMargin=0 onload="" marginheight="0" marginwidth="0" >
		<form id="Form1" method="post" runat="server">
			<table width="204" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="27"><img src='<%=Application[Session["Style"].ToString()+"xleft1_bgimage"]%>' width="200" height="27"></td>
					<td rowspan="3" bgColor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>'></td>
				</tr>
				<tr>
					<td height="100%" valign="top" background='<%=Application[Session["Style"].ToString()+"xleftbj_bgimage"]%>'>
						<div align="left"><font color="#314a72">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></div>
						<br>
						&nbsp;
						<asp:TreeView ID="TreeView1" runat="server"  Height="100%" Width="193px">
                        </asp:TreeView>
                       
                       
                    </td>
				</tr>
				<tr>
					<td height="19"><img src='<%=Application[Session["Style"].ToString()+"xleft2_bgimage"]%>' width="200" height="19"></td>
				</tr>
			</table>
			<uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>
		</form>
	</body>
</HTML>
