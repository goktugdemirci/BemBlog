<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BemBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_articles" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="Article">
                <h2 style="text-align: center"><%# Eval("Baslik") %></h2>
                <br />
                <hr />
                <br />
                <div class="SubInfo">
                    <label><%# Eval("YetkiAdi") %></label>
                    📝<label><%# Eval("Adi") %></label>
                    <div style="float: right">
                        <label>Yayınlandı 📅 <%# Eval("YuklemeTarih") %></label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <label>Kategori 📌 <%# Eval("KategoriAdi") %></label>
                    </div>

                </div>
                <br />
                <hr />
                <br />
                <img src="Images/<%#Eval("ThumbnailAdi")%>" style="margin-top: 5px; max-height: 250px; width: 20%; float: left;" />
                <p style="float: right; width: 75%; margin-top: 75px;">
                    <%# Eval("Ozet") %>&nbsp;
                    <a href='MakaleDetay.aspx?makid=<%# Eval("ID") %>' style="text-decoration: none; color: #046380;">Devamını Oku..</a>
                </p>

            </div>
            <div class="AdBanner">
                <img src="Images/cat-computer.gif" />
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
