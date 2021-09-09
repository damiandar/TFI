<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FormaEnvio.aspx.vb" Inherits="carrito_FormaEnvio" %>

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
<section class="container drop-shadow lifted" id="content">
 
<%-- barraCarrito--%>
<uc1:barracarrito ID="barracarrito1" Item="divEnvio" runat="server" />


<div class="row" id="content-body">
<div class="span20 alpha omega" id="content-center">
<div class="page shipping-method-page">

<div class="page-title"><h1>Seleccione la forma de envio</h1></div>
<div class="page-body checkout-data">    
  
    <div class="opt-list shipping-options">
<%--OPCIONES--%>
    <%--distribucion empresa--%>
    <div class="opt-list-item payment-method-item selected">
    <div class="opt-data">
		<div class="opt-control option-name">
			<label for="paymentmethod_4" class="radio">
				<asp:RadioButton ID="rbDistribucionEmpresa" GroupName="metodoenvio" runat="server" />
				<span class="opt-name">Distribución de la empresa</span>
			</label>
		</div>
	</div>
</div>
    <%--correo argentino--%>
    <div class="opt-list-item payment-method-item selected">
	<div class="opt-data">
		<div class="opt-control option-name">
			<label for="paymentmethod_4" class="radio">
				<asp:RadioButton ID="rbCorreo" GroupName="metodoenvio" runat="server" />
				<span class="opt-name">Retira Cliente</span>
			</label>
		</div>
	</div>
</div>
    </div>
    <asp:Panel runat="server" ID="PanelAlerta" Visible="false">
        <div class="select-button clearfix">
            <div class="terms-of-service alert alert-danger">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <asp:Label ID="lblMensaje" CssClass="checkbox span8" runat="server" Text=""></asp:Label>
            </div> 
        </div>
    </asp:Panel>
    <div class="select-button clearfix">
        <asp:LinkButton class="btn pull-left" ID="lnkVolver" runat="server"><i class="fa fa-caret-left"></i>&nbsp;Volver</asp:LinkButton>   
        <asp:LinkButton  class="btn btn-warning pull-right shipping-method-next-step-button"  ID="btnSiguiente" runat="server">
            Siguiente   &nbsp;<i class="fa fa-caret-right"></i>
        </asp:LinkButton>
    </div>


</div>
</div>

   
</div>
</div>
</section>
</div>
</asp:Content>

