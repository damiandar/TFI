<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Control_tbMotivo.ascx.vb" Inherits="controles_Control_tbMotivo" %>
<td style="width: 37px">Motivo</td>
<td style="width: 60px">
    <asp:TextBox ID="tbMotivo" runat="server" Width="30px" Height="20px" TabIndex="3" AutoPostBack="True" MaxLength="1"></asp:TextBox>
    <asp:RegularExpressionValidator  ErrorMessage="El motivo debe ser numérico" ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbMotivo" ValidationExpression="^[1-9]{1,1}$" ValidationGroup="VGproducto">*</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator  ErrorMessage="El motivo no puede quedar vacío" ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMotivo" Display="Dynamic" ValidationGroup="VGproducto">*</asp:RequiredFieldValidator>
</td>