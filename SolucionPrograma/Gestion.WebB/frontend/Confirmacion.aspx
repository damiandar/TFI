<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Confirmacion.aspx.vb" Inherits="carrito_Confirmacion" %>

<%@ Register src="../controles/barracarrito.ascx" tagname="barracarrito" tagprefix="uc1" %>


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
<div id="content-wrapper">

<!-- Terms of service -->
<section id="content" class="container drop-shadow lifted">
<div id="content-body" class="row">
                
<uc1:barracarrito ID="barracarrito1" Item="divConfirmacion" runat="server" />

<div id="content-center" class="span24 alpha omega">
    
<div class="page checkout-confirm-page">

<div class="page-title"><h1>Por favor confirme su pedido.</h1></div>

<div class="page-body checkout-data">
         
<div class="page-intro">
Por favor, compruebe el total del pedido y los detalles relativos a la dirección de facturación y , si es necesario , la dirección de envío . Puede hacer correcciones a su entrada en cualquier momento haciendo clic en <strong> volver </strong>. Si todo es como debe ser , entregar su pedido a nosotros por hacer clic en <strong> confirmar</strong>.
</div>
 
<div class="confirm-order">
            
<div class="select-button bottom clearfix">
<div class="payment-method">
    <div class="block block-bordered">
        <div class="block-title">
            <b><span>Metodo de pago</span></b>
            <asp:LinkButton ID="lnkFormaPagoCambiar" class="change-checkout-data pull-right" runat="server">Cambiar</asp:LinkButton>
        </div>
        <div class="block-body"><asp:Label ID="lblMetodoPago" runat="server" Text=""></asp:Label></div>
    </div>
</div>
    </div>
    </div>
<div class="confirm-order">
            
<div class="select-button bottom clearfix">
<div class="shipping-method">
    <div class="block block-bordered">
        <div class="block-title">
                <b><span>Metodo de envio</span></b>
                <asp:LinkButton ID="lnkFormaEnvioCambiar" class="change-checkout-data pull-right" runat="server">Cambiar</asp:LinkButton>
	    </div>
        <div class="block-body"><asp:Label ID="lblMetodoEnvio" runat="server" Text=""></asp:Label></div>
    </div>
</div>
    </div>
    </div>  
<div class="confirm-order">
            
<div class="select-button bottom clearfix">
    <div class="billinginfo span12">
        <div class="block block-bordered">
            <div class="block-title">
                <b><span>Domicilio de facturacion</span></b>
                <a class="change-checkout-data pull-right" href="">Cambiar</a>
            </div>
            <div class="block-body">
                <div class="name"><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>  </div>
                <div class="email">Email:<asp:Label ID="lblMail" runat="server" Text=""></asp:Label>  </div>
                <div class="phone">Telefono:<asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label> </div> 
                <div class="address1"><asp:Label ID="lblDomicilio" runat="server" Text=""></asp:Label> </div>
                <div class="city-state-zip"><asp:Label ID="lblLocalidad" runat="server" Text=""></asp:Label>  </div>
                <div class="country"><asp:Label ID="lblPais" runat="server" Text=""></asp:Label>   </div>
            </div>
        </div>
    </div>
    </div>
        </div>
<div class="confirm-order">
            
<div class="select-button bottom clearfix">
    <div class="shippinginfo span12">
        <div class="block block-bordered">
            <div class="block-title">
                <b><span>Domicilio Envio</span></b>
                <asp:LinkButton ID="lnkDomicilioEnvioCambiar" class="change-checkout-data pull-right" runat="server">Cambiar</asp:LinkButton>
            </div>
            <div class="block-body">
                <div class="address1"><asp:Label ID="lblDomicilioEnvio" runat="server" Text=""></asp:Label> </div>
                <div class="city-state-zip"><asp:Label ID="lblLocalidadEnvio" runat="server" Text=""></asp:Label>  </div>
                <div class="name"><asp:Label ID="lblCPEnvio" runat="server" Text=""></asp:Label>   </div>
                <div class="country"><asp:Label ID="lblProvinciaEnvio" runat="server" Text=""></asp:Label>   </div>
                <div class="phone">Telefono:<asp:Label ID="lblTelefonoEnvio" runat="server" Text=""></asp:Label> </div>
            </div>
        </div>
    </div>
    </div>
        </div>
