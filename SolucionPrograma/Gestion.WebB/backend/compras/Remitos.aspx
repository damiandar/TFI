<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Remitos.aspx.vb" Inherits="compras_Remitos" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div class="text-right"> 
    <asp:HyperLink ID="lnkNuevo" runat="server">Nuevo <i class="fa fa-arrow-circle-right"></i> </asp:HyperLink>
</div>

<asp:GridView ID="GrillaRemitos" runat="server"  AllowPaging="true" PageSize="10" PagerStyle-CssClass="estilospaginador"  class="table table-bordered table-hover table-striped"  AutoGenerateColumns="false">
    <EmptyDataTemplate>
    No hay remitos cargados.
    </EmptyDataTemplate>
    <Columns>
    <asp:BoundField DataField="nro"  HeaderText="Nro Remito"  />
    <asp:TemplateField HeaderText="CUIT"  >
    <ItemTemplate>
    <asp:Label runat="server" ID="lblCuit" Text='<%#Eval("orden.proveedor.cuit") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Proveedor"  >
    <ItemTemplate>
    <asp:Label runat="server" ID="lblProveedor" Text='<%#Eval("orden.proveedor.razon") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"  />
    <asp:TemplateField HeaderText="Orden"  >
    <ItemTemplate>
        <asp:Label runat="server" ID="lblOrden" Text='<%#Eval("orden.id") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# string.Format("~/backend/compras/DetalleRemito.aspx?ComprobanteID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
<%--    <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnkPDF" CommandName="Imprimir" CommandArgument='<%#Eval("id") %>' runat="server"><span class="fa fa-file-pdf-o"></span> PDF</asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>--%>
    </Columns>
    </asp:GridView>
</asp:Content>

