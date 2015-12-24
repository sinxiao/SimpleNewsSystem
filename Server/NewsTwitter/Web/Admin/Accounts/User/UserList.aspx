<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.User.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <form id="form1"  runat="server">

    <asp:GridView ID="grdUserAll" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
        onrowdatabound="grdUserAll_RowDataBound">
        <Columns>
            <asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" />
            <asp:BoundField DataField="in_email" HeaderText="in_email" 
                SortExpression="in_email" />
            <asp:BoundField DataField="in_pwd" HeaderText="in_pwd" 
                SortExpression="in_pwd" />
            <asp:BoundField DataField="nick_name" HeaderText="nick_name" 
                SortExpression="nick_name" />
        </Columns>
         <FooterStyle BackColor="#CCCC99" />
         <RowStyle BackColor="#F7F7DE" />
         <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="WoeMobile.Model.euser" DeleteMethod="Delete" 
        InsertMethod="Add" SelectMethod="GetModelList" TypeName="WoeMobile.BLL.EuserManager" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="uid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="uid!=0" Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:Panel ID="Panel1" runat="server">
     <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		in_email
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtin_email" runat="server" Width="200px" 
            ontextchanged="txtin_email_TextChanged"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		in_pwd
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtin_pwd" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		nick_name
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtnick_name" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Label ID="lblTip" runat="server"></asp:Label>
                <asp:Button ID="btnSave" runat="server" Text="添加"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    </asp:Panel>

</form>
    
    
</body>
</html>
