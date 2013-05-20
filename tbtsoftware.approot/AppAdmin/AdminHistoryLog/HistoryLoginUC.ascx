<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HistoryLoginUC.ascx.cs" Inherits="bnb.approot.AppAdmin.AdminHistoryLog.HistoryLoginUC" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th class="Title" align="left">
            + QUẢN LÝ NHẬT KÝ ĐĂNG NHẬP HỆ THỐNG
        </th>
    </tr>
    <tr>
        <td valign="top">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GrvLogLogịn" runat="server" AutoGenerateColumns="False" Width="100%"
                                  AllowPaging="True" OnPageIndexChanging="GrvLogLogin_PageIndexChanging" PageSize="25">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="STT" runat="server">STT</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="indexNum" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="Group" runat="server">Thời gian</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="verticalrow"/>
                                <ItemTemplate>
                                    <%#this.objComm.ConvertDateTime(Eval("DateTime").ToString()) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="Group" runat="server">Tên đăng nhập</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "UserName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="Group" runat="server">Địa chỉ IP</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "Ip") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle CssClass="SubTitle" />
                                <HeaderTemplate>
                                    <asp:Label ID="Group" runat="server">Trạng thái</asp:Label>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                <ItemTemplate>
                                    <%#((bool)Eval("Status")) ? "Đăng nhập thành công" : "<font color='red'>Đăng nhập thất bại</font>" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="5%" CssClass="SubTitle" Height="20px" />
                                <HeaderTemplate>
                                    <input onclick=" JavaScript:checkDeleteAll(this.form); " type="checkbox" name="chb_DeleteAll"
                                           title="Chọn tất">
                                </HeaderTemplate>
                                <ItemStyle CssClass="ListContent" Height="20px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <input type="checkbox" value="delete" name="chbDelete<%#DataBinder.Eval(Container.DataItem, "id") %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="#EFF0F3" />
                        <HeaderStyle BackColor="#999966" ForeColor="White" Height="30px" />
                        <PagerSettings FirstPageText="Trang đầu" LastPageText="Trang cuối" NextPageText="Tiếp theo"
                                       PreviousPageText="Trang trước" />
                        <PagerStyle HorizontalAlign="Left" Width="100%" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <th class="Title" align="left">
            <asp:Button CssClass="button" OnClientClick=" return checkDelete(this.form) " ID="bntDel"
                        runat="server" Text="Xóa bản ghi" OnClick="bntDel_Click" />
            <asp:LinkButton ID="lbtn_Back" OnClientClick=" javascript:history.back(); return false; " CssClass="toolbar" runat="server"><span title="Back" class="Icon-32-Back"></span>Quay lại</asp:LinkButton>
        </th>
    </tr>
</table>