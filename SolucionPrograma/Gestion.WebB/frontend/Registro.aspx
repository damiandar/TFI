<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registro.aspx.vb" Inherits="frontend_Registro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div id="register-form"   >
<div class="modal-body">
	<div id="div-register-msg">
        <%--<div id="icon-register-msg" class="glyphicon glyphicon-chevron-right"></div>--%>
        <span id="text-register-msg">Registrar una cuenta.</span>
    </div>
    <asp:TextBox ID="UserName" class="form-control"  placeholder="Username (type ERROR for error effect)" required  runat="server"></asp:TextBox>
    <asp:TextBox ID="tbMail" class="form-control"  placeholder="E-mail" required  runat="server"></asp:TextBox>
    <asp:TextBox ID="pwd" class="form-control" TextMode="Password"  placeholder="Contraseña" required  runat="server"></asp:TextBox>
    <asp:textbox class="form-control" placeholder="CUIT"  runat="server" ID="tbCuit" ></asp:textbox>
    <asp:textbox class="form-control" placeholder="Razon Social" runat="server" ID="tbRazonSocial" ></asp:textbox> 
    <asp:DropDownList class="form-control" ID="comboResponsabilidad" runat="server"></asp:DropDownList>  
    <asp:textbox class="form-control" placeholder="Domicilio" runat="server" ID="tbDomicilio"></asp:textbox> 
    <asp:textbox class="form-control" placeholder="Localidad"  runat="server" ID="tbLocalidad"></asp:textbox> 
    <asp:textbox class="form-control" placeholder="Código Postal" runat="server" ID="tbCodigoPostal"></asp:textbox> 
    <asp:DropDownList class="form-control" ID="comboProvincia" runat="server"></asp:DropDownList>
    <asp:textbox class="form-control" placeholder="Teléfono" runat="server" ID="tbTelefono"></asp:textbox> 
    <asp:textbox  class="form-control" placeholder="Contacto" runat="server" ID="tbContacto"></asp:textbox> 
    <asp:textbox  class="form-control"  placeholder="WEB" runat="server" ID="tbWEB"></asp:textbox>               
</div>
<div class="modal-footer">
    <div>
        <asp:LinkButton ID="lnkLogin"  class="btn btn-primary btn-lg btn-block" runat="server">Registrarme</asp:LinkButton>
    </div>
    <div>
        <button id="register_login_btn" type="button" class="btn btn-link">Entrar</button>
        <button id="register_lost_btn" type="button" class="btn btn-link">Recuperar Contraseña</button>
    </div>
</div>
</div>
    </form>
</body>
</html>
