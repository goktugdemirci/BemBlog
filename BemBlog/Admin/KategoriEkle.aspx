<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="BemBlog.Admin.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="pnl_info" CssClass="info" Visible="false">
            <asp:Label ID="lbl_message" runat="server" />
        </asp:Panel>
        <br />
        <asp:TextBox ID="tb_kategoriAdi" runat="server" CssClass="textbox" placeholder="Kategori Adı Giriniz"></asp:TextBox>
        <asp:LinkButton ID="lbtn_kategoriEkle" runat="server" OnClick="lbtn_kategoriEkle_Click" Text="Kategori Ekle" CssClass="formButton" />
    </div>
</asp:Content>
