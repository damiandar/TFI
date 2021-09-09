<%@ Control Language="VB" AutoEventWireup="false" CodeFile="login.ascx.vb" Inherits="controles_login_login" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<div id="login-form" >
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="modal-body">
        <div id="div-login-msg">
        <div id="icon-login-msg" class="fa fa-fw fa-users"></div> 
            <span id="text-login-msg">Ingrese usuario y contraseña.</span>
        </div>
        <asp:TextBox ID="UserName" class="form-control"   ValidationGroup="VGpasoLogin"   placeholder="Usuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="Debe ingresar el usuario" ValidationGroup="VGpasoLogin"></asp:RequiredFieldValidator>  
        <asp:RegularExpressionValidator ID="REV1" runat="server" 
            ControlToValidate="UserName"
            ErrorMessage="Debe tener entre 5 y 50 letras y/o números." 
            ValidationExpression="[^\s]{5,50}" ValidationGroup="VGpasoLogin" />   
        <asp:TextBox ID="pwd" class="form-control" TextMode="Password" MaxLength="8"  ValidationGroup="VGpasoLogin"  placeholder="Contraseña" required runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="pwd"      Display="Dynamic" ErrorMessage="Debe ingresar la contraseña" ValidationGroup="VGpasoLogin"></asp:RequiredFieldValidator>  
        <asp:RegularExpressionValidator ID="REV2" runat="server" 
            ControlToValidate="pwd"
            ErrorMessage="Debe tener entre 5 y 8 letras y/o números." 
            ValidationExpression="[^\s]{5,8}" ValidationGroup="VGpasoLogin" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Text=""></asp:Label>
        <asp:CheckBox ID="chkRecordarme" Visible="false" runat="server" />
</div>

<div class="modal-footer">
    <div>
        <asp:LinkButton ID="lnkLogin" ValidationGroup="VGpasoLogin"  class="btn btn-primary btn-lg btn-block" runat="server">Entrar</asp:LinkButton>
    </div>
	<div>
        <asp:LinkButton ID="lnkOlvide" class="btn btn-link" PostBackUrl="~/Recuperar.aspx" runat="server">Perdi mi contraseña</asp:LinkButton>
        <asp:LinkButton ID="LinkRegistrarse" class="btn btn-link" PostBackUrl="~/Registrarse.aspx" runat="server">Registrarse</asp:LinkButton>
    </div>
</div>

</ContentTemplate>
</asp:UpdatePanel>

</div>
