<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="YoneticiEkle.aspx.cs" Inherits="BemBlog.Admin.YoneticiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="pnl_info" Visible="false">
            <asp:Label runat="server" ID="lbl_message"></asp:Label>
        </asp:Panel>
        <div>
            <table class="table">
                <tr>
                    <td>
                        <asp:TextBox ID="tb_adi" runat="server" CssClass="textbox" placeholder="Yönetici Adı Giriniz"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tb_soyadi" runat="server" CssClass="textbox" placeholder="Yönetici Soyadı Giriniz"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textbox" placeholder="Kullanıcı Adı Giriniz"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tb_eposta" runat="server" CssClass="textbox" placeholder="epostanız@ornek.com"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="textbox" TextMode="Password" placeholder="Şifrenizi Giriniz"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="rb_admin" Text="Yonetici" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                            <asp:RadioButton ID="rb_yazar" Text="Yazar" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        <asp:LinkButton ID="lbtn_add" runat="server" OnClick="lbtn_add_Click" Text="Yönetici Ekle" CssClass="formButton"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>








    </div>
</asp:Content>
