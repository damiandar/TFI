<%@ Page Title="" Language="VB" MasterPageFile="~/Inicio.master" AutoEventWireup="false" CodeFile="Registrarse.aspx.vb" Inherits="Registrarse" %>

<%@ Register Src="~/controles/login/registrar.ascx" TagPrefix="uc1" TagName="registrar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:registrar runat="server" ID="registrar" />
</asp:Content>

