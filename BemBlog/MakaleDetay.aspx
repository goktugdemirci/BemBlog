<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="BemBlog.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Article">
        <h2>
            <asp:Literal ID="ltrl_title" runat="server"></asp:Literal></h2>
        <hr />
        <div>
            <label>Yazar : </label>
            &nbsp:&nbsp<asp:Literal ID="ltrl_author" runat="server"></asp:Literal>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <label>Kategori : </label>
            &nbsp:&nbsp<asp:Literal ID="ltrl_category" runat="server"></asp:Literal>
        </div>
        <hr />
        <br />
        <asp:Image ID="img_max" runat="server" Style="width: 250px;" />
        <br />
        <asp:Literal ID="ltrl_content" runat="server"></asp:Literal>
        <br />
        <br />
        <div>
            <h2 style="text-align: center">Yorumlar</h2>
            <hr />
            <br />
            <asp:ListView ID="lv_comments" runat="server">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <label>Kullanıcı Adı : </label>
                    &nbsp:&nbsp<%# Eval("KullaniciAdi") %>
                    <br />
                    <%# Eval("YorumIcerik") %>
                    <br />
                    <hr />
                    <br />
                </ItemTemplate>
                <EmptyDataTemplate>
                    <label style="text-align: center">Henüz Yorum Yapılmadı.</label>
                    <br />
                </EmptyDataTemplate>
            </asp:ListView>
            <br />
            <asp:Panel ID="pnl_loggedout" runat="server">
                Yorum yapabilmek için <a href="GirisYap.aspx" style="text-decoration: none; color: orangered; font-size: 16pt;">Uye Girisi</a>&nbsp;Yapınız.
            </asp:Panel>
            <asp:Panel ID="pnl_loggedin" runat="server" Visible="false" CssClass="infoLabel">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                <asp:TextBox ID="tb_comment" runat="server" TextMode="MultiLine" CssClass="TextBox2"></asp:TextBox>
                <br />
                <br />
                <asp:LinkButton ID="lbtn_gonder" runat="server" OnClick="lbtn_gonder_Click" CssClass="buton">Yorum Gonder</asp:LinkButton>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
