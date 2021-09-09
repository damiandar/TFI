<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="compras_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>    
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
   Nuevo Pedido de Abastecimiento
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Detalle
    </li>
</ol>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="text-right"><a href="default.aspx">Volver <i class="fa fa-arrow-circle-right"></i></a></div>

<asp:Panel ID="PanelCabeceraPedido" runat="server">
<div class="row">
    <div class="col-lg-12">
        <div class="form-group">
            <label>Nro Pedido:</label><asp:Label ID="lblNroPedido" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Notas:</label><asp:Label ID="lblNotas"          CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static"  runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>
</asp:Panel>

<asp:Panel ID="PanelCargarItem" runat="server">
        <div class="panel panel-info">
        <div class="panel-heading">
        Agregar Insumo al pedido
        </div> 
        <div class="panel-body">            
        <div class="form-inline" role="form">
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="comboCategoria">Categoria:</label>
                    <asp:DropDownList ID="comboCategoria" AppendDataBoundItems="true"  AutoPostBack="true" class="form-control" runat="server">
                    </asp:DropDownList>                                
                </div><!-- form group [rows] -->
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="comboSubCategoria">Subcategoria:</label>
                    <asp:DropDownList ID="ComboSubCategoria" AppendDataBoundItems="true" AutoPostBack="true"  class="form-control" runat="server">
                    </asp:DropDownList>                                
                </div><!-- form group [rows] -->
            </div>
        <br />
        <div class="form-inline" role="form">
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="comboproducto">Insumo:</label>
                    <asp:DropDownList ID="comboproducto" class="form-control" runat="server">
                    </asp:DropDownList>                                
                </div><!-- form group [rows] -->
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Cantidad:</label>
                    <asp:TextBox ID="tbCantidad" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div><!-- form group [search] -->
                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="comboPrioridad">Prioridad:</label>
                    <asp:DropDownList ID="comboPrioridad" class="form-control" runat="server">
                    <asp:ListItem Value="0" >Baja</asp:ListItem>
                    <asp:ListItem Value="1" >Media</asp:ListItem>
                    <asp:ListItem Value="2" >Alta</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- form group [order by] --> 
                <div class="form-group">
                    <label class="filter-col" for="tbEspecificacion" >Especificación:</label>
                    <asp:TextBox ID="tbEspecificacion"  class="form-control"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">    
                    <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>
    </asp:Panel>

<asp:GridView ID="GrillaReposicion" runat="server" class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" >
<Columns>
        <asp:TemplateField HeaderText="Insumo">
        <ItemTemplate>
            <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("insumo.nombrecorto") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Cantidad"  DataField="cantidadpedida" />
        <asp:TemplateField HeaderText="Prioridad">
        <ItemTemplate>
            <asp:Label ID="lblPrioridad" runat="server" ></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Especificacion"  DataField="Especificacion" />
</Columns>
</asp:GridView>

<div class="text-center">
        <asp:Button ID="btnCerrarPedido" runat="server" Text="Cerrar Pedido"  class="btn btn-primary"  />          
</div>
 
</asp:Content>

