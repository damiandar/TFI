<%@ Control Language="VB" AutoEventWireup="false" CodeFile="recuperar.ascx.vb" Inherits="controles_login_recuperar" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<div id="lost-form">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="modal-body">
		<div id="div-lost-msg">
            <div id="icon-lost-msg" class="glyphicon glyphicons-user-alert"></div>
            <span id="text-lost-msg"><asp:Label runat="server"  ID="lblMensaje" Text="Debe ingresar un usuario valido" ></asp:Label></span>
        </div>
		<asp:TextBox ID="tbMail" class="form-control"  placeholder="E-mail"  ValidationGroup="VGRecuperar"  required  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbMail" Display="Dynamic" ErrorMessage="Debe ingresar el usuario." 
            ValidationGroup="VGRecuperar"></asp:RequiredFieldValidator>  
        <div>
            <asp:LinkButton ID="lnkEntrar"   ValidationGroup="VGRecuperar" class="btn btn-primary btn-lg btn-block" runat="server">Enviar</asp:LinkButton>
        </div>
    </div>

</ContentTemplate>
</asp:UpdatePanel>
<div class="modal-footer">

<div>
    <asp:LinkButton ID="lnkLogin" class="btn btn-link" PostBackUrl="~/Login.aspx" runat="server">Entrar al sistema</asp:LinkButton>
    <asp:LinkButton ID="lnkRegistrarse" class="btn btn-link" PostBackUrl="~/Registrarse.aspx" runat="server">Registrarme</asp:LinkButton>
 
</div>
</div>



</div>