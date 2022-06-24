<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="YeniKayit.aspx.cs" Inherits="BemBlog.YeniKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <label style="float: left; margin-top: 10px; color: #EFECCA; font-weight: 900">Yeni Kullanıcı&nbsp;&nbsp;&nbsp;</label>
        <ul class="breadcrumb" style="float: right">
            <li><a href="#">Anasayfa</a></li>
            <li><a href="#">Yeni Kayıt</a></li>
            <li>Kayıt Formu</li>
        </ul>
        <br />
        <hr />
        <br />
        <asp:TextBox ID="tb_eposta" runat="server" CssClass="TextBox" Placeholder="E-Posta Adresiniz"></asp:TextBox>
        <br />
        <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="TextBox" Placeholder="Kullanıcı Adınız"></asp:TextBox>
        <br />
        <label style="float: left; margin-left: 200px; margin-top: 20px;">Doğum Tarihiniz&nbsp;</label>
        <asp:TextBox ID="dtp_dogumTarihi" runat="server" TextMode="Date" CssClass="TextBox"></asp:TextBox>
        <br />
        <asp:TextBox ID="tb_sifre" runat="server" CssClass="TextBox" TextMode="Password" PlaceHolder="Şifrenizi Giriniz"></asp:TextBox>
        <br />
        <asp:TextBox ID="tb_sifre2" runat="server" CssClass="TextBox" TextMode="Password" Placeholder="Şifrenizi Tekrar Giriniz"></asp:TextBox>
        <br />
        <asp:LinkButton ID="ltbn_yeniKayit" runat="server" CssClass="buton" Text="Gönder" OnClick="ltbn_yeniKayit_Click"></asp:LinkButton>

    </div>
</asp:Content>
