<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrillaProductosRelacionados.ascx.vb" Inherits="controles_GrillaProductosRelacionados" %>
<div class="product-recommendations">
                    
<div class="block">
    <div class="block-title"><h3>Clientes que compraron este producto tambien compraron</h3></div>
    <div class="block-body">

        <div class="also-purchased-products-grid">
            <div class="product-list scroll">
<div class="pl-slider" style="overflow: hidden;position: relative;">
<div class="pl-row row clearfix" style="position: relative">
<asp:DataList ID="GrillaProductosRecomendados" runat="server" RepeatDirection="Horizontal">
<ItemTemplate>
<article class="item-box product-compact span4 equalized-column" style=" width:180px;margin-left:20px;" data-equalized-deep="true">
<figure class="picture" data-equalized-part="picture" data-equalized-valign="true" style="min-height: 102px; line-height: 102px; vertical-align: middle;">
    <a href="" title='<%#Eval("nombrelargo") %>'><asp:Image ID="Image1" runat="server"  Width="135px" Height="135px"  /></a>
</figure>
<div class="data">

<h3 class="name" data-equalized-part="name" style="min-height: 40px;">
    <a href='<%#string.format("Detalle.aspx?producto_id={0}",Eval("id")) %>'>
        <span><asp:Label ID="Label1" runat="server" Text='<%#Eval("nombrecorto") %>'></asp:Label> </span>
    </a>
</h3>
<div class="prices" data-equalized-part="prices" style="min-height: 18px;">
    <div class="text-success product-price"><asp:Label class="price" ID="lblPrecioUnitario" runat="server" Text='<%#Eval("precio.valorfinal", "{0:c}") %>'></asp:Label></div>
</div>
</div>
</article>
</ItemTemplate>
</asp:DataList>


</div>
</div>
    <a class="sb pl-scroll-prev sb-dir-left disabled scroll-button btn large" href="#" rel="nofollow" style="width: 28px; height: 96px; top: 40.1094px; left: 0.5px; opacity: 0.4;"><i class="fa fa-chevron-left"></i></a>
    <a class="sb pl-scroll-next sb-dir-right scroll-button btn large" href="#" rel="nofollow" style="width: 28px; height: 96px; top: 40.1094px; left: 690.5px; opacity: 0.4;"><i class="fa fa-chevron-right"></i></a>
            </div>
        </div>

    </div>
</div>
<script type="text/javascript">
    $(function () {
        $(".also-purchased-products-grid .product-list").productListScroller();
    });
</script>
</div>