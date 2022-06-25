<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="YorumIndex.aspx.cs" Inherits="BemBlog.Admin.YorumIndex" %>
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
                    <th>Durum</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %>|<%#Eval("Adi") %></td>
                <td><%#Eval("MakaleKategori") %></td>
                <td><%#Eval("MakaleAdi") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_yorumSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_onayla" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="onayla">Yayınla</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("KullaniciAdi") %>|<%#Eval("Adi") %></td>
                <td><%#Eval("MakaleKategori") %></td>
                <td><%#Eval("MakaleAdi") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_yorumSil" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtn_onayla" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="onayla">Yayınla</asp:LinkButton>
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
                    <th>Durum</th>
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
