<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="UrunIslemleri.aspx.cs" Inherits="E_Shop.UrunIslemleri" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">
        <div class="box">
            <form method="post" action="checkout2.html">
                <h1>Admin İşlemleri</h1>
                <ul class="nav nav-pills nav-justified">
                    <li class="nav nav-pills nav-justified"><a href="GunlukRaporlar.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Rapolar</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="kullanıcıIslemlerı.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Kullanıcı İşlemleri</a>
                    </li>
                    <li class="active"><a href="UrunIslemleri.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Ürün İşlemleri</a>
                    </li>
                  
                </ul>
                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnMarkaIslemleri" runat="server" Text="Marka İşlemleri" class="btn btn-primary btn-sm" OnClick="btnMarkaIslemleri_Click" />

                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnKategoriIslemleri" runat="server" Text="Kategori İşlemleri" class="btn btn-primary btn-sm" OnClick="btnKategoriIslemleri_Click" />
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnAKategoriIslemleri" runat="server" Text="Alt Kategori İşlemleri" class="btn btn-primary btn-sm" OnClick="btnAKategoriIslemleri_Click" />
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnRenkIslemleri" runat="server" Text="Renk İşlemleri" class="btn btn-primary btn-sm" OnClick="btnRenkIslemleri_Click" />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Button ID="btnUrunIslemleri" runat="server" Text="Urun İşlemleri" class="btn btn-primary btn-sm" OnClick="btnUrunIslemleri_Click" />
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlMarkaIslem" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Panel ID="pnlMarkaEkle" runat="server" Visible="False"> <table>
                                    <tr><td><span>                                        
                                        Marka Adı :</span></td><td>
                                        <asp:TextBox ID="txtMarkaAd" runat="server"></asp:TextBox></td></tr>
                                    <tr><td></td><td colspan="2" style="float:right">
                                        <asp:Button ID="btnMarkaKaydet"  class="form-control" OnClick="btnMarkaKaydet_Click" runat="server" Text="Kaydet" /></td></tr>
                                    <tr><td>
                                        <asp:Label ID="lblMarkaMesaj" runat="server" Text="" ></asp:Label></td></tr>
                                </table></asp:Panel>
                                <asp:Button ID="btnYeniMarka" runat="server" OnClick="btnYeniMarka_Click"  class="btn btn-primary btn-sm" Text="Yeni Marka Ekle" />
                                <asp:GridView ID="gvMarkalar" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvMarkalar_SelectedIndexChanged" Width="358px">
                                    <Columns>
                                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" />
                                        <asp:BoundField DataField="MarkaAd" HeaderText="MarkaAd" />
                                    </Columns>
                                </asp:GridView>

                                <asp:DetailsView ID="dvDetailsMarklaar" runat="server" AutoGenerateRows="False" DataKeyNames="id" Height="50px" Width="359px" OnItemUpdating="dvDetailsMarklaar_ItemUpdating" OnModeChanging="dvDetailsMarklaar_ModeChanging" OnItemDeleting="dvDetailsMarklaar_ItemDeleting" OnItemInserting="dvDetailsMarklaar_ItemInserting">
                                    <Fields>
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:TemplateField HeaderText="MarkaAd" SortExpression="MarkaAd">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGMarkaAd" runat="server" Text='<%# Bind("MarkaAd") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtEMarkaAd" runat="server" Text='<%# Bind("MarkaAd") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MarkaAd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField CancelText="Vazgeç" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" NewText="Yeni" SelectText="Seç" UpdateText="Güncelle" />
                                    </Fields>
                                </asp:DetailsView>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnpKategoriIslem" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                 <asp:Panel ID="pnlKategoriEkle" runat="server" Visible="False"> <table>
                                    <tr><td><span>                                        
                                        Kategori Adı :</span></td><td>
                                        <asp:TextBox ID="txtKategoriAd" runat="server"></asp:TextBox></td></tr>
                                    <tr><td></td><td colspan="2" style="float:right">
                                        <asp:Button ID="btnKategoriKaydet" OnClick="btnKategoriKaydet_Click" class="form-control"  runat="server" Text="Kaydet" /></td></tr>
                                    <tr><td>
                                        <asp:Label ID="lblKatmesaj" runat="server" Text="" ></asp:Label></td></tr>
                                </table></asp:Panel>
                                <asp:Button ID="btnYeniKategori" runat="server" OnClick="btnYeniKategori_Click"  class="btn btn-primary btn-sm" Text="Yeni Kategori Ekle" />
                                <asp:GridView ID="gvKategoriler" runat="server" AutoGenerateColumns="False" Width="358px" OnSelectedIndexChanged="gvKategoriler_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" />
                                        <asp:BoundField DataField="KategoriAd" HeaderText="KategoriAd" />
                                    </Columns>
                                </asp:GridView>

                                <asp:DetailsView ID="dvDetayKategoriler" runat="server" AutoGenerateRows="False" DataKeyNames="id" Height="50px" Width="359px" OnItemUpdating="dvDetayKategoriler_ItemUpdating" OnItemDeleting="dvDetayKategoriler_ItemDeleting" OnItemInserting="dvDetayKategoriler_ItemInserting" OnModeChanging="dvDetayKategoriler_ModeChanging">
                                    <Fields>
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:TemplateField HeaderText="KategoriAd" SortExpression="KategoriAd">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGKategoriAd" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtEKategoriAd" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField CancelText="Vazgeç" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" NewText="Yeni" SelectText="Seç" UpdateText="Güncelle" />
                                    </Fields>
                                </asp:DetailsView>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlAKategoriIslem" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                 <asp:Panel ID="pnlAKategoriEkle" runat="server" Visible="False"> <table>
                                    <tr><td><asp:Label ID="lblKategori" runat="server" Text="Label" Visible="False">Kategori Seçiniz : </asp:Label></td>
                                        <td><asp:DropDownList ID="ddlKategoriler" runat="server" Width="128px" Visible="False" AutoPostBack="True" DataTextField="KategoriAd" DataValueField="id" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged"></asp:DropDownList></td></tr>
                                      <tr><td><span>                                        
                                        Giyim Adı :</span></td><td>
                                        <asp:TextBox ID="txtAKategoriAd" runat="server"></asp:TextBox></td></tr>
                                    <tr><td></td><td colspan="2" style="float:right">
                                        <asp:Button ID="btnAKategoriKaydet" class="form-control" OnClick="btnAKategoriKaydet_Click"  runat="server" Text="Kaydet" /></td></tr>
                                    <tr><td>
                                        <asp:Label ID="lblAltKatmesaja" runat="server" Text="" ></asp:Label></td></tr>
                                </table></asp:Panel>
                                <asp:Button ID="btnYeniAltKategori" runat="server" OnClick="btnYeniAltKategori_Click" class="btn btn-primary btn-sm" Text="Yeni Kategori Ekle" />
                                <asp:GridView ID="gvAKategoriIslem" runat="server" AutoGenerateColumns="False" Width="358px" OnSelectedIndexChanged="gvAKategoriIslem_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" />
                                        <asp:BoundField DataField="GiyimAd" HeaderText="GiyimAd" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                          
                                <asp:DetailsView ID="dvAKategori" runat="server" AutoGenerateRows="False" DataKeyNames="id" Height="50px" Width="359px" OnModeChanging="dvAKategori_ModeChanging" OnItemUpdating="dvAKategori_ItemUpdating" OnItemDeleting="dvAKategori_ItemDeleting" OnItemInserting="dvAKategori_ItemInserting">
                                    <Fields>

                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:TemplateField HeaderText="Kategori">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGAKategoriAd" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtEAKategoriAd" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("KategoriAd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GiyimAd" SortExpression="GiyimAd">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGAGiyimAd" runat="server" Text='<%# Bind("GiyimAd") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtEAGiyimAd" runat="server" Text='<%# Bind("GiyimAd") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("GiyimAd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField CancelText="Vazgeç" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" NewText="Yeni" SelectText="Seç" UpdateText="Güncelle" />
                                    </Fields>
                                </asp:DetailsView>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlRenkIslem" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                 <asp:Panel ID="pnlRenkEkle" runat="server" Visible="False"> <table>
                                    <tr><td><span>                                        
                                        Renk Adı :</span></td><td>
                                        <asp:TextBox ID="txtRenkAd" runat="server"></asp:TextBox></td></tr>
                                    <tr><td></td><td colspan="2" style="float:right">
                                        <asp:Button ID="btnRenkAdKaydet"  class="form-control" OnClick="btnRenkAdKaydet_Click" runat="server" Text="Kaydet" /></td></tr>
                                     <tr><td>
                                        <asp:Label ID="lblRenkMesaj" runat="server" Text="" ></asp:Label></td></tr>
                                </table></asp:Panel>
                                <asp:Button ID="btnYeniRenk" runat="server" OnClick="btnYeniRenk_Click"  class="btn btn-primary btn-sm" Text="Yeni Marka Ekle" />
                                <asp:GridView ID="gvRenkler" runat="server" AutoGenerateColumns="False" Width="358px" OnSelectedIndexChanged="gvRenkler_SelectedIndexChanged">
                                    <Columns>
                                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" />
                                        <asp:BoundField DataField="RenkAd" HeaderText="RenkAd" />
                                    </Columns>
                                </asp:GridView>

                                <asp:DetailsView ID="dvRenkler" runat="server" AutoGenerateRows="False" DataKeyNames="id" Height="50px" Width="359px" OnItemDeleting="dvRenkler_ItemDeleting" OnItemInserting="dvRenkler_ItemInserting" OnItemUpdating="dvRenkler_ItemUpdating" OnModeChanging="dvRenkler_ModeChanging">
                                    <Fields>
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:TemplateField HeaderText="RenkAd" SortExpression="RenkAd">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGRenkAd" runat="server" Text='<%# Bind("RenkAd") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="txtERenkAd" runat="server" Text='<%# Bind("RenkAd") %>'></asp:TextBox>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("RenkAd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField CancelText="Vazgeç" DeleteText="Sil" EditText="Düzenle" InsertText="Ekle" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" NewText="Yeni" SelectText="Seç" UpdateText="Güncelle" />
                                    </Fields>
                                </asp:DetailsView>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlUrunIslemlerı" runat="server" Visible="False">
                    <asp:Panel ID="pnlUrunEkle" runat="server">
                                  <div class="box">  
                                    <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="state">Cinsiyet</label><asp:Label ID="lblID" runat="server" Text="" Visible="False"></asp:Label>
                                                <asp:DropDownList ID="ddlCinsiyet" runat="server" CssClass="form-control" DataTextField="cinsiyet" DataValueField="id"></asp:DropDownList>
                                            </div>
                                        </div>
                                        
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="zip">Metaryali</label>
                                                <asp:TextBox ID="txtMetaryali" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="state">Adet</label>
                                                <asp:TextBox ID="txtAdet" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-6 col-md-3">
                                                <div class="form-group">
                                                    <label for="country">Fiyat</label>
                                                    <asp:TextBox ID="txtFiyat" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="city">Markası</label>
                                                <asp:DropDownList ID="ddlMarkasi" runat="server" class="form-control" DataTextField="MarkaAd" DataValueField="id" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="zip">Kategorisi</label>
                                                 <asp:DropDownList ID="ddlKategorisi" runat="server" class="form-control" DataTextField="KategoriAd" DataValueField="id" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="state">Rengi</label>
                                                  <asp:DropDownList ID="ddlRengi" runat="server" class="form-control" DataTextField="RenkAd" DataValueField="id" ></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-6 col-md-3">
                                                <div class="form-group">
                                                    <label for="country">Alt Kategori</label>
                                                    <asp:DropDownList ID="ddlAltKategori" runat="server" class="form-control" DataTextField="GiyimAd" DataValueField="id" ></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="city">Yeni Mi</label>
                                                <asp:CheckBox ID="cbYeniMi"  runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="zip">Vitrin</label>
                                                 <asp:CheckBox ID="cbVitrin"  runat="server" />
                                            </div>
                                        </div>
                                               <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="city">ÜrÜn Tanımı</label>
                                                <asp:TextBox ID="txtUTanimi" CssClass="auto-style1" runat="server" Height="74px" TextMode="MultiLine" Width="353px"></asp:TextBox>
                                            </div>
                                        </div>                                 
                                    </div>
                                      <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="city">Resim Bir</label>
                                                <asp:TextBox ID="txtResimBir" runat="server" Visible="False"></asp:TextBox><br />
                                                <asp:FileUpload ID="fuResimBir" runat="server" />
                                            </div>
                                        </div></div>
                                        <div class="row">
                                        <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="zip">Resim İki</label> <asp:TextBox ID="txtResimİki" runat="server" Visible="False"></asp:TextBox><br />
                                                 <asp:FileUpload ID="fuResimİki" runat="server" />
                                            </div>
                                        </div></div>
                                        <div class="row">
                                               <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                                <label for="city">Resim Üç</label> <asp:TextBox ID="txtResimUc" runat="server" Visible="False"></asp:TextBox><br />
                                                <asp:FileUpload ID="fuResimUc"  runat="server" />
                                            </div>
                                        </div>                                 
                                    </div>
                                      <div class="row">
                                               <div class="col-sm-6 col-md-3">
                                            <div class="form-group">
                                               
                                                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-default btn-sm btn-primary" OnClick="btnKaydet_Click"/>||                                                                                               
                                                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-default btn-sm btn-primary" OnClick="btnGuncelle_Click" />
                                                <asp:Label ID="lblUrunMesaj" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>                                 
                                    </div>
                                  </div>
                                </asp:Panel>
                    <div class="box">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:GridView ID="gvUrunler" runat="server" AutoGenerateColumns="False" Width="625px" DataKeyNames="id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="gvUrunler_SelectedIndexChanged" OnRowDeleting="gvUrunler_RowDeleting">
                                    <Columns>
                                        <asp:CommandField CancelText="Vazgeç" InsertText="Ekle" NewText="Yeni" SelectText="Seç" ShowSelectButton="True" UpdateText="Güncelle" />
                                        <asp:CommandField CancelText="Vazgeç" DeleteText="Sil" EditText="Düzelt" ShowDeleteButton="True" />
                                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                        <asp:BoundField DataField="MarkaId" HeaderText="MarkaId" SortExpression="MarkaId">
                                            <ItemStyle Width="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="KategoriID" HeaderText="KategoriID" SortExpression="KategoriID" />
                                        <asp:BoundField DataField="UrunKatId" HeaderText="UrunKatId" SortExpression="UrunKatId">
                                            <ItemStyle Width="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RenkId" HeaderText="RenkId" SortExpression="RenkId">
                                            <ItemStyle Width="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" SortExpression="Fiyat" />
                                        <asp:BoundField DataField="Adet" HeaderText="Adet" SortExpression="Adet" />
                                        <asp:BoundField DataField="ResimBir" HeaderText="ResimBir" SortExpression="ResimBir" />
                                        <asp:BoundField DataField="UrunTanimi" HeaderText="UrunTanimi" SortExpression="UrunTanimi" />
                                        <asp:BoundField DataField="UrunMetaryali" HeaderText="UrunMetaryali" SortExpression="UrunMetaryali" />
                                    </Columns>
                                </asp:GridView>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EShopConnectionString %>" DeleteCommand="DELETE FROM [Urunler] WHERE [id] = @id" InsertCommand="INSERT INTO [Urunler] ([MarkaId], [UrunKatId], [RenkId], [Fiyat], [Adet], [ResimBir], [Resimİki], [ResimUc], [UrunTanimi], [UrunMetaryali], [BendenId], [YeniMi], [Vitrin], [CinsiyetId], [KategoriID]) VALUES (@MarkaId, @UrunKatId, @RenkId, @Fiyat, @Adet, @ResimBir, @Resimİki, @ResimUc, @UrunTanimi, @UrunMetaryali, @BendenId, @YeniMi, @Vitrin, @CinsiyetId, @KategoriID)" SelectCommand="SELECT * FROM [Urunler]" UpdateCommand="UPDATE [Urunler] SET [MarkaId] = @MarkaId, [UrunKatId] = @UrunKatId, [RenkId] = @RenkId, [Fiyat] = @Fiyat, [Adet] = @Adet, [ResimBir] = @ResimBir, [Resimİki] = @Resimİki, [ResimUc] = @ResimUc, [UrunTanimi] = @UrunTanimi, [UrunMetaryali] = @UrunMetaryali, [BendenId] = @BendenId, [YeniMi] = @YeniMi, [Vitrin] = @Vitrin, [CinsiyetId] = @CinsiyetId, [KategoriID] = @KategoriID WHERE [id] = @id">
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="MarkaId" Type="Int32" />
                                        <asp:Parameter Name="UrunKatId" Type="Int32" />
                                        <asp:Parameter Name="RenkId" Type="Int32" />
                                        <asp:Parameter Name="Fiyat" Type="Decimal" />
                                        <asp:Parameter Name="Adet" Type="Int32" />
                                        <asp:Parameter Name="ResimBir" Type="String" />
                                        <asp:Parameter Name="Resimİki" Type="String" />
                                        <asp:Parameter Name="ResimUc" Type="String" />
                                        <asp:Parameter Name="UrunTanimi" Type="String" />
                                        <asp:Parameter Name="UrunMetaryali" Type="String" />
                                        <asp:Parameter Name="BendenId" Type="Int32" />
                                        <asp:Parameter Name="YeniMi" Type="Boolean" />
                                        <asp:Parameter Name="Vitrin" Type="Boolean" />
                                        <asp:Parameter Name="CinsiyetId" Type="Int32" />
                                        <asp:Parameter Name="KategoriID" Type="Int32" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="MarkaId" Type="Int32" />
                                        <asp:Parameter Name="UrunKatId" Type="Int32" />
                                        <asp:Parameter Name="RenkId" Type="Int32" />
                                        <asp:Parameter Name="Fiyat" Type="Decimal" />
                                        <asp:Parameter Name="Adet" Type="Int32" />
                                        <asp:Parameter Name="ResimBir" Type="String" />
                                        <asp:Parameter Name="Resimİki" Type="String" />
                                        <asp:Parameter Name="ResimUc" Type="String" />
                                        <asp:Parameter Name="UrunTanimi" Type="String" />
                                        <asp:Parameter Name="UrunMetaryali" Type="String" />
                                        <asp:Parameter Name="BendenId" Type="Int32" />
                                        <asp:Parameter Name="YeniMi" Type="Boolean" />
                                        <asp:Parameter Name="Vitrin" Type="Boolean" />
                                        <asp:Parameter Name="CinsiyetId" Type="Int32" />
                                        <asp:Parameter Name="KategoriID" Type="Int32" />
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                                <asp:EntityDataSource ID="Urunlerim" runat="server">
                                </asp:EntityDataSource>
                                


                            </div>
                        </div>
                    </div>
                        </div>
                </asp:Panel>
            </form>
        </div>
    </div>
</asp:Content>
