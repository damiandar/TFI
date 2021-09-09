<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrillaConferencias.ascx.vb" Inherits="Tsu.Paginas.controles_GrillaConferencias" %>
    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <asp:GridView ID="GrillaConferencias" Width="715" AutoGenerateColumns="false" runat="server" DataKeyNames="id" BorderStyle="None" >
           <EmptyDataTemplate>
				<div class="mensaje_contenedor" >
                	<div class="mensaje_info_715" >No hay conferencias cargadas.</div>
                </div>
        </EmptyDataTemplate>
    <Columns>
        <asp:BoundField DataField="zona" HeaderText="Zona" ItemStyle-Width="40px" HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left" />
        <asp:TemplateField  SortExpression="anio"   HeaderText="Año"  ItemStyle-Width="40px" HeaderStyle-BorderStyle="None">
            <HeaderTemplate>
                  <table><td>Año</td>
            <td>
            <asp:ImageButton OnClick="btnAnioAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnAnioAsc" runat="server" />
            <asp:ImageButton OnClick="btnAnioDesc_Click" ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnAnioDesc" runat="server" />        
            </td>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblAnio" Text='<%#Eval("anio") %>' ></asp:Label>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField   HeaderText="Campaña"  ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderStyle="None">
            <HeaderTemplate>
                  <table><td>Campaña</td>
            <td>
            <asp:ImageButton OnClick="btnCampaniaAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnCampaniaAsc" runat="server" />
            <asp:ImageButton OnClick="btnCampaniaDesc_Click" ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnCampaniaDesc" runat="server" />        
            </td>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblCampania" Text='<%#Eval("campania") %>' ></asp:Label>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField   HeaderText="Fecha" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderStyle="None">
            <HeaderTemplate>
                  <table><td>Fecha</td>
            <td>
            <asp:ImageButton OnClick="btnFechaAsc_Click"  ImageUrl="~/assets/images/boton_orden_arriba.gif"  ID="btnFechaAsc" runat="server" />
            <asp:ImageButton OnClick="btnFechaDesc_Click"  ImageUrl="~/assets/images/boton_orden_abajo.gif"  ID="btnFechaDesc" runat="server" />        
            </td>
            </table>
            </HeaderTemplate>
            <ItemTemplate>
            <asp:Label runat="server" ID="lblFecha" Text='<%#FormatearCampoFecha(Eval("fecha") )%>' ></asp:Label>
            </ItemTemplate>
       </asp:TemplateField>
        <asp:TemplateField  HeaderStyle-BorderStyle="None" HeaderText="Hora" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"   >
           <ItemTemplate>
           <asp:Label runat="server"  ID="lblHora" Text='<%#FormatearCampoHora(Eval("hora") )%>'></asp:Label>
           </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left" dataField="actividad" HeaderText="Act." HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left"/>
        <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-BorderStyle="None"  >
            <ItemTemplate>
            <asp:Label runat="server" ID="lblActPrincipal" ForeColor="#59c2d3" Font-Size="14px" Font-Bold="true"  Text='<%# FormatearCampoActPrincipal(Eval("principal")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Lugar"   ItemStyle-Width="250px" HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate >
            <asp:Label runat="server" ID="lblSalon" Text='<%#FormatearCampoTexto( Eval("salon.nombre")) %>' ></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-BorderStyle="None">
            <ItemTemplate >
                <asp:imagebutton  CommandName="Select" ImageUrl="~/assets/images/header_buscar.png" ID="btnSeleccionar" runat="server" text="" BorderStyle="None" />      
            </ItemTemplate> 
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-BorderStyle="None">
            <ItemTemplate >
                <asp:imagebutton  CommandName="Edit" ImageUrl="~/assets/images/boton_modificar.gif" ID="btnModificar" runat="server" text="" BorderStyle="None" />      
            </ItemTemplate> 
            </asp:TemplateField>
        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="70px"  ShowHeader="False" HeaderStyle-BorderStyle="None" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" >
            <ItemTemplate>
                <asp:ImageButton OnClientClick="return confirm('¿Estás seguro que deseas eliminar el evento?')"  ID="ImageButton1" runat="server" CausesValidation="false"    CommandName="BorrarItem" ImageUrl="~/assets/images/boton_borrar.gif" />
            </ItemTemplate>
        </asp:TemplateField> 
    </Columns>
    </asp:GridView>
<br /> <asp:Label ID="lblAsterisco"  Font-Bold="true" ForeColor="#59c2d3" runat="server" Text="X Actividad Principal"></asp:Label><br />
<asp:Button ID="btnPopUp" runat="server" style="display:none" />

<asp:ModalPopupExtender ID="modalPopUpExtender1" runat="server" TargetControlID="btnPopUp" PopupControlID="pnlModalPopUp" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"  ></asp:ModalPopupExtender>

<asp:Panel runat="Server"  ID="pnlModalPopUp">
<div id="detalleEvento"  style="width:100%; height:100%; background-image:url(assets/images/home_campana_fondo.png); z-index:5; display:block; position:absolute; left:0px; top: 0px; ">
      <div style="width:535px; height:200px; background-color:#FFF; border:solid 1px #000; position:absolute; left:50%; top:50%; margin-left:-267px; margin-top:-100px;">
        <div style="width:535px; height:40px; background-color:#676767;">
            <div style="color:#FFF; text-transform:capitalize; font-family: Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; float:left; margin-top:10px; margin-left:10px;">
            DATOS DEL EVENTO
            </div>
            
            <div style="float:right; margin-top:10px; margin-right:10px;">
           <asp:ImageButton ID="btnCancel" ImageUrl="~/assets/images/Cerrar_Ventana.gif" width="20" height="20"  runat="server" />
            </div>
		</div>
        <div style="width:515px; padding:10px; font-family: Arial, Helvetica, sans-serif; font-size:12px;">
       <asp:Literal ID="ltTipoConferencia" runat="server"></asp:Literal><br />
            <b>Zona:</b> <asp:Literal ID="ltZona" runat="server"></asp:Literal> &nbsp;&nbsp;<b>Campaña:</b> <asp:Literal ID="ltCampania" runat="server"></asp:Literal>&nbsp;&nbsp;<b>Año:</b><asp:Literal ID="ltAnio" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltFechayHora" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltLugar" runat="server"></asp:Literal><br />
        <asp:Literal ID="ltTelefono" runat="server"></asp:Literal> &nbsp;&nbsp;<asp:Literal ID="ltTelefono2" runat="server"></asp:Literal><br />
        Observaciones:<asp:Literal ID="ltObservaciones" runat="server"></asp:Literal><br />
</div>
      </div>
</div>
</asp:Panel>