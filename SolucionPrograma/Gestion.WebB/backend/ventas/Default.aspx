<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="ventas_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server"> 
 <h1 class="page-header">
    Ventas
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="Default.aspx">Inicio</a>
    </li>
    <li class="active">
        Pedidos
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
 
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
        <label class="filter-col" style="margin-right:0;" for="comboClientes">Cliente:</label>
            <asp:DropDownList ID="comboClientes" AppendDataBoundItems="true" class="form-control" runat="server">
            </asp:DropDownList>
        </div> 
        <div class="form-group">
            <label class="filter-col" style="margin-right:0;" for="comboEstado">Estado:</label>
            <asp:DropDownList ID="comboEstado" AppendDataBoundItems="true" class="form-control" runat="server">
            </asp:DropDownList>
        </div> 
    </div><%--primera linea--%>
    <div class="form-inline" role="form">		
    <div class="form-group">
        <label for="dtp_input1" class="filter-col"  >Fecha Desde</label>
        <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input1" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaDesde" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input1" value="" /><br/>
    </div>
    <div class="form-group">
        <label for="dtp_input2" class="filter-col"  >Fecha Hasta</label>
        <div class="input-group date form_date col-md-5" data-date="" data-date-format="dd/mm/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
            <asp:TextBox  class="form-control" Width="100px" ID="tbFechaHasta" runat="server"></asp:TextBox>
            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
			<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
        </div>
		<input type="hidden" id="dtp_input2" value="" /><br/>
    </div>
    <div class="form-group">  
        <asp:LinkButton ID="lnkBuscar" class="btn btn-success"  runat="server"> Buscar</asp:LinkButton>
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
<asp:GridView ID="GrillaPedidos" runat="server"  AllowPaging="true" PageSize="9"   PagerStyle-CssClass="estilospaginador"  AutoGenerateColumns="false"  class="table table-bordered table-hover table-striped">
    <EmptyDataTemplate>
    No hay ventas pendientes.
    </EmptyDataTemplate>
    <Columns>        
        <asp:TemplateField Headertext="Nro Pedido">      
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField Headertext="CUIT">      
        <ItemTemplate>
            <asp:Label ID="lblCuit" runat="server" Text='<%#Eval("cliente.cuit") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Razon Social" >
            <ItemTemplate>
                <asp:Label ID="lblRazon" runat="server" Text='<%#Eval("cliente.razon") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>     
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("EstadoPedido") %>' ></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Forma Envio">
            <ItemTemplate>
                <asp:Label ID="lblEnvio" runat="server" Text='<%#Eval("formaenvio.descripcion") %>'></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="Forma Pago">
            <ItemTemplate>
                <asp:Label ID="lblPago" runat="server" Text='<%#Eval("formapago.descripcion") %>'></asp:Label> 
            </ItemTemplate>
        </asp:TemplateField>  
        <asp:BoundField HeaderText="Fecha Creacion"   DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("detalle.aspx?PedidoID={0}",Eval("ID"))%>'  runat="server">EDITAR</asp:HyperLink>
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

