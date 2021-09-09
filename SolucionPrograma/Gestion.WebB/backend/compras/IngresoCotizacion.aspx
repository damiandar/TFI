<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngresoCotizacion.aspx.vb" Inherits="compras_IngresoCotizacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
      function CloseWindow() {
            window.close();
        }
    </script>
  
</head>
<body>
    <form id="form1" runat="server">

    <div id="PanelIngreso">
      INGRESAR COTIZACION 
       <table>
       <tr><td>Proveedor:</td><td><asp:DropDownList ID="comboProveedor" runat="server"></asp:DropDownList></td></tr>
       <tr><td>Valor Unitario:</td><td><asp:TextBox ID="tbValorUnitario" runat="server"></asp:TextBox></td></tr>
       <tr><td>IVA</td>
            <td>
            <asp:DropDownList ID="comboIVA" runat="server">
            <asp:ListItem Value="0" >Sin IVA</asp:ListItem>
            <asp:ListItem Value="1" >10,5 %</asp:ListItem>
            <asp:ListItem Value="2" >21   %</asp:ListItem>
            </asp:DropDownList>
            </td>
       </tr>
       <tr><td colspan="2"><asp:Button ID="btnCotizacion" runat="server" Text="Ingreso Cotizacion" /></td></tr>
       </table>
        
    </div>
    </form>
</body>
</html>
