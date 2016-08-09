<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="GunlukRaporlar.aspx.cs" Inherits="E_Shop.GunlukRaporlar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">
        <div class="box">
            <form method="post" action="checkout2.html">
                <h1>Admin İşlemleri</h1>
                <ul class="nav nav-pills nav-justified">
                    <li class="active"><a href="GunlukRaporlar.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Rapolar</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="kullanıcıIslemlerı.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Kullanıcı İşlemleri</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="UrunIslemleri.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Ürün İşlemleri</a>
                    </li>
                   
                </ul>
                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnTariheGore" runat="server" Text="Tarihe Göre" class="btn btn-primary btn-sm" OnClick="btnTariheGore_Click" />

                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:Button ID="btnMusteri" runat="server" Text="Müşteriye Göre" class="btn btn-primary btn-sm" OnClick="btnMusteri_Click" />
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSıralama" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSıralama_SelectedIndexChanged"  >
                                <asp:ListItem>Artan Fiyat</asp:ListItem>
                                <asp:ListItem>Azalan Fiyat</asp:ListItem>
                                <asp:ListItem>Artan Adet</asp:ListItem>
                                <asp:ListItem>Azalan Adet</asp:ListItem>
                                <asp:ListItem>A-Z</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlTarihSorgusu" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="firstname">Başlagıç Tarihi</label>
                                <asp:TextBox ID="txtBaşlangic" runat="server" OnTextChanged="txtBaşlangic_TextChanged"></asp:TextBox>


                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="lastname">Bitiş Tarihi</label>
                                <asp:TextBox ID="txtBitisTrh" runat="server" OnTextChanged="txtBitisTrh_TextChanged"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnpMusteriSorgusu" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="firstname">Müşteri Adı Giriniz : </label>
                                <asp:TextBox ID="txtMusteriAra" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Calendar ID="CdBaslangicTrh" runat="server" Visible="False" OnSelectionChanged="CdBaslangicTrh_SelectionChanged" Width="323px"></asp:Calendar>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Calendar ID="CdBitisTrh" runat="server" Visible="False" OnSelectionChanged="CdBitisTrh_SelectionChanged" Width="323px"></asp:Calendar>
                        </div>
                    </div>
                </div>
                <div class="box">

                    <div class="table-responsive">
                        <table class="table table-hover">
                            <asp:Repeater ID="rptRaporlar" runat="server">
                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Kullanıcı</th>
                                            <th>Adres</th>
                                            <th>Kime </th>
                                            <th>KargoAd</th>
                                            <th>Adet</th>
                                            <th>Tutar</th>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <th><%# Eval("id") %></th>
                                            <td><%# Eval("Ad") %>  <%# Eval("Soyad") %></td>
                                            <td><%# Eval("Adres") %></td>
                                            <td><%# Eval("Name") %>  <%# Eval("LastName") %></td>
                                            <td><%# Eval("KargoAd") %></td>
                                            <td><%# Eval("Adet") %></td>
                                            <td><%# Eval("Tutar") %></td>

                                            <td><a href="customer-order.html" class="btn btn-primary btn-sm">Detay</a>
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
