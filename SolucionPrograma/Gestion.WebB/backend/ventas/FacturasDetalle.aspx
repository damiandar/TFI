<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FacturasDetalle.aspx.vb" Inherits="backend_ventas_FacturasDetalle" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
     <h1 class="page-header">
    Detalle Factura
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="Default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Facturas
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-3">
            <div class="form-group">
                <label>Factura Nro:</label><asp:Label ID="lblNro" CssClass="form-control-static" runat="server" Text=""></asp:Label>
            </div>
        </div>   
        <div class="col-lg-3">
            <div class="form-group">
                <label>Punto de venta:</label><asp:Label ID="lblPtoVenta" CssClass="form-control-static" runat="server" Text=""></asp:Label>
            </div>
        </div>   
        <div class="col-lg-3">
            <div class="form-group">
                <label>Letra:</label><asp:Label ID="lblLetra" CssClass="form-control-static" runat="server" Text=""></asp:Label>
            </div> 
        </div> 
    </div>

</div>

<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-12">
        <div class="form-group">
            <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        
        </div>
        <div class="col-lg-12">
        <div class="form-group">
            <label>Cliente:</label><asp:Label ID="lblCliente" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        
        </div>
    </div>
</div>

<div class="row">
    <div class="text-right" style="padding:5px;">
                <asp:LinkButton runat="server"  CssClass="form-control-static" ID="ImprimirPDF" Text="Imprimir" ><i class="fa fa-file-pdf-o"></i> Imprimir</asp:LinkButton>
    </div>
</div>

    <asp:GridView runat="server" ID="GrillaFacturas" AutoGenerateColumns="false"  class="table table-bordered table-hover table-striped" >
        <Columns>
            <asp:TemplateField HeaderText="Producto">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblProducto" Text='<%#Eval("producto.NombreCorto") %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="cantidad" DataField="cantidad" />
            <asp:BoundField HeaderText="precio" DataField="precio" />
            <asp:TemplateField HeaderText="Sub Total">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSubTotal" Text='<%# String.Format("{0:C}", (Eval("precio") * Eval("cantidad"))) %>' ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

