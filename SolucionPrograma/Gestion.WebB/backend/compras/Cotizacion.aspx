<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cotizacion.aspx.vb" Inherits="backend_compras_Proveedores" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
<%--<script type="text/javascript" src="../../assets/js/jquery.js"></script>--%>
<style type="text/css" >

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Compras" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> Pedidos Abastecimiento</h1>
<ol class="breadcrumb">
    <li><i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a></li>
    <li class="active"> Ingreso Cotización</li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1"  runat="server">
    </asp:ScriptManagerProxy>

<div class="row">
    <div class="col-lg-12">
        <div class="form-group">
            <label>Pedido Nro:</label><asp:Label ID="lblNro" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Fecha:</label><asp:Label ID="lblFecha" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Notas:</label><asp:Label ID="lblNotas" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <label>Estado:</label><asp:Label ID="lblEstado" CssClass="form-control-static" runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>


<div class="row">


<div class="col-lg-12">
<div role="form">
    <div class="form-group">
    <asp:GridView ID="GrillaCotizacion" runat="server" class="table table-bordered table-hover table-striped" AutoGenerateColumns="false">
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:HiddenField ID="hProductoID" Value='<%#Eval("insumo.id")%>' runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Insumo"  >
        <ItemTemplate>
        <asp:Label ID="lblProducto" Text='<%#Eval("insumo.nombrecorto") %>' runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="cantidadpedida" HeaderText="Cant" />
            <asp:BoundField DataField="cantidadrestante" HeaderText="Restante" />
        <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="btnCotizar" Text="Cotizar" class="btn btn-primary"  CommandName="Cotizar"  CommandArgument='<%#Eval("insumo.id") %>'  runat="server"/>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Prioridad">
            <ItemTemplate>
                <asp:Label ID="lblPrioridad" runat="server" ></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
        <asp:BoundField HeaderText="Especificacion"  DataField="Especificacion" />
        <asp:TemplateField HeaderText="Comprar" >
        <ItemTemplate>
            <asp:TextBox ID="tbComprar" CssClass="form-control" runat="server"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:DropDownList ID="comboCotizacion"  class="form-control" runat="server">
            </asp:DropDownList>  
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
</div>
</div> <%--fin col-lg-12--%>
    
<div  class="col-lg-6">
<div role="form">
     <div class="form-group input-group">
        <asp:Button ID="btnComprar" class="btn btn-primary"  runat="server" Text="Comprar" />
    </div>
</div>
</div> <%--fin col-lg-6--%>
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
          <h4 class="modal-title">INGRESAR COTIZACION </h4>
        </div>
        <div class="modal-body">
            <div class="row"> 
            
            <div class="col-lg-12">
                 <div class="form-group">
               <label> Proveedor:</label> 
                <asp:DropDownList ID="comboProveedor" CssClass="form-control" runat="server"></asp:DropDownList>
            </div> 

            
                <div class="form-group">
                    <label>Valor Unitario:</label>
                    <asp:TextBox ID="tbValorUnitario" CssClass="form-control" runat="server"></asp:TextBox> 
                </div>          
      
               <div class="form-group">
                    <label>IVA</label>
                    <asp:DropDownList CssClass="form-control" ID="comboIVA" runat="server">
                        <asp:ListItem Value="0" >Sin IVA</asp:ListItem>
                        <asp:ListItem Value="1" >10,5 %</asp:ListItem>
                        <asp:ListItem Value="2" >21   %</asp:ListItem>
                    </asp:DropDownList>
                </div> 

                <div class="form-group">
                    <asp:Button ID="btnCotizacion" class="btn btn-primary" runat="server" Text="Ingreso Cotizacion" /> 
                </div>
            </div><%-- col--%>
        
            </div> <%-- row --%>
        </div>
        <div class="modal-footer">
     
        </div>
      </div>
      
    </div>
  </div>
  
</div>
  
<%--</asp:Panel>	--%> 

</asp:Content>

