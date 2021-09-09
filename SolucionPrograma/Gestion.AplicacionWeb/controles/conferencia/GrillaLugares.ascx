<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GrillaLugares.ascx.vb" Inherits="Tsu.Paginas.controles_conferencia_GrillaLugares" %>
  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy> 
    <asp:GridView ID="GrillaLugares" runat="server" 
    EditRowStyle-CssClass="tablaFilaDestacada" AutoGenerateColumns="False" 
    DataKeyNames="id,zona" BorderStyle="None" >
              <EmptyDataTemplate>
				<div class="mensaje_contenedor" >
                	<div class="mensaje_info_715" >No hay lugares cargados.</div>
                </div>
        </EmptyDataTemplate>
    <Columns>
    <asp:BoundField DataField="zona"  HeaderText="Zona" ItemStyle-Width="40" 
            HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left"  >
<HeaderStyle HorizontalAlign="Left" BorderStyle="None"></HeaderStyle>

<ItemStyle Width="40px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%#  FormatearCampoTexto(Eval("nombre")) %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle BorderStyle="None" HorizontalAlign="Left" />
            <ItemStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dirección">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# FormatearCampoTexto( Eval("domicilio")) %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle BorderStyle="None" HorizontalAlign="Left" />
            <ItemStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Localidad">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# FormatearCampoTexto( Eval("localidad")) %>'></asp:Label>
            </ItemTemplate>
            <HeaderStyle BorderStyle="None" HorizontalAlign="Left" />
            <ItemStyle Width="150px" />
        </asp:TemplateField>
    <asp:TemplateField HeaderText="Provincia" ItemStyle-Width="150" HeaderStyle-BorderStyle="None" HeaderStyle-HorizontalAlign="Left" >
    <ItemTemplate>
    <asp:Label runat="server" ID="lblProvincia" Text='<%#FormatearCampoProvincia(Eval("provincia")) %>'></asp:Label>
    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left" BorderStyle="None"></HeaderStyle>

<ItemStyle Width="150px"></ItemStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-BorderStyle="None">
    <ItemTemplate >
        <asp:imagebutton  CommandName="Select" ImageUrl="~/assets/images/header_buscar.png" ID="btnSeleccionar" runat="server" text="" BorderStyle="None" />      
    </ItemTemplate> 

<HeaderStyle BorderStyle="None"></HeaderStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-BorderStyle="None" >
        <ItemTemplate >
        <asp:imagebutton  CommandName="Edit" ImageUrl="~/assets/images/boton_modificar.gif" ID="btnModificar" runat="server" text="" BorderStyle="None" />      
        </ItemTemplate> 

<HeaderStyle BorderStyle="None"></HeaderStyle>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="70px"  ShowHeader="False" HeaderStyle-BorderStyle="None" ControlStyle-BorderStyle="None" ItemStyle-BorderStyle="None" >
        <ItemTemplate>
        <asp:ImageButton OnClientClick="return confirm('¿Estás seguro que deseas eliminar el lugar?')"  ID="ImageButton1" runat="server" CausesValidation="false"    CommandName="BorrarItem" ImageUrl="~/assets/images/boton_borrar.gif" />
        </ItemTemplate>

<ControlStyle BorderStyle="None"></ControlStyle>

<HeaderStyle HorizontalAlign="Center" BorderStyle="None" Width="70px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" BorderStyle="None"></ItemStyle>
    </asp:TemplateField> 
    </Columns>
    
<EditRowStyle CssClass="tablaFilaDestacada"></EditRowStyle>
    
    </asp:GridView>
<%--    panel popup de la lupa--%>
    <asp:Button ID="btnPopUp" runat="server" style="display:none" />

<asp:ModalPopupExtender ID="modalPopUpExtender1" runat="server" TargetControlID="btnPopUp" PopupControlID="pnlModalPopUp"  BackgroundCssClass="modalBackground" CancelControlID="btnCancel"  > </asp:ModalPopupExtender>

<asp:Panel runat="Server"  ID="pnlModalPopUp"  >
<div id="detalleEvento"  style="width:100%; height:100%; background-image:url(assets/images/home_campana_fondo.png); z-index:5; display:block; position:absolute; left:0px; top: 0px; ">
    <div style="width:535px; height:200px; background-color:#FFF; border:solid 1px #000; position:absolute; left:50%; top:50%; margin-left:-267px; margin-top:-100px;">
        <div style="width:535px; height:40px; background-color:#676767;">
            <div style="color:#FFF; text-transform:capitalize; font-family: Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; float:left; margin-top:10px; margin-left:10px;">
            DATOS DE LA UBICACIÓN
            </div>
            
            <div style="float:right; margin-top:10px; margin-right:10px;">
                <asp:ImageButton ID="btnCancel" ImageUrl="~/assets/images/Cerrar_Ventana.gif" width="20" height="20"  runat="server" />
            </div>
		</div>
    
        <div style="width:515px; padding:10px; font-family: Arial, Helvetica, sans-serif; font-size:12px;">
        Nombre:<asp:Literal ID="ltNombre" runat="server"></asp:Literal><br />
        Zona: <asp:Literal ID="ltZona" runat="server"></asp:Literal><br />
        Dirección:<asp:Literal ID="ltDireccion" runat="server"></asp:Literal> ,<asp:Literal ID="ltLocalidad" runat="server"></asp:Literal>,<asp:Literal ID="ltProvincia" runat="server"></asp:Literal><br />
        Barrio:<asp:Literal ID="ltBarrio" runat="server"></asp:Literal> <br />
        Entre calles: <asp:Literal ID="ltEntreCalles" runat="server"></asp:Literal><br />
        Teléfono:<asp:Literal ID="ltTelefono1" runat="server"></asp:Literal> <br />
        Teléfono alternativo: <asp:Literal ID="ltTelefono2" runat="server"></asp:Literal>
        </div>
 	</div>
</div>    
</asp:Panel>
<%-- fin panel popup de la lupa--%>

<%--    panel popup de eliminacion--%>
    <asp:Button ID="btnPopUpEliminacion" runat="server" style="display:none" />

<asp:ModalPopupExtender ID="modalPopUpExtender2" runat="server" TargetControlID="btnPopUpEliminacion" PopupControlID="PanelPopUpEliminacion"  BackgroundCssClass="modalBackground" CancelControlID="btnCancel"  > </asp:ModalPopupExtender>

<asp:Panel runat="Server"  ID="PanelPopUpEliminacion"  >
    <div class="mensaje_advertencia_715"> 
    <table  width="535">
     <tr><td align="right"><asp:ImageButton ID="ImageButton2" ImageUrl="~/assets/images/close_button.png" runat="server" /></td></tr>   
     <tr><td><asp:Label  ID="lblAdvertencia" Text="No se puede eliminar el lugar porque esta asignado a un evento" runat="server" /></td></tr>

    </table>
    </div>
</asp:Panel>

<%-- fin panel popup de eliminacion--%>