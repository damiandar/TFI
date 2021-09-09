<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Insumos.aspx.vb" Inherits="aplicacion_Catalogo" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>

<asp:Content ID="Encabezado1" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header">
    Insumos
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>   Inicio
    </li>
    <li class="active">
        <a href="InsumosListado.aspx"> Insumos</a>
    </li>
</ol>
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
<div class="row">
   <div class="col-lg-4">
        <div class="form-group">
            <label>Categoria:</label>
            <asp:DropDownList ID="comboCategoria" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
   </div>
   <div class="col-lg-4">
        <div class="form-group">
            <label>Sub Categoria:</label>
            <asp:DropDownList ID="comboSubCategoria" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
   </div>
</div>
<div class="row">
<div class="col-lg-6">
    <div class="form-group">
        <label>Nombre Corto</label>
        <asp:TextBox ID="tbNombreCorto" class="form-control" placeholder="Nombre Corto  " runat="server"></asp:TextBox> 
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
        <p class="help-block"></p>
    </div>
 </div>
</div>  

<div class="row">

    <div class="col-lg-3">
        <div class="form-group">
            <label>Stock Minimo:</label>
            <asp:TextBox ID="tbStockMin" class="form-control" placeholder="Stock Minimo"   runat="server"></asp:TextBox> 
            <p class="help-block">
                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="tbStockMin" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
            </p>
        </div>
    </div>
    <div class="col-lg-3">
        <div class="form-group">
            <label>Stock Maximo:</label>
            <asp:TextBox ID="tbStockMax" class="form-control" placeholder="Stock Maximo" runat="server"></asp:TextBox> 
            <p class="help-block">
                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="tbStockMax" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
        </div>
    </div>
    <div class="col-lg-3">
        <div class="form-group has-error">
            <label>Stock Actual:</label>
            <asp:TextBox ID="tbStockActual" class="form-control" placeholder="Stock Maximo" runat="server"></asp:TextBox> 
            <p class="help-block">
                <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="tbStockActual" Display="Dynamic"  ErrorMessage="*"></asp:RequiredFieldValidator>
            </p>
        </div>
    </div>  
</div>



    <asp:Button ID="btnCrear"     class="btn btn-primary" runat="server" Text="Crear" />
    <asp:Button ID="btnModificar" class="btn btn-primary" runat="server" Text="Modificar" Visible="false" />
    <asp:Button ID="btnCancelar"  class="btn btn-default" runat="server" Text="Cancelar" />
</asp:Content>

