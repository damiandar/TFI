<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="carrito_Default" %>
<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register src="../controles/menuizquierda.ascx" tagname="menuizquierda" tagprefix="uc1" %>
<%@ Register src="../controles/encuestas.ascx" tagname="encuestas" tagprefix="uc4" %>        
<%@ Register src="../controles/BreadcrumbCategoria.ascx" tagname="BreadcrumbCategoria" tagprefix="uc2" %>

<%-- <uc4:encuestas ID="encuestas1" runat="server" />--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:menuizquierda ID="menuizquierda1" runat="server" />       
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<uc2:BreadcrumbCategoria ID="BreadcrumbCategoria1" runat="server" />

<div class="page-title">
    <h1>Productos</h1>
</div>


<div class="page-body">     
<div class="product-list-options clearfix">
    <asp:TextBox ID="tbBusqueda" runat="server"></asp:TextBox><asp:LinkButton ID="lnkBuscar" runat="server"><i class="fa fa-fw fa-search"></i></asp:LinkButton>
</div>
<div class="product-list-options clearfix">
<%--<div class="product-viewmode pull-right">
        <div class="btn-group" data-toggle="buttons-radio">
                <a href="" class='btn active tooltip-toggle' rel="tooltip nofollow" title='Ver como grilla'><i class="fa fa-th"></i></a>
                <a href="" class='btn tooltip-toggle' rel="tooltip nofollow" title='Ver como lista'><i class="fa fa-bars"></i></a>
        </div>
    </div>--%>
<%--ordenamiento--%>
<div class="btn-group pull-left"><%--title="Sort by: Position"--%>
		<a class="btn dropdown-toggle tooltip-toggle" data-toggle="dropdown" href="#" rel="nofollow" >
		    <i class="fa fa-fw fa-sort"></i>
            <asp:Label ID="lblOrden" runat="server" Text="Orden"></asp:Label>
            <span class="fa fa-fw fa-caret-down"></span>
		</a>
        <ul class="dropdown-menu">
            <%--<li class="disabled"><a href="" >Orden</a></li>--%>
            <li><asp:LinkButton ID="lnkOrdAlfAsc"  runat="server">Nombre: A-Z</asp:LinkButton></li>
            <li><asp:LinkButton ID="lnkOrdAlfDesc" runat="server">Nombre: Z-A</asp:LinkButton></li>
            <li><asp:LinkButton ID="lnkPrecAsc"    runat="server">Precio: Menor a Mayor</asp:LinkButton></li>
            <li><asp:LinkButton ID="lnkPrecDesc"   runat="server">Precio: Mayor a Menor</asp:LinkButton></li>
            <li><asp:LinkButton ID="lnkCreacion"   runat="server">Creación</asp:LinkButton></li>
        </ul>
    </div>
<%--productos por pagina--%>
<div class="btn-group pull-left"> <%--title="Display: 12"--%>
		<a class="btn dropdown-toggle tooltip-toggle" data-toggle="dropdown" href="#" rel="nofollow">
	        <i class="fa fa-fw fa-sort-amount-asc"></i>
            <asp:Label ID="lblProductosPorPagina" runat="server" Text=""></asp:Label>
            <span class="fa fa-fw fa-caret-down"></span>
		</a>
        <ul class="dropdown-menu">
            <li><asp:LinkButton ID="lnkProductoPorPagina1" CommandArgument="2" runat="server">2</asp:LinkButton></li>
            <li><asp:LinkButton ID="lnkProductoPorPagina2" CommandArgument="3" runat="server">3</asp:LinkButton></li>     
        </ul>
    </div>
</div>
        
<!--GRILLA PRODUCTOS-->
<div class="product-list-container" style="width:100%">

<div class="product-grid">
<div class='data-list data-list-grid' style="float:left">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:Panel ID="PanelMensaje" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            Se agregó al carrito correctamente.
         </div>
        </div>
    </div>
