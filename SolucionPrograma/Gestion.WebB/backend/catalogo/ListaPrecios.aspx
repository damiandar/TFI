<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ListaPrecios.aspx.vb" Inherits="backend_catalogo_ListaPrecios" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header">
    Lista Precios
</h1>
<ol class="breadcrumb">
    <li class="active">
        Lista Precios
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
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
<%--<div class="text-right"><a href="Insumos.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>--%>

<asp:GridView ID="GrillaPrecios" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
 	<Columns>
        <asp:BoundField DataField="ID" HeaderText="Nro. Lista" />
        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creacion" />
        <asp:BoundField DataField="FechaVigencia" HeaderText="Fecha Vigencia" />
        <asp:CheckBoxField DataField="Activa" HeaderText="Activa" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnActivar" CssClass="btn btn-danger" runat="server" Text="Activar" CommandArgument='<%#Eval("id") %>' CommandName="Activar" />    
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
           <ItemTemplate>
               <asp:LinkButton ID="lnkDetalle" PostBackUrl='<%# String.Format("ListaPreciosDetalle.aspx?id={0}", Eval("id")) %>' runat="server">Detalle</asp:LinkButton>
           </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div class="text-right"><asp:Button runat="server" CssClass="btn btn-primary" Text="Crear Nueva" ID="btnNuevaLista" /></div>

</asp:Content>

