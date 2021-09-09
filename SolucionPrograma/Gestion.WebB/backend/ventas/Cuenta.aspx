<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cuenta.aspx.vb" Inherits="aplicacion_forms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<%@ Register src="~/controles/menuizquierda.ascx" tagname="menuizquierda" tagprefix="uc1" %>
<%@ Register src="~/controles/BreadcrumbCategoria.ascx" tagname="BreadcrumbCategoria" tagprefix="uc2" %>

<%-- <uc4:encuestas ID="encuestas1" runat="server" />--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
 <h1 class="page-header">
    Cuentas
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Forms
    </li>
</ol>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:menuizquierda ID="menuizquierda1" runat="server" />       
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"   >
    </asp:ScriptManagerProxy> 

<div class="row">
    <div  class="col-lg-12">
    <div role="form">
    <div class="form-group input-group">
            <input type="text" class="form-control"/>
            <span class="input-group-btn">
                <button class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
            </span>
    </div>
    </div>
    </div>
</div>
                            
    <asp:GridView ID="GrillaCuentas" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField datafield="Razon" HeaderText="Razon" />
            <asp:BoundField datafield="cuit" HeaderText="CUIT" />
            <%--<asp:BoundField datafield="telefono" HeaderText="telefono" />
            <asp:BoundField datafield="mail" HeaderText="mail" />
            <asp:BoundField datafield="web" HeaderText="web" />
            <asp:BoundField datafield="contacto" HeaderText="contacto" />
            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
            <asp:BoundField DataField="localidad" HeaderText="Localidad" />
            <asp:BoundField datafield="CP" HeaderText="CP" />
            <asp:BoundField DataField="estado" HeaderText="estado" />--%>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%#String.Format("Default.aspx?ClienteId={0}", Eval("ID"))%>'  runat="server">Pedidos</asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkFactura" NavigateUrl='<%#String.Format("Facturas.aspx?ClienteId={0}", Eval("ID"))%>'  runat="server">Pedidos</asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
 
  
 


</asp:Content>

