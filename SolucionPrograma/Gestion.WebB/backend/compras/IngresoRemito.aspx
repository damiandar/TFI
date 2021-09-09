<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="IngresoRemito.aspx.vb" Inherits="compras_IngresoRemito" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css" >

</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server">
<h1 class="page-header">
  Detalle Orden de compra
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <asp:HyperLink ID="hlInicio" NavigateUrl="~/backend/default.aspx" runat="server">Inicio</asp:HyperLink> 
    </li>
    <li class="active">
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/backend/compras/ordenes.aspx" runat="server">Ordenes de compra</asp:HyperLink> 
    </li>
</ol> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<div class="row">

<div class="col-lg-12">
    <div class="form-group">
        <label>Nro Orden:</label><asp:Label ID="lblNroOrden" CssClass="form-control-static" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label>Proveedor:</label><asp:Label ID="lblProveedor" CssClass="form-control-static" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label>Fecha Compra:</label><asp:Label ID="lblFecha" CssClass="form-control-static"  runat="server" Text=""></asp:Label>
    </div>
</div>

<div class="col-lg-12">
    <div class="panel panel-default">
        <div class="panel-heading">
    <h3 class="panel-title">Datos Remito</h3>
</div>    <%--fin de panel encabezado--%>
        <div class="panel-body">
<div class="col-lg-3">
    <div class="form-group">
        <label>Nro Remito:</label><asp:TextBox CssClass="form-control" ID="tbNro" runat="server"></asp:TextBox>
    </div>
</div>
<div class="col-lg-3">
    <div class="form-group">
        <label>Fecha Recepción:</label><asp:TextBox CssClass="form-control"  ID="tbFecha" runat="server"></asp:TextBox>
    </div>
</div>
<div class="col-lg-6">
    <div class="form-group">
        <label>Notas:</label><asp:TextBox CssClass="form-control"  ID="tbNotas" runat="server"></asp:TextBox>
    </div>
</div>
</div>       <%--fin de panel body--%>
    </div>
</div>
 
</div> <%--fin del row --%>  
<asp:Panel runat="server" ID="PanelMensaje">
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
<asp:GridView ID="GrillaDetalle" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped"   >
      <Columns>
  <asp:TemplateField HeaderText="Insumo" >
        <ItemTemplate>
            <asp:HiddenField ID="hProductoID" value='<%#Eval("insumo.id") %>' runat="server" />
            <asp:Label ID="lblProducto" Text='<%#Eval("insumo.nombrecorto") %>' runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cant. Pedida">
            <ItemTemplate>
                <asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("cantidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cant. Restante">
            <ItemTemplate>
                <asp:Label ID="lblCantidadRestante" runat="server" Text='<%#Eval("cantidadrestante") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cant. Recibida">
        <ItemTemplate>
        <div class="form-group">
            <div class="col-lg-2">
                <asp:TextBox ID="tbCantidadRecibida"  CssClass="form-control" runat="server" ></asp:TextBox>
            </div>
        </div>
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    </asp:GridView>
    <asp:Button ID="btnIngresarRemito" CssClass="btn btn-primary" runat="server" Text="Finalizar Remito" />
</asp:Content>

