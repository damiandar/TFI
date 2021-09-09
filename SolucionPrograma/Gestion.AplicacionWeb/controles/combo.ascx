<%@ Control Language="VB" AutoEventWireup="false" CodeFile="combo.ascx.vb" Inherits="controles_combo" %>
  <table width="715" border="0" cellpadding="5" cellspacing="0">    
    <tr class="tablaTitulo2">
      <td width="112" height="30">Elegir campa&ntilde;a</td>
      <td height="30" style="width: 248px">
      <asp:DropDownList ID="ddlCampania" runat="server" AutoPostBack="True"></asp:DropDownList>
      </td>
      <td><asp:Label  ID="lblCampaniaCerrada" runat="server" ForeColor="Blue"></asp:Label></td>      
    </tr>
    </table>