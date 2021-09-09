<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FormaPago.aspx.vb" Inherits="carrito_FormaPago" %>
<%@ Register src="../controles/barracarrito.ascx" tagname="barracarrito" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>--%>

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
<section class="container drop-shadow lifted" id="content">
    
<div class="row" id="content-body">

<div class="span24 alpha omega" id="content-center">
<uc1:barracarrito ID="barracarrito1" Item="divPago" runat="server" />   
<div class="page payment-method-page">

<div class="page-title"><h1>Seleccione el metodo de pago</h1></div>
<div class="page-body checkout-data">

<div class="alert alert-info">
    <label class="checkbox">
        <strong>Ingrese los datos de su pago</strong> 
    </label>
</div>
    <asp:Panel runat="server" ID="PanelAlerta" Visible="false">
        <div class="select-button clearfix">
            <div class="terms-of-service alert alert-danger">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <asp:Label ID="lblMensaje" CssClass="checkbox span8" runat="server" Text=""></asp:Label>
            </div> 
        </div>
    </asp:Panel>
<div class="opt-list payment-methods">
<%--pago efectivo contra entrega--%>
<div class="opt-list-item payment-method-item">
    <div class="opt-data">
	    <div class="opt-control option-name">
		    <label for="paymentmethod_2" class="radio">
                <asp:RadioButton ID="rbPagoEfectivo" AutoPostBack="true" GroupName="metodopago" runat="server" />
			    <span class="opt-name">Pago Contra Entrega</span>
		    </label>
	    </div>
    </div>

<div class="opt-info payment-method-info" data-system-name="Payments.CashOnDelivery">
    <div class="muted">		<p>Fácilmente pagar en efectivo a la entrega.
    Los productos pedidos serán enviados inmediatamente .
    Usted paga directamente al cartero.</p></div>
</div>
</div> 
<%--tarjeta credito--%>
<div class="opt-list-item payment-method-item">
<div class="opt-data">
	<div class="opt-control option-name">
		<label for="paymentmethod_3" class="radio">
		<asp:RadioButton ID="rbTarjetaCredito" AutoPostBack="true" GroupName="metodopago" runat="server" />
        <span class="opt-name">Tarjeta de Credito</span></label>
    </div>
</div>
                            
<div class="opt-info payment-method-info" data-system-name="Payments.CashOnDelivery">
<asp:Panel ID="PanelTarjetaCredito" runat="server"  Visible="false">
<div class="form-horizontal">

    <div class="control-group">
    <label class="control-label required" for="CreditCardTypes">Seleccione su tarjeta </label>
    <asp:DropDownList ID="comboTarjeta" runat="server">
        <asp:ListItem Value="3">AMEX</asp:ListItem>
        <asp:ListItem Value="2">VISA</asp:ListItem>
        <asp:ListItem Value="1">MASTERCARD</asp:ListItem>
    </asp:DropDownList>
</div> 
    <%--titular--%>
    <div class="control-group"> 
        <label class="control-label required" for="CardholderName">Titular</label>
        <asp:TextBox ID="tbTitular" runat="server"></asp:TextBox>
    </div>
    <div class="control-group">
        <label class="control-label required" for="CardholderName">Número</label>
        <asp:TextBox ID="tbNumero" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server"   TargetControlID="tbNumero"
            Mask="9999-9999-9999-9999" MessageValidatorTip="true" 
            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"    
            MaskType="Number"
            ErrorTooltipEnabled="True" />
    </div>
    <%--fecha de vencimiento--%>
    <div class="control-group">
        <label class="control-label required" for="ExpireMonth">Valida hasta</label>
        <asp:DropDownList ID="comboMesVencimiento"  class="dropdownlists" style="min-width: 53px;"  runat="server"></asp:DropDownList>
	    /
        <asp:DropDownList ID="comboAnioVencimiento"  class="dropdownlists"  style="min-width: 83px;"  runat="server"></asp:DropDownList>
    </div> 
    <%--codigo de seguridad--%>
    <div class="control-group"> 
        <label class="control-label required" for="CardholderName">Codigo Seguridad</label>
        <asp:TextBox ID="tbCodigoSeguridad" runat="server"></asp:TextBox>
    </div>

</div>
</asp:Panel>
</div>
                           
</div>
<%--cuenta corriente--%>
<div class="opt-list-item payment-method-item">
	<div class="opt-data">
		<div class="opt-control option-name">
			<label for="paymentmethod_4" class="radio">
				<asp:RadioButton ID="rbCuentaCorriente" AutoPostBack="true"  GroupName="metodopago" runat="server" />
				<span class="opt-name">Cuenta Corriente</span>
			</label>
		</div>
	</div>
</div> 

</div>

</div>

<div class="select-button clearfix">
    <asp:LinkButton  class="btn pull-left"  ID="lnkVolver" runat="server"><i class="fa fa-caret-left"></i>&nbsp;	Volver	</asp:LinkButton> 
    <asp:LinkButton  class="btn btn-warning pull-right shipping-method-next-step-button"    ID="btnSiguiente" runat="server">
        Siguiente   &nbsp;<i class="fa fa-caret-right"></i>
    </asp:LinkButton>
</div>		
	
                		
</div>
</div>

</div>
          
</section> 
</div>


</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>--%>

