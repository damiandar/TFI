<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ProductosListado.aspx.vb" Inherits="backend_catalogo_ProductosListado" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
            <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header"> Productos </h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i> Inicio 
    </li>
    <li class="active">
        Listado de productos
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="text-right"><a href="Productos.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>
    <asp:GridView ID="GrillaProductos" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay productos cargados
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
<%--    <asp:TemplateField HeaderText="Descripcion">
            <ItemTemplate>
            <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("descripcion") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Comentarios">
        <ItemTemplate>
            <asp:HyperLink ID="lnkComentarios" NavigateUrl='<%#String.Format("Comentarios.aspx?ProductoID={0}", Eval("ID"))%>'  runat="server"></asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("Productos.aspx?ProductoID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
   <asp:TemplateField>
   <FooterTemplate>
        <div class="panel-footer">
                    <div class="row">
                        <div class="col col-xs-offset-3 col-xs-6">
                            <nav aria-label="Page navigation" class="text-center">
                                <ul class="pagination">
                                    <li>
                                        <a href="#" aria-label="Previous">
                                            <span aria-hidden="true">«</span>
                                        </a>
                                    </li>
                                    <li class="active"><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a href="#">4</a></li>
                                    <li><a href="#">5</a></li>
                                    <li>
                                        <a href="#" aria-label="Next">
                                            <span aria-hidden="true">»</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                        <div class="col col-xs-3">
                            <div class="pull-right">
                                <button type="button" class="btn btn-primary">
                                    <span class="glyphicon glyphicon-plus"
                                          aria-hidden="true"></span>
                                    Add row
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
   </FooterTemplate>
   </asp:TemplateField>
    </Columns>
   
    </asp:GridView>
</asp:Content>

