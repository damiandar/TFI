<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="Tsu.Paginas.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Entrar al sistema::</title>
    <link href="assets/css/frontend_base.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/vkey.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="assets/images/tsu.ico" />

    <script src="assets/js/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="assets/js/vkeyboard.js" type="text/javascript"></script>
    <script src="assets/js/jquery-ui-personalized-1.5.2.min.js" type="text/javascript"></script>
    <script src="assets/js/jquery-fieldselection.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function()    {
       
       $('[id$="UserName"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="pwd"]').focus(); } });
      
      $('[id$="pwd"]').keypress(function(e) {
      if( e.which==43)   {  e.preventDefault();  $('[id$="loginButton"]').focus(); } });
     
      $("#espacio_tsu_link").click(function() {$("#espacio_tsu_login").toggle();     });
									 });
    </script>

</head>

<body>
<form id="form1" runat="server">
<div id="todo"> 
<%--pagina--%>
<div id="pagina"> 
<div id="background_superior"> 
<div id="background_inferior"> 
    <div id="cuerpo"> 
        <div id="header"> 
		    <div class="logoTsu"><a href=" " target="_blank" ><img src="assets/images/imagen_logo.png" alt="" width="215" height="104"></a></div>
		</div>
        <div id="menu"><a href="login.aspx" >Inicio</a><a href="manualinicio/preguntasfrecuentesinicio.aspx">ayuda</a></div>
        <div id="contenedor">
        <div id="columnaIzquierda">  &nbsp; </div>
            <div style="width:715px;  float:left;">
						        <div id="tituloSeccion">							
                                    <div class="Titulo">Inicio de sesión</div><br />							
                                    <div class="subTitulo"></div>
						         </div>
						        <div style="width:505px;  float:left;">
        						
			        <!-- InstanceBeginEditable name="Centro" -->
                      
        <%--    teclado--%>
            <div class="teclado_virtual">
              <a href="#" id="showkeyboard" title=""><img src="assets/images/mensaje_teclado_virtual.gif" alt="" width="505" height="47" /></a>
            </div>
            <div id="keyboard" style="display:none; ">
	        <div id="" style="background:transparent;">
		        <div style="width: 60%; float:left; background-color: #B3C8D9; margin-bottom:3px; margin-right: 2px; "></div>
		        <div style="background: #FFFFFF; width: 90px; margin-bottom:3px; float:right; margin-right: 30px;"><a href="#" id="showkeyboardX">cerrar teclado x</a></div>
	        </div>
	        <div id="caracteres" style="float:left; width:230px;" >
         
         
	        <div id="row1" class="filasTeclas" style="margin:0px !important;">
		        <div class="estiloTeclas"><input name="q" type="button" value="q" onmouseover="" onmouseout=""/></div>
		        <div class="estiloTeclas"><input name="w" type="button" value="w" /></div>
		        <div class="estiloTeclas"><input name="e" type="button" value="e" /></div>
		        <div class="estiloTeclas"><input name="r" type="button" value="r" /></div>
		        <div class="estiloTeclas"><input name="t" type="button" value="t" /></div>
		        <div class="estiloTeclas"><input name="y" type="button" value="y" /></div>
		        <div class="estiloTeclas"><input name="u" type="button" value="u" /></div>
		        <div class="estiloTeclas"><input name="i" type="button" value="i" /></div>
		        <div class="estiloTeclas"><input name="o" type="button" value="o" /></div>
		        <div class="estiloTeclas"><input name="p" type="button" value="p" /></div>
		        <div class="teclaBack"><input name="backspace" type="button" value="  " /></div>
	        </div>
         
	        <div id="row1_shift" class="filasTeclas" style="margin:0px !important;">
		        <div class="estiloTeclas"><input name="Q" type="button" value="Q" /></div>
		        <div class="estiloTeclas"><input name="W" type="button" value="W" /></div>
		        <div class="estiloTeclas"><input name="E" type="button" value="E" /></div>
		        <div class="estiloTeclas"><input name="R" type="button" value="R" /></div>
		        <div class="estiloTeclas"><input name="T" type="button" value="T" /></div>
		        <div class="estiloTeclas"><input name="Y" type="button" value="Y" /></div>
		        <div class="estiloTeclas"><input name="U" type="button" value="U" /></div>
		        <div class="estiloTeclas"><input name="I" type="button" value="I" /></div>
		        <div class="estiloTeclas"><input name="O" type="button" value="O" /></div>
		        <div class="estiloTeclas"><input name="P" type="button" value="P" /></div>
		        <div class="teclaBack"><input name="backspace" type="button" value="  "   /></div>
	        </div>
         
	        <div id="row2" class="filasTeclas">
		        <div class="estiloTeclas"><input name="a" type="button" value="a" /></div>
		        <div class="estiloTeclas"><input name="s" type="button" value="s" /></div>
		        <div class="estiloTeclas"><input name="d" type="button" value="d" /></div>
		        <div class="estiloTeclas"><input name="f" type="button" value="f" /></div>
		        <div class="estiloTeclas"><input name="g" type="button" value="g" /></div>
		        <div class="estiloTeclas"><input name="h" type="button" value="h" /></div>
		        <div class="estiloTeclas"><input name="j" type="button" value="j" /></div>
		        <div class="estiloTeclas"><input name="k" type="button" value="k" /></div>
		        <div class="estiloTeclas"><input name="l" type="button" value="l" /></div>
		        <div class="estiloTeclas"><input name="l" type="button" value="ñ" /></div>		        
	            <div class="teclaEnter"><input name="Enter" type="button" value="   "  onclick="document.forms[0].submit();"/></div>
	         </div>
         
	        <div id="row2_shift" class="filasTeclas">
		        <div class="estiloTeclas"><input name="a" type="button" value="A" /></div>
		        <div class="estiloTeclas"><input name="s" type="button" value="S" /></div>
		        <div class="estiloTeclas"><input name="d" type="button" value="D" /></div>
		        <div class="estiloTeclas"><input name="f" type="button" value="F" /></div>
		        <div class="estiloTeclas"><input name="g" type="button" value="G" /></div>
		        <div class="estiloTeclas"><input name="h" type="button" value="H" /></div>
		        <div class="estiloTeclas"><input name="j" type="button" value="J" /></div>
		        <div class="estiloTeclas"><input name="k" type="button" value="K" /></div>
		        <div class="estiloTeclas"><input name="l" type="button" value="L" /></div>
		        <div class="estiloTeclas"><input name="l" type="button" value="Ñ" /></div>
		        <div class="teclaEnter"><input name="Enter"  type="button"   onclick="document.forms[0].submit();"/></div>
	         </div>
         
	        <div id="row3" class="filasTeclas">
	            <div class="estiloTeclas"><input name="z" type="button" value="z" /></div>
		        <div class="estiloTeclas"><input name="x" type="button" value="x" /></div>
		        <div class="estiloTeclas"><input name="c" type="button" value="c" /></div>
		        <div class="estiloTeclas"><input name="v" type="button" value="v" /></div>
		        <div class="estiloTeclas"><input name="b" type="button" value="b" /></div>
		        <div class="estiloTeclas"><input name="n" type="button" value="n" /></div>
		        <div class="estiloTeclas"><input name="m" type="button" value="m" /></div>
	            <div class="teclaShift"><input name="Shift" type="button" value=" " id="shift" /></div>
		        
		    </div>
         
	        <div id="row3_shift" class="filasTeclas">   <div class="estiloTeclas"><input name="Z" type="button" value="Z" /></div>
		        <div class="estiloTeclas"><input name="X" type="button" value="X" /></div>
		        <div class="estiloTeclas"><input name="C" type="button" value="C" /></div>
		        <div class="estiloTeclas"><input name="V" type="button" value="V" /></div>
		        <div class="estiloTeclas"><input name="B" type="button" value="B" /></div>
		        <div class="estiloTeclas"><input name="N" type="button" value="N" /></div>
		        <div class="estiloTeclas"><input name="M" type="button" value="M" /></div>
		        <div class="teclaShift"><input name="Shift" type="button" value=" " id="shifton" /></div>
		   </div>
        </div>
	        <div id="numeros" style="float:left; width:60px;">
	        <div id="numerosF1" class="filasTeclas">
		        <div class="estiloTeclas"><input name="1" type="button" value="1" /></div>
		        <div class="estiloTeclas"><input name="2" type="button" value="2" /></div>
		        <div class="estiloTeclas"><input name="3" type="button" value="3" /></div>
	        </div>
        	
	        <div id="numerosF2" class="filasTeclas">
		        <div class="estiloTeclas"><input name="4" type="button" value="4" /></div>
		        <div class="estiloTeclas"><input name="5" type="button" value="5" /></div>
		        <div class="estiloTeclas"><input name="6" type="button" value="6" /></div>
	        </div>
         
	        <div id="numerosF3" class="filasTeclas">
		        <div class="estiloTeclas"><input name="7" type="button" value="7" /></div>
		        <div class="estiloTeclas"><input name="8" type="button" value="8" /></div>
		        <div class="estiloTeclas"><input name="9" type="button" value="9" /></div>
	        </div>
	        <div id="numerosF4" class="filasTeclas">
		        <div class="estiloTeclas">&nbsp;</div>
		        <div class="estiloTeclas"><input name="0" type="button" value="0" /></div>
	        </div>
	        </div>
         
        </div>
        <%--fin de teclado--%>

        <%--usuario y contraseña--%>
            <table width="505" border="0" cellspacing="0" cellpadding="5">
	          <tr>
	            <td width="100">Usuario:</td>
	            <td width="415" height="30">
                <asp:TextBox ID="UserName" Text="" MaxLength="9"   style="border: 1px solid #999; width:300px; height:20px;" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ErrorMessage="Debe ingresar una cuenta"  Display="None"></asp:RequiredFieldValidator>
                </td>
              </tr>
	          <tr>
	            <td>Contrase&ntilde;a:</td>
	            <td height="30">
	             <asp:TextBox ID="pwd" MaxLength="8"   runat="server" TextMode="Password"   style="border: 1px solid #999; width:300px; height:20px;"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="pwd"  ErrorMessage="Debe ingresar una contraseña" Display="None"></asp:RequiredFieldValidator>
                </td>
              </tr>
	          <tr>
	            <td>&nbsp;</td>
	            <td><asp:CheckBox Visible="false" ID="RememberMe" runat="server" Text="Recordar contraseña" /></td>
              </tr>
	          <tr>
	            <td>&nbsp;</td>
	            <td>&iquest;Olvidaste tu contrase&ntilde;a? <a href="Olvido.aspx"><strong>Click aqu&iacute;.</strong></a></td>
              </tr>
	          <tr>
	            <td>&nbsp;</td>
	            <td><asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="El usuario o la contraseña es inválida. Vuelva a intentar" Visible="False"></asp:Label><asp:Panel ID="contraseniaErronea" runat="server">
         <asp:Label ID="lblCantidadSuperada" runat="server" ForeColor="Red"></asp:Label>        
        </asp:Panel></td>
              </tr>
	          <tr>
	            <td>&nbsp;</td>
	            <td><asp:ImageButton ID="LoginButton" ImageUrl="~/assets/images/boton_aceptar.gif"  width="65" height="19" runat="server" /></td>
              </tr>
            </table>
        <%--usuario y contraseña--%>				

        <a href="usuarionuevo.aspx"><img alt="" src="assets/images/banner_nuevos_usuarios.gif" width="505" height="90" /></a><!-- InstanceEndEditable -->
        </div>
        <div id="columnaDerecha">
        &nbsp;
        </div>
					        </div>
		</div>
    </div>
</div> 
</div> 
</div> 

    
<%--footer--%>
<div id="footer_background"> 
	<div id="footer">
	    <div id="footer_disclaimer"> TSU Cosméticos 2011 - Todos los derechos reservados.	</div> 
	</div> 
</div> 
<%--footer--%>
</div>

</form>

</body>
</html>
