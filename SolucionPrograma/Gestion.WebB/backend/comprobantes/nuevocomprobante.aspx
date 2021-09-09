<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="nuevocomprobante.aspx.vb" Inherits="comprobantes_nuevocomprobante" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
IVA: <asp:DropDownList ID="ComboIVA" runat="server">
    </asp:DropDownList>
Tipo Comprobante: 
    <asp:DropDownList ID="ComboTipoComprobante" runat="server">
    </asp:DropDownList>
  <asp:ImageButton ID="btnIngresar" ImageUrl="~/assets/images/Boton_Solicitar_Contrasena.gif" runat="server" width="130" height="19" />
	
      <asp:GridView ID="GrillaComprobante" runat="server">
      </asp:GridView>

       

</asp:Content>

