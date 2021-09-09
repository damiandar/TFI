<%@ Control Language="VB" AutoEventWireup="false" CodeFile="barracarrito.ascx.vb" Inherits="controles_barracarrito" %>
           
<nav class="order-progress">
    <ul class="unstyled clearfix">
        <li id="divCarrito" runat="server">      
            <a class="order-progress-step step-cart" href="Carrito.aspx">
                <span class="order-progress-label">Carrito</span>
            </a>
        </li>
        <li id="divDomicilio" runat="server">
            <a class="order-progress-step step-address" href="DomicilioEnvio.aspx">
                <span class="order-progress-label">Domicilio</span>
            </a>
        </li>
        <li id="divEnvio" runat="server">
            <a class="order-progress-step step-shipping" href="FormaEnvio.aspx">
                <span class="order-progress-label">Envio</span>
            </a>
        </li>
        <li id="divPago" runat="server">
            <a class="order-progress-step step-payment" href="FormaPago.aspx">
                <span class="order-progress-label">Pago</span>
            </a>
        </li>
        <li id="divConfirmacion" runat="server">
            <a class="order-progress-step step-confirm" href="Confirmacion.aspx">
                <span class="order-progress-label">Confirmar</span>
            </a>
        </li>
        <li id="divCompletar" runat="server">
            <a class="order-progress-step step-complete" href="Resumen.aspx">
                <span class="order-progress-label">Completar</span>
            </a>
        </li>
    </ul>
</nav>

<nav class="order-progress hide">
    <ul>
        
        <li>
            <a class="inactive-step" href="/frontend/en/cart">
                <span class="order-progress-label">Cart</span>
            </a>
        </li>
        <li>
            <a class="inactive-step" href="/frontend/en/Checkout/BillingAddress">
                <span class="order-progress-label">Address</span>
            </a>
        </li>
        <li>
            <a class="active-step" href="/frontend/en/Checkout/ShippingMethod">
                <span class="order-progress-label">Shipping</span>
            </a>
        </li>
        <li>
            <a class="inactive-step">
                <span class="order-progress-label">Payment</span>
            </a>
        </li>
        <li>
            <a class="inactive-step">
                <span class="order-progress-label">Confirm</span>
            </a>
        </li>
        <li>
            <a class="inactive-step">
                <span class="order-progress-label">Complete</span>
            </a>
        </li>
        
    </ul>
</nav>