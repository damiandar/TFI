<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrillaEvolucion.ascx.vb" Inherits="controles_GrillaEvolucion" %>
<div class="tablaSeparador1">
	    <table width="715" border="0" cellpadding="5" cellspacing="0">
		    <tr class="tablaTitulo1">
			    <td colspan="2">
                    <asp:Label ID="lblTituloGrilla" runat="server" Text=""></asp:Label>    
                    <asp:ImageButton ID="btnExportarGrilla" runat="server" 
                        ImageUrl="~/assets/images/icon-excel.gif" />
                </td>
			</tr>
			<tr class="tablaSeparador1">
			    <td colspan="2">
<asp:GridView ID="Grilla"  AllowSorting="True"  EmptyDataText="No hay pedidos cargados" runat="server" DataKeyNames="campania,zona,grupo" AutoGenerateColumns="False" Width="701px" BorderStyle="None" >
        <Columns>
        <asp:TemplateField HeaderText="zona" SortExpression="zona" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderTemplate>
                <table>
                <tr><td rowspan="2">zona</td><td><asp:ImageButton OnClick="btnZonaAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnZonaAsc0" runat="server" /></td></tr>
                <tr><td><asp:ImageButton OnClick="btnZonaDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnZonaDesc0" runat="server" /></td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblzona" runat="server" Width="30px" Text='<%# Eval("zona") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="30px" />            
