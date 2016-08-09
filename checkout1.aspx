<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="checkout1.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.checkout1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12" id="checkout">
      <div class="box">
            <form method="post" action="checkout2.html">
                <h1>Adres Bilgileri</h1>
                <ul class="nav nav-pills nav-justified">
                    <li class="active"><a href="checkout1.aspx"><i class="fa fa-map-marker"></i>
                        <br>
                        Adres</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="checkout2.aspx"><i class="fa fa-truck"></i>
                        <br>
                        Kargo</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="checkout3.aspx"><i class="fa fa-money"></i>
                        <br>
                        Ödeme</a>
                    </li>
                    <li class="nav nav-pills nav-justified"><a href="checkout4.aspx"><i class="fa fa-eye"></i>
                        <br>
                        Onay</a>
                    </li>
                </ul>

                   <div class="box">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
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
                <!-- /.row -->

                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="company">Cadde</label>
                            <asp:TextBox ID="txtCadde" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="street">Sokak</label>
                            <asp:TextBox ID="txtSokak" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                </div>
                <!-- /.row -->

                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label for="city">Mahalle</label>
                            <asp:TextBox ID="txtMahalle" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label for="zip">Posta Kodu</label>
                            <asp:TextBox ID="txtPostaKodu" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label for="state">İl</label>
                            <asp:TextBox ID="txtIl" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="form-group">
                            <label for="country">İlçe</label>
                            <asp:TextBox ID="txtIlce" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="phone">Telefon</label>
                            <asp:TextBox ID="txtTelefon" TextMode="Phone" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="email">Email</label>
                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>

                </div>
            
             
                <div class="box-footer">
                    <div class="pull-left">
                        <a href="basket.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i>Sepetim</a>
                    </div>
                    <div class="pull-right">
                        <asp:LinkButton ID="btnKargoyeGec" CssClass="btn btn-primary" runat="server" OnClick="btnKargoyeGec_Click1">Kargo Seç<i class="fa fa-chevron-right"></i></asp:LinkButton>
                    </div>
                </div>
        </div>
        </form>                  
    </div> 
</div>
</asp:Content>
