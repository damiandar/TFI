<%@ Page Title="" Language="VB" MasterPageFile="~/Inicio.master" AutoEventWireup="false" CodeFile="Contacto.aspx.vb" Inherits="Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="contact" style="padding-top:50px;padding-left:20px; padding-right:20px;">
<div class="container">
    <div class="row">
        <div class="col-lg-12 text-center">
            <h2 class="section-heading">Contacto</h2>
            <h3 class="section-subheading text-muted">Deje sus inquietudes y nos comunicaremos con usted.</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div name="sentMessage" id="contactForm" >
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                        <asp:TextBox  ValidationGroup="VGContacto"  ID="tbNombre"  class="form-control" placeholder="Su nombre *"  required data-validation-required-message="Please enter your name." runat="server"></asp:TextBox>
                        <%--<input type="text" class="form-control" placeholder="Your Name *" id="name" required data-validation-required-message="Please enter your name.">--%>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div class="form-group">
                        <asp:TextBox  ValidationGroup="VGContacto"   type="email" class="form-control" placeholder="Su mail *" id="tbEmail" required data-validation-required-message="Please enter your email address." runat="server"></asp:TextBox>
                            <%--<input type="email" class="form-control" placeholder="Your Email *" id="email" required data-validation-required-message="Please enter your email address.">--%>
                            <p class="help-block text-danger"></p>
                        </div>
                        <div class="form-group">
                            <asp:TextBox  ValidationGroup="VGContacto"  type="tel" class="form-control" placeholder="Su telefono *" id="phone" required data-validation-required-message="Please enter your phone number." runat="server"></asp:TextBox>
                            <%--<input type="tel" class="form-control" placeholder="Your Phone *" id="phone" required data-validation-required-message="Please enter your phone number.">--%>
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                        <asp:TextBox  class="form-control" ValidationGroup="VGContacto"  placeholder="Su mensaje *" id="tbMensaje" required data-validation-required-message="Please enter a message." runat="server"></asp:TextBox>
                        <%-- <textarea class="form-control" placeholder="Your Message *" id="message" required data-validation-required-message="Please enter a message."></textarea>--%>
                            <p class="help-block text-danger"></p>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-lg-12 text-center">
                        <div id="success"><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></div>
                        <asp:Button ID="btnEnviar" ValidationGroup="VGContacto" class="btn btn-xl" runat="server" Text="Enviar"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</section>
</asp:Content>

