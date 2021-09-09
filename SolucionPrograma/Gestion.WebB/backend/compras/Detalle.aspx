<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="compras_Detalle" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header">
  Pedido de Reposición
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        Pedido de reposición
    </li>
</ol>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css" >
 
</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
    <div class="col-lg-12">
        <div class="form-group">
            <label>Pedido Nro:</label><asp:Label ID="lblNro" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Notas:</label><asp:Label ID="lblNotas" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Estado:</label><asp:Label ID="lblEstado" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>
    <asp:GridView ID="GrillaItemsReposicion" runat="server" AutoGenerateColumns="false"   class="table table-bordered table-hover table-striped" >
    <Columns>
      <asp:TemplateField HeaderText="Insumo">
        <ItemTemplate>
            <asp:Label ID="lblProducto" runat="server" Text='<%#Eval("insumo.nombrecorto") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
            <asp:BoundField HeaderText="Cantidad"  DataField="cantidadpedida" />
            <asp:BoundField HeaderText="Especificacion"  DataField="Especificacion" />
    </Columns>
          
    </asp:GridView>

<div class="row"> 
    <div class="col-lg-12">
        <div class="form-group">
            <asp:Button ID="btnVolver" class="btn btn-success" runat="server" Text="Volver" /> 
        </div>
    </div>
</div>
</asp:Content>

