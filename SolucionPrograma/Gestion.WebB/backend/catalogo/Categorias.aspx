<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="backend_catalogo_ProductosListado" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
            <uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Ventas" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
    <h1 class="page-header"> Categorias </h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="Productos.aspx">Inicio</a>
    </li>
    <li class="active">
        Ingreso de categorias
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<div class="text-right"><a href="Productos.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>--%>

<asp:Panel ID="PanelMensaje" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label> 
         </div>
        </div>
    </div>
</div> 
</asp:Panel>
<asp:Panel ID="PanelErrorCategoria" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-warning alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <asp:Label ID="lblErrorCategoria" runat="server" Text=""></asp:Label> 
         </div>
        </div>
    </div>
</div> 
</asp:Panel>
<div class="row">
   <div class="col-lg-4">
        <div class="form-group">
        <label>Tipo Catalogo:</label>
&nbsp;<asp:DropDownList ID="comboTipoCatalogo" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <div class="col-lg-6">
    <div class="form-group">
        <label>SubCategoria</label>
        <asp:TextBox ID="tbCategoria" class="form-control" placeholder="Ingresar nombre categoria nueva" runat="server"></asp:TextBox> 
            <p class="help-block">      
                <asp:RequiredFieldValidator ID="RFVC" ValidationGroup="CGV" runat="server" ControlToValidate="tbCategoria" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
            </p>
    </div>
    </div>
    <div class="col-lg-2">
        <div class="form-group">
            <asp:Button ID="btnIngresarCategoria" CssClass="btn btn-primary" ValidationGroup="CGV"  runat="server" Text="Ingresar Categoria" />
        </div>
    </div>
</div>
<asp:GridView ID="GrillaCategorias" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay categorias cargadas
    </EmptyDataTemplate>
    <Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
            <asp:Label ID="lblNombreCorto" runat="server" Text='<%#Eval("descripcion") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnKBorrar" CommandArgument='<%#Eval("id") %>' CommandName="Borrar" runat="server">
                        <i class="glyphicon glyphicon-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:Panel ID="PanelMensaje2" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-success alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <asp:Label ID="lblMensaje2" runat="server" Text=""></asp:Label> 
         </div>
        </div>
    </div>
</div> 
</asp:Panel>
<asp:Panel ID="PanelErrorSubCategoria" runat="server" >
<div class="container">
    <div class="row">
        <div class="col-lg-9">
        <div class="alert alert-warning alert-dismissable">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            <asp:Label ID="lblErrorSubCategoria" runat="server" Text=""></asp:Label> 
         </div>
        </div>
    </div>
</div> 
</asp:Panel>
<div class="row">
   <div class="col-lg-4">
        <div class="form-group">
        <label>Categoria:</label>
&nbsp;<asp:DropDownList ID="comboCategoria" class="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <div class="col-lg-6">
    <div class="form-group">
        <label>SubCategoria</label>
        <asp:TextBox ID="tbSubCategoria" class="form-control" placeholder="Ingresar nombre subcategoria nueva" runat="server"></asp:TextBox> 
            <p class="help-block">      
                <asp:RequiredFieldValidator ID="RFV1" ValidationGroup="SCGV" runat="server" ControlToValidate="tbSubCategoria" Display="Dynamic" ErrorMessage="*"  ></asp:RequiredFieldValidator>  
            </p>
    </div>
    </div>
    <div class="col-lg-2">
        <div class="form-group">
            <asp:Button ID="btnIngresarSubCategoria" CssClass="btn btn-primary"  ValidationGroup="SCGV"  runat="server" Text="Ingresar SubCategoria" />
        </div>
    </div>
</div>
<asp:GridView ID="GrillaSubCategorias" runat="server" AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
    <EmptyDataTemplate>
    No hay subcategorias cargadas
    </EmptyDataTemplate>    
    <Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción">
            <ItemTemplate>
            <asp:Label ID="lblNombreCorto" runat="server" Text='<%#Eval("descripcion") %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnKBorrar" CommandArgument='<%#Eval("id") %>' CommandName="Borrar" runat="server">
                        <i class="glyphicon glyphicon-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>

</asp:Content>

