<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="DetalleRemito.aspx.vb" Inherits="compras_DetalleRemito" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server">
<h1 class="page-header">
    Remitos
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
       Remitos
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row">
<div class="col-lg-12">
    <div class="form-group">
        <label>Remito:</label>
        <asp:Label ID="lblRemito" runat="server" CssClass="form-control-static" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <label>Proveedor:</label><asp:Label ID="lblProveedor" CssClass="form-control-static" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static"  runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label>Nota:</label>
        <asp:Label ID="lblNota" runat="server" CssClass="form-control-static" Text=""></asp:Label>
    </div>
</div>
</div>
    <asp:GridView ID="GrillaDetalle" runat="server"  class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" >
    <Columns>
        <asp:TemplateField HeaderText="Nombre Corto">
            <ItemTemplate>
                <asp:Label ID="lblProducto" Text='<%#Eval("insumo.nombrecorto") %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Largo">
            <ItemTemplate>
                <asp:Label ID="lblNombreLargo" Text='<%#Eval("insumo.nombrelargo") %>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField  HeaderText="Cantidad" DataField="Cantidad"  />
    </Columns>
    </asp:GridView>
</asp:Content>

