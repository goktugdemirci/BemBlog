<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleIndex.aspx.cs" Inherits="BemBlog.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_makaleler" OnItemCommand="lv_makaleler_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Önizleme</th>
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
                <td><img src="../Images/<%#Eval("ThumbnailAdi") %>" alt="Makale Görseli" style="width:50px"/></td>
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
                <td><img src="../Images/<%#Eval("ThumbnailAdi") %>" alt="Makale Görseli" style="width:50px"/></td>
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
