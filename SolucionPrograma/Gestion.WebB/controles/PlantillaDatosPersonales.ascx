<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PlantillaDatosPersonales.ascx.vb" Inherits="Tsu.Paginas.controles_PlantillaDatosPersonales" %>
<asp:Panel ID="PanelMostrar" runat="server">
<div class="row">
    <div class="col-lg-4">
        <div class="form-group">
            <label>CUIT:</label>        
            <asp:Literal runat="server" ID="ltCuit" ></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Razon Social:</label>
            <asp:Literal runat="server" ID="ltRazonSocial" ></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Domicilio:</label>
            <asp:Literal runat="server" ID="ltDomicilio"></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Localidad:</label>
            <asp:Literal runat="server" ID="ltLocalidad"></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Código Postal:</label>
            <asp:Literal runat="server" ID="ltCodigoPostal"></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Provincia:</label>
            <asp:Literal runat="server" ID="ltProvincia"></asp:Literal>
        </div> 
        <div class="form-group">
            <label>Nº Teléfono fijo:</label>
            <asp:Literal runat="server" ID="ltTelefono"></asp:Literal>
        </div> 
       <%--  <div class="form-group">
            <label>Nº Celular:</label>
           <asp:TextBox runat="server" class="form-control" ID="TextBox8"></asp:TextBox>
            <asp:Literal runat="server"    ID="ltCelular"></asp:Literal>
        </div>--%>
        <div class="form-group">
            <label>E-mail:</label>
            <asp:Literal runat="server" ID="ltMail"></asp:Literal> 
        </div>
    </div>
</div>  
</asp:Panel>

<div class="row">
    <div class="col-lg-12">
    <div class="alert alert-success alert-dismissable">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label> 
        </div>
    </div>
</div>

<asp:Panel ID="PanelEdicion" Visible="false" runat="server"> 
<div class="row">
<div class="col-lg-4">
        <div class="form-group">
            <label>CUIT:</label>        
            <asp:TextBox runat="server" class="form-control" ID="tbCuit" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCuit" Display="Dynamic" ErrorMessage="Debe ingresar el CUIT." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div> 
        <div class="form-group">
            <label>Razon Social:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbRazonSocial" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbRazonSocial" Display="Dynamic" ErrorMessage="Debe ingresar la razon social." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div> 
        <div class="form-group">
            <label for="comboResponsabilidad">Responsabilidad Fiscal</label>
            <asp:DropDownList class="form-control" placeholder="Responsabilidad Fiscal" ID="comboResponsabilidad" runat="server"></asp:DropDownList>  
        </div>
        <div class="form-group">
            <label>Domicilio:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbDomicilio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDomicilio" Display="Dynamic" ErrorMessage="Debe ingresar el domicilio." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div> 
        <div class="form-group">
            <label>Localidad:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbLocalidad"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbLocalidad" Display="Dynamic" ErrorMessage="Debe ingresar la localidad." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div> 
        <div class="form-group">
            <label>Código Postal:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbCodigoPostal"></asp:TextBox>
        </div> 
        <div class="form-group">
            <label>Provincia:</label>
            <asp:DropDownList class="form-control" placeholder="Provincia" ID="comboProvincia" runat="server"></asp:DropDownList>
        </div> 
        <div class="form-group">
            <label>Nº Teléfono:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbTelefono"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbTelefono" Display="Dynamic" ErrorMessage="Debe ingresar un telefono." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator>   
        </div> 
        <div class="form-group">
            <label>Web:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbWeb"></asp:TextBox>
        </div> 
        <div class="form-group">
            <label>Contacto:</label>
            <asp:TextBox runat="server" class="form-control" ID="tbContacto"></asp:TextBox>
        </div> 
        <div class="form-group">
            <label>E-mail:</label>
            <asp:TextBox runat="server" class="form-control" ReadOnly="true" ID="tbMail"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbMail" ErrorMessage="Debe ingresar un mail."
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator>
        </div>
</div>
</div>  
   <asp:Button ID="btnModificar" ValidationGroup="VGAlta" CssClass="btn btn-primary" runat="server" Text="Modificar" />
   <asp:Button ID="btnCancelar"  ValidationGroup="VGAlta" CssClass="btn btn-default" runat="server" Text="Cancelar"  />
</asp:Panel>
