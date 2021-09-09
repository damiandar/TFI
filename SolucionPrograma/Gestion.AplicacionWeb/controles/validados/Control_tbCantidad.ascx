<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Control_tbCantidad.ascx.vb" Inherits="controles_Control_tbCantidad" %>
 <td width="50">Cantidad</td>
 <td width="70">
    <asp:TextBox ID="tbCantidad"  MaxLength="4"  runat="server" style="border: 1px solid #999; width:60px; height:20px;" TabIndex="3"></asp:TextBox>
    <asp:RegularExpressionValidator  ErrorMessage="La cantidad debe ser numérica"  ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbCantidad" ValidationExpression="^[0-9]{1,4}$" ValidationGroup="VGproducto">*</asp:RegularExpressionValidator>
    <asp:RangeValidator              ErrorMessage="La cantidad debe ser numérica o distinta de cero." ControlToValidate="tbCantidad"  MinimumValue="1" ValidationGroup="VGproducto" MaximumValue="9999" SetFocusOnError="True"  ID="RangeValidator1" runat="server">*</asp:RangeValidator>
    <asp:RequiredFieldValidator      ErrorMessage="La cantidad no puede quedar vacía"  ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCantidad" ValidationGroup="VGproducto">*</asp:RequiredFieldValidator>
</td>	