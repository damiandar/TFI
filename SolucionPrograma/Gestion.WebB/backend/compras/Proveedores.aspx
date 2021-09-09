<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Proveedores.aspx.vb" Inherits="backend_compras_Proveedores" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../../controles/popProveedorInsert.ascx" tagname="popProveedorInsert" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> Proveedores</h1>
<ol class="breadcrumb">
    <li><i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a></li>
    <li class="active"> Listado de proveedores</li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1"  runat="server">
    </asp:ScriptManagerProxy>

<%--</asp:ToolkitScriptManager>--%>
<div class="row">

<div  class="col-lg-6">
    <div role="form">
     <div class="form-group input-group">
            <input type="text" class="form-control"/>
            <span class="input-group-btn">
                <button class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Nuevo</button>
            </span>
    </div>
    </div>
    </div> <%--fin col-lg-6--%>
<div class="col-lg-12">
        <div role="form">
            <div class="form-group">
                <asp:GridView ID="GrillaCuentas" runat="server"  AutoGenerateColumns="false" class="table table-bordered table-hover table-striped" >
                <EmptyDataTemplate>
                No hay proveedores cargados.
                </EmptyDataTemplate>
                <Columns>
                <asp:BoundField DataField="id"  HeaderText="ID" />
                <asp:BoundField DataField="cuit" HeaderText="CUIT" />
                <asp:BoundField DataField="Razon" HeaderText="Razon Social" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" CommandName="Editar" CommandArgument='<%#Eval("id") %>' runat="server">Editar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </div>
        </div>
</div> <%--fin col-lg-12--%>

</div>

<div class="container">
  <!-- Trigger the modal with a button -->
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header modal-header-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Ingresar Proveedor</h4>
        </div>
        <div class="modal-body">
            <uc1:popProveedorInsert ID="popCuentaInsert1" tipoingreso="Proveedor" runat="server" />
        </div>
        <div class="modal-footer">
          <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
        </div>
      </div>
      
    </div>
  </div>
  
</div>
  
<%--</asp:Panel>	--%> 

</asp:Content>

