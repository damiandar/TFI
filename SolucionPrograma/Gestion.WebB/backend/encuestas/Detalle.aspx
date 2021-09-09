<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Detalle.aspx.vb" Inherits="backend_encuestas_Detalle" %>
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
        <i class="fa fa-edit"></i> Forms
    </li>
</ol>   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-lg-10">
    <div class="form-group">
    <label>Encuesta: </label>
    <asp:Label runat="server" ID="lblEncuesta"> </asp:Label>
    </div>
</div>
</div>
<asp:Chart ID="Chart1" runat="server">
    <Series>
        <asp:Series Name="Series1" CustomProperties="DrawingStyle=Emboss"></asp:Series>
    </Series>
    <Legends>
        <asp:Legend Name="Legend1" Title="Opciones"></asp:Legend>
    </Legends>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>

<asp:GridView ID="GrillaEncuestas" runat="server" class="table table-bordered table-hover table-striped">
    <Columns>
<%--    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("Detalle.aspx?EncuestaID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>--%>
    </Columns>
</asp:GridView>

</asp:Content>

