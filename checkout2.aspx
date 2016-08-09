<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="checkout2.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.checkout2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">

                    <div class="box">
                        <form method="post" action="checkout3.html">
                            <h1>Kargo Seçiniz</h1>
                            <ul class="nav nav-pills nav-justified">
                                <li><a href="checkout1.aspx"><i class="fa fa-map-marker"></i><br>Adres</a>
                                </li>
                                <li class="active"><a href="checkout2.aspx"><i class="fa fa-truck"></i><br>Kargo</a>
                                </li>
                                <li class="nav nav-pills nav-justified"><a href="checkout3.aspx"><i class="fa fa-money"></i><br>Ödeme</a>
                                </li>
                                <li class="nav nav-pills nav-justified"><a href="checkout4.aspx"><i class="fa fa-eye"></i><br>Onay</a>
                                </li>
                            </ul>

                            <div class="content">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="box shipping-method">

                                            <h4>USPS Kargo</h4>

                                            <p>Ertesi Gün Teslim </p>

                                            <div class="box-footer text-center">

                                                <asp:RadioButton ID="rbUps"  Text="Seç" runat ="server" GroupName="1" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="box shipping-method">

                                            <h4>Yurtiçi Kargo </h4>

                                            <p>1 Hafta İçinde Teslim</p>

                                            <div class="box-footer text-center">

                                                <asp:RadioButton ID="rbYurtİci" Text="Seç" runat="server" GroupName="1" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="box shipping-method">

                                            <h4>Aras Kargo</h4>

                                            <p>3 gün sonra  teslim. </p>

                                            <div class="box-footer text-center">

                                                <asp:RadioButton ID="rbAras" Text="Seç" runat="server" GroupName="1" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.row -->

                            </div>
                            <!-- /.content -->

                            <div class="box-footer">
                                <div class="pull-left">
                                     <asp:LinkButton ID="btnAdreseGit" CssClass="btn btn-default" runat="server" OnClick="btnAdreseGit_Click" >Adrese Git<i class="fa fa-chevron-circle-left"></i></asp:LinkButton>
                                   
                                </div>
                                <div class="pull-right">
                                    <asp:LinkButton ID="btnOdemeyeGec" CssClass="btn btn-primary" runat="server" OnClick="btnOdemeyeGec_Click" >Ödemeye Geç<i class="fa fa-chevron-right"></i></asp:LinkButton>
                                </div>
                            </div>
                        </form>
                    </div>
                    <!-- /.box -->


                </div>
</asp:Content>
