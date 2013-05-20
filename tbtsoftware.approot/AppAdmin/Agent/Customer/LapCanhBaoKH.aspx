<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LapCanhBaoKH.aspx.cs" Inherits="MinhPham.Web.BepNhaBan.AppAdmin.Customer.LapCanhBaoKH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <link href="../../StyleLibrary/AdminStyles/LapCBKH.css" rel="stylesheet" type="text/css" />
    </head>
    <body style="background-color: #E3FEE2">
        <form id="form1" runat="server">
            <div id="iRightAccess" runat="Server" style="height: 100%; width: 100%;">
                <table style="border: 1px solid #9A9A9A; box-shadow: 5px 5px 0 rgba(223, 223, 223, 0.75); width: 527px;">
                    <tr>
                        <td class="firstCol" style="width: 17%">
                            <span>
                                <asp:Literal ID="ltr_ID" runat="server"></asp:Literal></span>
                        </td>
                        <td class="firstCol">
                            <span><asp:Literal ID="ltr_Name" runat="server"></asp:Literal></span>
                        </td>
                        <td class="firstCol" style="width: 27%;">
                            <span> <span><asp:Literal ID="ltr_Tel" runat="server"></asp:Literal></span>
                        </td>
                        <td class="firstCol" style="border-right: 1px solid #0085C2; width: 10%;">
                            <span><asp:Literal ID="ltr_Gas" runat="server"></asp:Literal></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="secondCol">
                            <span style="font-size: 17px;"><asp:Literal ID="ltr_Address" runat="server"></asp:Literal></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="secondCol">
                            <span style="font-size: 17px; margin-right: 20px;">Lý do: </span>
                            <asp:TextBox CssClass="input-txt" ID="txt_LyDo" runat="server" Font-Size="15pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="order">
                    <asp:LinkButton ID="btn_LapCanhBaoKH" runat="server" 
                                    onclick="btn_LapCanhBaoKH_Click">Xác nhận</asp:LinkButton>
                    <a href="danh-sach-khach-hang" >Hủy bỏ</a>
                </div>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td id="idNotPermissionAccess" runat="server">
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>