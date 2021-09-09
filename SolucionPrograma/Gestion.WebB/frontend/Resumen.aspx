<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Resumen.aspx.vb" Inherits="carrito_Resumen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css">
   #wrapper {
    padding-left: 0px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div id="page product-details-page">

<!-- Terms of service -->     
<section class="container drop-shadow lifted" id="content">
<div class="row" id="content-body">     

<div class="span24 alpha omega" id="content-center">
    
<div class="page order-details">
    <div class="clearfix">
        <div class="page-title pull-left">
            <div class="title"><h1>Informacion del pedido</h1></div>
        </div>

        <div class="print-buttons pull-right" style="margin-top: 12px">
             <asp:LinkButton class="btn pdf-order-button" ID="lnkPdf" runat="server" rel="nofollow">
                <i class="fa fa-file-pdf-o"></i>PDF
            </asp:LinkButton>
        </div>
    </div>

<div class="page-body">

    <dl class="dl-horizontal">
            <dt>Nro:</dt>
            <dd><asp:Label ID="lblPedidoNro" runat="server"></asp:Label></dd>
            <dt>Fecha:</dt>
            <dd><asp:Label ID="lblPedidoFecha" runat="server"></asp:Label></dd>
            <dt>Razon Social:</dt>
            <dd><asp:Label ID="lblCliente" runat="server" Text=""></asp:Label></dd>
            <dt>E-mail:</dt>
            <dd><asp:Label ID="lblMail" runat="server" Text=""></asp:Label></dd>
            <dt>Total:</dt>
            <dd class="text-success"><strong><asp:Label ID="lblPedidoTotal" runat="server"></asp:Label></strong></dd>
    </dl>
    
    <div class="order-details-box well">
        <table class="order-details-table">
            <tbody>
                <tr>
                    <td class="billinginfo">
                        <div class="title"><strong>Domicilio Facturacion:</strong></div>
                        <div class="address1">Domicilio: <asp:Label ID="lblDomicilioFactura" runat="server" Text=""></asp:Label></div>
                        <div class="city-state-zip">Localidad: <asp:Label ID="lblLocalidadFactura" runat="server" Text=""></asp:Label></div>
                        <div class="city-state-zip">Codigo Postal:<asp:Label ID="lblCPFactura" runat="server" Text=""></asp:Label></div>
                        <div class="country"><asp:Label ID="lblProvinciaFactura" runat="server" Text=""></asp:Label> </div> 
                        <div class="phone">Telefono: <asp:Label ID="lblTelefonoFactura" runat="server" Text=""></asp:Label></div> 
                    
                        <p class="payment-method">
                            <div class="payment-method-label"><strong>Metodo de pago:</strong></div>
                            <div class="payment-method-value"><asp:Label ID="lblFormaPago" runat="server" Text=""></asp:Label> </div>
                        </p>
                    </td>
                    <td class="shippinginfo">
                            <div class="title"><strong>Domicilio Envio:</strong></div>
                            <div class="address1">Domicilio:<asp:Label ID="lblDomicilioEnvio" runat="server" Text=""></asp:Label></div>
                            <div class="email">Localidad:<asp:Label ID="lblLocalidadEnvio" runat="server" Text=""></asp:Label>  </div>
                            <div class="city-state-zip">Codigo Postal:<asp:Label ID="lblCPEnvio" runat="server" Text=""></asp:Label></div>
                            <div class="country"><asp:Label ID="lblProvinciaEnvio" runat="server" Text=""></asp:Label> </div> 
                            <div class="phone">Telefono:<asp:Label ID="lblTelefonoEnvio" runat="server" Text=""></asp:Label> </div>
                            <p class="shipping-method">
                                <div class="shipping-method-label"> <strong>Metodo de envio:</strong>     </div>
                                <div class="shipping-method-value"><asp:Label ID="lblFormaEnvio" runat="server" Text=""></asp:Label>                   </div>
                            </p>
                        </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="section-title">Productos</div>

<div class="products-box">

<asp:DataList ID="GrillaItems" runat="server" ItemStyle-CssClass="product-body product-body-simple" CssClass="table table-order-items table-order-products" >
<HeaderTemplate>
        <th class="a-center">Codigo</th>
        <th>Producto</th>
        <th class="ar">Unitario</th>
        <th class="ac">Cantidad</th>
        <th class="ar">Total</th>
</HeaderTemplate>
<ItemTemplate>
<td><asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("producto.codigointerno") %>'></asp:Label></td>
<td><asp:HyperLink ID="hlnkProducto" runat="server" Text='<%#Eval("producto.descripcion") %>' NavigateUrl='<%#string.format("Detalle.aspx?producto_id={0}",Eval("producto.id")) %>' ></asp:HyperLink></td>
<td class="ar"><asp:Label ID="lblPrecioUnitario"  runat="server" Text='<%#String.Format("{0:C}",Eval("producto.precio.valorfinal")) %>' ></asp:Label></td>
<td class="ac"> <asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("cantidad") %>' ></asp:Label></td>
<td class="ar text-success"><asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:C}",Eval("total")) %>'></asp:Label></td>
</ItemTemplate>
</asp:DataList>
    
<div class="actions clearfix">
	<div class="pull-right">
        <a class="btn btn-primary re-order-button" href="Default.aspx" rel="nofollow"><i class="fa fa-shopping-cart"></i>Hacer otra compra</a>
	</div>
</div>

</div>
<%--TOTALES--%>   
<div class="row-fluid">
    <div class="total-info span8 offset16">
        <table class="cart-total table">
            <tbody>
                <tr>
                    <td class="cart-total-left"><strong>Total del pedido:</strong></td>
                    <td class="cart-total-right"><span class="nobr"><strong><asp:Label ID="lblTotalCarrito" runat="server" Text=""></asp:Label></strong></span></td>
                </tr>
            </tbody>
        </table>
    </div>
</div>

</div>
</div>
    
</div>

</div>
</section>
</div>

</asp:Content>

