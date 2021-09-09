<%@ Page  Title="::Conferencias::"  Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="lugares.aspx.vb" Inherits="Tsu.Paginas.gestionzona_lugares" %>
  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register src="../controles/conferencia/cargaSalon.ascx" tagname="cargaSalon" tagprefix="uc2" %>
<%@ Register src="../controles/conferencia/GrillaLugares.ascx" tagname="GrillaLugares" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Gestion"   runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
        <div class="Titulo">GESTION DE ZONA</div>
        <div class="subTitulo">Carga de lugares</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" >        </asp:ToolkitScriptManager>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>--%>
    Zona: <asp:DropDownList ID="combozona" runat="server" AutoPostBack="True">    
    </asp:DropDownList>           
    <br />        
    <uc2:cargaSalon ID="cargaSalon1" runat="server" />
    <uc3:GrillaLugares ID="GrillaLugares1" runat="server" />
<%--</ContentTemplate>
  </asp:UpdatePanel>--%>
</asp:Content>

