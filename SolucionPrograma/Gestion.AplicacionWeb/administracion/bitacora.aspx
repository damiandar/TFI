<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="bitacora.aspx.vb" Inherits="micuenta_bitacora" %>

<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Administracion" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table>
    <tr>
    <td>
    Login:<asp:DropDownList ID="comboUsuario" runat="server"></asp:DropDownList>
    </td>
    <td>
    Objeto: <asp:DropDownList ID="comboObjeto" runat="server"></asp:DropDownList>
    </td>
    <td>
    Accion:<asp:DropDownList ID="comboAccion" runat="server"> </asp:DropDownList>
        <asp:Button ID="btnMostrarBitacora" runat="server" Text="Bitacora" />
        
    </td>
    </tr>
    </table>
    <asp:GridView ID="GrillaBitacora" runat="server">
        </asp:GridView>
</asp:Content>

