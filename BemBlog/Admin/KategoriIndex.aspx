<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriIndex.aspx.cs" Inherits="BemBlog.Admin.KategoriIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_kategoriler" OnItemCommand="lv_kategoriler_ItemCommand" >
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kategori Adı</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KategoriAdi") %></td>
                <td>
                    <asp:LinkButton ID="lbtn_deletecomment" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='KategoriGuncelle.aspx?katid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("KategoriAdi") %></td>
                <td>
                    <asp:LinkButton ID="lbtn_deletecomment" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='KategoriGuncelle.aspx?katid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kategori Adı</th>
                    <th>
                        <img src="../Images/settings.png" width="20" />
                    </th>
                </tr>
                <tr>
                    <td colspan="2">Henüz Kategori Eklenmedi.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