</div> 
</asp:Panel>

<asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"  DataKeyField="id">
<HeaderTemplate>
<div class='data-list-row row-fluid'>
<div class='data-list-item equalized-column' data-equalized-deep='true'>
<article class="item-box">
</HeaderTemplate>
<ItemTemplate>
        
<div class="DetalleItem" style="width:250px; padding:10px; border:1px; border-style:solid; border-color:#337ab7; margin:5px;">
    <figure class="picture" data-equalized-part="picture" data-equalized-valign="true">
        <a href="" title='<%#Eval("descripcion") %>'>
            <asp:Image ID="Image1" runat="server"   Width="135px" Height="135px"  />
        </a>
    </figure>
    <div class="data">
        <div class="reviews" title="3review(s)">
            <div class="rating"><div id="divrating" runat="server" ></div></div>
        </div>
        <h3 class="name" data-equalized-part="name">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#String.Format("Detalle.aspx?producto_id={0}&tipo_id={1}", Eval("id"), Eval("CatalogoTipo")) %>'>
            <asp:Label ID="lblNombreCorto" runat="server" Text='<%#Eval("NombreCorto") %>'></asp:Label>
        </asp:HyperLink>
        </h3>
        <p class="description" title="it." data-equalized-part="description">
            <asp:Label ID="lblNombreLargo" runat="server" Text='<%#Eval("NombreLargo") %>'></asp:Label>
        </p>
        <div class="delivery-time" data-equalized-part="delivery-time">
			<span class="delivery-time-label">Tiempo de entrega:</span>
			<asp:Label ID="lblTiempoEntrega" CssClass="delivery-time-color"  runat="server" ></asp:Label>
	    </div>
        <div class="prices" data-equalized-part="prices">
            <p class="product-price">
                <span class="price text-success"><asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("precio.valorfinal", "{0:c}") %>'></asp:Label></span>
            </p>
        </div>
        <div class="buttons">
            <asp:LinkButton CommandName="AgregarAlCarrito" class="btn btn-warning "  ID="LinkButton1" runat="server">
                <i class="fa fa-shopping-cart"></i> 
            </asp:LinkButton>       
        <asp:HyperLink ID="HyperLink1" cssclass="btn" NavigateUrl='<%#string.format("Detalle.aspx?producto_id={0}",Eval("id")) %>' runat="server"><i class="fa fa-info-circle"></i>  Detalle</asp:HyperLink>
        </div>
    </div>  
</div>

</ItemTemplate>
<FooterTemplate>
</article>
</div>
</div> 
<div  class="table table-bordered table-hover table-striped">
    <asp:Label Visible='<%#boolean.Parse((DataList1.Items.Count=0).ToString())%>' runat="server" ID="lblNoRecord" Text="No hay productos con estos parametros de busqueda"></asp:Label>
</div>
</FooterTemplate>
</asp:DataList>

</ContentTemplate>				    
</asp:UpdatePanel>

</div>

</div>

<div class="Encuestas" style=" padding-left:10px; float:right;margin:10px; width:250px; border:1px solid;"">
    <uc4:encuestas ID="encuestas1" runat="server" />
</div>

</div>

    
<asp:Panel runat="server" ID="PanelPaginador">
<div class="delivery-time" data-equalized-part="delivery-time" style="width:100%;display:block;float:left"> 
<p class="old-product-price">
    <span class="price">
        <asp:LinkButton ID="btnPaginaPrevia" runat="server"><i class="fa fa-chevron-left"></i></asp:LinkButton>
        <asp:Label ID="lblPagina" runat="server" Text=""></asp:Label> 
		<asp:LinkButton ID="btnPaginaProxima" runat="server"><i class="fa fa-chevron-right"></i></asp:LinkButton> 
    </span>
</p>
</div>
</asp:Panel>

<!--GRILLA PRODUCTOS-->
		
        
</div>

</asp:Content>

