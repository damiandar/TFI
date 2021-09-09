<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="alta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
   #wrapper {
    padding-left: 0px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header">
        Alta de Usuario
    </h1>
    <ol class="breadcrumb">
        <li class="active">
            <%--<i class="fa fa-Inicio"></i>--%> Por favor complete todos los datos para continuar.
        </li>
    </ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="contact" >
 
<div class="container">
<div class="row">
<div  class="col-lg-12">
    <div role="form">
        <div class="col-sm-6">
        <!-- Text input-->
        <div class="form-group">
            <label for="tbRazonSocial">Razon Social</label>
            <asp:textbox class="form-control" placeholder="Razon Social" runat="server" ID="tbRazonSocial" ></asp:textbox> 
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbRazonSocial" Display="Dynamic" ErrorMessage="Debe ingresar la razon social." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div>
        <div class="form-group">
            <label for="tbCuit">Cuit</label>
            <asp:textbox class="form-control" placeholder="CUIT"  runat="server" ID="tbCuit" ></asp:textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCuit" Display="Dynamic" ErrorMessage="Debe ingresar el CUIT." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
         </div>
        
        <div class="form-group">
        <label for="comboResponsabilidad">Responsabilidad Fiscal</label>
       <asp:DropDownList class="form-control" placeholder="Responsabilidad Fiscal" ID="comboResponsabilidad" runat="server"></asp:DropDownList>  
        </div>
        <div class="form-group">
            <label for="tbDomicilio">Domicilio</label>
            <asp:textbox class="form-control" placeholder="Domicilio" runat="server" ID="tbDomicilio"></asp:textbox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDomicilio" Display="Dynamic" ErrorMessage="Debe ingresar el domicilio." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
       </div>
        <div class="form-group">
            <label for="tbLocalidad">Localidad</label>
            <asp:textbox class="form-control" placeholder="Localidad"  runat="server" ID="tbLocalidad"></asp:textbox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbLocalidad" Display="Dynamic" ErrorMessage="Debe ingresar la localidad." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator> 
        </div>
        <div class="form-group">
            <label for="tbCodigoPostal">Código Postal</label>
            <asp:textbox class="form-control" placeholder="Código Postal" runat="server" ID="tbCodigoPostal"></asp:textbox> 
          </div>

        </div>
        <div class="col-sm-6">
        <div class="form-group">
            <label for="comboProvincia">Provincia</label>
            <asp:DropDownList class="form-control" placeholder="Provincia" ID="comboProvincia" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="tbTelefono">Telefono</label>
            <asp:textbox class="form-control" placeholder="Teléfono" runat="server" ID="tbTelefono"></asp:textbox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbTelefono" Display="Dynamic" ErrorMessage="Debe ingresar un telefono." 
            ValidationGroup="VGAlta"></asp:RequiredFieldValidator>  
        </div>
        <div class="form-group">
            <label for="tbContacto">Contacto</label>
            <asp:textbox  class="form-control" placeholder="Contacto" runat="server" ID="tbContacto"></asp:textbox> 
         </div>
        <div class="form-group">
            <label for="exampleTextarea">Mail</label>
            <asp:textbox  class="form-control" placeholder="E-mail" runat="server" ID="tbMail"></asp:textbox> 
        </div>         
        <div class="form-group">
            <label for="tbWEB">Web</label>
            <asp:textbox  class="form-control"  placeholder="WEB" runat="server" ID="tbWEB"></asp:textbox> 
        </div>
        </div>
    </div>
</div>
<div class="col-lg-12">
    <div role="form">
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
              <div class="pull-right">
                    <button type="submit" class="btn btn-default">Cancelar</button>
                   
                    <asp:Button ID="btnGuardar" runat="server"  ValidationGroup="VGAlta"  class="btn btn-primary" Text="Guardar" cssclass="btn btn-primary" />
              </div>
            </div>
        </div>
        <div class="form-group input-group">
            <asp:Label ID="Label1" runat="server"  Text=""></asp:Label>  
        </div>
    </div>
</div>
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
    <h4 class="modal-title">Usuario Registrado </h4>
</div>
<div class="modal-body">
    <div class="row"> 
        <div class="col-lg-12">
            <div class="form-group">
                <label> Se insertó correctamente, ahora puede cargar pedido.</label> 
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

</section>
</asp:Content>