</asp:TemplateField>
        <asp:TemplateField HeaderText="campania"  SortExpression="campania" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderTemplate>
                <table><tr><td rowspan="2">campaña</td>
                <td width="10px">
                <asp:ImageButton OnClick="btnCampaniaAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCampaniaAsc0" runat="server" />
                </td> </tr>
                <tr><td width="10px">
                <asp:ImageButton OnClick="btnCampaniaDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCampaniaDesc0" runat="server" />        
                </td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblcampania" runat="server" Width="60px" Text='<%# Eval("campania") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  Width="100px" HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="grupo" HeaderText="grupo" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderTemplate>
                <table><tr><td rowspan="2">grupo</td><td width="10px"><asp:ImageButton OnClick="btnGrupoAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnGrupoAsc0" runat="server" /></td></tr>
                <tr><td><asp:ImageButton OnClick="btnGrupoDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnGrupoDesc0" runat="server" /></td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblgrupo" runat="server" Width="50px" Text='<%# Eval("grupo") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="50px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="cuenta"  SortExpression="cuenta" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <HeaderTemplate>
                <table>
                <tr><td rowspan="2">cuenta</td><td width="10px"><asp:ImageButton OnClick="btnCuentaAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCuentaAsc0" runat="server" /></td></tr>
                <td><asp:ImageButton OnClick="btnCuentaDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCuentaDesc0" runat="server" /></td>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="lnkCuenta" CommandName="MostrarCuenta" Text='<%# Eval("cuenta") %>'  runat="server">LinkButton</asp:LinkButton>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="80px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="Cantidad pedidos"  ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
                    <HeaderTemplate>
                <table>
                <tr><td rowspan="2">Cantidad Pedidos</td><td width="10px"><asp:ImageButton OnClick="btnCantidadPedidosAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCantidadPedidosAsc0" runat="server" /></td></tr>                
                <tr><td><asp:ImageButton OnClick="btnCantidadPedidosDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCantidadPedidosDesc0" runat="server" /></td></tr>                
                </table>
           </HeaderTemplate>
        <ItemTemplate>
        <asp:Label ID="lblCantidadPedidos"  Text='<%#Eval("cantidadpedidos") %>'   runat="server" ></asp:Label>
        </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="80px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Catálogos, Productos y Auxiliares"  SortExpression="cantunidadesPFAV" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">--%>
        <asp:TemplateField HeaderText="Cat., Prod.y Aux."  SortExpression="cantunidadesPFAV" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <%--DataField="cantunidadesPFAV" --%>
            <HeaderTemplate>
                <%--<table><td>Catálogos, Productos y Auxiliares</td>--%>
                <table>
                <tr><td rowspan="2">Cat., Prod. y Aux.</td>
                <td width="10px"><asp:ImageButton OnClick="btnProductosAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnProductosAsc0" runat="server" /></td></tr>
                <tr><td><asp:ImageButton OnClick="btnProductosDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnProductosDesc0" runat="server" /></td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblproductos" runat="server" Width="90px" Text='<%# Eval("cantunidadesPFAV") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Right" Width="90px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Right" Width="90px" />
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Cambios y Reclamos"   SortExpression="cantunidadesCR" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">--%>
        <asp:TemplateField HeaderText="Cambios y Reclamos" SortExpression="cantunidadesCR" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
        <%--DataField="cantunidadesCR" --%>
            <HeaderTemplate>
                <table>
                    <tr>
                        <td rowspan="2">CyR</td> 
                        <td width="10px"><asp:ImageButton OnClick="btnCambiosAsc0_Click" ImageUrl="~/assets/images/boton_orden_arriba.gif" ID="btnCambiosAsc0" runat="server" /></td></tr>
                    <tr>
                    <td><asp:ImageButton OnClick="btnCambiosDesc0_Click" ImageUrl="~/assets/images/boton_orden_abajo.gif" ID="btnCambiosDesc0" runat="server" /></td>
                    </tr>
                </table>
            </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="lblcambios" runat="server" Width="70px" Text='<%# Eval("cantunidadesCR") %>'></asp:Label>
        </ItemTemplate>
        <ControlStyle BorderStyle="None"></ControlStyle>
        <HeaderStyle HorizontalAlign="Right" Width="70px"></HeaderStyle> 
        <ItemStyle HorizontalAlign="Right" Width="70px" />   
    </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Cambios y Reclamos Motivo 5" SortExpression="cantunidadesCR5"  ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">--%>
        <asp:TemplateField HeaderText="CyR Mot.5" SortExpression="cantunidadesCR5"  ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <%--DataField="cantunidadesCR5" --%>
            <HeaderTemplate>
                <%--<table><td>Cambios y Reclamos Motivo 5</td>--%>
                <table><tr><td rowspan="2">CyR Mot.5</td>
                <td width="10px">
                <asp:ImageButton OnClick="btnCambios5Asc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCambios5Asc0" runat="server" />
                </td></tr>
                <tr><td>
                <asp:ImageButton OnClick="btnCambios5Desc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCambios5Desc0" runat="server" />        
                </td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblcambios5" runat="server" Width="70px" Text='<%# Eval("cantunidadesCR5") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Right" Width="70px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Right" Width="70px" />
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Notas de Crédito"  SortExpression="cantunidadesNC" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">--%>
        <asp:TemplateField HeaderText="NC"  SortExpression="cantunidadesNC" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <%--DataField="cantunidadesNC" --%>
            <HeaderTemplate>
                <%--<table><td>Notas de Crédito</td>--%>
                <table><tr><td rowspan="2">NC</td>
                <td width="10px">
                <asp:ImageButton OnClick="btnNCAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnNCAsc0" runat="server" />
                </td></tr>
                <tr><td>
                <asp:ImageButton OnClick="btnNCDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnNCDesc0" runat="server" />        
                </td></tr>
                </table>
           </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblnc" runat="server" Width="70px" Text='<%# Eval("cantunidadesNC") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Right" Width="70px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Right" Width="70px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Usr.Carga"  ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">            
              <ItemTemplate>
                <asp:Label ID="lbltipousuario" runat="server" Width="70px" Text='<%# Eval("tipousuario") %>' ToolTip='<%# nombreTipoUsuario(Eval("tipousuario")) %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="70px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="70px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha"  ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">            
              <HeaderTemplate>
                <table><tr><td rowspan="2">Fecha</td>
                <td width="10px">
                <asp:ImageButton OnClick="btnFechaAsc0_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnFechaAsc0" runat="server" />
                </td></tr>
                <tr><td>
                <asp:ImageButton OnClick="btnFechaDesc0_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnFechaDesc0" runat="server" />        
                </td></tr>
                </table>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblfechaultimo" runat="server" Width="50px" Text='<%# formatofecha(Eval("fechaultimo")) %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="50px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="" ControlStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None">
            <ItemTemplate>
                <asp:Label ID="lblMotivo6" ForeColor="Red" runat="server" Width="20px" Text='<%# llenarMotivo6( Eval("motivo6") )%>'></asp:Label>
            </ItemTemplate>
            <ControlStyle BorderStyle="None"></ControlStyle>
            <HeaderStyle  HorizontalAlign="Center" Width="20px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:TemplateField>            
       </Columns>
</asp:GridView>
   </td>
  </tr>
    <tr class="tablaSeparador1" style=" border-bottom: #999 1px dashed;" >
        <td style="width: 150px"><b>Total de unidades:</b></td>
        <td style="width: 500px"> <asp:Label ID="SumaUnPP" runat="server" ></asp:Label>   </td>          
    </tr>
    <tr class="tablaSeparador1" style=" border-bottom: #999 1px dashed;" >
        <td style="width: 150px"><b>Total de pedidos:</b></td>
        <td width="500px"> <asp:Label ID="SumaPP" runat="server" ></asp:Label>   </td>          
    </tr>     
  </table>
 </div>     