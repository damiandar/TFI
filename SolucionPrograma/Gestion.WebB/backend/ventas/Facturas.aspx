<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Facturas.aspx.vb" Inherits="backend_ventas_Facturas" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
        <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
     <h1 class="page-header">
    Facturas
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

<div id="filter-panel" class="collapse filter-panel" style="height: auto;">
<div class="panel panel-default">
    <div class="panel-body">
    <div class="form-inline" role="form"> 
        <div class="form-group">
            <label class="filter-col" style="margin-right:0;" for="tbID">ID:</label> 
            <asp:TextBox ID="tbID" class="form-control input-sm"  runat="server"></asp:TextBox>
        </div><!-- form group [search] -->
        <div class="form-group">
            <label class="filter-col" style="margin-right:0;" for="comboClientes">Cliente:</label>
            <asp:DropDownList ID="comboCliente" AppendDataBoundItems="true" class="form-control" runat="server">
            </asp:DropDownList>
        </div><!-- form group [order by] --> 
    </div><%--primera linea--%>
    <div class="form-inline" role="form">		
    <div class="form-group">
        <label for="dtp_input1" class="filter-col">Fecha Desde</label>
        <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input1" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaDesde" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input1" value="" /><br/>
    </div>
    <div class="form-group">
        <label for="dtp_input2" class="filter-col">Fecha Hasta</label>
        <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaHasta" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input2" value="" /><br/>
    </div>
    <div class="form-group">  
        <asp:LinkButton ID="lnkBuscar" class="btn btn-success"  runat="server"> Busqueda</asp:LinkButton>
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
    
<asp:GridView runat="server" ID="GrillaFacturas" AutoGenerateColumns="false"  class="table table-bordered table-hover table-striped" >
    <Columns>
        <asp:BoundField HeaderText="Nro" DataField="nro" />
        <asp:TemplateField HeaderText="Letra">
            <ItemTemplate>
                <asp:Label ID="lblLetra" runat="server" Text='<%#Eval("letra") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="PtoVenta" DataField="PtoVenta" />   
        <asp:TemplateField HeaderText="Cliente">
        <ItemTemplate>
                <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("cliente.razon") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha">
            <ItemTemplate>
                <asp:Label ID="lblFecha" runat="server"  Text='<%#   String.Format("{0:dd/MM/yyyy}", Eval("fecha")) %>'  ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">      
            <ItemTemplate>
                <asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:c}", Eval("total")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>      
                <asp:LinkButton ID="lblDetalle" runat="server" Text="Detalle" PostBackUrl='<%# String.Format("FacturasDetalle.aspx?ID={0}", Eval("id")) %>'  ></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnkPDF" CommandName="Imprimir" CommandArgument='<%#Eval("id") %>' runat="server"><span class="fa fa-file-pdf-o"></span> PDF</asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
    No hay facturas cargadas.
    </EmptyDataTemplate>
</asp:GridView>


</asp:Content>

