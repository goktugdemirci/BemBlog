<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="BemBlog.Admin.KategoriGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="pnl_info" CssClass="info" Visible="false">
            <asp:Label ID="lbl_message" runat="server" />
        </asp:Panel>
        <br />
        <asp:TextBox ID="tb_kategoriAdi" runat="server" CssClass="textbox" placeholder="Kategori Adı Giriniz"></asp:TextBox>
        <asp:LinkButton ID="lbtn_kategoriGuncelle" runat="server" OnClick="lbtn_kategoriGuncelle_Click" Text="Kategori Guncelle" CssClass="formButton" />
    </div>
</asp:Content>
