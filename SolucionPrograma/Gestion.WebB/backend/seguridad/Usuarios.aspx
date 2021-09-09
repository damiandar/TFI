<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Usuarios.aspx.vb" Inherits="seguridad_Usuarios" %>
<%@ Register src="../../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
<uc1:MenuIzquierda ID="MenuIzquierda1" runat="server" menu="Seguridad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
<div class="Titulo">Usuarios </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GrillaUsuarios" runat="server">
    </asp:GridView>

</asp:Content>

