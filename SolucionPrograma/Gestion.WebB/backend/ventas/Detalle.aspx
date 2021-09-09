<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="ventas_Detalle" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server">
<h1 class="page-header">
    Ventas
</h1>
<ol class="breadcrumb">
    <li><i class="fa fa-Inicio"></i>  <a href="Default.aspx">Inicio</a></li>
    <li class="active">Detalle Pedido</li>
</ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="text-right" style="padding:5px;">
<asp:LinkButton ID="btnGenerarFactura" class="btn btn-info"  runat="server">
    <%--<span class="glyphicon glyphicon-cog"></span>--%> Facturar
</asp:LinkButton>
</div>
<div class="row">
    <div class="col-lg-12">
         <div class="col-lg-3">
            <div class="form-group">
                <label>Pedido Nro:</label><asp:Label ID="lblNro" CssClass="form-control-static" runat="server" Text=""></asp:Label>
            </div>
         </div>   
         <div class="col-lg-3">
   
        
        <div class="form-group">
            <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
         </div>   
         <div class="col-lg-3">
        
        <div class="form-group">
            <label>Estado:</label><asp:Label ID="lblEstado" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div> 
        </div> 
    </div>

</div>
<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-12">
        <div class="form-group">
            <label>Notas:</label><asp:Label ID="lblNotas" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        
        </div>
        <div class="col-lg-12">
        <div class="form-group">
            <label>Cliente:</label><asp:Label ID="lblCliente" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        
        </div>
    </div>
</div>


<asp:GridView runat="server" ID="GrillaDetalle" AutoGenerateColumns="false"  class="table table-bordered table-hover table-striped" >
<Columns>
<asp:TemplateField HeaderText="Servicio" >
<ItemTemplate>
    <asp:HiddenField ID="hProductoID" Value='<%#Eval("producto.id")%>' runat="server" />
    <asp:HyperLink ID="hLinkProducto" title="Details" Font-Bold="true" ForeColor="Blue" Text='<%#Eval("producto.nombrecorto") %>' runat="server"></asp:HyperLink>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Descripcion">
<ItemTemplate>
    <asp:Label ID="lblDetalle" runat="server" Text='<%#Eval("producto.nombrelargo") %>'></asp:Label>

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Precio Final" >
<ItemTemplate>
  <asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("producto.precio.valorfinal","{0:c}") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado">
<ItemTemplate>
    <asp:Label CssClass="form-control-static" ID="lblEstado" runat="server" ></asp:Label>
</ItemTemplate>
<EditItemTemplate>

    <asp:DropDownList ID="comboEstado" runat="server"></asp:DropDownList>
</EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Cantidad">
<ItemTemplate> 
    <asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("cantidad") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField >
<ItemTemplate>
<asp:Label ID="lblTotal" runat="server" Text='<%#Eval("total","{0:c}") %>' ></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate>
    <asp:Button runat="server" ID="btnEditar"  class="btn btn-primary"  Text="Modificar" CommandName="Edit"   />
    </ItemTemplate>
    <EditItemTemplate>
    <asp:Button runat="server" ID="btn" Text="Aceptar"  class="btn btn-primary"  CommandArgument='<%#Eval("producto.id") %>' CommandName="Update"   />
    </EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
    <ItemTemplate>
        <asp:Button ID="btnAnular" runat="server" class="btn btn-danger" CommandArgument='<%# Container.DataItemIndex %>'   Text="Anular" CommandName="Anular" />
    </ItemTemplate>
    <EditItemTemplate>
         <asp:Button runat="server" ID="btnCancelar" Text="Cancelar"  class="btn btn-primary"  CommandName="Cancel"   />
    </EditItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</asp:Content>

