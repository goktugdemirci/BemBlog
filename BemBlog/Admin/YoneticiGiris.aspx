<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="BemBlog.Admin.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BemBlog Giriş</title>
    
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Staatliches&display=swap" rel="stylesheet"/>
    <link href="../CSS/AdminLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="panel">
                <img src="../Images/bem.png" alt="resimYazisi" />
                <h3 style="font-size: 30pt;">Admin Login</h3>
                <hr style="color: #F7F7F7; margin-top: 15px;" />
                <asp:Panel ID="pnl_mesaj" runat="server" CssClass="hata" Visible="false">
                    <asp:Label ID="lbl_hata" runat="server"></asp:Label>
                </asp:Panel>
                <div>
                    <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="textbox" Placeholder="E-Posta Adresiniz"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="textbox" Placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="buton" Text="Giriş Yap" OnClick="lbtn_giris_Click"></asp:LinkButton>
                </div>
                <div>
                    <a href="#" class="link">Şifremi Unuttum</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
