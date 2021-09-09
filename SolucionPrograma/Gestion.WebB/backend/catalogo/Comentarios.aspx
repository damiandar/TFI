<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Comentarios.aspx.vb" Inherits="backend_catalogo_Comentarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> Comentarios </h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="Productos.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> <a href="ProductosListado.aspx">Productos</a>
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GrillaComentarios" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay productos cargados
    </EmptyDataTemplate>
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="ProductoID" DataField="ProductoID" />
        <asp:BoundField HeaderText="Titulo" DataField="titulo" />
        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
        <asp:BoundField HeaderText="Por" DataField="por" />
        <asp:BoundField HeaderText="Fecha" DataFormatString="{0:dd/mm/yyyy}" DataField="fecha" />
        <asp:BoundField HeaderText="Hora" DataFormatString="{0:hh:mm}" DataField="fecha" />
        <asp:BoundField HeaderText="Puntaje" DataField="puntaje" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblVoto" runat="server"  Text=""></asp:Label>         <i class="fa fa-thumbs-down"></i>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Positivo" DataField="positivo" />
        <asp:BoundField HeaderText="Negativo" DataField="negativo" />
    </Columns>
</asp:GridView>
</asp:Content>