<div class="confirm-order">
<div class="select-button bottom clearfix">
<div class="block block-bordered comment-box">
    <div class="block-title">¿Quieres decirnos algo respecto a este pedido ?</div>
    <div class="block-body">
        <asp:TextBox ID="tbComentarios" TextMode="MultiLine"   runat="server"></asp:TextBox>
    </div>
</div>
</div>
</div>


<div class="order-summary-body">

<div class="order-summary-content">

<%--Grilla Items--%>

<asp:DataList ID="GrillaItems" HeaderStyle-CssClass="cart-header-row" ItemStyle-CssClass="product-body product-body-simple" runat="server" CssClass="cart table table-order-products">
<HeaderTemplate>
	    <th>CODIGO</th>
		<th class="picture"></th>
        <th>Producto</th>
        <th class="unit-price">Precio</th>
        <th>Cantidad</th>
        <th class="omega">Total</th>
</HeaderTemplate>
<ItemTemplate>
		<td class="remove"><input name="removefromcart" type="checkbox" value=""></td>
		<td class="productpicture nobr"> 
            <asp:Image ID="Image1" runat="server" style="max-width:80px;max-height:80px" AlternateText="aaa"  CssClass="img-polaroid"  ></asp:Image>
	    </td>
		<td class="product">
            <asp:HyperLink ID="hlnkProducto" runat="server" Text='<%#Eval("producto.descripcion") %>' NavigateUrl='<%#string.format("Detalle.aspx?producto_id={0}",Eval("producto.id")) %>' ></asp:HyperLink>
			    <div class="short-desc">
				    <asp:Label ID="lblDetalle" runat="server" Text='<%#Eval("producto.nombrelargo") %>'></asp:Label>
				</div>
                <div class="delivery-time">
					<span class="delivery-time-label">Tiempo de entrega:</span>
					<span title="7 days" class="delivery-time-color" style="background-color:#008000"></span>
					<span class="delivery-time-value">7 dias</span>
				</div>
        </td>
        <td class="unit-price nobr">
                <asp:Label ID="lblPrecioUnitario" CssClass="product-unit-price" runat="server" Text='<%#String.Format("{0:C}",Eval("producto.precio.valorfinal")) %>' ></asp:Label>
		</td>
		<td class="nobr">
            <asp:Label ID="lblCantidad" runat="server" Text='<%#Eval("cantidad") %>' ></asp:Label>
			<span class="measure-unit"></span>
		</td>
		<td class="nobr omega">
			<span class="product-subtotal">
                <asp:Label ID="lblTotal" runat="server" Text='<%# String.Format("{0:C}",Eval("total")) %>'></asp:Label>
            </span>
		</td>
</ItemTemplate>
</asp:DataList>

<div class="cart-footer row-fluid">
<div class="span16 order-totals-left"></div>

<!-- Totals -->
<div class="span8">

				
<div class="total-info">
    <table class="cart-total table">
        <tbody>
            <tr class="omega lined">
                <td class="cart-total-left"><span class="nobr"><strong>Total:</strong></span></td>
                <td class="cart-total-right"><span><span class="product-price order-total"><asp:Label ID="lblTotalCarrito" runat="server" Text=""></asp:Label></span></span></td>
            </tr>
        </tbody>
    </table>
</div>

</div>
</div>

</div>

</div>

<div class="confirm-order">
<div class="select-button bottom clearfix">
    <div class="terms-of-service alert alert-info"><label class="checkbox span10">Al hacer click se confirmara el pedido.</label></div> 
   <asp:LinkButton class="btn pull-left" ID="lnkVolver" runat="server"><i class="fa fa-caret-left"></i>&nbsp;Volver</asp:LinkButton>   
   <asp:LinkButton ID="lnkConfirmar"  runat="server"  CssClass="btn btn-danger btn-large pull-right confirm-order-next-step-button"> Confirmar &nbsp;<i class="fa fa-fw fa-caret-right"></i> </asp:LinkButton>
</div>
</div>
 

</div>
</div>
                
</div>
</section>

</div>

</asp:Content> 

