<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Panel.aspx.vb" Inherits="aplicacion_Default" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
    Mis Pedidos
</h1>
<%--<ol class="breadcrumb">
    <li class="active">
        <i class="fa fa-Inicio"></i> Inicio
    </li>
</ol>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="row">
 
    <div class="col-lg-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title"><i class="fa fa-credit-card fa-fw"></i> Listado de pedidos</h3>
            </div>
            <div class="panel-body">
                <div class="table-responsive">

                    <asp:GridView class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" ID="GrillaPedidos" runat="server">
                    <EmptyDataTemplate>
                    No hay pedidos cargados.
                    </EmptyDataTemplate>
                    <Columns>
                    <asp:TemplateField HeaderText="Nro">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server"  Text='<%# string.format("{0:dd/MM/yyyy}",Eval("Fecha")) %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>    
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("EstadoPedido") %>' ></asp:Label>    
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnPDF" runat="server" Text="PDF" CommandName="Imprimir" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>                    
                </div>
<%--                <div class="text-right">
                    <a href="#">View All Transactions <i class="fa fa-arrow-circle-right"></i></a>
                </div>--%>
            </div>
        </div>
    </div>
</div>
<!-- /.row -->
</asp:Content>

