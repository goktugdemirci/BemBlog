<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="KullaniciIndex.aspx.cs" Inherits="BemBlog.Admin.KullaniciIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ListView runat="server" ID="lv_kullanicilar" OnItemCommand="lv_kullanicilar_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>E-Posta Adresi</th>
                    <th>Kullanıcı Yaş</th>
                    <th>Yorum Sayısı</th>
                    <th>Aktif Mi</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("DogumTarihi") %></td>
                <td>#</td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Evet" :"Hayır"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_kullaniciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='KullaniciGuncelle.aspx?makid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("DogumTarihi") %></td>
                <td>#</td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Evet" :"Hayır"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_kullaniciSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='KullaniciGuncelle.aspx?makid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>E-Posta Adresi</th>
                    <th>Kullanıcı Yaş</th>
                    <th>Yorum Sayısı</th>
                    <th>Aktif Mi</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Kullanici Eklenmedi.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
