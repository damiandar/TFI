﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Reportes.aspx.vb" Inherits="micuenta_Default" %>

<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1" menu="Datos" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Reporte" />
</asp:Content>

