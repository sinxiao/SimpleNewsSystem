<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationByTraceList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Picture.LocationByTraceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gdvLocation" runat="server" Height="118px" Width="477px" 
            DataSourceID="odsLocation">
        </asp:GridView>
        <br />
        <asp:ObjectDataSource ID="odsLocation" runat="server" SelectMethod="GetList" 
            TypeName="WoeMobile.BLL.LocationsManager">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="strWhere" Type="String" />
            </SelectParameters>

        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
