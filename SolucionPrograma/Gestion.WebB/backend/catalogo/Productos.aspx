<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Productos.aspx.vb" Inherits="aplicacion_Catalogo" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header"> Productos </h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Nuevos productos
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="PanelMensaje" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label> 
         </div>
        </div>
    </div>
</div> 
</asp:Panel>
<%--categoria y subcategoria--%>
<div class="row">
   <div class="col-lg-4">
        <div class="form-group">
        <label>Categoria:</label>
&nbsp;<asp:DropDownList ID="comboCategoria" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
        </div>
   <div class="col-lg-4">
        <div class="form-group">
        
        <label>Sub Categoria:</label>
        <asp:DropDownList ID="comboSubCategoria" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
     </div>
</div>
<%--nombre corto y largo--%>
<div class="row">
    <div class="col-lg-6">
    <div class="form-group">
        <label>Nombre Corto</label>
        <asp:TextBox ID="tbNombreCorto" class="form-control" placeholder="Nombre Corto a" runat="server"></asp:TextBox> 
            <p class="help-block">      
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="tbNombreCorto" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
            </p>
    </div>
    </div>
    <div class="col-lg-6">
    <div class="form-group">
        <label>Nombre Largo</label>
        <asp:TextBox ID="tbNombreLargo" class="form-control" placeholder="Nombre Largo" runat="server"></asp:TextBox> 
        <p class="help-block">
            <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="tbNombreLargo" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
        </p>
    </div>
    </div>
</div>
<div class="row">
<div class="col-lg-6">
    <div class="form-group">
        <label>Detalle</label>
        <asp:TextBox ID="tbDetalle" class="form-control" placeholder="Detalle" runat="server"></asp:TextBox> 
<%--        <p class="help-block">Example block-level help text here.</p>--%>
    </div>

  <%--<div class="form-group">
    <label for="tbCondiciones">Condiciones</label> 
    <asp:TextBox class="form-control"  ID="tbCondiciones" runat="server" TextMode="MultiLine" rows="3"  ></asp:TextBox>
  </div>--%>

 
 </div>
 </div>  
<div class="row">
 <div class="col-lg-3">
 <div class="form-group">
    <label for="tbCondiciones">Tiempo de Entrega</label> 
    <asp:TextBox class="form-control"  ID="tbTiempoEspera" runat="server"  ></asp:TextBox>
    <p class="help-block">      
    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="tbTiempoEspera" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
    </p>
 </div>
 </div>
 <div class="col-lg-3">
    <div class="form-group">
        <label>Codigo Interno</label>
        <asp:TextBox ID="tbCodigoInterno" class="form-control" placeholder="Codigo"  runat="server" ></asp:TextBox>
        <p class="help-block">Codigo Interno.</p>
    </div>  
 </div>
 </div>
<div class="row">
    <div class="col-lg-3">
        <div class="form-group">
        <label>Precio</label>
        <asp:TextBox ID="tbPrecio" class="form-control" placeholder="Precio"  runat="server" ></asp:TextBox>
        <p class="help-block">
        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="tbPrecio" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
        </p>
    </div>   
    </div>
    <div class="col-lg-3">
        <div class="form-group">
        <label>IVA:</label>
        <asp:DropDownList ID="comboIva" class="form-control" runat="server" AppendDataBoundItems="true" >
            <asp:ListItem Text="Sin IVA" Value="0" ></asp:ListItem>
            <asp:ListItem Text="10,5 % " Value="1" ></asp:ListItem>
            <asp:ListItem Text=" 21  % " Value="2" ></asp:ListItem>
        </asp:DropDownList>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-lg-4">
        <div class="form-group">
         <asp:Panel ID="PanelProducto" Visible="true" runat="server">
        <label class="btn btn-default btn-file">
        Imagen:<asp:FileUpload ID="FileUpload1" runat="server" /> 
        </label>
            
        
        </asp:Panel>
        </div>
       
    </div>
     <div class="col-lg-4">
 
        <asp:Image ID="Image1"  class="img-rounded" runat="server" Height="200px"  />
 
        
    </div>
</div>

       <asp:Button ID="btnCrear"     CssClass="btn btn-primary" runat="server" Text="Crear" />
        <asp:Button ID="btnModificar" Visible="false" CssClass="btn btn-primary" runat="server" Text="Modificar" />
        <asp:Button ID="btnCancelar"  CssClass="btn btn-default" runat="server" Text="Cancelar" />
 
</asp:Content>

