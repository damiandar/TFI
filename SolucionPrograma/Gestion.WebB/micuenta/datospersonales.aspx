<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="datospersonales.aspx.vb" Inherits="micuenta_datospersonales" %>

<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<%@ Register src="../controles/PlantillaDatosPersonales.ascx" tagname="PlantillaDatosPersonales" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" Runat="Server">
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Datos"   runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Encabezado" Runat="Server">
<h1 class="page-header"> Datos Personales</h1>
<ol class="breadcrumb"> 
    <li>
        <i class="fa fa-Inicio"></i>  <a href="default.aspx">Inicio</a>
    </li>
    <li class="active">
        <i class="fa fa-edit"></i> Datos Personales
    </li>
</ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="text-right" >
        <asp:HyperLink ID="hlCambiarClave" NavigateUrl="~/micuenta/cambioclave.aspx" runat="server">Cambiar Clave <i class="fa fa-arrow-circle-right"></i></asp:HyperLink>
        <a href="#"></a>
    </div>
    <uc2:PlantillaDatosPersonales ID="PlantillaDatosPersonales1" runat="server" />

    <asp:Panel runat="server" ID="PanelMensajeDatos" Visible="false" >
    <div class="mensaje_advertencia_505"> Sus datos serán actualizados a la brevedad
    </div>
</asp:Panel>
   <br />
    <asp:Panel runat="server" ID="MensajeContenedor">
   		<div class=" mensaje_contenedor">
            <div class="mensaje_info_715">
                Si alguno de los datos registrados no son correctos y/o incompletos 
                <strong><asp:LinkButton ID="lnkEnviar" runat="server">haga click aqui</asp:LinkButton></strong> 
            </div>
        </div>
    </asp:Panel>
    <asp:Panel id="Enviado" runat="server" Visible="false">
        <div class=" mensaje_contenedor">
        	<div class="mensaje_ok_715"> El alerta fue enviado. Su asistente de zona se contactará con usted.
            </div>
		</div>
   </asp:Panel>
    <asp:Panel ID="NOEnviado" runat="server" Visible="false">
        <div class="mensaje_contenedor">
            <div class="mensaje_error_715">
        	Se mensaje no ha podido enviarse, intente nuevamente.
        	</div>
        </div>
    </asp:Panel>   
</asp:Content>

