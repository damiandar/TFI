<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ListaPreciosDetalle.aspx.vb" Inherits="backend_catalogo_ListaPrecios" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header">
    Lista Precios
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="ListaPrecios.aspx">Listas de precio</a>
    </li>
  
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row">
    <div class="col-lg-12">
         <div class="col-lg-3">
            <div class="form-group">
                <label>ID:</label><asp:Label ID="lblListaID" CssClass="form-control-static"  runat="server" Text=""></asp:Label>
            </div>
         </div>   
         <div class="col-lg-3">
   
        
        <div class="form-group">
            <label>Fecha Creación:</label>
            <asp:Label ID="lblFechaCreacion"  CssClass="form-control-static"  runat="server" Text=""></asp:Label> 
        </div>
         </div>   
         <div class="col-lg-3">
        
        <div class="form-group">
            <label>Fecha Vigencia:</label>
            <asp:Label ID="lblFechaVigencia" CssClass="form-control-static"  runat="server" Text=""></asp:Label>
        </div> 
        </div> 
    </div>

</div>
 <asp:Panel ID="PanelMensaje" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-10">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            Se modificó la lista de precios correctamente.
         </div>
        </div>
    </div>
</div> 
</asp:Panel> 
 <asp:Panel ID="PanelError" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-10">
        <div class="alert alert-warning alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            Error en los datos ingresados.
         </div>
        </div>
    </div>
</div> 
</asp:Panel> 
<div class="text-right"><a href="ListaPrecios.aspx">Volver <i class="fa fa-arrow-circle-right"></i></a></div>

<asp:GridView ID="GrillaPrecios" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay lista de precios
    </EmptyDataTemplate>
    <Columns>
        <asp:TemplateField HeaderText="Producto">
            <ItemTemplate>
                <asp:HiddenField ID="hProductoID" runat="server" Value='<%#Eval("id") %>' />
                <asp:Label runat="server" ID="lblProducto" Text='<%#Eval("NombreCorto") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Precio Unitario">
            <ItemTemplate>
                <asp:TextBox runat="server" Text='<%#Eval("precio.valorunitario") %>' ID="tbPrecioUnitario"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ForeColor="Red" ControlToValidate="tbPrecioUnitario" ErrorMessage="*"></asp:RequiredFieldValidator>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="IVA">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblIVA" Text='<%#Eval("precio.iva.descripcion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="Total" ItemStyle-HorizontalAlign="Right" >
            <ItemTemplate>
                <asp:Label runat="server" ID="lblTotal" Text='<%# string.format("{0:c}", Eval("precio.valorfinal")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div class="text-right"><asp:Button runat="server" CssClass="btn btn-primary" Text="Actualizar" ID="btnActualizarPrecios" /></div>

</asp:Content>

