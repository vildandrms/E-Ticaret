<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" EnableEventValidation="false"  Inherits="E_Shop._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row products">
       
    <asp:Repeater ID="rpYeniUrunler" runat="server" OnItemCommand="rpYeniUrunler_ItemCommand">
       
            <itemtemplate>
          

                <div class="col-md-4 col-sm-6">
                    <div class="product">
                        <div class="flip-container">

                            <div class="flipper">
                                <div class="front">
                                    <a href='<%# string.Format("../detail.aspx?UId={0}",Eval("id")) %>'>
                                        <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive"><asp:Label ID="lblResimBir" runat="server" Text='<%# string.Format("img/{0}", Eval("ResimBir"))%>' Visible="False"></asp:Label>
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="back">
                                    <a href="detail.aspx">
                                        <img src='<%# string.Format("img/{0}", Eval("Resimİki"))%>' alt="" class="img-responsive">
                                    </a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            </div>
                        </div>
                        <a href="detail.aspx" class="invisible">
                            <img src='<%# string.Format("img/{0}", Eval("ResimBir"))%>' alt="" class="img-responsive">
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="text">
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
</asp:Content>
