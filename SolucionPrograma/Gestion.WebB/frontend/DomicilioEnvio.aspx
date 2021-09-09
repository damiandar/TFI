<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="DomicilioEnvio.aspx.vb" Inherits="carrito_DomicilioEnvio" %>
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

 <uc1:barracarrito ID="barracarrito1" Item="divDomicilio" runat="server" />   



<div class="row" id="content-body">
           
<div class="span24 alpha omega" id="content-center">
    
<div class="page billing-address-page">
    <div class="page-title"><h1>Domicilio de Envio</h1></div>
    <div class="page-body checkout-data">
        
        
        <div class="block">
            <div class="block-title">Ingresar domicilio de envio </div>
            <div class="block-body">
                <div class="enter-address">
<div class="enter-address-body">


<input name="NewAddress.Id" id="NewAddress_Id" type="hidden" value="0" data-val-number="The field ID must be a number." data-val="true" data-val-required="'Id' must not be empty.">

<div class="form-horizontal">  
 
    <%--domicilio--%>
    <div class="control-group">
        <label class="control-label required" for="Address1">Domicilio</label>
        <div class="controls">
            <asp:TextBox ID="tbDomicilio" runat="server" data-val="true" data-val-required="Street address is required"></asp:TextBox>
        </div>
    </div> 
    <%--localidad--%>
    <div class="control-group">
        <label class="control-label required" for="City">Localidad</label>
        <div class="controls">
            <asp:TextBox ID="tbLocalidad" data-val="true" data-val-required="City is required" runat="server"></asp:TextBox>
        </div>
    </div>
    <%--codigo postal--%>
    <div class="control-group">
        <label class="control-label required" for="ZipPostalCode">Codigo Postal</label>
        <div class="controls">
            <asp:TextBox ID="tbCodigoPostal" runat="server"  data-val="true" data-val-required="Zip / postal code is required"></asp:TextBox>
        </div>
    </div>
    <%--provincia--%>
    <div class="control-group">
        <label class="control-label" for="StateProvinceId">Provincia</label>
        <div class="controls">
            <asp:DropDownList ID="comboProvincia" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="control-group">
        <label class="control-label required" for="PhoneNumber">Telefono</label>
        <div class="controls">
            <asp:TextBox ID="tbTelefono" runat="server" data-val="true" data-val-required="Phone is required"></asp:TextBox>
         </div>
    </div>
     

    <div class="control-group">
        <div class="controls muted address-required-hint">
            * Los elementos con asterisco son necesarios y tienen que ser rellenados. 
        </div>
    </div>

</div>

                        </div>
<div class="buttons clearfix">
    <asp:LinkButton class="btn pull-left" ID="lnkVolver" runat="server"><i class="fa fa-caret-left"></i>&nbsp;Volver</asp:LinkButton>   
    <asp:LinkButton class="btn btn-warning pull-right new-address-next-step-button" ID="btnSiguiente" runat="server">Siguiente&nbsp;<i class="fa fa-caret-right"></i></asp:LinkButton>
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
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>--%>

