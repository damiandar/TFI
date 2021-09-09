<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="AgregarItems.aspx.vb" Inherits="compras_AgregarItems" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" runat="server" >
<h1 class="page-header"> Pedido Reposición - Agregar items</h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Agregar items
    </li>
</ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css" >

</style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GrillaItems" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped">
    </asp:GridView>
</asp:Content>

