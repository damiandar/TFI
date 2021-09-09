<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuIzquierda.ascx.vb" Inherits="controles_MenuIzquierda" %>

<div id="menubackend" class="collapse navbar-collapse navbar-ex1-collapse" runat="server">
    <ul class="nav navbar-nav side-nav">
        <%--inicio--%>
        <li class="active">
            <asp:HyperLink ID="hlInicio"  NavigateUrl="~/backend/Default.aspx" runat="server"><i class="fa fa-fw fa-Inicio"></i> Inicio</asp:HyperLink>
        </li>
        <%--graficos--%>
        <li>
            <asp:HyperLink ID="hlGraficos"  NavigateUrl="~/aplicacion/Graficos.aspx" runat="server"><i class="fa fa-fw fa-users"></i> Graficos</asp:HyperLink>
        </li>
        <%--compras--%>
      <li>
            <a href="javascript:;" data-toggle="collapse" data-target="#demoCompras"  ><i class="fa fa-fw fa-arrows-v"></i> Compras<i class="fa fa-fw fa-caret-down"></i></a>
            <ul id="demoCompras" class="collapse" > 
                <li>
                    <asp:HyperLink ID="hlCompras" NavigateUrl="~/backend/compras/default.aspx" runat="server">Pedidos</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlOrdenes" NavigateUrl="~/backend/compras/ordenes.aspx" runat="server">Ordenes</asp:HyperLink>
                </li>
                <li>     
                    <asp:HyperLink ID="hlProveedores"  NavigateUrl="~/backend/compras/Proveedores.aspx" runat="server"><i class="fa fa-fw fa-table"></i> Proveedores</asp:HyperLink>
                 </li>
                 <li>     
                    <asp:HyperLink ID="hlRemitos"  NavigateUrl="~/backend/compras/remitos.aspx" runat="server"><i class="fa fa-fw fa-table"></i> Remitos</asp:HyperLink>
                 </li>
            </ul>
        </li> 
        <%--abastecimiento--%>
       <li>
            <asp:HyperLink ID="hlAbastecimientos"  NavigateUrl="~/backend/abastecimiento/Default.aspx" runat="server"><i class="fa fa-fw fa-table"></i> Abastecimiento</asp:HyperLink>
        </li> 
        <%--ventas--%>
        <li>
            <a href="javascript:;" data-toggle="collapse" data-target="#demoVentas"  ><i class="fa fa-fw fa-arrows-v"></i> Ventas<i class="fa fa-fw fa-caret-down"></i></a>
            <ul id="demoVentas" class="collapse" > 
                <li>
                      <asp:HyperLink ID="hlVentas"  NavigateUrl="~/backend/ventas/Default.aspx" runat="server"><i class="fa fa-fw fa-wrench"></i> Pedidos</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlCuentas"  NavigateUrl="~/backend/ventas/Cuenta.aspx" runat="server"><i class="fa fa-fw fa-users"></i> Clientes</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlFacturas"  NavigateUrl="~/backend/ventas/Facturas.aspx" runat="server"><i class="fa fa-fw fa-users"></i> Facturas</asp:HyperLink>
                </li>
            </ul>
        </li>
        <%--catalogo--%>
        <li>
            <a href="javascript:;" data-toggle="collapse" data-target="#demoCatalogo"  ><i class="fa fa-fw fa-arrows-v"></i> Catalogo<i class="fa fa-fw fa-caret-down"></i></a>
            <ul id="demoCatalogo" class="collapse" > 
                <li>
                    <asp:HyperLink ID="hlCategorias" NavigateUrl="~/backend/catalogo/Categorias.aspx" runat="server"> Categorias</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlInsumos" NavigateUrl="~/backend/catalogo/insumosListado.aspx" runat="server"> Insumos</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hlProductos" NavigateUrl="~/backend/catalogo/productosListado.aspx" runat="server"> Productos</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/backend/catalogo/ListaPrecios.aspx" runat="server"> Lista de Precios</asp:HyperLink>
                </li>
            </ul>
        </li>
        <%--administracion--%>
        <li>
            <a href="javascript:;" data-toggle="collapse" data-target="#administracion"  ><i class="fa fa-fw fa-wrench"></i> Administracion<i class="fa fa-fw fa-caret-down"></i></a>
            <ul id="administracion" class="collapse" > 
                <li>
                    <asp:HyperLink ID="hlBackUp" NavigateUrl="~/backend/administracion/backup.aspx" runat="server"><i class="fa fa-fw fa-wrench"></i> Backup</asp:HyperLink>
                </li>
                <li>    
                    <asp:HyperLink ID="hlBitacora" NavigateUrl="~/backend/administracion/bitacora.aspx" runat="server"><i class="fa fa-fw fa-wrench"></i> Bitacora</asp:HyperLink>
                </li>
            </ul>
        </li>
        <%--encuestas--%>
         <li>
            <asp:HyperLink ID="hlEncuestas"  NavigateUrl="~/backend/encuestas/default.aspx" runat="server"><i class="fa fa-fw fa-wrench"></i> Encuestas</asp:HyperLink>
        </li>
    </ul>
</div>

<div id="menufrontend" class="collapse navbar-collapse navbar-ex1-collapse" runat="server">
    <ul class="nav navbar-nav side-nav">
        <li class="active">
            <asp:HyperLink ID="hlInicioBackEnd" NavigateUrl="~/frontend/Default.aspx" runat="server"><i class="fa fa-fw fa-Inicio"></i> Inicio</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="hlPanel" NavigateUrl="~/frontend/Panel.aspx" runat="server"><i class="fa fa-fw fa-credit-card"></i> Mis Pedidos</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="hlCarrito" NavigateUrl="~/frontend/carrito.aspx"  runat="server"><i class="fa fa-fw fa-bar-chart-o"></i> Carrito</asp:HyperLink>
        </li>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <li>
            <a href="javascript:;" data-toggle="collapse" data-target="#demo<%#Eval("id") %>"><i class="fa fa-fw fa-arrows-v"></i> <%# Eval("descripcion")%><i class="fa fa-fw fa-caret-down"></i></a>
            <ul id="demo<%#Eval("id") %>" class="collapse">
            <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hlCat" NavigateUrl='<%# string.Format("~/frontend/default.aspx?subcat={0}",Eval("ID"))%>'   Text='<%# Eval("descripcion")%>'   runat="server"></asp:HyperLink>
                    </li>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
        </li>
        </ItemTemplate>
        </asp:Repeater>
        
      
    </ul>
</div>