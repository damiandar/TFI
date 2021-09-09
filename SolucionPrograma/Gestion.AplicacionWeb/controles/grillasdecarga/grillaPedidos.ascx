<%@ Control Language="VB" AutoEventWireup="false" CodeFile="grillaPedidos.ascx.vb" Inherits="Tsu.Paginas.controles_grillaPedidos" %>
<div class="tablaSeparador1">
<table> <tr><td>
 <asp:GridView ID="ListaProductos"   AllowSorting="True" BorderStyle="None" BorderWidth="0" Font-Bold="false" ShowFooter="false" runat="server"   EmptyDataText="No hay productos cargados" Width="715px" BorderColor="Blue" DataKeyNames="codigoproducto,campania,cuenta,zona,motivocr,tipocr,campaniaorigen,tiponc" RowStyle-BorderStyle="None" AutoGenerateColumns="False" DataSourceID="ODSdetallepedido" >
        <EmptyDataTemplate>
				<div class="mensaje_contenedor" >
                	<div class="mensaje_info_715" >No hay productos cargados.</div>
                </div>
        </EmptyDataTemplate>
        <Columns>     
        <asp:BoundField DataField="campania" HeaderText="campania" Visible="false"  />
        <asp:BoundField DataField="zona" HeaderText="zona" Visible="false"/>
        <asp:BoundField DataField="cuenta" HeaderText="cuenta" Visible="false" />
<%--        codigo--%>
        <asp:TemplateField HeaderText="Código" SortExpression="Codigoproducto"  HeaderStyle-Width="70px" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None"  >
        <HeaderTemplate>
            <table><td>Código</td>
            <td>
            <asp:ImageButton OnClick="btnCodigoAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCodigoAsc" runat="server" />
            <asp:ImageButton OnClick="btnCodigoDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCodigoDesc" runat="server" />        
            </td>
            </table>
       </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblcodigoproducto" runat="server" Width="70px" Text='<%# Eval("codigoproducto") %>'></asp:Label>
            </ItemTemplate>
        <HeaderStyle Width="70px" HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
<%--        producto descripcion--%>
        <asp:TemplateField HeaderText="Producto" HeaderStyle-Width="240px" SortExpression="descripcionproducto" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None"  >
            <HeaderTemplate>
                <table><td>Producto</td>
                <td width="10px">
                <asp:ImageButton OnClick="btnProductoAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnProductoAsc" runat="server" />
                <asp:ImageButton OnClick="btnProductoDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnProductoDesc" runat="server" />        
                </td>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbldescripcionfolleto" runat="server" Width="240px" Text='<%# Eval("producto.descripcionproducto") %>'></asp:Label>
            </ItemTemplate>
<HeaderStyle Width="240px" HorizontalAlign="Left"></HeaderStyle>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
<%--        cantidad--%>
        <asp:TemplateField HeaderText="Cantidad"  HeaderStyle-Width="65px" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-Font-Bold="false">
            <EditItemTemplate>
                <asp:TextBox  ID="tbCantidadSolicitadaGrilla" runat="server" CssClass="TextoCantidad" MaxLength="4" Text='<%# Eval("cantidadsolicitada") %>' ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" Width="35px" ></asp:TextBox>
                <asp:CompareValidator ControlToValidate="tbCantidadSolicitadaGrilla" runat="server" Display="Dynamic" Type="Integer"  ValidationGroup="VGdetalle" Operator="DataTypeCheck" id="validinteg" ErrorMessage="La cantidad debe ser numérica"  >*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar un valor" ValidationGroup="VGdetalle" ControlToValidate="tbCantidadSolicitadaGrilla">*</asp:RequiredFieldValidator>            
                  <asp:RangeValidator ControlToValidate="tbCantidadSolicitadaGrilla"  MinimumValue="1" ValidationGroup="VGdetalle"  MaximumValue="9999" SetFocusOnError="True"  ID="RangeValidator1" runat="server" ErrorMessage="La cantidad debe ser numérica o distinta de cero.">*</asp:RangeValidator>
            </EditItemTemplate>
       <ItemTemplate>
                <asp:Label ID="lblcantidadsolicitada" runat="server" Width="65px" Text='<%# Eval("cantidadsolicitada") %>' ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" ></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
<%--        precio unitario--%>
        <asp:TemplateField HeaderText="Precio unitario" HeaderStyle-Width="75px" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-Font-Bold="false">
            <ItemTemplate>
                <asp:Label ID="lblpreciofolleto" runat="server" Width="75px" Text='<%# Eval("producto.preciofolleto","{0:c}") %>' ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None"></asp:Label>
            </ItemTemplate>
               <HeaderStyle HorizontalAlign="Right" />
               <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
<%--        folleto--%>
        <asp:TemplateField HeaderText="Catálogo"  HeaderStyle-Width="75px" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-Font-Bold="false">
            <ItemTemplate>
                <asp:Label ID="lblcodigofolleto" runat="server" Width="75px" Text='<%# Eval("producto.codigofolleto") %>' ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None"></asp:Label>                    
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
<%--        pagina--%>
        <asp:TemplateField  HeaderText="Pág." HeaderStyle-Width="30px" SortExpression="paginafolleto" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" >
            <HeaderTemplate>
                <table><td>Pág.</td>
                <td>
                <asp:ImageButton OnClick="btnPaginaAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnPaginaAsc" runat="server" />
                <asp:ImageButton OnClick="btnPaginaDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnPaginaDesc" runat="server" />        
                </td>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblpaginafolleto" runat="server" Width="30px" Text='<%# Eval("producto.paginafolleto") %>'  ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None"></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>        
<%--        botones confirmar/modificar   --%>
        <asp:TemplateField   HeaderStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="65px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="65px" ShowHeader="False" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" > 
