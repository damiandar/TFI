<%@ Page Language="VB" MasterPageFile="~/masterlogin.master" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="Tsu.Paginas.Logout" title="::Fin de sesión" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 
    <div class="mensaje_contenedor">
    	<div class="mensaje_ok_715">
    	<asp:Label runat="server" ID="MensajeSalida">    	
    	</asp:Label>
    	</div>
    </div>
    <p>
        Para volver a entrar, por favor vuelva a la <a href="Login.aspx">página de inicio. </a></p>
    </asp:Content>