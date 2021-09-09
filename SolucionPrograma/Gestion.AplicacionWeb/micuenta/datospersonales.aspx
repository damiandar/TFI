<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="datospersonales.aspx.vb" Inherits="Tsu.Paginas.datospersonales" title="::Información personal::" %>

<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>

<%@ Register src="../controles/PlantillaDatosPersonales.ascx" tagname="PlantillaDatosPersonales" tagprefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
     
    <uc1:MenuIzquierda ID="MenuIzquierda1"  menu="Datos"   runat="server" />
     
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

<div class="Titulo">
DATOS PERSONALES
</div>
<div class="subTitulo">
Información personal
</div>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--<p style="background-color:Red">&nbsp;</p>--%>


    <uc2:PlantillaDatosPersonales ID="PlantillaDatosPersonales1" runat="server" />

    <asp:Panel runat="server" ID="PanelMensajeDatos" Visible="false" >
    <div class="mensaje_advertencia_505"> Sus datos serán actualizados a la brevedad
    </div>
</asp:Panel>
   <br />
    <asp:Panel runat="server" ID="MensajeContenedor">
   						<div class=" mensaje_contenedor">
                        	<div class="mensaje_info_715">
                        	Si alguno de los datos registrados no son correctos y/o incompletos <strong>
                        	<asp:LinkButton ID="lnkEnviar" runat="server">haga click aqui</asp:LinkButton>
                        	    &nbsp;
                        	</strong> Se enviar&aacute; un alerta a quien asiste la zona, quien se pondr&aacute; en contacto con usted para que sean modificados y registrados.
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
<%--<table width="715" border="0" cellspacing="0" cellpadding="5">
   <tr><td width="125">Nº Celular:</td><td width="570"><asp:TextBox ID="tbCelular" runat="server" MaxLength="13"   style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="tbCelular" ErrorMessage="Debe ingresar sólo números" 
            ValidationExpression="^[0-9]{1,13}$"></asp:RegularExpressionValidator>
                                                </td></tr>
   <tr><td>E-mail:</td>    <td><asp:TextBox ID="tbMail" runat="server" MaxLength="60"   style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox></td></tr>
   <tr><td  style="width:75px;">Repetir Email: </td><td>
        <asp:TextBox ID="tbMailRepetido" MaxLength="60" runat="server"  style="border: 1px solid #999; width:250px; height:20px;"></asp:TextBox>  
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="El mail es distinto al anterior" 
            ControlToCompare="tbmail" ControlToValidate="tbMailRepetido"></asp:CompareValidator> </td></tr>
   <tr><td colspan="2" align="center"> <asp:ImageButton ID="btnModificar" 
           runat="server" ImageUrl="~/assets/images/boton_aceptar.gif" /></td></tr>
</table>
<asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>--%>
</asp:Content>

