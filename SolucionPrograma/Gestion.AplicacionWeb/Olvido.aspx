<%@ Page Language="VB" MasterPageFile="~/masterlogin.master" AutoEventWireup="false" CodeFile="Olvido.aspx.vb" Inherits="Tsu.Paginas.Olvido" title="::Olvide mi contraseña::" %>

<%@ Register src="controles/olvidemicontrasenia.ascx" tagname="olvidemicontrasenia" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <uc1:olvidemicontrasenia ID="olvidemicontrasenia1" runat="server" />


</asp:Content>

