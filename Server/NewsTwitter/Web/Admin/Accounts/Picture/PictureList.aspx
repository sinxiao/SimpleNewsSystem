<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PictureList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Picture.PictureList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
        <td>
            <asp:Label ID="labKeyWord" runat="server" Text="关键字："></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txtBoxTraceKeyWord" runat="server"></asp:TextBox>
            </td><td>
                <asp:Button ID="btnTraceKeyWordSearch" runat="server" Text="搜索" />
            </td>
            <td>
                <asp:Button ID="btnTraceKeyWordAdd" runat="server" Text="添加图片夹" 
                    onclick="btnAdd_Click" />
            </td>
        </tr>
        </table>
        <br />
        <asp:GridView ID="gdvTraceList"  BackColor="White" BorderColor="#DEDFDE"
      BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" 
         GridLines="Vertical" Width="98%" runat="server" onrowcommand="gdvTraceList_RowCommand" 
            onselectedindexchanged="gdvTraceList_SelectedIndexChanged" 
            onrowupdating="gdvTraceList_RowUpdating" 
            onrowcancelingedit="gdvTraceList_RowCancelingEdit" 
            onrowediting="gdvTraceList_RowEditing" AllowPaging="True" PageSize="6">

            <Columns>
                <asp:BoundField DataField="idtraces"  ReadOnly="true" Visible="false"
                    SortExpression="idtraces" />    
                <asp:BoundField DataField="trace_name" HeaderText="名字" 
                    SortExpression="trace_name" />
                
                <asp:TemplateField  HeaderText="创建者"  SortExpression="uid" >
                    <ItemTemplate>
                        <asp:Label ID="labUser" runat="server" Text='<%# GetUnameById(Eval("uid")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

              <asp:BoundField DataField="build_time" ReadOnly="true" HeaderText="创建时间" 
                    SortExpression="build_time" />

                <asp:TemplateField HeaderText="总数"  SortExpression="idtraces" >
                    <ItemTemplate>
                        <asp:Label ID="labSum" runat="server" Text='<%# GetLocSumById(Eval("idtraces")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            <asp:TemplateField ShowHeader="false"  SortExpression="idtraces" >
                <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnView" runat="server" CommandName="View" Text="详细" CommandArgument='<%# Eval("idtraces") %>'></asp:LinkButton>
                 </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField ShowHeader="false"  SortExpression="idtraces" >
                <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDel" runat="server" CommandName="Del" Text="删除" CommandArgument='<%# Eval("idtraces") %>'></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>

                <asp:CommandField CancelText="取消"  EditText="编辑" SelectText="选择" 
                    ShowEditButton="True" UpdateText="更新" />
                

            </Columns>

         <FooterStyle BackColor="#CCCC99" />
         <RowStyle BackColor="#F7F7DE" />
         <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
    </div>
    <br />
    <asp:Panel ID="panelAddTrace" runat="server" Height="100%">
        <table>
            <tr>
                <td>
                    <asp:Label ID="labKeyWord0" runat="server" Text="名字："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="关键字："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxKeyWord" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="备注："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxDemo" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSaveTraces" runat="server" onclick="btnSaveTraces_Click" 
                        Text="保存类别" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSaveTracceHide" runat="server" 
                        onclick="btnSaveTracceHide_Click" Text="隐藏" />
                </td>
                <td>
                    <asp:Label ID="labStatus" runat="server"></asp:Label>
                  </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
                    <asp:Button ID="btnSaveLocation" runat="server" onclick="btnSaveLocation_Click1" 
                        Text="显示添加主题" />
    <asp:Panel ID="panelAddLocation" runat="server" Height="100%" Visible="False">
        <table>
         <tr>
                <td>
                   
                </td>
                <td>
                   添加主题
                </td>
                <td>
                   </td>
                <td>
                   </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labKeyWord1" runat="server" Text="名字："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxLocName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
             
              <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="备注："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBoxLocDemo" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSaveLoc" runat="server" onclick="btnSaveLoc_Click" 
                        Text="添加主题" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnLocHide" runat="server" 
                        onclick="btnLocHide_Click" Text="隐藏" />
                </td>
                <td>
                    <asp:Label ID="lalLocStatu" runat="server"></asp:Label>
                  </td>
                <td>
                    <asp:Button ID="btnAddImage" runat="server" onclick="btnAddImage_Click" 
                        Text="添加" Visible="False" />
                  </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
        <asp:GridView ID="gdvPicList0"  BackColor="White" BorderColor="#DEDFDE"
      BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" 
         GridLines="Vertical" Width="98%" runat="server" 
        ondatabinding="gdvPicList0_DataBinding" 
        onrowcommand="gdvPicList0_RowCommand" onrowediting="gdvPicList0_RowEditing" 
        onrowupdating="gdvPicList0_RowUpdating">

            <Columns>

                <asp:BoundField DataField="Lname" HeaderText="名字" SortExpression="Lname" />
               
                <asp:BoundField DataField="Demo" HeaderText="说明" SortExpression="Demo" />
                
                
                <asp:BoundField DataField="datetime" ReadOnly="true" HeaderText="创建日期" 
                    SortExpression="datetime" />
                
                <asp:TemplateField  HeaderText="创建者"  SortExpression="uid" >
                    <ItemTemplate>
                        <asp:Label ID="labUser" runat="server" Text='<%# GetUnameById(Eval("uid")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField  HeaderText="类别"  SortExpression="trace_id" >
                    <ItemTemplate>
                        <asp:Label ID="labTrace" runat="server" Text='<%# GetTraceNameById(Eval("trace_id")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ShowHeader="false"  SortExpression="idlocations" >
                <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnLocaionView" runat="server" CommandName="View" Text="详细" CommandArgument='<%# Eval("idlocations") %>'></asp:LinkButton>
                 </ItemTemplate>
            </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" />

            </Columns>

         <FooterStyle BackColor="#CCCC99" />
         <RowStyle BackColor="#F7F7DE" />
         <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
         <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </form>
</body>
</html>
