<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="Word_dntb.Importword" %>
<%@ Import Namespace="DotNetTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><%=ResourceManager.GetString("importword")%></title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<style type="text/css">
body,a,table,input,button{font-size:9pt;font-family:Verdana,Arial}
</style>
<script language=javascript>
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);

function loading()
{
    document.getElementById("loading").style.visibility="visible";
    return true;
}

function addeditor()
{
if(confirm('<%=ResourceManager.GetString("importwordconfirm")%>'))
{

if(is_ie)
{
window.returnValue=document.getElementById("worddoc").value;
window.close();
}
else{
window.opener.plugin_execommand(document.getElementById("worddoc").value);
window.close();
}

}

}
</script>
</head>
<body leftmargin=5 topmargin=5>
    <form id="form1" runat="server">
            <div id="loading" style="border-right: #333333 1px dashed; border-top: #333333 1px dashed;
                        font-size: 9pt; visibility: hidden; border-left: #333333 1px dashed;
                        width: 270px; color: #000000; border-bottom: #333333 1px dashed; position: absolute; height: 120px; background-color: #ffffff">
                        <center>
                            <br />
                            <br />
                            <%=ResourceManager.GetString("getpageloading")%></center>
                        <br />
                        <center>
                            <asp:Button ID="canceloading" runat="server" Style="border-top-style: dashed; border-right-style: dashed;
                                border-left-style: dashed; border-bottom-style: dashed" />&nbsp;</center>
                        <br />
                    </div>
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" Height="20px" />
        <asp:Button ID="btnUpload" runat="server" OnClientClick="loading()" OnClick="btnUpload_Click" /><br />
        <asp:CheckBox ID="saveword" runat="server" Width="206px" /><br />
        <asp:HiddenField ID="worddoc" runat="server" /></div>
    </form>
</body>
<script language=javascript>
var load=document.getElementById('loading');
resizeLoad();
window.setInterval("resizeLoad()",10);
function resizeLoad()
{
load.style.top = parseInt((document.body.clientHeight-load.offsetHeight)/2+document.body.scrollTop);
load.style.left = parseInt((document.body.clientWidth-load.offsetWidth)/2+document.body.scrollLeft);
}
if(is_ie)
{
document.body.bgColor="ButtonFace";
}
else
{
document.body.bgColor="#E0E0E0";
}
</script>
</html>