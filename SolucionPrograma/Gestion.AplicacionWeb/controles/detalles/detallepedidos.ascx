<%@ Control Language="VB" AutoEventWireup="false" CodeFile="detallepedidos.ascx.vb" Inherits="controles_detallepedidos" %>
<%@ Register src="../validados/Control_tbCodigo.ascx" tagname="Control_tbCodigo" tagprefix="uc1" %>
<%@ Register src="../validados/Control_tbCantidad.ascx" tagname="Control_tbCantidad" tagprefix="uc2" %>

<script type="text/javascript">
    $(document).ready(function()    {
    
   
    //pasar con el +
      $('[id$="tbproducto"]').keypress(function(e) {
      if( e.which==43)  {  e.preventDefault();  $('[id$="tbCantidad"]').focus(); } });
      
     
      $('[id$="tbCantidad"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="btnaceptar"]').focus(); } });
    
    //pasa con el enter
        $('[id$="tbCantidad"]').keypress(function(e) {
      if( e.which==13)   {  e.preventDefault();  $('[id$="btnaceptar"]').focus(); } });
      
        $('[id$="tbproducto"]').keypress(function(e) {
      if( e.which==13)  {  e.preventDefault();  $('[id$="tbCantidad"]').focus(); } });
      });
      
</script>

<asp:Panel runat="server" ID="panelbusqueda" TabIndex="1" CssClass="tablaSeparador1"  >
<div style="float:left; width:350px;">                     
</div>
    <div class="advertenciaStock" style="padding-top:4px">
		        <asp:Panel runat="server" ID="PanelCargaMasiva">
        Carg&aacute; tu pedido de forma m&aacute;s r&aacute;pida
        <asp:ImageButton  ImageUrl="~/assets/images/boton_carga_masiva.gif" alt="" width="145" height="19"  ID="btnCargaMasiva" runat="server" TabIndex="5" />
	 </asp:Panel>   
    </div>						
                        	<div style="clear:both">
                            </div>
 <asp:Panel ID="PanelIngreso" runat="server">
    
    <table width="715" border="0" cellspacing="0" cellpadding="5">
	  <tr class="tablaTitulo1" >
	    <td width="715" height="30" colspan="7">Cargar producto</td>
      </tr>
	  <tr>
        <uc1:Control_tbCodigo ID="tbProducto" runat="server" />
        <uc2:Control_tbCantidad ID="tbCantidad" runat="server" />
      <td style="width: 180px" >
		<asp:ImageButton  ImageUrl="~/assets/images/boton_cargar.gif" alt="" width="60" height="19"  ID="btnaceptar" runat="server" TabIndex="3" ValidationGroup="VGproducto" />
	    </td>						    						    						   
      </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Error en los siguientes campos:" ShowMessageBox="True" ValidationGroup="VGproducto" />
    </asp:Panel>    
</asp:Panel>
<asp:Label ID="lblrepetido"  runat="server" Text="El código ya esta ingresado en el pedido actual... ¿Desea sumar a la cantidad existente?"  Visible="False" ForeColor="Red"></asp:Label>
 
<div style="background-color:#f4f4f4;">

<asp:DetailsView  EmptyDataText="El código ingresado no es válido para la campaña vigente" ID="DetalleProducto" EmptyDataRowStyle-ForeColor="Red"  runat="server">
<Fields>
        <asp:BoundField DataField="campania" HeaderText="campania" Visible="false" />
        <asp:BoundField DataField="zona" HeaderText="zona"  Visible="false" />
        <asp:BoundField DataField="cuenta" HeaderText="cuenta" Visible="false" />
        <asp:TemplateField HeaderText="Codigo" Visible="false">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("producto.codigoproducto") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Producto" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" ItemStyle-Width="300px" >
        <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# Eval("producto.descripcionproducto") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>            
        <asp:TemplateField  HeaderText="Precio unitario" HeaderStyle-Font-Bold="true">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("producto.preciofolleto","${0}") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="Tipo catálogo" HeaderStyle-Font-Bold="true">
        <ItemTemplate>
        <asp:Label ID="Label3" runat="server"      Text='<%# Eval("producto.codigofolleto") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>            
        <asp:TemplateField HeaderText="Página Catálogo" HeaderStyle-Font-Bold="true">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("producto.paginafolleto") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>            
        <asp:BoundField DataField="cantidadsolicitada" HeaderText="Cantidad" HeaderStyle-Font-Bold="true" />
        <asp:BoundField DataField="motivocr" HeaderText="Motivo" Visible="false" />
        <asp:BoundField DataField="tipocr" HeaderText="tipocr"  Visible="false" />
        <asp:BoundField DataField="productofacturado" HeaderText="productofacturado"  Visible="false"/>
        <asp:BoundField DataField="cuentacarga" HeaderText="cuentacarga"  Visible="false"/>
        <asp:BoundField DataField="fechaultimo" HeaderText="fechaultimo"  Visible="false" />
        <asp:BoundField DataField="horaultimo" HeaderText="horaultimo"   Visible="false"/>
</Fields>        
</asp:DetailsView>

<asp:Label ID="lblMuchaCantidad"  runat="server" Text="¿Estas seguro que deseas la cantidad ingresada?" Font-Bold="true"  Visible="False" ForeColor="Red"></asp:Label>
 
</div>
<br />
<asp:ImageButton ID="btnConfirmar"  Visible="false"  runat="server" ImageUrl="~/assets/images/boton_confirmar.gif" />       &nbsp;
<asp:ImageButton ID="btnCancelar" Visible="false" ImageUrl="~/assets/images/boton_cancelar.gif" runat="server" />
  