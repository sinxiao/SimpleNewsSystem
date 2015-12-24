<%@ Page Title="news" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WoeMobile.Web.news.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="idnews" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="intro" HeaderText="intro" SortExpression="intro" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="gen_time" HeaderText="gen_time" SortExpression="gen_time" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="writer" HeaderText="writer" SortExpression="writer" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="title" HeaderText="title" SortExpression="title" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="content" HeaderText="content" SortExpression="content" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="itemid" HeaderText="itemid" SortExpression="itemid" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="passcheked" HeaderText="passcheked" SortExpression="passcheked" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="keyword" HeaderText="keyword" SortExpression="keyword" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="default_news" HeaderText="default_news" SortExpression="default_news" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="clicked" HeaderText="clicked" SortExpression="clicked" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="news_url" HeaderText="news_url" SortExpression="news_url" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="image_url" HeaderText="image_url" SortExpression="image_url" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="comment_sum" HeaderText="comment_sum" SortExpression="comment_sum" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="idnews" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="idnews" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
