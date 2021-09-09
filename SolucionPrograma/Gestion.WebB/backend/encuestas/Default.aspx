<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="backend_encuestas_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
    Encuestas
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        Listado de encuestas
    </li>
</ol>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="text-right"><a href="nuevo.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>
    <asp:GridView ID="GrillaEncuestas" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped">
    <EmptyDataTemplate>
    No hay encuestas cargadas.
    </EmptyDataTemplate>
    <Columns>
    <asp:TemplateField HeaderText="ID">
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("id") %>' ></asp:Label>  
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Descripción">
        <ItemTemplate>
            <asp:Label ID="lblID" runat="server" Text='<%#Eval("descripcion") %>' ></asp:Label>  
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("Detalle.aspx?EncuestaID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</asp:Content>

