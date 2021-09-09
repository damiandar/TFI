<%@ Page Title="" Language="VB" MasterPageFile="~/Inicio.master" AutoEventWireup="false" CodeFile="Recuperar.aspx.vb" Inherits="Recuperar" %>

<%@ Register Src="~/controles/login/recuperar.ascx" TagPrefix="uc1" TagName="recuperar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:recuperar runat="server" ID="recuperar" />
</asp:Content>

