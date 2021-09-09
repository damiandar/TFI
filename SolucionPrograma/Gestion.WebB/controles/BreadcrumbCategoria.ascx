<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BreadcrumbCategoria.ascx.vb" Inherits="controles_BreadcrumbCategoria" %>
<ul id="breadcrumb" class="breadcrumb">
<li>
    <a href="default.aspx" title="Inicio" itemprop="url"><i class="fa fa-home"></i></a> 
</li>
<li>
    <span itemscope="" itemtype="">
        <asp:HyperLink ID="hlCategoria" runat="server"></asp:HyperLink>
    </span> 
</li>
<li>
    <span itemscope="" itemtype="">
        <asp:HyperLink ID="hlSubCategoria" runat="server"></asp:HyperLink>
    </span> 
</li>
<li> 
    <asp:Label ID="lblProductoDescripcionTitulo" runat="server" Text=""></asp:Label> 
</li>

</ul>
