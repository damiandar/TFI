<%@ Control Language="VB" AutoEventWireup="false" CodeFile="registrar.ascx.vb" Inherits="controles_login_registrar" %>
     <div id="register-form">
<div class="modal-body">
	<div id="div-register-msg"  class="glyphicon glyphicons-user-add">
        <span id="text-register-msg">Registrar una cuenta.</span>
    </div>
    <asp:TextBox ID="tbMail" class="form-control"  ValidationGroup="VGRegistrar"   placeholder="E-mail"   runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="tbMail" Display="Dynamic" ErrorMessage="Debe ingresar el usuario."  ValidationGroup="VGRegistrar">
    </asp:RequiredFieldValidator> 
    <asp:RegularExpressionValidator ID="REV1" runat="server" 
            ControlToValidate="tbMail"
            ErrorMessage="Debe tener entre 5 y 50 letras y/o números." 
            ValidationExpression="[^\s]{5,50}" ValidationGroup="VGRegistrar" />   
    <asp:CustomValidator ID="CVMail2"         runat="server" Display="Dynamic" ControlToValidate="tbMail" ValidationGroup="VGRegistrar" ErrorMessage="*" OnServerValidate="ValidarMail" ></asp:CustomValidator> 
    <asp:TextBox ID="pwd" class="form-control" MaxLength="8"  ValidationGroup="VGRegistrar"  TextMode="Password"  placeholder="Contraseña"   runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="pwd" Display="Dynamic" ErrorMessage="Debe ingresar la contraseña." ValidationGroup="VGRegistrar">
    </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="pwd"
        ErrorMessage="Debe tener entre 5 y 8 letras y/o números." 
        ValidationExpression="[^\s]{5,8}" ValidationGroup="VGRegistrar" /> 
    <asp:textbox class="form-control"  ValidationGroup="VGRegistrar"  placeholder="Razon Social" runat="server" ID="tbRazonSocial" ></asp:textbox> 
    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="tbRazonSocial" Display="Dynamic" ErrorMessage="Debe ingresar la razon social."  ValidationGroup="VGRegistrar">
    </asp:RequiredFieldValidator> 
</div>
<div class="modal-footer">
    <div>
        <asp:LinkButton ID="lnkLogin" ValidationGroup="VGRegistrar"  class="btn btn-primary btn-lg btn-block" runat="server">Registrarme</asp:LinkButton>
    </div>
    <div>
        <asp:LinkButton ID="lnkEntrar" class="btn btn-link" PostBackUrl="~/Login.aspx" runat="server">Entrar</asp:LinkButton>
        <asp:LinkButton ID="LnkRecuperar" class="btn btn-link" PostBackUrl="~/Recuperar.aspx" runat="server">Recuperar Contraseña</asp:LinkButton>
    <%--<button id="register_login_btn" type="button" class="btn btn-link">Entrar</button>
        <button id="register_lost_btn" type="button" class="btn btn-link">Recuperar Contraseña</button>--%>
    </div>
</div>
<div class="modal-footer">
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</div>
</div>

<div class="container">
  <!-- Trigger the modal with a button -->
  <!-- Modal -->
<div class="modal fade" id="myModal" role="dialog">
<div class="modal-dialog">
<!-- Modal content-->
<div class="modal-content">
<div class="modal-header modal-header-primary">
    <button type="button" class="close" data-dismiss="modal">&times;</button>
    <h4 class="modal-title">Usuario Creado </h4>
</div>
<div class="modal-body">
    <div class="row"> 
        <div class="col-lg-12">
            <div class="form-group">
                <label> Se creó correctamente, puede entrar con su usuario y contraseña.</label> 
            </div> 
            <div class="form-group">
                <asp:Button ID="btnIngresar" class="btn btn-success" runat="server" Text="Ingresar" /> 
            </div>
        </div><%-- col--%>
    </div> <%-- row --%>
</div>
<div class="modal-footer">
     
</div>
</div>
</div>
</div>
  
</div>