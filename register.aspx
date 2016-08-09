<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="E_Shop.register" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
                    <div class="box">
                        <h1>Yeni üye</h1>

                     

                        <hr>

                       
                            <div class="form-group">
                                <label for="name">Ad</label>
                                <asp:TextBox ID="txtAd" class="form-control"  runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ValidationGroup="1" ErrorMessage="Ad Boş Geçilemez" ControlToValidate="txtAd"></asp:RequiredFieldValidator>
                               
                            </div>
                         <div class="form-group">
                                <label for="name">Soyad</label>
                                <asp:TextBox ID="txtSoyad" class="form-control"  runat="server"></asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ValidationGroup="1" ErrorMessage="Soyad Boş Geçilemez" ControlToValidate="txtSoyad"></asp:RequiredFieldValidator>
                               
                            </div>
                            <div class="form-group">
                                <label for="email">Email</label>
                                 <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email"  runat="server"></asp:TextBox>
                                <%--<input type="text" class="form-control" id="email">--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" ValidationGroup="1" ErrorMessage="Email Boş Geçilemez" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                               
                            </div>
                            <div class="form-group">
                                <label for="password">Şifre</label>
                                 <asp:TextBox ID="txtSifre" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" ValidationGroup="1" ErrorMessage="Ad Boş Geçilemez" ControlToValidate="txtSifre"></asp:RequiredFieldValidator>
                               
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="1" />
                               
                            </div>
                            <div class="text-center">
                                 <asp:LinkButton ID="btnUyeOl" class="btn btn-primary" runat="server" OnClick="btnUyeOl_Click" ValidationGroup="1"><i class="fa fa-user-md"></i>Uye Ol</asp:LinkButton>
                             
                            </div>
                        
                    </div>
                </div>
    <div class="col-md-6">
                    <div class="box">
                        <h1>Giriş</h1>                      
                        <hr/>
                          <div class="form-group">
                                <label for="email">Email</label>
                                 <asp:TextBox ID="txtGEmail" class="form-control" TextMode="Email"  runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" ValidationGroup="2" ErrorMessage="Email Boş Geçilemez" ControlToValidate="txtGEmail"></asp:RequiredFieldValidator>
                               
                            </div>
                            <div class="form-group">
                                <label for="password">Şifre</label>
                                 <asp:TextBox ID="txtGSifre" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="*" ValidationGroup="2" ErrorMessage="Şifre Boş Geçilemez" ControlToValidate="txtGSifre"></asp:RequiredFieldValidator>
                               
                                <br />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="2" />
                               
                            </div>
                            <div class="text-center">
                                 <asp:LinkButton ID="btnGiris" class="btn btn-primary" runat="server" OnClick="btnGiris_Click" ValidationGroup="2"><i class="fa fa-sign-in"></i>Giriş</asp:LinkButton>
                                
                            </div>
                    </div>
                </div>
</asp:Content>
