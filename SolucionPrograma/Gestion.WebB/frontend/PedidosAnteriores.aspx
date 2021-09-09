<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PedidosAnteriores.aspx.vb" Inherits="frontend_PedidosAnteriores" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
    Pedidos Anteriores
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GrillaPedidosAnteriores"  class="table table-bordered table-hover table-striped" AutoGenerateColumns="false"  runat="server">
    <Columns>
    <asp:BoundField HeaderText="Nro." DataField="id" />
    <asp:TemplateField HeaderText="Fecha">
    <ItemTemplate>
        <asp:Label ID="lblFecha" runat="server" text='<%#Eval("fecha") %>' ></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Estado">
    <ItemTemplate>
        <asp:Label ID="lblEstado" runat="server" text='<%#Eval("estadopedido") %>' ></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</asp:Content>

