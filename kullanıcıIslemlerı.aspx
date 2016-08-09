<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="kullanıcıIslemlerı.aspx.cs" Inherits="E_Shop.kullanıcıIslemlerı" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">
        <div class="box">
            <form method="post" action="checkout2.html">
                <h1>Admin İşlemler</h1>
                <ul class="nav nav-pills nav-justified">
                    <li class="nav nav-pills nav-justified"><a href="GunlukRaporlar.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Raporlar</a>
                    </li>
                    <li class="active"><a href="kullanıcıIslemlerı.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Kullanıcı İşlemleri</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="UrunIslemleri.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Ürün İşlemleri</a>
                    </li>
                  
                </ul>


                <div class="box">
                    <div class="row">
                    <div class="pull-left">
                        <asp:Button ID="btnYeniEkle" runat="server" class="btn btn-default" Text="Yeni Ekle" OnClick="btnYeniEkle_Click" />
                    </div>
                        </div>
                    <div class="row">
                        <asp:Panel ID="pnlKullanıcıIslemlerı" runat="server" Visible="False">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblId" runat="server"></asp:Label>
                                        <label for="firstname">Ad</label>
                                        <asp:TextBox ID="txtAd" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="lastname">Soyad</label>
                                        <asp:TextBox ID="txtSoyad" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="firstname">Adres</label>
                                        <asp:TextBox ID="txtAdres" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="lastname">Email</label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="firstname">Telefon</label>
                                        <asp:TextBox ID="txtTelefon" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label for="lastname">Sifre</label>
                                        <asp:TextBox ID="txtSifre" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                     
                    <div class="pull-right">
                        <asp:LinkButton ID="btnKaydet" CssClass="btn-primary"  runat="server" OnClick="btnKaydet_Click">Kaydet</asp:LinkButton> 
                    </div>
                
                        </asp:Panel>
                    </div>
                    
                </div>
                 <div class="box">
                   <div class="table-responsive">
                        <table class="table table-hover">
                            <asp:Repeater ID="rptKullanıcılar" runat="server" OnItemCommand="rptKullanıcılar_ItemCommand">
                           <HeaderTemplate> <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Ad Soyad</th>                                                             
                                    <th>Adres</th>                                 
                                    <th>Mail</th>
                                    <th>Telefon</th>
                                    <th>Şifre</th>
                                </tr>
                            </thead>
                               </HeaderTemplate>
                         <ItemTemplate>
                                   <tbody>
                                <tr>
                                    <th><%# Eval("id") %></th>
                                    <td><%# Eval("Ad") %> <%# Eval("Soyad") %></td>                                                               
                                    <td><%# Eval("Adres") %> </td>                                
                                    <td><%# Eval("EMail") %></td>
                                    <td><%# Eval("Telefon") %></td>
                                    <td><%# Eval("Sifre") %></td>
                                   
                                    <td>
                                        <asp:LinkButton ID="btnGüncelle" runat="server" CommandName="Guncelle" CssClass="btn btn-primary btn-sm" CommandArgument='<%# Eval("id") %>' >Güncelle</asp:LinkButton>
                                       <%-- <asp:Button ID="btnGüncelle" runat="server" class="btn btn-primary btn-sm" Text="Güncelle" />--%>
                                        <asp:LinkButton ID="btnSıl" runat="server" CommandName="Sil" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary btn-sm" >Sil</asp:LinkButton>
                                    </td>
                                </tr>
           </tbody>
                             </ItemTemplate>
                                </asp:Repeater>
                        </table>
                    </div>
                 </div>
            </form>
        </div>
    </div>
</asp:Content>
