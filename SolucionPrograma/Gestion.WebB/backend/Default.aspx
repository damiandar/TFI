<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="aplicacion_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    #wrapper {
	    padding-left: 5px; 
    }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header">  Inicio </h1>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row"> 
<div class="col-lg-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><i class="fa fa-clock-o fa-fw"></i> Panel</h3>
            </div>
            <div class="panel-body">
                <div class="list-group">
                <%--<i class="fa fa-money fa-fw"></i>--%>
                    <a href="ventas/Default.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblPedidos" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-money"></i> Pedidos
                    </a>
                    <a href="compras/Default.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblAbastecimiento" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-calendar"></i> Solicitudes de abastecimiento                    
                    </a> 
                    <a href="compras/Ordenes.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblOrdenes" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-calendar"></i> Ordenes de Compra                    
                    </a> 
                    <a href="catalogo/ProductosListado.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblProductos" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-calendar"></i> Productos y Servicios
                    </a>
                    <a href="catalogo/InsumosListado.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblInsumos" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-calendar"></i> Insumos
                    </a>
                    <asp:HyperLink ID="hlComentarios" runat="server" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblComentarios" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-comment"></i> Ultimo Comentario
                    </asp:HyperLink> 
                    <a href="ventas/Cuenta.aspx" class="list-group-item">
                        <span class="badge"><asp:Label ID="lblClientes" runat="server" Text=""></asp:Label></span>
                        <i class="fa fa-fw fa-user"></i> Clientes
                    </a> 
                </div> 
            </div>
        </div>
    </div>
<div class="col-lg-8">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title"><i class="fa fa-money fa-fw"></i> Panel de Pedidos</h3>
        </div>
        <div class="panel-body">
            <div class="table-responsive">

            <asp:DataList runat="server" ID="Lista" class="table table-bordered table-hover table-striped">
                    <HeaderTemplate>
                        <th>Pedido N°</th><th>Cliente</th><th>Fecha</th><th>Total</th><th></th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td><%#Eval("id")%></td>
                        <td><%#Eval("cliente.razon")%></td>
                        <td><%#Eval("fecha", "{0:dd/M/yyyy}")%></td>
                        <td align="right"><%#Eval("total", "{0:c}")%></td>
                        <td>
                            <asp:HyperLink ID="hlVer" NavigateUrl='<%#String.Format("~/backend/Ventas/Detalle.aspx?PedidoID={0}", Eval("ID"))%>'  runat="server">Ver</asp:HyperLink>
                        </td>
                    </ItemTemplate>
            </asp:DataList>
            </div>
            <div class="text-right">
                <a href="ventas/default.aspx">Ver todos los pedidos <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
</div>

</div>
<!-- /.row -->
</asp:Content>

