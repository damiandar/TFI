<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Ordenes.aspx.vb" Inherits="compras_Ordenes" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server">
<h1 class="page-header">
    Ordenes de compra
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>
        <asp:HyperLink ID="hlInicio" NavigateUrl="~/backend/default.aspx" runat="server">Inicio</asp:HyperLink> 
    </li>
    <li class="active">
        Ordenes de compra
    </li>
</ol> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css" >

</style>  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="filter-panel" class="collapse filter-panel" style="height: auto;">
<div class="panel panel-default">
    <div class="panel-body">
  
    <div class="form-inline" role="form">		
    <div class="form-group">
        <label class="filter-col" style="margin-right:0;" for="tbID">ID:</label> 
        <asp:TextBox ID="tbID" class="form-control input-sm"  runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label class="filter-col" style="margin-right:0;" for="comboProveedor">Proveedor:</label>
        <asp:DropDownList ID="comboProveedor" AppendDataBoundItems="true" runat="server" class="form-control">
        </asp:DropDownList>
    </div><!-- form group [order by] --> 
    <div class="form-group">
        <label for="dtp_input1" class="filter-col">Desde</label>
        <div class="input-group date form_date col-md-5"  data-date-format="dd/mm/yyyy" data-link-field="dtp_input1" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaDesde" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input1" value="" /><br/>
    </div>
    <div class="form-group">
        <label for="dtp_input2" class="filter-col">Hasta</label>
        <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaHasta" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input2" value="" /><br/>
    </div>
    <div class="form-group">  
        <asp:LinkButton ID="lnkBuscar" class="btn btn-primary filter-col"  runat="server"> <%--<span class="glyphicon glyphicon-cog"></span>--%> Buscar</asp:LinkButton>
    </div>
    </div><%--segunda linea--%>
    </div>
</div>
</div>    
     
<div class="text-right" style="padding:5px;">
<button type="button" class="btn btn-primary" data-toggle="collapse" data-target="#filter-panel">
    <span class="glyphicon glyphicon-cog"></span> Busqueda Avanzada
</button>
</div>
<asp:GridView ID="GrillaOrdenes" runat="server"  AllowPaging="true" PageSize="10"  PagerStyle-CssClass="estilospaginador"  AutoGenerateColumns="false"  class="table table-bordered table-hover table-striped"  >
    <EmptyDataTemplate>
    No hay ordenes cargadas.
    </EmptyDataTemplate>
    <Columns>
    <asp:BoundField HeaderText="Nro" DataField="id" />
    <asp:TemplateField HeaderText="CUIT">
        <ItemTemplate>
            <asp:Label runat="server" ID="lblCuit" Text='<%#Eval("proveedor.cuit") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Proveedor">
        <ItemTemplate>
            <asp:Label runat="server" ID="lblProveedor" Text='<%#Eval("proveedor.razon") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"  />

    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("~/backend/compras/detalleorden.aspx?ComprobanteID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate> 
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkRemito"  NavigateUrl='<%# String.Format("~/backend/compras/Remitos.aspx?ComprobanteID={0}", Eval("ID"))%>'  runat="server">Remitos</asp:HyperLink>
        </ItemTemplate> 
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnkPDF" CommandName="Imprimir" CommandArgument='<%#Eval("id") %>' runat="server"><span class="fa fa-file-pdf-o"></span> PDF</asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>

</asp:Content>

