<%@ Page Title="::Conferencias::" Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="conferencia.aspx.vb" Inherits="Tsu.Paginas.gestionzona_conferencia" %>
<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
<%@ Register src="../controles/conferencia/GrillaConferencias.ascx" tagname="GrillaConferencias" tagprefix="uc3" %>
<%@ Register src="../controles/conferencia/cargaConferencia.ascx" tagname="cargaConferencia" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Gestion"   runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" Runat="Server">
        <div class="Titulo">GESTION DE ZONA</div>
        <div class="subTitulo">Carga de conferencias</div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" >        </asp:ToolkitScriptManager>   
<%--<asp:UpdatePanel runat="server" ID="PanelUpdate">
<ContentTemplate>--%>
<asp:Panel ID="panelfiltros"  runat="server" >
    <div class="advertenciaStock"><asp:ImageButton ID="btnCargarLugar" ImageUrl="~/assets/images/boton_cargar_lugar.gif" runat="server" PostBackUrl="~/gestionzona/lugares.aspx" /></div>
    <table width="715" border="0" cellspacing="0" cellpadding="5" class="tablaTitulo1">
        <tr>        
        <td width="34px"><b>Zona</b></td><td width="100px"><asp:DropDownList DataTextField="zona" DataValueField="zona" ID="comboZona" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        <td width="45px"><b>Año</b></td><td width="100px"><asp:DropDownList ID="ddlAnio" DataValueField="anio" DataTextField="anio" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        <td width="70px"><b>Campaña</b></td><td width="100px"><asp:DropDownList ID="ddlCampania" runat="server" DataTextField="campania" DataValueField="campania" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
    </table>
</asp:Panel>

 <uc4:cargaConferencia ID="cargaConferencia1" runat="server" />
 <uc3:GrillaConferencias ID="GrillaConferencias1" runat="server" />
  <br />
  <asp:ImageButton ID="btnExportarExcel" runat="server" ImageUrl="~/assets/images/Boton_Descargar_Listado.gif" />
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

