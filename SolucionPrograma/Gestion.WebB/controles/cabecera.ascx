<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cabecera.ascx.vb" Inherits="Tsu.Paginas.controles_cabecera" %>


<div id="mod_Catalogo">
    <div class="tapa">
    <asp:Image ID="imagencalendario" runat="server"  width="80" height="86" align="absmiddle" />
    </div>

    <div class="contenido">
    <span class="titulo">INFORMACIÓN&nbsp; <asp:Literal ID="ltCampania" runat="server"></asp:Literal></span><br />
	<span class="texto">
	    <asp:Literal ID="ltfecha" runat="server"></asp:Literal> <br />
	</span>
    <span class="hora">
    <b>Fecha actual: <asp:Label ID="lblReloj" Font-Bold="true" runat="server" Text="Label"></asp:Label></b><br />
    </span>
	</div>
                            
    <div class="boton">
         <asp:ImageButton ID="BotonCatalogo"  Width="109" Height="19" ImageUrl="~/assets/images/boton_ver_catalogo.gif" runat="server" />
    </div>
</div>

<div id="mod_Usuario">
    <div class="texto">
    <b><asp:Literal ID="ltApellido" runat="server"></asp:Literal></b><br />
    USUARIO:  <asp:Literal ID="ltCuenta" runat="server"></asp:Literal><br />
    DOCUMENTO: <asp:Literal ID="ltDocumento" runat="server"></asp:Literal><br />
    ZONA:  <asp:Literal ID="ltZona" runat="server"></asp:Literal>&nbsp;&nbsp;
    GRUPO: <asp:Literal ID="ltGrupo" runat="server"></asp:Literal>       
    </div>

<div class="boton">
    <asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate><asp:LoginStatus ID="LoginStatus2" LogoutImageUrl="~/assets/images/boton_salir.gif" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Logout.aspx?salir=fin" /></LoggedInTemplate>
    <AnonymousTemplate><asp:LoginStatus ID="LoginStatus1"   runat="server" /></AnonymousTemplate>
    </asp:LoginView>
 </div>
</div>



