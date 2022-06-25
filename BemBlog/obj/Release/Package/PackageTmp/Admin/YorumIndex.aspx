<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="YorumIndex.aspx.cs" Inherits="BemBlog.Admin.YorumIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_yorumlar" OnItemCommand="lv_yorumlar_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0" style="width:48%;float:left;margin-left:10px;">
                <tr>
                    <th>KullanıcıAdı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Gönderildi</th>
                    <th>Yorum</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <%--<td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>--%>
                <td>
                    <asp:LinkButton ID="lbtn_aktifEt" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="aktif">AktifEt</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_kaliciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="kaliciSil">Sil</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <%--<td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>--%>
                <td>
                    <asp:LinkButton ID="lbtn_aktifEt" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="aktif">AktifEt</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_kaliciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="kaliciSil">Sil</asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0" style="width:48%;float:left;margin-left:10px;">
                <tr>
                    <th>KullanıcıAdı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Gönderildi</th>
                    <th>Yorum</th>
                    <%--<th>Durum</th>--%>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Yorum Eklenmedi.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView runat="server" ID="lv_aktifYorum" OnItemCommand="lv_aktifYorum_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0" style="width:48%;float:right;margin:0px 10px;">
                <tr>
                    <th>KullanıcıAdı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Gönderildi</th>
                    <th>Yorum</th>
                    <%--<th>Durum</th>--%>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik")%></td>
                <%--<td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>--%>
                <td>
                    <asp:LinkButton ID="lbtn_pasifEt" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="pasif">PasifEt</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_kaliciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="kaliciSil">Sil</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <%--<td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>--%>
                <td>
                    <asp:LinkButton ID="lbtn_pasifEt" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="pasif">PasifEt</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_kaliciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="kaliciSil">Sil</asp:LinkButton>
                </td>
            </tr>   
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0" style="width:48%;float:left;margin-left:10px;">
                <tr>
                    <th>KullanıcıAdı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Gönderildi</th>
                    <th>Yorum</th>
                    <%--<th>Durum</th>--%>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Yorum Eklenmedi.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
