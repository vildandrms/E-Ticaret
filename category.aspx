<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" EnableEventValidation="false" Inherits="E_Shop.category" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row products">
     
                <div class="box">
                    <h1>Ürünler</h1>
                    <p></p>
                </div>
                <div class="box info-bar">
                    <div class="row">
                        <div class="col-sm-12 col-md-4 products-showing" style="left: 0px; top: 2px">
                           
                        </div>

                        <div class="col-sm-12 col-md-8  products-number-sort">
                            <div class="row">
                                <form class="form-inline">
                                    <div class="col-md-6 col-sm-6">
                                        <div class="products-number">
                                          
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <div class="products-sort-by">
                                            <strong>Sırala                    
                                                       
                                                            <asp:DropDownList ID="ddlSıralama" runat="server" class="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlSıralama_SelectedIndexChanged" >
                                                                <asp:ListItem>Artan Fiyat</asp:ListItem>
                                                                <asp:ListItem>Azalan Fiyat</asp:ListItem>
                                                                <asp:ListItem>Markaya Göre</asp:ListItem>
                                                            </asp:DropDownList>
                                                       
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
           <asp:Repeater ID="rptUrunler" runat="server" OnItemCommand="rptUrunler_ItemCommand1">
           
            <ItemTemplate>


                <div class="col-md-4 col-sm-6">
                    <div class="product">
                        <div class="flip-container">

                            <div class="flipper">
                                <div class="front">
                                    <a href="detail.aspx">
                                        <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive"><asp:Label ID="lblResimBir" runat="server" Text='<%# string.Format("img/{0}", Eval("ResimBir"))%>' Visible="False"></asp:Label>
                                    </a>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </div>
                                <div class="back">
                                    <a href="detail.aspx">
                                        <img src='<%# string.Format("img/{0}", Eval("Resimİki"))%>' alt="" class="img-responsive">
                                    </a>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </div>
                            </div>
                        </div>
                        <a href="detail.aspx" class="invisible">
                            <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive">
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="text">
                            <h3><a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>'>
                                <asp:Label ID="lblRenkAdMarka" runat="server" Text='<%# string.Format("{0},{1},{2}",Eval("RenkAd"),Eval("GiyimAd"),Eval("MarkaAd"))%>'></asp:Label></a></h3>
                            <p class="price">
                                <asp:Label ID="lblFiyat" runat="server" Text='<%# Eval("Fiyat") %>'></asp:Label></p>
                            <p class="buttons">
                                <%--   <a href="detail.aspx" class="btn btn-default">Göz At</a>--%>
                                <a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>' class="btn btn-default">Göz At</a>
                                <asp:LinkButton ID="btnSepeteEkle" runat="server" CommandName="sepeteAt" CommandArgument='<%# Eval("id") %>' class="btn btn-primary" OnClick="btnSepeteEkle_Click"><i class="fa fa-shopping-cart"></i>Sepete At</asp:LinkButton>
                                <%-- <a href="basket.aspx" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Sepete Ekle</a>--%>
                            </p>
                        </div>
                    </div>
                </div>

                <!-- /.text -->
            </ItemTemplate>


        </asp:Repeater>



    </div>

    </strong>

</asp:Content>
