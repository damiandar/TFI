<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="carrito_Detalle" %>
<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register src="../controles/menuizquierda.ascx" tagname="menuizquierda" tagprefix="uc1" %>
<%@ Register src="../controles/encuestas.ascx" tagname="encuestas" tagprefix="uc4" %>

<%@ Register src="../controles/BreadcrumbCategoria.ascx" tagname="BreadcrumbCategoria" tagprefix="uc2" %>

<%@ Register src="../controles/GrillaProductosRelacionados.ascx" tagname="GrillaProductosRelacionados" tagprefix="uc3" %>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc4:encuestas ID="encuestas1" runat="server" />
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" Runat="Server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:menuizquierda ID="menuizquierda1" runat="server" />       
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page product-details-page">

<!--product breadcrumb-->
<uc2:BreadcrumbCategoria ID="BreadcrumbCategoria1" runat="server" />

<div id="TotalPriceUpdateContainer" class="page-body update-container" data-referto="#ProductAttributes, #AddToCart, #ProductBundleOverview" data-url="">
<div id="product-details-form">            
<div class="row-fluid top-content">
<div class="product-image span12">
                        
<!--product pictures-->
<div id="pd-gallery-container-outer">
<div id="pd-gallery-container">
							    

<div id="pd-gallery" class="picture pd-gallery">

<div class="sg-image-wrapper">
    <div class="sg-image" style="width: 200px; height: 200px; top: 0px; left: 26px;">
    <a href="" target="_blank">
        <asp:Image ID="Image1" runat="server"  data-zoom-image="telefon.jpg" style="max-height: 200px;" />  
    </a>
    </div>
    <div class="ajax-loader-small sg-loader" style="display: none;">
    </div>
</div>

</div>
</div>
</div>
                        
<%--imagen de abajo--%>
<div class="manufacturer-pics">
    <div class="manufacturer-item">
        <div class="picture">
            <%--<a href="/frontend/en/avm" title="Show details for AVM">--%>
                <asp:Image ID="Image2" runat="server"  />  
            <%--</a>--%>
        </div>
    </div>
</div>

<!-- atributos -->
<table id="ProductAttributes" class="attributes">
<tbody>
    <tr valign="top" class="attr-sku ">
        <td class="caption bold">CODIGO:<asp:Label ID="lblCodigo" runat="server" Text=""></asp:Label></td><td class="value"></td> 
    </tr>
</tbody>
</table>

</div>

<div class="product-data span12">
    <div class="page-title alpha">
        <h1 class="product-name" itemprop="name"><asp:Label ID="lblNombreCorto" runat="server" ></asp:Label></h1>
    </div>
    
    <div id="details-cnt">
        <div class="short-description line alpha"><asp:Label ID="lblNombreLargo" runat="server" ></asp:Label></div>


<!--product reviews-->
<div class="product-reviews-overview line clearfix" itemprop="aggregateRating" itemscope="" itemtype="http://schema.org/AggregateRating">
        
<div class="product-review-box pull-left">
<div class="rating"><div id="divrating" runat="server" ></div></div><span>(<asp:LinkButton ID="lnkReviews" runat="server"></asp:LinkButton>)</span>
</div>
 
<div class="product-review-links pull-right"> 
<asp:HyperLink ID="linkPublicarComentario" runat="server">Publique su comentario</asp:HyperLink>
<span itemprop="ratingValue" style="display:none;">5.0</span>
<span itemprop="reviewCount" style="display:none;">1</span>
</div>
</div>
<div id="AddToCart" class="">


<div class="price-details price-block line well">
        <div class="clearfix">

            <div class="pull-right without-discount-block">
						
				<span></span>

                <span class="product-price current text-success">
                    <span class="product-price-without-discount" itemprop="price">
                        <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label>
                    </span>
                </span>
            </div>
        
			<div class="pull-left">
				<span></span>

				<span class="product-price with-discount current">
					<span class="product-price-with-discount" itemprop="price">
					</span>
				</span>
			</div>
                    
        </div>

    <!-- base price -->
<%--    <div class="base-price muted hide fade">
                
    </div>--%>

    <!-- delivery time -->			
		<div class="delivery-time"> 
            <span class="delivery-time-label">Tiempo de entrega:</span>
			<asp:Label ID="lblTiempoEntrega" CssClass="delivery-time-color"  runat="server" ></asp:Label>
		</div>
