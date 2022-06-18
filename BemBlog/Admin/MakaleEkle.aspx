<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="BemBlog.Admin.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="pnl_info" Visible="false">
            <asp:Label runat="server" ID="lbl_message"></asp:Label>
        </asp:Panel>
        <div class="yarimForm">
            <div>
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="textbox" Style="font-size: 13pt;" placeholder="Makale Başlığı"></asp:TextBox>
            </div>
            <hr />
            <div>
                <label>Category of Article</label>
                <asp:DropDownList ID="ddl_category" runat="server" CssClass="textbox" DataTextField="KategoriAdi" DataValueField="ID"></asp:DropDownList>
            </div>
            <hr />
            <div>
                <label>Min Img</label>
                <asp:FileUpload ID="fu_min" runat="server" />
            </div>
            <hr />
            <div>
                <label>Max Img</label>
                <asp:FileUpload ID="fu_max" runat="server" />
            </div>
            <hr />
            <div>
                <label>I agree to the Terms of Services</label>
                &nbsp &nbsp &nbsp &nbsp &nbsp 
                        <asp:CheckBox ID="cb_confirm" runat="server" Text=' YES !' Checked="false" />
            </div>
            <hr />
            <div style="width: 200px; margin-left: 190px;">
                <asp:LinkButton ID="lbtn_makaleEkle" runat="server" CssClass="AddButton" Text="Makale Ekle" OnClick="lbtn_makaleEkle_Click"></asp:LinkButton>
            </div>
        </div>
        <div class="yarimForm" style="margin-left: 10px">
            <div>
                <label>Liste Görünümü</label>
                <br />
                <asp:TextBox ID="tb_list" runat="server" TextMode="MultiLine" MaxLength="300" CssClass="textbox" Style="width: 570px"></asp:TextBox>
            </div>
            <div>
                <label>Tam Görünümü</label><br />
                <asp:TextBox ID="tb_tam" runat="server" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                <script>
                    CKEDITOR.replace('ctl00$ContentPlaceHolder1$tb_tam');
                </script>
            </div>
        </div>
    </div>

</asp:Content>
