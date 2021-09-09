<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="DetalleOrden.aspx.vb" Inherits="compras_DetalleOrden" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header">
  Detalle Orden de compra
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        Detalle Orden
    </li>
</ol>   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Compras" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css" >

</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
</div>

    <asp:GridView ID="GrillaDetalle" runat="server"  class="table table-bordered table-hover table-striped"  AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField HeaderText="Nombre Corto" >
            <ItemTemplate>
                <asp:Label ID="lblProducto" Text='<%#Eval("insumo.nombrecorto") %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Largo" >
            <ItemTemplate>
                <asp:Label ID="lblProducto" Text='<%#Eval("insumo.nombrelargo") %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
        <asp:TemplateField HeaderText="Unitario" >
            <ItemTemplate>
                <asp:Label ID="lblPrecio" Text='<%#String.Format("{0:c}", Eval("PrecioConImpuestos")) %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total" >
            <ItemTemplate>
                <asp:Label ID="lblTotal" Text='<%#String.Format("{0:c}", Eval("Total")) %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>

</asp:Content>

