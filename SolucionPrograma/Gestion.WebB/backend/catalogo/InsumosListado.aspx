<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="InsumosListado.aspx.vb" Inherits="backend_catalogo_InsumosListado" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
            <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header"> Insumos </h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  Inicio
    </li>
    <li class="active">
        Listado de insumos
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="text-right"><a href="Insumos.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>
    <asp:GridView ID="GrillaInsumos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay insumos cargados
    </EmptyDataTemplate>
    <Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Corto">
            <ItemTemplate>
                <asp:Label ID="lblNombreCorto" runat="server" Text='<%#Eval("nombrecorto") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre Largo"> 
            <ItemTemplate>
                <asp:Label ID="lblNombreLargo" runat="server" Text='<%#Eval("nombrelargo") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stock Actual">
            <ItemTemplate>
                <asp:Label ID="lblStock" runat="server" Text='<%#Eval("stock.actual") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Stock Maximo">
            <ItemTemplate>
                <asp:Label ID="lblStock" runat="server" Text='<%#Eval("stock.maximo") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Stock Minimo">
            <ItemTemplate>
                <asp:Label ID="lblStock" runat="server" Text='<%#Eval("stock.minimo") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("Insumos.aspx?InsumoID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnKBorrar" CommandArgument='<%#Eval("ID") %>' CommandName="Borrar" runat="server">
                    <i class="glyphicon glyphicon-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
</asp:Content>

