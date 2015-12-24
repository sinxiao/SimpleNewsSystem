<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxTest.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Picture.AjaxTest" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
       
        <asp:BalloonPopupExtender ID="AjaxFileUpload1_BalloonPopupExtender" 
            runat="server" CustomCssUrl="" DynamicServicePath="" Enabled="True" 
            ExtenderControlID="" TargetControlID="AjaxFileUpload1">
        </asp:BalloonPopupExtender>
    
    </div>
    </form>
</body>
</html>
