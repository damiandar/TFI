<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Carrito.aspx.vb" Inherits="carrito_Carrito" %>
<%@ Register src="../controles/barracarrito.ascx" tagname="barracarrito" tagprefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" Runat="Server">
    <style type="text/css">
   #wrapper {
    padding-left: 0px;
}
</style>
</asp:Content>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
<div id="content-wrapper">
<section class="container drop-shadow lifted" id="content">
<div class="row" id="content-body">
<div class="span24 alpha omega" id="content-center">
<uc1:barracarrito ID="barracarrito1" Item="divCarrito" runat="server" />   
    <div class="page shopping-cart-page">
    <div class="page-title"><h1>Carrito</h1></div>

    <div class="page-body">
    <div class="order-summary-content">
    <asp:Panel ID="PanelMensaje" runat="server" >
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label> 
                 </div>
                </div>
            </div>
        </div> 
    </asp:Panel>

    <asp:DataList ID="DataList1" runat="server" HeaderStyle-CssClass="cart-header-row" ItemStyle-CssClass="cart-item-row" CssClass="cart table table-order-products">
    <HeaderTemplate>
        <th class="picture"></th>
        <th class="product">Producto</th>
        <th class="unit-price">Precio</th>
        <th>Cant.</th>
        <th class="omega">Total</th>
        <th class="remove">Eliminar</th> 
    </HeaderTemplate>
    <ItemTemplate>
            <td class="productpicture nobr">
                <asp:Image ID="Image1" runat="server"  AlternateText="aaa"  CssClass="img-polaroid" style="max-width:80px;max-height:80px" ></asp:Image>
	        </td>
		    <td class="product">
                <asp:HyperLink ID="hlnkProducto" runat="server" Text='<%#Eval("producto.nombrecorto") %>' NavigateUrl='<%#string.format("Detalle.aspx?producto_id={0}",Eval("producto.id")) %>' ></asp:HyperLink>
				<div class="short-desc">
				    <asp:Label ID="lblDetalle"   runat="server" Text='<%#Eval("producto.nombrelargo") %>'></asp:Label>
				</div>
				<div class="delivery-time">
			        <span class="delivery-time-label">Tiempo de entrega:</span>
                    <asp:Label ID="lblTiempoEntrega" CssClass="delivery-time-color"  runat="server" ></asp:Label>
				</div>
            </td>
            <td class="unit-price nobr">
                <asp:Label ID="lblPrecioUnitario" CssClass="product-unit-price" runat="server" Text='<%#String.Format("{0:C}",Eval("producto.precio.valorfinal")) %>' ></asp:Label>
		    </td>
		    <td class="nobr">
                <span class="measure-unit"><asp:TextBox ID="tbCantidad" CssClass="qty-input" Text='<%#Eval("cantidad") %>' runat="server"></asp:TextBox></span>
		    </td>
		    <td class="nobr omega">
			    <span class="product-subtotal"><asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:C}",Eval("total")) %>'></asp:Label></span>
		    </td>
            <td class="remove">
                <asp:LinkButton ID="lnKBorrar" CommandArgument='<%#Eval("producto.id") %>' CommandName="Borrar" runat="server">
                        <i class="glyphicon glyphicon-trash"></i>
                </asp:LinkButton>
                <asp:HiddenField ID="hProductoID" runat="server" Value='<%#Eval("producto.id") %>' />
 		    </td>
    </ItemTemplate>
    </asp:DataList>

    <div class="common-buttons clearfix">
        <asp:LinkButton ID="lnkActualizarCarrito" runat="server"  class="btn pull-right update-cart-button" >
            <i class="fa fa-refresh"></i>&nbsp;Actualizar Carrito
        </asp:LinkButton>
        <asp:LinkButton ID="LinkButton1"  cssclass="btn pull-left continue-shopping-button" PostBackUrl="~/frontend/Default.aspx"  runat="server">
            <i class="fa fa-caret-left"></i>&nbsp;Continuar comprando
        </asp:LinkButton>
    </div>
    <div class="cart-footer row-fluid">
    <!-- Totals -->
    <div class="span8">
		
    <div class="total-info">
    <table class="cart-total table">
    <tbody>
    <tr>
        <td class="cart-total-left"> <span class="nobr">Impuestos:</span></td>
        <td class="cart-total-right"><span><span class="product-price"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></span> </span></td>
    </tr>
    <tr class="omega lined">
        <td class="cart-total-left"> <span class="nobr"><strong>Total:</strong></span></td>
        <td class="cart-total-right"><span class="product-price order-total"><asp:Label ID="lblTotalCarrito" runat="server" Text=""></asp:Label> </span></td>
    </tr>
    </tbody>
    </table>
    </div>


    <div class="checkout-buttons">
        <asp:LinkButton ID="lnkCheckOut" CssClass="btn btn-primary btn-large pull-right checkout-button" runat="server"> 
            Finalizar Compra&nbsp;<i class="fa fa-arrow-right" style="font-size: 18px"></i>
        </asp:LinkButton>			
    </div>

    </div>
    </div>
    </div>
    </div>
    </div>
</div>
</div>
</section>
</div>
</asp:Content>

