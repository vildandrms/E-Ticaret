<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="checkout4.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.checkout4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            display: block;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 4px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" id="checkout">

        <div class="box">
            <form method="post" action="checkout4.html">
                <h1>Onayla</h1>
                <ul class="nav nav-pills nav-justified">
                    <li><a href="checkout1.aspx"><i class="fa fa-map-marker"></i>
                        <br>
                        Adres</a>
                    </li>
                    <li><a href="checkout2.aspx"><i class="fa fa-truck"></i>
                        <br>
                        Kargo</a>
                    </li>
                    <li><a href="checkout3.aspx"><i class="fa fa-money"></i>
                        <br>
                        Ödeme</a>
                    </li>
                    <li class="active"><a href="#"><i class="fa fa-eye"></i>
                        <br>
                        Onay</a>
                    </li>
                </ul>

                <div class="content">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <td>
                                        <div class="col-sm-6">
                                            <h4>Teslim Adresi</h4>
                                            <div class="box payment-method">
                                              <span>Sayın , </span>
                                                <asp:Label ID="lblAdSoyad" runat="server" Text=""></asp:Label><br />
                                                 <asp:Label ID="lblKargo" runat="server" Text=""></asp:Label><span> aracılığıyla</span><br />
                                                <asp:Label ID="lblAdres" runat="server" Text=""></asp:Label>
                                                <span>adresine teslim edilecektir</span>

                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                

                            </thead>

                            <tfoot>
                                <tr>
                                    <th colspan="5">Toplam</th>
                                    <th>
                                        <asp:Label ID="txtToplam" runat="server" Text=""></asp:Label></th>
                                </tr>
                            </tfoot>
                        </table>

                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.content -->

                <div class="box-footer">
                    <div class="pull-left">
                        <a href="checkout3.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i>Ödemeye</a>
                    </div>
                    <div class="pull-right">
                        <asp:LinkButton ID="btnSiparisOnay" CssClass="btn btn-primary" runat="server" OnClick="btnSiparisOnay_Click" >Onayla</asp:LinkButton> 
                      
                    </div>
                </div>
            </form>
        </div>
        <!-- /.box -->


    </div>
</asp:Content>