</div>
<div class="add-to-cart line">
    <div class="form-inline clearfix" style="text-align:right;">
        <label class="qty-label" for="addtocart">Cantidad</label>:
        <input class="qty-input" data-val="true" data-val-number="The field Qty must be a number." id="addtocart"  style="width:25px" type="text" value="1">                             
        <span style="margin-right: 5px;"></span>
        <asp:LinkButton ID="lnkAgregarCarrito" CssClass="btn btn-lg btn-warning add-to-cart-button"  runat="server">Agregar al carrito <i class="fa fa-plus-circle"></i></asp:LinkButton>
    </div>
</div>
    

</div>
 
 
                    
                
</div>
                     
</div>
            
</div>
            
<div class="bottom-content">

<!-- tabs -->
<div id="product-detail-tabs" class="tabbable">
	<ul class="nav nav-tabs">
		<li class="active"><a href="#product-detail-tabs-1" data-toggle="tab" data-loaded="true">Detalles</a></li>
<%--        <li><a href="#product-detail-tabs-2" data-toggle="tab" data-loaded="true">Especificaciones</a></li>--%>
        <li><a href="#product-detail-tabs-3" data-toggle="tab" data-loaded="true" class="clearfix"><span class="tab-caption">Comentarios</span><span class="label label-info"> <asp:Label ID="lblComentariosCantidad" runat="server" Text=""></asp:Label></span></a></li>
	</ul>
    
<div class="tab-content">
    <%--detalles--%>
    <div class="tab-pane fade in active" id="product-detail-tabs-1">
		<div itemprop="description">
            <div><br/><asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label></div>
            <div>&nbsp;
            </div>
        </div>
    </div>


    <%--comentarios--%>
    <div class="tab-pane fade" id="product-detail-tabs-3">
	    <div class="product-review-list">

<asp:DataList ID="GrillaComentarios" runat="server" class="table table-bordered table-hover table-striped" >
<FooterTemplate>
<asp:Label Visible='<%#boolean.Parse((GrillaComentarios.Items.Count=0).ToString())%>' runat="server" ID="lblNoRecord" Text="No hay comentarios"></asp:Label>
</FooterTemplate>
<ItemTemplate>
    <div class="product-review-item">
    <div class="review-title">
        <div class="rating"><div id="divrating" runat="server" ></div></div>
        <strong><%#Eval("titulo") %></strong>,
        <span class="muted"><small><%#Eval("fecha") %></small></span>
    </div>
    <div class="review-author muted"><strong>De:</strong><%#Eval("cliente.razon")%></div>
    <div class="review-text"><%#Eval("descripcion") %></div>
    <div class="product-review-vote muted" data-review-id="947" data-href="">
    <span>Fue util este comentario?</span>
    <a class="vote vote-yes" href="#" title="Yes" rel="tooltip nofollow">
        <i class="fa fa-thumbs-up"></i><span class="vote-count" data-bind-to="TotalYes"><strong style="font-size:12px"><%#Eval("positivo")%></strong></span>
    </a>
    <a class="vote vote-no" href="#" title="No" rel="tooltip nofollow">
        <i class="fa fa-thumbs-down"></i><span class="vote-count" data-bind-to="TotalNo"><strong style="font-size:12px"><%#Eval("negativo")%></strong></span>
    </a>
</div>

                
            </div>
</ItemTemplate>
</asp:DataList>
 
        </div>
    </div>
</div>

    <input type="hidden" class="loaded-tab-name" name="LoadedTabs" value="#product-detail-tabs-1">
	<input type="hidden" class="loaded-tab-name" name="LoadedTabs" value="#product-detail-tabs-2">
	<input type="hidden" class="loaded-tab-name" name="LoadedTabs" value="#product-detail-tabs-3">

</div>
            
<!-- product recommendations -->
<uc3:GrillaProductosRelacionados ID="GrillaProductosRelacionados1" runat="server" />    
<!-- product tags -->
<div class="product-tags"> </div>
            
</div>

</div>        
    </div>
</div>
</asp:Content>
   
