<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="compras_Default" %>

<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">     
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header">
    Pedidos de Abastecimiento
</h1>
<ol class="breadcrumb">
    <li>
        <i class="fa fa-Inicio"></i> 
        <asp:HyperLink ID="hlInicio" NavigateUrl="~/backend/abastecimiento/Default.aspx" runat="server">Inicio</asp:HyperLink>  
    </li>
    <li class="active">
         Abastecimiento
    </li>
</ol>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="filter-panel" class="collapse filter-panel" style="height: auto;">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-inline" role="form">
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-perpage">Rows per page:</label>
                            <select id="pref-perpage" class="form-control">
                                <option value="2">2</option>
                                <option value="9">9</option>
                                <option selected="selected" value="10">10</option>
                                <option value="15">15</option>
                                <option value="20">20</option>
                                <option value="1000">1000</option>
                            </select>                                
                        </div><!-- form group [rows] -->
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-search">Search:</label>
                            <input type="text" class="form-control input-sm" id="pref-search">
                        </div><!-- form group [search] -->
                        <div class="form-group">
                            <label class="filter-col" style="margin-right:0;" for="pref-orderby">Order by:</label>
                            <select id="pref-orderby" class="form-control">
                                <option>Descendent</option>
                            </select>                                
                        </div><!-- form group [order by] --> 
                        <div class="form-group">    
                            <div class="checkbox" style="margin-left:10px; margin-right:10px;">
                                <label><input type="checkbox"> Remember parameters</label>
                            </div>
                            <button type="submit" class="btn btn-default filter-col">
                                <span class="fa fa-file-pdf-o"></span> PDF
                            </button>  
                        </div>
                    </div>
                </div>
            </div>
        </div>

<asp:Panel ID="PanelCargarItem" runat="server">
        <div class="panel panel-info">
        <div class="panel-heading">
        Agregar nuevo pedido
        </div> 
        <div class="panel-body">     
        <div class="form-inline" role="form">
            <div class="col-lg-8">
                <div class="form-group">
                    <label class="filter-col" for="tbNotas" >Notas:</label>
                    <asp:TextBox ID="tbNotas"  class="form-control"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFV1" ValidationGroup="VGP"  runat="server" ControlToValidate="tbNotas" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
        </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnAgregar" ValidationGroup="VGP" class="btn btn-primary" runat="server" Text="Crear Pedido" />
                </div>
        </div>
        </div>
        </div>
    </div>
    </asp:Panel>
<%--    <div class="text-right"><a href="BajoStock.aspx">Nuevo <i class="fa fa-arrow-circle-right"></i></a></div>--%>
    <asp:GridView ID="GrillaReposicion" runat="server"   class="table table-bordered table-hover table-striped" AutoGenerateColumns="false" >
   <EmptyDataTemplate>
   No hay pedidos de abastecimiento pendientes
   </EmptyDataTemplate>
    <Columns>
        <asp:BoundField HeaderText="Nro" DataField="id" />  
        <asp:BoundField HeaderText="Notas" DataField="Notas" />    
        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />    
        <asp:BoundField HeaderText="Estado" DataField="Estado" />             
        <asp:TemplateField>
        <ItemTemplate>
            <%--<asp:HyperLink ID="lnkDetalle" NavigateUrl='<%# string.Format("Detalle.aspx?ReposicionID={0}",Eval("ID"))%>'  runat="server">Detalle</asp:HyperLink>--%>
            <asp:HyperLink ID="hlVer"   runat="server">Detalle</asp:HyperLink>
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
    
<%--    <asp:Button ID="btnCrearSolicitud"  class="btn btn-primary"   runat="server" Text="Crear" />--%>
</asp:Content>

