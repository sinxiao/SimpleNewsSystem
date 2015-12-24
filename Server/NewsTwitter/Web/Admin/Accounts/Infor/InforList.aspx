<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InforList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Infor.InforList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 45%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="panSaveInfor" runat="server">
        <table width="100%" border="1px"  >
        <tr >
            <td width="15%">
                <asp:Label ID="Label1" runat="server" Text="文字:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtBoxTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="15%" >
                <asp:Label ID="Label2" runat="server" Text="图片:"></asp:Label>
            </td>
            <td class="style1" >
                <asp:FileUpload ID="imgUploader" runat="server" />
                &nbsp;
                <asp:Button ID="btnUpload" runat="server" Text="上传" onclick="btnUpload_Click" />
            </td>
           
        </tr>
        <tr>
        <td>消息类型:</td>
        <td>
            <asp:DropDownList ID="dpnInfType" runat="server">
            <asp:ListItem Text="广告" Value="101" Selected="true" ></asp:ListItem>
            <asp:ListItem Text="通知" Value="102" ></asp:ListItem>
            <asp:ListItem Text="私人消息" Value="103" ></asp:ListItem>
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
            <td width="15%" >
                &nbsp;</td>
            <td class="style1" >
                <asp:Button ID="btnAdd" runat="server" Text="保存" onclick="btnAdd_Click" />
            </td>
        </tr>
        </table>
            &nbsp;&nbsp;
            <asp:Image ID="imgPre" runat="server" Height="45px" Width="600px" />
            <br />
            <br />
            <br />
        </asp:Panel>
    
    </div>
    <asp:Button ID="btnShowAdd" runat="server" Text="显示添加消息" 
        onclick="btnShowAdd_Click" />
    <br />
    <br />
    <br />
    <asp:GridView ID="ltvInfor" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" PageSize="6">
        <Columns>
            <asp:BoundField DataField="idinformation" HeaderText="idinformation"  Visible="false" ReadOnly="true"
                SortExpression="idinformation" />
           
            <asp:TemplateField HeaderText="发送者" SortExpression="from_id" >
                <ItemTemplate>
                    <asp:Label ID="labFromItem" runat="server" Text='<%# GetFromById(Eval("from_id")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="接收者" SortExpression="to_id" >
                <ItemTemplate>
                    <asp:Label ID="labToItem" runat="server" Text='<%# GetToById(Eval("to_id")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="content" HeaderText="内容" SortExpression="content" />
            
            <asp:TemplateField HeaderText="已读" SortExpression="readed" >
                <ItemTemplate>
                    <asp:Label ID="labReadItem" runat="server" Text='<%# GetReadById(Eval("readed")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="gen_time" HeaderText="生成时间" 
                SortExpression="gen_time" />

           <asp:TemplateField HeaderText="信息类型" SortExpression="infor_type" >
                <ItemTemplate>
                    <asp:Label ID="labInforTypeItem" runat="server" Text='<%# GetInforTypeById(Eval("infor_type")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="发布者" SortExpression="manager_id" >
                <ItemTemplate>
                    <asp:Label ID="labManaItem" runat="server" Text='<%# GetManagerById(Eval("manager_id")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