<EditItemTemplate> 
   <asp:imagebutton  ImageUrl="~/assets/images/boton_confirmar.gif" ID="LinkButton1" runat="server" Width="65px" BorderStyle="None" ValidationGroup="VGdetalle" CommandName="ActualizaItem" />
</EditItemTemplate> 
<ItemTemplate> 
<asp:imagebutton  CommandName="Edit" ImageUrl="~/assets/images/boton_modificar.gif" ID="btiEditar" runat="server" Width="65px" BorderStyle="None" />
</ItemTemplate> 

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<%--        botones borrar/cancelar--%>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="70px"  ShowHeader="False" HeaderStyle-BorderStyle="None" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" >
    <ItemTemplate>
    <asp:ImageButton OnClientClick="return confirm('¿Confirma la eliminación del item?')"  ID="ImageButton1" runat="server" CausesValidation="false"    CommandName="BorrarItem" ImageUrl="~/assets/images/boton_borrar.gif" />
    </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        <EditItemTemplate> 
        <asp:imagebutton  ImageUrl="~/assets/images/boton_cancelar.gif" ID="LinkButton2" runat="server" Width="65px" BorderStyle="None" ValidationGroup="VGdetalle" CommandName="Cancel" />
        </EditItemTemplate> 
<ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:TemplateField>
<%--        tipocr--%>
        <asp:BoundField DataField="tipocr" Visible="false" />
        <%--        agregados pero no son funcionales, estan invisibles--%>
        <%--        campaña origen--%>
        <asp:TemplateField Visible="false" HeaderText="Campaña" SortExpression="campaniaorigen" >
        <HeaderTemplate>
                    <table><td>Campaña</td>
                    <td>
                    <asp:ImageButton OnClick="btnCampaniaAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCampaniaAsc" runat="server" />
                    <asp:ImageButton OnClick="btnCampaniaDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCampaniaDesc" runat="server" />        
                    </td>
                    </table>
        </HeaderTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label3" runat="server" Width="50px" BorderStyle="None" Text='<%# Eval("campaniaorigen") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Width="60px" BorderStyle="None" Text='<%# Eval("campaniaorigen") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
         <%--        tiponc--%>
        <asp:TemplateField Visible="false" HeaderText="Tipo" SortExpression="tiponc"  >
                    <HeaderTemplate>
                        <table><td>Tipo</td>
                        <td>
                        <asp:ImageButton OnClick="btnTipoAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnTipoAsc" runat="server" />
                        <asp:ImageButton OnClick="btnTipoDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnTipoDesc" runat="server" />        
                        </td>
                        </table>
                    </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTipoNc" runat="server" Width="40px" Text='<%# Eval("tiponc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
         <%--motivocr--%>
        <asp:TemplateField Visible="false" HeaderText="Motivo" SortExpression="motivocr" >
<HeaderTemplate>
<table><td>Motivo</td>
<td>
<asp:ImageButton OnClick="btnMotivoAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnMotivoAsc" runat="server" />
<asp:ImageButton OnClick="btnMotivoDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnMotivoDesc" runat="server" />        
</td>
</table>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblMotivocr" runat="server" Width="20px" Text='<%# Eval("motivocr") %>'></asp:Label>
</ItemTemplate>                       
</asp:TemplateField> 
        <%--producto facturado--%>
        <asp:TemplateField Visible="false"  >
        <ItemTemplate>
        <asp:Label ID="lblProductoFacturado" runat="server" Text='<%# llenarProductoFacturado( Eval("productofacturado") )%>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
       </Columns>
    </asp:GridView>
    <%--fin del gridview  --%> 
  </td>
  </tr></table>
  <br />
<%--  boton eliminar/ mostrar total unidades--%>
   <table width="715" border="0" cellspacing="0" cellpadding="5">
        <tr>
          <td width="139"><b>Total de unidades:</b></td>
          <td width="88"> <asp:Label ID="Summary" runat="server" Text=""></asp:Label></td>
          <td width="550">
          <asp:ImageButton ImageUrl="~/assets/images/boton_borrar_pedido.gif" OnClientClick="return confirm('¿Estás seguro que deseas borrar, de forma completa, todo lo pedido en la Solicitud de Compra?')" ID="btnEliminar"     runat="server" CommandName="Eliminar" CausesValidation="false" /> 
          </td>
        </tr>  
        <tr>
        <td width="139"></td>
          <td width="88"> <asp:Label ID="Label1" runat="server" Text="" Visible="false" ></asp:Label></td>
          <td width="550">
        <asp:ImageButton ImageUrl="~/assets/images/boton_RestaurarPedido.gif" OnClientClick="return confirm('¿Estás seguro que deseas restaurar todo el pedido eliminado?')" ID="btnRestaurar"     runat="server" CommandName="Restaurar" CausesValidation="false" /> </td> 
        </tr>        
      </table>      
</div>
<%--validacion--%>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server"  HeaderText="Error en el campo Cantidad" ShowMessageBox="True"  ValidationGroup="VGdetalle" />
<%--datasource--%>
    <asp:ObjectDataSource ID="ODSdetallepedido" runat="server"         SelectMethod="MostrarPedidoCompra" SortParameterName="SortExpression" DataObjectTypeName="Tsu.Entity.VistaConsulta"         TypeName="Tsu.ProviderOra.fachadaVistaConsulta">
        <SelectParameters>
            <asp:Parameter Name="iCuenta" Type="Int32" />
            <asp:Parameter Name="iCampania" Type="Int32" />
            <asp:Parameter Name="iOpcion" DefaultValue="1" Type="Int32" />
            <asp:Parameter Name="SortExpression" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>