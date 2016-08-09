<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
     <div class="container">   <asp:Repeater ID="rptUrunDetay" runat="server" OnItemCommand="rptUrunDetay_ItemCommand">
                            <ItemTemplate>   
                                
                                <div class="col-md-9">

                    <div class="row" id="productMain">
                   
                                  <div class="col-sm-6">
                           
                                <div id="mainImage">
                                <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive"><asp:Label ID="lblResimBir" runat="server" Text='<%# string.Format("img/{0}", Eval("ResimBir"))%>' Visible="False"></asp:Label>
                            </div>

                       <%--     <div class="ribbon sale">
                                <div class="theribbon">İndirim</div>
                                <div class="ribbon-background"></div>
                            </div>
                            <!-- /.ribbon -->

                            <div class="ribbon new">
                                <div class="theribbon">Yeni</div>
                                <div class="ribbon-background"></div>
                            </div>--%>
                            <!-- /.ribbon -->

                        </div>
                        <div class="col-sm-6">
                            <div class="box">
                                 <h1 class="text-center">
                                     <asp:Label ID="lblRenkAdMarka" runat="server" Text='<%# string.Format("{0},{1},{2}",Eval("RenkAd"),Eval("GiyimAd"),Eval("MarkaAd"))%>'></asp:Label></h1>                                                                                                                                                                                  
                                <p class="goToDescription"><a href="#details" class="scroll-to">
                                    <asp:Label ID="lblUrunTanimi" runat="server" Text='<%# Eval("UrunTanimi") %>'></asp:Label></a>
                                </p>
                                <p class="price">
                                    <asp:Label ID="lblFiyat" runat="server" Text='<%# Eval("Fiyat") %>'></asp:Label></p>

                                <p class="text-center buttons">
                                    <asp:LinkButton ID="btnSepeteEkle" runat="server" CommandName="sepeteAt"  class="btn btn-primary" OnClick="btnSepeteEkle_Click"><i class="fa fa-shopping-cart"></i>Sepete At</asp:LinkButton>
                                    <%--<a href="basket.html" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Sepete Ekle</a> --%>
                                    <a href="basket.aspx" class="btn btn-default"><i class="fa fa-heart"></i>Sepete Bak</a>
                                </p>
                            </div>

                            <div class="row" id="thumbs">
                                <div class="col-xs-4">
                                    <a href='<%# string.Format("img/{0}", Eval("ResimBir"))%>' class="thumb">
                                        <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-xs-4">
                                    <a href='<%# string.Format("img/{0}", Eval("Resimİki"))%>' class="thumb">
                                        <img src='<%# string.Format("img/{0}", Eval("Resimİki"))%>' alt="" class="img-responsive">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-xs-4">
                                    <a href='<%# string.Format("img/{0}", Eval("ResimUc"))%>' class="thumb">
                                        <img src='<%# string.Format("img/{0}", Eval("ResimUc"))%>' alt="" class="img-responsive">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;</div>
                            </div>
                        </div>

                    </div>


                    <div class="box" id="details">
                        <p>
                           <h4>Ürün Detay</h4>
                        <ul>  <li>  <p><%# Eval("UrunTanimi") %></p></li>
                               </ul>
                            <h4>Materyali</h4>
                            <ul>
                                <li><%# Eval("UrunMetaryali")%></li>
                                
                            </ul>
                            <h4>Size</h4>
                            <ul>
                                <li>
                                    <asp:CheckBox ID="cbSBeden" Text="S" runat="server" /></li>
                         <li>
                                    <asp:CheckBox ID="cbMBeden" Text="M" runat="server" /></li>
                                <li>
                                    <asp:CheckBox ID="cbLBeden" Text="L" runat="server" /></li>
                            </ul>

                            <blockquote>
                                
                            </blockquote>

                            <hr>
                            <div class="social">
                                <h4>Show it to your friends</h4>
                                <p>
                                    <a href="#" class="external facebook" data-animate-hover="pulse"><i class="fa fa-facebook"></i></a>
                                    <a href="#" class="external gplus" data-animate-hover="pulse"><i class="fa fa-google-plus"></i></a>
                                    <a href="#" class="external twitter" data-animate-hover="pulse"><i class="fa fa-twitter"></i></a>
                                    <a href="#" class="email" data-animate-hover="pulse"><i class="fa fa-envelope"></i></a>
                                </p>
                            </div>
                    </div>

                  
         </div>
               </ItemTemplate></asp:Repeater>
                <!-- /.col-md-9 --></div>
    </div>
</asp:Content>
