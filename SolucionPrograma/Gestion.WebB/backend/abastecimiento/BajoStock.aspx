<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="BajoStock.aspx.vb" Inherits="compras_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>    
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
   Nuevo Pedido de Abastecimiento
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i>     <asp:HyperLink ID="hlInicio" NavigateUrl="~/backend/abastecimiento/Default.aspx" runat="server">Inicio</asp:HyperLink>  
    
    </li>
<%--    <li class="active">
            <asp:HyperLink ID="hlInic" NavigateUrl="~/backend/abastecimiento/Default.aspx" runat="server">Abastecimiento</asp:HyperLink>  
    </li>--%> 
</ol>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="PanelCargarItem" runat="server">
        <div class="panel panel-info">
        <div class="panel-heading">
        Agregar Insumo al pedido
        </div> 
        <div class="panel-body">     
        <div class="form-inline" role="form">
<%--                <div class="form-group">
                    <label class="filter-col" style="margin-right:0;" for="tbCantidad">Nombre:</label>
                    <asp:TextBox ID="tbCantidad" class="form-control input-sm"  runat="server"></asp:TextBox>
                </div> --%>
        <div class="col-lg-4">
                <div class="form-group">
                    <label class="filter-col" for="tbFecha" >Fecha:</label>
                    <asp:TextBox ID="tbFecha"  class="form-control"  runat="server"></asp:TextBox>
                </div>
        </div>
        <div class="col-lg-6">
                <div class="form-group">
                    <label class="filter-col" for="tbNotas" >Notas:</label>
                    <asp:TextBox ID="tbNotas"  class="form-control"  runat="server"></asp:TextBox>
                </div>
        </div>

    
            </div>
        </div>
    </div>
    </asp:Panel>

    <asp:GridView ID="GrillaReposicion" runat="server"   class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" >
    <EmptyDataTemplate>
    No hay insumos por debajo del stock.
    </EmptyDataTemplate>
    <Columns>
            <asp:TemplateField >
               <ItemTemplate>
                   <asp:HiddenField ID="hCodigo" value='<%# Eval("id") %>' runat="server"></asp:HiddenField>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Insumo">
            <ItemTemplate>
                <asp:Label ID="lblInsumo" runat="server" Text='<%# Eval("nombrecorto") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Minimo">
                <ItemTemplate>
                    <asp:Label ID="lblStockMin" runat="server" Text='<%#Eval("stock.minimo") %>' ></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Maximo">
                <ItemTemplate>
                    <asp:Label ID="lblStockMax" runat="server" Text='<%#Eval("stock.maximo") %>' ></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock Actual">
                <ItemTemplate>
                    <asp:Label ID="lblStockActual" runat="server" Text='<%#Eval("stock.actual") %>' ></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad" >
                <ItemTemplate>
                <asp:TextBox ID="tbCantidad"   class="form-control"  runat="server"></asp:TextBox>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prioridad">
            <ItemTemplate>
                <asp:DropDownList ID="comboPrioridad" class="form-control" runat="server">
                    <asp:ListItem Value="0" >Baja</asp:ListItem>
                    <asp:ListItem Value="1" >Media</asp:ListItem>
                    <asp:ListItem Value="2" >Alta</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especificacion">
            <ItemTemplate>
                <asp:TextBox ID="tbEspecificacion"   class="form-control"  runat="server"></asp:TextBox>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="¿Pedir?">
            <ItemTemplate>
                <asp:CheckBox ID="chkPedir"  class="custom-control-indicator" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
    </Columns>
    </asp:GridView>

    <div class="row">
    <div class="col-lg-12">
    <div class="form-group">    
                    <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Registrar Pedido" />
                </div>
    </div>
                
    </div>
    <div class="text-center">
        
    </div>
 
</asp:Content>

