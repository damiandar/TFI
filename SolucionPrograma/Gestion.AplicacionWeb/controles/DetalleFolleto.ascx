<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DetalleFolleto.ascx.vb" Inherits="Tsu.Paginas.controles_DetalleFolleto" %>


<script type="text/javascript">
    $(document).ready(function()    {
    
    $('[id$="tbCantidad"]').keypress(function(e) {
      if( (e.which==43) || (e.which==13))  {  
      {
    e.preventDefault();  $('[id$="btnConfirmar"]').focus(); }
      } });     
    });        
</script>  

<div style="width:715px;  float:left;">
			
							<!-- InstanceBeginEditable name="Centro" -->
                        <div class="tablaSeparador2">
                            <asp:Image ID="ImagenPromocion" runat="server"  width="715" height="90"  />    
                             <%--ImageUrl="~/assets/images/Banner_PromoCatalogo.png"--%>
                        </div>
                        
						<div class="tablaSeparador1">
                           <asp:GridView ID="GrillaFolletos" runat="server" AutoGenerateColumns="False" BorderStyle="None" AlternatingRowStyle-CssClass="tabla5" RowStyle-CssClass="tabla5" RowStyle-Height="30px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Cat&aacute;logo" itemStyle-Width="180px"  HeaderStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BorderStyle="None" HeaderStyle-CssClass ="tablaTitulo1" >
                                        <ItemTemplate >
                                            <asp:Label ID="lblDescripcion" Text='<%#FormatearDescripcion( Eval("campaniafolleto"),Eval("tipo")) %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C&oacute;digo" HeaderStyle-Width="100px" HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass ="tablaTitulo1" >
                                    <ItemTemplate>
                                    <asp:Label  ID="lblCodigo" Text='<%#Eval("codigo") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="Precio" DataField="precio"  ReadOnly="true" HeaderStyle-Width="60px" HeaderStyle-BorderStyle="None" HeaderStyle-CssClass ="tablaTitulo1" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />--%>
                                    <asp:TemplateField HeaderText="Precio" HeaderStyle-Width="60px" HeaderStyle-BorderStyle="None"  HeaderStyle-CssClass="tablaTitulo1" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprecio" runat="server" Width="60px" Text='<%# Eval("precio","{0:c}") %>' ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-BorderStyle="None" HeaderStyle-CssClass ="tablaTitulo1" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="200px" >
                                       <ItemTemplate>            
                                            <asp:TextBox ID="tbCantidad" Width="50px" Text='<%#FormatearCantidad(Eval("codigo")) %>' BackColor="#d2f1fa"  runat="server" Style="text-align: right;" MaxLength="4" ></asp:TextBox>
                                            <asp:RegularExpressionValidator  ErrorMessage="La cantidad debe ser numérica"  ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbCantidad" ValidationExpression="^[0-9]{1,4}$" ValidationGroup="VGproducto">*</asp:RegularExpressionValidator>                                            
                                            <asp:RangeValidator ErrorMessage="Confirme cantidad"  ID="RegularExpressionValidator1" runat="server" MaximumValue="24" MinimumValue="1" ControlToValidate="tbCantidad" ValidationGroup="VGproducto99" Type="Integer" Display="Static" ></asp:RangeValidator>
                                    </ItemTemplate>
                                    <HeaderTemplate>                                       
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cantidad
                                    </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" HeaderStyle-CssClass="tablaTitulo1" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="right" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Right">
                                       <ItemTemplate>
                                            <asp:Label ID="lblCantidad" Width="50px" Text='<%#FormatearCantidad(Eval("codigo")) %>' runat="server" Style="text-align: right;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="" HeaderStyle-CssClass="tablaTitulo1" HeaderStyle-BorderStyle="None" ItemStyle-BorderStyle="None" HeaderStyle-Width="120px" >
                                       <ItemTemplate>
                                            <asp:Label ID="lblMensaje" Width="120px" Text='' runat="server" ></asp:Label>
                                      </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        
                      <asp:ValidationSummary ID="ValidationSummary1"  runat="server" HeaderText="Error en los siguientes campos:" ShowMessageBox="True" ValidationGroup="VGproducto" />
       
                        <div class="tablaSeparador2">
&nbsp;&nbsp;&nbsp;&nbsp;
<table width="440" border="0" cellspacing="0" cellpadding="5">
                                <tr>
                                  <td align="right">
                                      <asp:ImageButton ID="btnModificar" ImageUrl="~/assets/images/boton_modificar.gif" runat="server" />
                                      &nbsp;<asp:ImageButton ID="btnConfirmar" ImageUrl="~/assets/images/boton_confirmar.gif" runat="server" width="65" height="19"  ValidationGroup="VGproducto" />
                                      &nbsp;<asp:ImageButton ID="btnCancelar" ImageUrl="~/assets/images/boton_cancelar.gif" runat="server" width="65" height="19"  />
                                  </td>
                                </tr>
                              </table>
                        </div>
						<!-- InstanceEndEditable --> 
</div>


