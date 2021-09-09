<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrillaConsulta.ascx.vb" Inherits="controles_GrillaConsulta" %>
    <div class="tablaSeparador1">
    <table width="715" border="0" cellpadding="5" cellspacing="0">
        <tr class="tablaTitulo1">    	        
        <td width="695"  colspan="2"><asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
     <%--grilla 1--%>
        <td colspan="2">
       <asp:GridView ID="ListaPedidos"  ShowFooter="false" runat="server" DataKeyNames="codigoproducto,campania,cuenta,zona" AutoGenerateColumns="False" BorderStyle="None" EmptyDataText="">        
        <%--<EmptyDataText="No hay productos cargados" <EmptyDataTemplate><div class="mensaje_contenedor" style="border:none"><div class="mensaje_info_715" > No hay productos cargados. </div> </div> </EmptyDataTemplate>--%>
        <Columns>     
            <asp:BoundField DataField="Campaniaorigen" HeaderText="Campaña" SortExpression="campaniaorigen"   ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-Width="70px" ItemStyle-Width="70px"/>                          
            <asp:TemplateField HeaderText="Código" SortExpression="codigoproducto" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle Width="70px" HorizontalAlign="Left" />
            <ItemTemplate>
            <asp:Label ID="lblcodigoproducto" runat="server" Text='<%# Eval("producto.codigoproducto") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px" />
            </asp:TemplateField>
            <asp:BoundField DataField="motivocr" ItemStyle-HorizontalAlign="Center" HeaderText="Motivo" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None"  >                
            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
            <HeaderStyle HorizontalAlign="Center" Width="40px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidadsolicitada" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right"  Width="70px" />
            <ItemTemplate>
            <asp:Label ID="lblcantidadsolicitada" runat="server" Width="70px" Text='<%# Eval("cantidadsolicitada") %>'></asp:Label>
            </ItemTemplate>
<%--            <ControlStyle Width="20px" />--%>
            <ItemStyle HorizontalAlign="Right" Width="70px" />
            </asp:TemplateField>
            <asp:BoundField DataField="tiponc" HeaderText="Tipo" ReadOnly="True"  SortExpression="tiponc" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None"  ItemStyle-Width="40px" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"/>                
            <asp:TemplateField HeaderText="Producto" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle Width="300px" HorizontalAlign="Left" />
            <ItemTemplate>
            <asp:Label ID="lbldescripcionfolleto" runat="server" Text='<%# Eval("producto.descripcionproducto") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="300px" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad" SortExpression="cantidadsolicitada" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right" Width="70px" />
            <ItemTemplate>
            <asp:Label ID="lblcantidadsolicitada" runat="server" Width="70px" Text='<%# Eval("cantidadsolicitada") %>'></asp:Label>
            </ItemTemplate>
<%--            <ControlStyle Width="20px" />--%>
            <ItemStyle HorizontalAlign="Right" Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right" Width="50px" />
            <ItemTemplate>
            <asp:Label ID="lblpreciofolleto"   runat="server" Text='<%# Eval("producto.preciofolleto","{0:c}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="70px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Catálogo" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Center" Width="70px" />
            <ItemStyle HorizontalAlign="Center" Width="70px" />
            <ItemTemplate>
            <asp:Label ID="lblcodigofolleto" runat="server" Text='<%# Eval("producto.codigofolleto") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Pag." ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right" Width="40px" />
            <ItemStyle HorizontalAlign="Right" Width="40px" />
            <ItemTemplate>
            <asp:Label ID="lblpaginafolleto" runat="server" Text='<%# Eval("producto.paginafolleto") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prod. Facturado" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <ItemTemplate>
            <asp:Label ID="lblProductoFacturado" runat="server" Text='<%# Eval("descripcionproductofacturado") %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" Width="250px" />
            <ItemStyle HorizontalAlign="Left" Width="250px" />
            </asp:TemplateField>
            <asp:BoundField DataField="zona" Visible="False"/>
            <asp:BoundField DataField="cuenta" Visible="False" />    
          <asp:TemplateField  HeaderText="Fecha" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right" Width="60px" />
            <ItemStyle HorizontalAlign="Right" Width="60px" />
            <ItemTemplate>
            <asp:Label ID="lblfecha" runat="server" Text='<%# FormatoFecha(Eval("fechaultimo")) %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario carga" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderStyle HorizontalAlign="Right" Width="60px" />
            <ItemStyle HorizontalAlign="Right" Width="60px" />
            <ItemTemplate>
            <asp:Label ID="lblTipoUsuario" runat="server" Text='<%# Eval("tipousuario") %>' ToolTip='<%# Eval("cuentacarga") %>'></asp:Label> 
            </ItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>
        </td>
     <%--fin de grilla 1  --%>
        </tr> 
        <tr>
          <td width="139"><b>Total de unidades:</b></td>
          <td width="481"> <asp:Label ID="Summary" runat="server" Font-Bold="true" ></asp:Label>   </td>          
        </tr>          
      </table>          

    </div>
