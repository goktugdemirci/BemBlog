<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="BemBlog.Admin.AdminDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ListView runat="server" ID="lv_yorumlar" OnItemCommand="lv_yorumlar_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
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
            <table class="table" cellspacing="0">
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
    <br />
    <asp:ListView runat="server" ID="lv_makaleler" OnItemCommand="lv_makaleler_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Yazar Adı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Yazıldı</th>
                    <th>Yayında Mı</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("YetkiAdi") %>|<%#Eval("Adi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YuklemeTarih") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Evet" :"Hayır"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_makaleSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='MakaleGuncelle.aspx?makid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("YetkiAdi") %>|<%#Eval("Adi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YuklemeTarih") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Evet" :"Hayır"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_makaleSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='MakaleGuncelle.aspx?makid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Yazar Adı</th>
                    <th>Makale Kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Yazıldı</th>
                    <th>Yayında Mı</th>
                    <th>
                        <img src="../Images/settings.png" width="20" />
                    </th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Makale Eklenmedi.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
