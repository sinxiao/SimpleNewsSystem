<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageByLocationList.aspx.cs" Inherits="WoeMobile.Web.Admin.Accounts.Picture.ImageByLocationList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:Button Text="添加图片" ID="btnUploadImg" runat="server" 
        onclick="btnUploadImg_Click"   />

    <asp:Panel ID="panalUpload" runat="server">
        <div style="width:100%; margin:10px auto;">
            <asp:Label ID="LblMessage" runat="server" Width="100%" ForeColor="#FF0033" 
            Font-Bold="True" Font-Size="Small" />
            <table border="1"  bordercolor="gray" style="border-collapse: collapse;">
                <tr>
                    <td style="text-align: center; font-size:10pt; font-weight:bold; color:DimGray;">
                        批量上传文件 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Pan_UpFile" runat="server" Height="200px" ScrollBars="Auto" 
                  Width="250px">
                            <table id="Tab_UpDownFile" runat="server" cellpadding="0" cellspacing="0" 
                     enableviewstate="true">
                                <tr>
                                    <td style="width: 100px; height: 30px">
                                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnAdd" runat="server" Text="添加文件" OnClick="BtnAdd_Click" 
                  BorderColor="Gray" BorderWidth="1px" />
                        <asp:Button ID="BtnUpFile" runat="server" OnClick="BtnUpFile_Click" Text="上传文件" 
                  BorderColor="Gray" BorderWidth="1px" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Repeater ID="repeaterImage" runat="server" >
    <HeaderTemplate><table width="98%"></HeaderTemplate>
    <ItemTemplate> <tr style="width:100%">
                            <td width="25%" align="center">
                            <asp:Image Width="185" Height="136" ID="imageNews" runat="server" ImageUrl='<%# getImagePath(Container.DataItem, "1") %>'  />

                            
                                </td>
                                <td width="25%" align="center">
                            <asp:Image Width="185" Height="136" ID="image1" runat="server" ImageUrl='<%# getImagePath(Container.DataItem, "2") %>'  />
                                </td>
                                <td width="25%" align="center">
                            <asp:Image Width="185" Height="136" ID="image2" runat="server" ImageUrl='<%# getImagePath(Container.DataItem, "3") %>'  />
                                </td>
                                <td width="25%" align="center">
                            <asp:Image Width="185" Height="136" ID="image3" runat="server" ImageUrl='<%# getImagePath(Container.DataItem, "4") %>'  />
                                </td>
                          </tr></ItemTemplate>
    <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
