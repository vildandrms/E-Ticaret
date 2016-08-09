<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="checkout3.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.checkout3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">

        <div class="box">
            <form method="post" action="checkout4.html">
                <h1>Odeme İşlemleri</h1>
                <ul class="nav nav-pills nav-justified">
                    <li><a href="checkout1.aspx"><i class="fa fa-map-marker"></i>
                        <br>
                        Adres</a>
                    </li>
                    <li><a href="checkout2.aspx"><i class="fa fa-truck"></i>
                        <br>
                        Kargo</a>
                    </li>
                    <li class="active"><a href="checkout3.aspx"><i class="fa fa-money"></i>
                        <br>
                        Ödeme</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="checkout4.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Onay</a>
                    </li>
                </ul>

                <div class="content">
                    <div class="row">

                        <div class="col-sm-6">
                            <div class="box payment-method">

                                <h4>Kredi Kartı ile Ödeme</h4>

                                <p>VISA yada Mastercard </p>

                                <div class="box-footer text-center">

                                    <asp:RadioButton ID="rbKrediKart" runat="server" GroupName="2" AutoPostBack="True" OnCheckedChanged="rbKrediKart_CheckedChanged" />
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="box payment-method">

                                <h4>Nakit Ödeme</h4>

                                <p>Kapıda Ödeme Yap</p>

                                <div class="box-footer text-center">

                                    <asp:RadioButton ID="rbNakit" runat="server" GroupName="2" AutoPostBack="True" OnCheckedChanged="rbNakit_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                    </div>
                  <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label for="city">Ad</label>
                                <asp:TextBox ID="txtAd" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label for="city">Soyad</label>
                                <asp:TextBox ID="txtSoyad" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="city">Kart No</label>
                                <asp:TextBox ID="txtKartNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
                        <div class="row">
                         <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label for="city">Taksit Sayısı</label>
                                <asp:TextBox ID="txtTSayisi" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         
                         <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label for="city">Cvc No</label>
                                <asp:TextBox ID="txtCvcNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3">
                            <div class="form-group">
                                <label for="city">Son Kullanım Tarihi</label>
                                <asp:TextBox ID="txtSonTrhi" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>    
                    </div>
                    <!-- /.row -->
                   
                        </asp:Panel>
                  
                </div>
                <!-- /.content -->

                <div class="box-footer">
                    <div class="pull-left">
                        <asp:LinkButton ID="btnKargoyaGit" CssClass="btn btn-default" runat="server" OnClick="btnKargoyaGit_Click">Kargo Bilgileri<i class="fa fa-chevron-circle-left"></i></asp:LinkButton>

                    </div>
                    <div class="pull-right">
                        <asp:LinkButton ID="btnSiparisBitir" CssClass="btn btn-primary" runat="server" OnClick="btnSiparisBitir_Click">Sipariş Bitir<i class="fa fa-chevron-right"></i></asp:LinkButton>
                    </div>
                </div>
            </form>
        </div>
        <!-- /.box -->


    </div>
</asp:Content>
