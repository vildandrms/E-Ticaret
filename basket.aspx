<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="basket.aspx.cs" Inherits="E_Shop.basket" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
       <div class="col-md-9" id="basket">
     <div class="box">

                        <form method="post" action="checkout1.html">

                            <h1>Sepetim</h1>
                            <p class="text-muted"></p>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>
                                                <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label></th>
                                            <th colspan="2">Ürünler</th>
                                            <th>Adet</th>
                                            <th>Fiyat</th>
                                            <th colspan="2">Tutar</th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="rptSiparisler" runat="server" OnItemCommand="rptSiparisler_ItemCommand">
                                   <HeaderTemplate><tbody></HeaderTemplate> 
                                      <ItemTemplate>
                                          <tr>
                                              <td><asp:Label ID="lbIDsi" runat="server" Text='<%# Eval("sepetID") %>' Visible="False"></asp:Label></td>
                                            <td>
                                                <a href="#">
                                                    <asp:Label ID="lblId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"UrunId") %>' Visible="False"></asp:Label>
                                                    <img src='<%# DataBinder.Eval(Container.DataItem,"ResimAdres") %>' alt="White Blouse Armani">
                                                </a>
                                            &nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            <td><a href="#">
                                                <asp:Label ID="lblRenkMarka" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RenkAd") %>'></asp:Label></a>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAdet" CssClass="form-control" Text='<%# DataBinder.Eval(Container.DataItem,"Adet") %>' runat="server"></asp:TextBox>   <%--<input type="number" value="2" class="form-control">--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFiyat" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Fiyat") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblTutar" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Tutar") %>'></asp:Label></td>
                                            <td>
                                                <asp:LinkButton ID="btnSiparisSil" runat="server" class="fa fa-trash-o" OnClick="btnSiparisSil_Click" CommandName="sepettenSil" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"sepetID") %>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                       </ItemTemplate>
                                   <FooterTemplate></tbody></FooterTemplate> 
                                    </asp:Repeater>
                                    <tfoot>
                                        <tr>
                                            <th colspan="5">Toplam
                                            <th>
                                                <asp:Label ID="lblToplam" runat="server" Text=""></asp:Label></th>
                                        </tr>
                                    </tfoot>
                                </table>

                            </div>
                            <!-- /.table-responsive -->

                            <div class="box-footer">
                                <div class="pull-left">
                                    <a href="category.aspx" class="btn btn-default"><i class="fa fa-chevron-left"></i>Alışverişe Devam</a>
                                </div>
                                <div class="pull-right">
                                 <%--   <button class="btn btn-default"><i class="fa fa-refresh"></i> Sepeti Güncelle</button>--%>
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-default" runat="server" PostBackUrl="#" ><i class="fa fa-refresh"></i>Sepeti Güncelle <i class="fa fa-chevron-right"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnOdemeyeGec" runat="server"  class="btn btn-primary" OnClick="btnOdemeyeGec_Click">Ödemeye Geç <i class="fa fa-chevron-right"></i></asp:LinkButton>
                                   
                                </div>
                            </div>

                        </form>

                    </div>
     </div>
      </div>
</asp:Content>
