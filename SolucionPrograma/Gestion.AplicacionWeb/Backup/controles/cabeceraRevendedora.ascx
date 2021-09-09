<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cabeceraRevendedora.ascx.vb" Inherits="Tsu.Paginas.controles_cabeceraRevendedora" %>
<%--<%@ Register src="../controles/domicilio.ascx" tagname="domicilio" tagprefix="uc2" %>--%>
<div >
      <table width="715"  style="background-color:#D6F1F5;"  border="0" cellpadding="5" cellspacing="0">
        <tr>
          <td height="30" colspan="6"><asp:Image ID="imgUser" ImageUrl="~/assets/images/user.png" runat="server" /><b>
              &nbsp;Datos de la Revendedora</b></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 132px"><b>Apellido y nombre:</b></td>
                <td colspan="5"><asp:Literal ID="ltapellido" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 132px"><b>Cuenta:</b></td>
            <td style="width: 149px" ><asp:Literal ID="ltcuenta" runat="server"></asp:Literal>
            </td>
            <td style="width: 39px"><b>Zona:</b></td>
            <td style="width: 132px"><asp:Literal ID="ltzona" runat="server"></asp:Literal>
            </td>
            <td style="width: 46px"><b>Grupo:</b></td>
            <td width="120"><asp:Literal ID="ltgrupo" runat="server"></asp:Literal>            
            </td>
        </tr>
        <tr><td colspan="6"><asp:Panel ID="PanelDomicilio" runat="server">
<b>Domicilio de opción: </b>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCalleCab" runat="server" Text=""></asp:Label>-
    <asp:Label ID="lblLocalidadCab" runat="server" Text=""></asp:Label>
</asp:Panel>
        </td></tr>
</table>

</div>
