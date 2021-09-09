<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="compras_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
    Pedidos de reposición
</h1>
<ol class="breadcrumb">
    <li><i class="fa fa-Inicio"></i><a href="default.aspx">Inicio</a></li>
    <li class="active">Compras</li>
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
        </div><!-- form group [search] -->
        <%--<div class="form-group">
            <label class="filter-col" style="margin-right:0;" for="pref-orderby">Order by:</label>
            <select id="pref-orderby" class="form-control">
                <option>Descendent</option>
            </select>                                
        </div> --%>
        <div class="form-group">
            <label class="filter-col" style="margin-right:0;" for="pref-orderby">Estado:</label>
            <asp:DropDownList ID="comboEstado" class="form-control" runat="server">

            </asp:DropDownList>                               
        </div>
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
        <asp:LinkButton ID="lnkBuscar" class="btn btn-primary"  runat="server"> <span class="glyphicon glyphicon-cog"></span> Busqueda</asp:LinkButton>
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
<div class="text-right"> 
    <asp:HyperLink ID="lnkNuevo" NavigateUrl="~/backend/abastecimiento/Default.aspx" runat="server">Nuevo <i class="fa fa-arrow-circle-right"></i> </asp:HyperLink>
</div>
<asp:GridView ID="GrillaReposicion" runat="server"   class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" >
    <EmptyDataTemplate>
    No hay compras
    </EmptyDataTemplate>
    <Columns>
    
    <asp:BoundField HeaderText="Nro" DataField="id" />  
    <asp:BoundField HeaderText="Notas" DataField="Notas" />    
        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />    
        <asp:BoundField HeaderText="Estado" DataField="Estado" />   
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkCotizacion" NavigateUrl='<%# string.Format("Cotizacion.aspx?ReposicionID={0}",Eval("ID"))%>'  runat="server">Cotizar</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>               
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%#String.Format("Detalle.aspx?ReposicionID={0}", Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkOrdenes" NavigateUrl='<%#String.Format("Ordenes.aspx?ReposicionID={0}", Eval("ID"))%>'  runat="server">Ordenes</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:LinkButton ID="lnkPDF" CommandName="Imprimir" CommandArgument='<%#Eval("id") %>' runat="server"><span class="fa fa-file-pdf-o"></span> PDF</asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>

<%--<asp:Button class="btn btn-primary"  ID="btnCrearSolicitud" runat="server" Text="Crear" />--%>

</asp:Content>

