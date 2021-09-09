<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Control_tbCodigo.ascx.vb" Inherits="controles_Codigo" %>
<td width="70" >C&oacute;digo</td>						    
<td width="100" >						    
    <asp:TextBox ID="tbproducto"  MaxLength="6" runat="server"  style="border: 1px solid #999; width:80px; height:20px;" TabIndex="1" ></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbproducto" ErrorMessage="El código de producto debe ser numérico" ValidationExpression="^[0-9]{1,6}$" ValidationGroup="VGproducto">*</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbproducto" Display="Dynamic" ErrorMessage="El código no puede quedar vacío" ValidationGroup="VGproducto">*</asp:RequiredFieldValidator>
</td> 