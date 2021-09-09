<%@ Page Title="" Language="VB" MasterPageFile="~/Inicio.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Src="~/controles/login/login.ascx" TagPrefix="uc1" TagName="login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:login runat="server" ID="login" />
</asp:Content>

