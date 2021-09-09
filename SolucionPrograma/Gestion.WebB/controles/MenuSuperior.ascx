<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuSuperior.ascx.vb" Inherits="controles_MenuSuperior" %>
<%@ Register src="carritomenu.ascx" tagname="carritomenu" tagprefix="uc1" %>
<%@ Register src="alertasmenu.ascx" tagname="alertasmenu" tagprefix="uc2" %>

<%@ Register src="notificacionesmenu.ascx" tagname="notificacionesmenu" tagprefix="uc3" %>

<ul class="nav navbar-right top-nav">
    <%--carrito--%>
    <uc1:carritomenu ID="carritomenu1" runat="server" />
    <%--mail--%>
    <uc3:notificacionesmenu ID="notificacionesmenu1" Visible="false" runat="server" />
    <%--alertas--%>
    <uc2:alertasmenu ID="alertasmenu1" runat="server"  Visible="false" />
    <%--usuario/opciones--%>
    <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li>
                <asp:HyperLink ID="hlMisDatos" NavigateUrl="~/micuenta/datospersonales.aspx" runat="server"><i class="fa fa-fw fa-user"></i> Mis Datos </asp:HyperLink>
            </li>
<%--            <li>
                <a href="#"><i class="fa fa-fw fa-envelope"></i> Inbox</a>
            </li>--%>
            <li>
                <asp:HyperLink ID="hlCambiarClave" NavigateUrl="~/micuenta/cambioclave.aspx" runat="server"><i class="fa fa-fw fa-key"></i> Cambiar Clave  </asp:HyperLink>
            </li>
            <li class="divider"></li>
            <li>
             <asp:LinkButton ID="lnkSalir" runat="server"><i class="fa fa-fw fa-power-off"></i> Salir</asp:LinkButton> 
                <%--<asp:LoginView ID="LoginView1" runat="server">
                    <LoggedInTemplate>
                        <asp:LoginStatus ID="LoginStatus2" LogoutImageUrl="~/assets/images/boton_salir.gif" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Logout.aspx?salir=fin" />
                     </LoggedInTemplate>
                    <AnonymousTemplate>
                        <asp:LoginStatus ID="LoginStatus1"   runat="server" />

                    </AnonymousTemplate>
                    </asp:LoginView>  --%>  
            </li>
        </ul>
    </li>
</ul>