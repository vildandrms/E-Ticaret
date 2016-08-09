<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="E_Shop.index" EnableEventValidation="false"%>

<!DOCTYPE html>

<html="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta name="robots" content="all,follow">
    <meta name="googlebot" content="index,follow,snippet,archive">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Obaju e-commerce template">
    <meta name="author" content="Ondrej Svestka | ondrejsvestka.cz">
    <meta name="keywords" content="">

    <title>
        Vildanın Sitesi
    </title>

    <meta name="keywords" content="">

    <link href='http://fonts.googleapis.com/css?family=Roboto:400,500,700,300,100' rel='stylesheet' type='text/css'>

    <!-- styles -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link href="css/owl.carousel.css" rel="stylesheet">
    <link href="css/owl.theme.css" rel="stylesheet">

    <!-- theme stylesheet -->
    <link href="css/style.default.css" rel="stylesheet" id="theme-stylesheet">

    <!-- your stylesheet with modifications -->
    <link href="css/custom.css" rel="stylesheet">

    <script src="js/respond.min.js"></script>

    <link rel="shortcut icon" href="favicon.png">



</head>

<body>
    <form runat="server"><!-- *** TOPBAR ***
 _________________________________________________________ -->
    <div id="top">
        <div class="container">
            <div class="col-md-6 offer" data-animate="fadeInDown">
                <a href="#" class="btn btn-success btn-sm" data-animate-hover="shake">Offer of the day</a>  <a href="#">Get flat 35% off on orders over $50!</a>
            </div>
            <div class="col-md-6" data-animate="fadeInDown">
                <ul class="menu">
                    <li><a href="#" data-toggle="" data-target="#login-modal"> <asp:Label ID="lblGiris" runat="server" Text="Giriş"></asp:Label></a>
                    </li>
                    <li><a href="register.aspx">Ayarlar</a>
                    </li>
                    <li><a href="contact.aspx">İletişim</a>
                    </li>
                    <li><a href="#">Recently viewed</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="Login" aria-hidden="true">
            <div class="modal-dialog modal-sm">

                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="Login">Giriş</h4>
                        </div>
                        <div class="modal-body">

                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="email" runat="server" TextMode="Email"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtSifre" CssClass="form-control" placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>

                            <p class="text-center">
                                <asp:LinkButton ID="btnGiris" class="btn btn-primary" runat="server" CssClass="fa fa-sign-in" OnClick="btnGiris_Click" >Giriş</asp:LinkButton>
                            </p>



                            <%--  <p class="text-center text-muted">Not registered yet?</p>--%>
                            <p class="text-center text-muted"><a href="register.aspx"><strong>Üye ol</strong></a></p>

                        </div>
                    </div>
                </div>
        </div>

    </div>

    <!-- *** TOP BAR END *** -->

 

    <div class="navbar navbar-default yamm" role="navigation" id="navbar">
        <div class="container">
            <div class="navbar-header">

                <a class="navbar-brand home" href="index.aspx" data-animate-hover="bounce" style="height: 70px">
                    <img src="img/logo.png" alt="Obaju logo" class="hidden-xs">
                    <img src="img/logo-small.png" alt="Obaju logo" class="visible-xs"><span class="sr-only">Obaju - go to homepage</span>
                </a>
                <div class="navbar-buttons">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation">
                        <span class="sr-only">Toggle navigation</span>
                        <i class="fa fa-align-justify"></i>
                    </button>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#search">
                        <span class="sr-only">Toggle search</span>
                        <i class="fa fa-search"></i>
                    </button>
                    <a class="btn btn-default navbar-toggle" href="basket.aspx">
                        <i class="fa fa-shopping-cart"></i>  <span class="hidden-xs">3 items in cart</span>
                    </a>
                </div>
            </div>
            <div class="navbar-collapse collapse" id="navigation">

                <ul class="nav navbar-nav navbar-left">
                        <li class="active"><a href="index.aspx">Home</a>
                        </li>
                        <li class="dropdown yamm-fw">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="200">Bayan <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <div class="yamm-content">
                                        <div class="row">
                                            <div class="col-sm-3">

                                                <asp:Repeater ID="rptKadınGiyim" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Giyim</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>

                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptKadınAyakkabı" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Ayakkabı</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptKadınAksesuar" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Aksesuar</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptKadınMarkalar" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Markalar</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UMarId={0}",Eval("id")) %>'><%# Eval("MarkaAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.yamm-content -->
                                </li>
                            </ul>
                        </li>

                        <li class="dropdown yamm-fw">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="200">Erkek <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <div class="yamm-content">
                                        <div class="row">
                                            <div class="col-sm-3">

                                                <asp:Repeater ID="rptErkekGiyim" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Giyim</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UEKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>

                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptErkekAyakkabı" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Ayakkabı</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UEKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptErkekAksesuar" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Aksesuar</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UEKatId={0}",Eval("id")) %>'><%# Eval("GiyimAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Repeater ID="rptErkekMarkalar" runat="server">
                                                    <HeaderTemplate>
                                                        <h5>Markalar</h5>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%# string.Format("../category.aspx?UEMarId={0}",Eval("id")) %>'><%# Eval("MarkaAd") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate></ul></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.yamm-content -->
                                </li>
                            </ul>
                        </li>

                        <li class="dropdown yamm-fw">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="200">
                                <asp:Label ID="Label1" runat="server" Text="Label">Admin Sayfası</asp:Label> <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <div class="yamm-content">
                                        <div class="row">                                          
                                            <div class="col-sm-3">
                                                <h5>Satıs Raporları</h5>
                                                <ul>
                                                    <li><a href="register.aspx">Günlük Raporlar</a>
                                                    </li>
                                                    <li><a href="customer-orders.aspx">Aylık Raporlar</a>
                                                    </li>
                                                    <li><a href="customer-order.aspx">En Çok Satanlar</a>
                                                    </li>
                                                    
                                                </ul>
                                            </div>
                                            <div class="col-sm-3">
                                                <h5>Kullanıcı İşlemleri</h5>
                                                <ul>
                                                    <li><a href="basket.aspx">Üye Kayıt</a>
                                                    </li>
                                                    <li><a href="checkout1.aspx">Kullanici Raporları</a>
                                                    </li>
                                                    <li><a href="checkout2.aspx">Satış Düzelleme</a>
                                                    </li>
                                                   
                                                </ul>
                                            </div>
                                            <div class="col-sm-3">
                                                <h5>Urun İşlemleri</h5>
                                                <ul>
                                                    <li><a href="blog.aspx">Markalar</a>
                                                    </li>
                                                    <li><a href="post.aspx">Kategoriler</a>
                                                    </li>
                                                    <li><a href="faq.aspx">Renkler</a>
                                                    </li>
                                                    <li><a href="text.aspx">Bedenler</a>
                                                    </li>
                                                    <li><a href="text-right.aspx">Urun Kategorileri</a>
                                                    </li>
                                                    <li><a href="404.aspx">Urunler</a>
                                                    </li>
                                                    <li><a href="contact.aspx">İletişim</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.yamm-content -->
                                </li>
                            </ul>
                        </li>
                    </ul>

            </div>
            <div class="navbar-buttons">

                <div class="navbar-collapse collapse right" id="basket-overview">
                    <a href="basket.aspx" class="btn btn-primary navbar-btn"><i class="fa fa-shopping-cart"></i><asp:Label ID="lblurunAdet" runat="server" Text="Boş"></asp:Label></a>
                </div>
                <!--/.nav-collapse -->

                <div class="navbar-collapse collapse right" id="search-not-mobile">
                    <button type="button" class="btn navbar-btn btn-primary" data-toggle="collapse" data-target="#search">
                        <span class="sr-only">Toggle search</span>
                        <i class="fa fa-search"></i>
                    </button>
                </div>

            </div>
            <div class="collapse clearfix" id="search">

                
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Search">
                        <span class="input-group-btn">

			<button type="submit" class="btn btn-primary"><i class="fa fa-search"></i></button>

		    </span>
                    </div>
              

            </div>
        </div>
    </div>
   <div id="all">

        <div id="content">

            <div class="container">
                <div class="col-md-12">
                    <div id="main-slider">
                        <div class="item">
                            <img src="img/main-slider1.jpg" alt="" class="img-responsive">
                        </div>
                        <div class="item">
                            <img class="img-responsive" src="img/main-slider2.jpg" alt="">
                        </div>
                        <div class="item">
                            <img class="img-responsive" src="img/main-slider3.jpg" alt="">
                        </div>
                        <div class="item">
                            <img class="img-responsive" src="img/main-slider4.jpg" alt="">
                        </div>
                    </div>
                    <!-- /#main-slider -->
                </div>
            </div>

            <!-- *** ADVANTAGES HOMEPAGE ***
 _________________________________________________________ -->
            <div id="advantages">

                <div class="container">
                    <div class="same-height-row">
                        <div class="col-sm-4">
                            <div class="box same-height clickable">
                                <div class="icon"><i class="fa fa-heart"></i>
                                </div>

                                <h3><a href="#">Müşterilerimiz Seviyoruz</a></h3>
                                <p>En iyi hizmet için çalışıyoruz.</p>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="box same-height clickable">
                                <div class="icon"><i class="fa fa-tags"></i>
                                </div>

                                <h3><a href="#">En İyi Fİyatlar</a></h3>
                                <p>Hem kaliteli hem uzun gelde alma.</p>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="box same-height clickable">
                                <div class="icon"><i class="fa fa-thumbs-up"></i>
                                </div>

                                <h3><a href="#">100% orjinal </a></h3>
                                <p>Her gün yeni yeni ürünler eklenir. </p>
                            </div>
                        </div>
                    </div>
                    <!-- /.row -->

                </div>
                <!-- /.container -->

            </div>
            <!-- /#advantages -->

            <!-- *** ADVANTAGES END *** -->

            <!-- *** HOT PRODUCT SLIDESHOW ***
 _________________________________________________________ -->
            <div id="hot">

                <div class="box">
                    <div class="container">
                        <div class="col-md-12">
                            <h2>Yeni Ürünler</h2>
                        </div>
                    </div>
                </div>

                <div class="container">
                    <div class="product-slider">
                   <asp:Repeater ID="rptYeniUrunler" runat="server" OnItemCommand="rptYeniUrunler_ItemCommand" >
            <itemtemplate>
          <div class="item">
               
                    <div class="product">
                        <div class="flip-container">

                            <div class="flipper">
                                <div class="front">
                                    <a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>'>
                                        <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive"><asp:Label ID="lblResimBir" runat="server" Text='<%# string.Format("img/{0}", Eval("ResimBir"))%>' Visible="False"></asp:Label>
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="back">
                                    <a href="detail.aspx">
                                        <img src='<%# string.Format("img/{0}", Eval("Resimİki"))%>' alt="" class="img-responsive">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            </div>
                        </div>
                        <a href="detail.aspx" class="invisible">
                            <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive">
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="text">
                            <h3><a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>'><asp:Label ID="lblRenkAdMarka" runat="server" Text='<%# string.Format("{0},{1},{2}",Eval("RenkAd"),Eval("GiyimAd"),Eval("MarkaAd"))%>'></asp:Label></a></h3>
                            <p class="price"><asp:Label ID="lblFiyat" runat="server" Text='<%# Eval("Fiyat") %>'></asp:Label></p>
                            <p class="buttons">
                               <a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>' class="btn btn-default">Göz At</a>
                               <asp:LinkButton ID="btnSepeteEkle" runat="server" CommandName="sepeteAt"  CommandArgument='<%# Eval("id") %>' class="btn btn-primary" ><i class="fa fa-shopping-cart"></i>Sepete At</asp:LinkButton>
                            </p>
                        </div>
                    </div>
                </div>
          
            <!-- /.text -->
        </itemtemplate>

       
    </asp:Repeater>
                    </div>
                    <!-- /.product-slider -->
                </div>
                <!-- /.container -->

            </div>
            <!-- /#hot -->

            <!-- *** HOT END *** -->

            <!-- *** GET INSPIRED ***
 _________________________________________________________ -->
            <div class="container" data-animate="fadeInUpBig">
                <div class="col-md-12">
                    <div class="box slideshow">
                        <h3>Get Inspired </h3> 
                                   <p>Get the inspiration from our world class designers</p>
                        <div id="get-inspired" class="owl-carousel owl-theme">
                            <div class="item">
                                <a href="#">
                                    <img src="img/getinspired1.jpg" alt="Get inspired" class="img-responsive">
                                </a>
                            </div>
                            <div class="item">
                                <a href="#">
                                    <img src="img/getinspired2.jpg" alt="Get inspired" class="img-responsive">
                                </a>
                            </div>
                            <div class="item">
                                <a href="#">
                                    <img src="img/getinspired3.jpg" alt="Get inspired" class="img-responsive">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- *** GET INSPIRED END *** -->

            <!-- *** BLOG HOMEPAGE ***
 _________________________________________________________ -->

            <div class="box text-center" data-animate="fadeInUp">
                <div class="container">
                    <div class="col-md-12">
                        <h3 class="text-uppercase">From our blog</h3>

                        <p class="lead">What's new in the world of fashion? <a href="blog.aspx">Check our blog!</a>
                        </p>
                    </div>
                </div>
            </div>

            <div class="container">

                <div class="col-md-12" data-animate="fadeInUp">

                    <div id="blog-homepage" class="row">
                        <div class="col-sm-6">
                            <div class="post">
                                <h4><a href="post.aspx">Fashion now</a></h4>
                                <p class="author-category">By <a href="#">John Slim</a> in <a href="#" >Fashion and style</a>
                                </p>
                                <hr>
                                <p class="intro">Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean
                                    ultricies mi vitae est. Mauris placerat eleifend leo.</p>
                                <p class="read-more"><a href="post.aspx" class="btn btn-primary">Continue reading</a>
                                </p>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="post">
                                <h4><a href="post.aspx">Who is who - example blog post</a></h4>
                                <p class="author-category">By <a href="#">John Slim</a> in <a href="#">About Minimal</a>
                                </p>
                                <hr>
                                <p class="intro">Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean
                                    ultricies mi vitae est. Mauris placerat eleifend leo.</p>
                                <p class="read-more"><a href="post.aspx" class="btn btn-primary">Continue reading</a>
                                </p>
                            </div>

                        </div>

                    </div>
                    <!-- /#blog-homepage -->
                </div>
            </div>
            <!-- /.container -->

            <!-- *** BLOG HOMEPAGE END *** -->


        </div>
        <!-- /#content -->
       </div>
         *** FOOTER ***

        <div id="footer" data-animate="fadeInUp">
                <div class="container">
                    <div class="row">
                        <div class="col-md-3 col-sm-6">
                            
                                <h4>Kullanıcı işlemleri</h4>
                            <ul>
                                  <li><a href="#" data-toggle="modal" data-target="#login-modal">Giriş</a>
                                    </li>
                                    <li><a href="register.aspx">Ayarlar</a>
                                    </li>
                                </ul>

                                <hr class="hidden-md hidden-lg hidden-sm">
                        </div>                
                        <div class="col-md-3 col-sm-6">

                            <h4>Adres</h4>

                            <p>
                                <strong>Obaju Ltd.</strong>
                                <br>
                                Maden Mahallesi
                            <br>
                                Selvi Sokak
                            <br>
                               No:1 /D:4
                            <br>
                                Sarıyer/İstanbul
                            <br>
                                <br>
                              Türkiye
                            <br>
                                <strong>Türkiye</strong>
                            </p>

                            <a href="contact.aspx">İletişim</a>

                            <hr class="hidden-md hidden-lg">
                        </div>    <hr />                      
                        <div class="col-md-3 col-sm-6">
                            <h4>Stay in touch</h4>

                            <p class="social">
                                <a href="#" class="facebook external" data-animate-hover="shake"><i class="fa fa-facebook"></i></a>
                                <a href="#" class="twitter external" data-animate-hover="shake"><i class="fa fa-twitter"></i></a>
                                <a href="#" class="instagram external" data-animate-hover="shake"><i class="fa fa-instagram"></i></a>
                                <a href="#" class="gplus external" data-animate-hover="shake"><i class="fa fa-google-plus"></i></a>
                                <a href="#" class="email external" data-animate-hover="shake"><i class="fa fa-envelope"></i></a>
                            </p>


                        </div>
                       

                    </div>
                    <!-- /.row -->

                </div>
        <!-- /#footer -->
       </div>

        <div id="copyright">
            <div class="container">
                <div class="col-md-6">
                    <p class="pull-left">© 2015 Your name goes here.</p>

                </div>
                <div class="col-md-6">
                    <p class="pull-right">Template by <a href="http://bootstrapious.com/e-commerce-templates">Bootstrapious</a> with support from <a href="https://kakusei.cz">Kakusei</a> 
                        <!-- Not removing these links is part of the licence conditions of the template. Thanks for understanding :) -->
                    </p>
                </div>
            </div>
        </div>
        
        <!-- *** COPYRIGHT END *** -->
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/waypoints.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/bootstrap-hover-dropdown.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/front.js"></script>




    

    <!-- *** SCRIPTS TO INCLUDE ***-->
    <script src="js/jquery-1.11.0.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/waypoints.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/bootstrap-hover-dropdown.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/front.js"></script>




</form>

</body>

</html>
 
