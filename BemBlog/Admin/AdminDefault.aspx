<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="BemBlog.Admin.AdminDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_yoneticiler" OnItemCommand="lv_yoneticiler_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Yetki Adı</th>
                    <th>Adı</th>
                    <th>Soyadı</th>
                    <th>Kullanıcı Adı</th>
                    <th>E-Posta</th>
                    <th>
                        <img src="../Images/settings.png" width="20" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("Adi") %></td>
                <td><%#Eval("Soyadi") %></td>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:LinkButton ID="lbtn_deletecomment" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='YoneticiGuncelle.aspx?yonid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F8BDA9">
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("Adi") %></td>
                <td><%#Eval("Soyadi") %></td>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:LinkButton ID="lbtn_deletecomment" runat="server" CssClass="silButton" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>&nbsp;|&nbsp;
                    <a href='YoneticiGuncelle.aspx?yonid=<%# Eval("ID") %>' class="guncButton">Güncelle</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Yetki Adı</th>
                    <th>Adı</th>
                    <th>Soyadı</th>
                    <th>Kullanıcı Adı</th>
                    <th>E-Posta</th>
                    <th>
                        <img src="../Images/settings.png" width="20" />
                    </th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Yönetici Eklenmedi.</td>
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
                <td><%# (string)Eval("IsDeleted") =="False" ? "Evet" :"Hayır"%></td>
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
