<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="BemBlog.GirisYap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="panel" style="margin-top:50px">
            <br />
            <h3 style="font-size: 30pt; text-align:center">Kullanıcı Girişi</h3>
            <hr style="color: #F7F7F7; margin-top: 15px;" />
            <asp:Panel ID="pnl_mesaj" runat="server" CssClass="hata" Visible="false">
                <asp:Label ID="lbl_hata" runat="server"></asp:Label>
            </asp:Panel>
            <div>
                <asp:TextBox ID="tb_eposta" runat="server" CssClass="TextBoxLogin" Placeholder="E-Posta Adresiniz"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="TextBoxLogin" Placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="buton" Text="Giriş Yap" OnClick="lbtn_giris_Click"></asp:LinkButton>
            </div>
            <br />
            <div>
                <a href="#" class="link">Şifremi Unuttum</a>
            </div>

        </div>
    </div>

</asp:Content>
