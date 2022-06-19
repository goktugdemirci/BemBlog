<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleGuncelle.aspx.cs" Inherits="BemBlog.Admin.MakaleGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="pnl_info" Visible="false">
            <asp:Label runat="server" ID="lbl_message"></asp:Label>
        </asp:Panel>
        <div class="yarimForm" style="margin-left:20px">
            <div>
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="textbox" Style="font-size: 13pt; text-align:center; margin-left:50px" placeholder="Makale Başlığı"></asp:TextBox>
            </div>
            <br />
            <div>
                <label>Makale Kategorisi</label>
                <asp:DropDownList ID="ddl_category" runat="server" DataTextField="KategoriAdi" DataValueField="ID" style="float:right"></asp:DropDownList>
            </div>
            <br />
            
            <div>
                <label>Liste Görseli</label>
                <asp:Image ID="img_min" runat="server" Style="width: 80px;" />
                <asp:FileUpload ID="fu_min" runat="server" style="float:right"/>
            </div>
            <br />
            
            <div>
                <label>İçerik Görseli</label>
                <asp:Image ID="img_max" runat="server" Style="width: 80px;" />
                <asp:FileUpload ID="fu_max" runat="server" style="float:right"/>
            </div>
            <br />
            
            <div>
                <label>Makale Yayına Alınsın :</label>
                &nbsp &nbsp &nbsp &nbsp &nbsp 
                        <asp:CheckBox ID="cb_confirm" runat="server" Text="Onaylıyorum." Checked="false" />
            </div>
            <br />
            
            <div style="width: 200px; margin-left: 190px;">
                <asp:LinkButton ID="lbtn_makaleEkle" runat="server" CssClass="formButton" Text="Makale Güncelle" OnClick="lbtn_makaleEkle_Click"></asp:LinkButton>
            </div>
        </div>
        <div class="yarimForm" style="margin-left: 50px">
            <div>
                <label>Liste Görünümü</label>
                <br />
                <asp:TextBox ID="tb_list" runat="server" TextMode="MultiLine" MaxLength="300" CssClass="textbox" style="min-height:100px; width:100%"></asp:TextBox>
            </div>
            <div>
                <label>Tam Görünümü</label><br />
                <asp:TextBox ID="tb_tam" runat="server" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                <script ValidateRequest="false">
                    CKEDITOR.replace('ctl00$ContentPlaceHolder1$tb_tam');
                </script>
            </div>
        </div>
    </div>
</asp:Content>
