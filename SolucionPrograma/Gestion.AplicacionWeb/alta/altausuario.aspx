<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="altausuario.aspx.vb" Inherits="Tsu.Paginas.altausuario" title="::Alta del Usuario::" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
    .
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <div id="tituloSeccion">
    <div class="Titulo">
        NUEVO USUARIO
    </div>
</div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=" mensaje_contenedor">
    	<div class="mensaje_info_715">
        Registrate ahora y en pocos minutos podr&aacute;s cargar tu orden y disfrutar los m&uacute;ltiples beneficios de este sitio.</div>
    </div>    
    <table width="715" border="0" cellspacing="0" cellpadding="5">
        <tr>
            <td width="125">Cuenta:</td>
            <td width="570">&nbsp;<asp:Literal runat="server" ID="ltCuenta"></asp:Literal></td>
        </tr>
        <tr>
            <td>Documento:</td>
            <td height="30">&nbsp;<asp:Literal runat="server" ID="ltDocumento"></asp:Literal></td>
        </tr>			    
        <tr>
	        <td>Zona: </td>
	        <td>&nbsp;<asp:Literal runat="server" ID="ltZona"></asp:Literal> </td>
        </tr>        
    </table>
    <div class="tablaSeparador1">
    </div>
    <strong>
    Ingrese una nueva contrase&ntilde;a</strong>
    <table width="715" border="0" cellpadding="5" cellspacing="0">
      <tr>
        <td width="125">Contrase&ntilde;a: </td>
        <td width="570"><asp:TextBox MaxLength="8" ID="tbpass" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Debe ingresar una contraseña" ControlToValidate="tbpass"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbpass" Font-Size="Smaller" ErrorMessage="Debe tener entre 6 y 8 letras y/o números." ValidationExpression="[^\s]{6,8}" />            
        </td>                
      </tr>      
      <td width="125"></td>
      <td style="font-size:x-small" colspan="2"> La contraseña debe tener entre 6 y 8 letras y/o números exceptuando espacios en blanco, signos y acentos.</td>
      <tr>
        <td>Repetir contrase&ntilde;a:</td>
        <td height="30"><asp:TextBox ID="tbpassrepetida" MaxLength="8"  runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe repetir la contraseña" ControlToValidate="tbpassrepetida"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbpass" ControlToValidate="tbpassrepetida"          ErrorMessage="Las contraseñas deben ser iguales"></asp:CompareValidator>
        </td>
      </tr>
    </table>
    <div class="tablaSeparador1">    </div>
    <b>Contestar las siguientes 3 preguntas</b><br />
      <table width="715" border="0" cellpadding="5" cellspacing="0">
        <tr><td width="125"><b>Pregunta 1</b></td>
            <td width="570">&iquest;C&uacute;al es el nombre de su madre?</td>
        </tr>
        <tr><td>Respuesta </td>
            <td><asp:TextBox ID="tbRespuesta1" MaxLength="20" runat="server" Width="200px"></asp:TextBox>
        </td></tr>
        <tr><td><b>Pregunta 2</b></td>
            <td>&iquest;C&uacute;al es el nombre de la localidad donde naci&oacute;?
        </td> </tr>
        <tr><td>Respuesta</td>
            <td><asp:TextBox ID="tbRespuesta2"  MaxLength="20" runat="server" Width="200px"></asp:TextBox>
        </td></tr>
        <tr><td><b>Pregunta 3</b></td>
            <td>&iquest;C&uacute;al es su apellido materno?
        </td></tr>
        <tr><td>Respuesta</td>
            <td><asp:TextBox ID="tbRespuesta3"  MaxLength="20" runat="server" Width="200px"></asp:TextBox>
        </td></tr>        
    </table>
    <br />
    <div class=" mensaje_contenedor">
      <div class="mensaje_info_715">Aclaraci&oacute;n: La informaci&oacute;n brindada en las respuestas es 
        s&oacute;lo por seguridad para uso de recupero de contrase&ntilde;a en caso de olvido de la 
        misma.</div>
    </div>    
    <div class="tablaSeparador1">    </div>
      <b>Mis preferencias</b>
<table width="715" border="0" cellpadding="5" cellspacing="0">
    <tr><td style="width: 20px"><asp:CheckBox ID="CheckBox1" Checked="true" runat="server" Text=" " />
    <td class="bold" style="width: 592px">  Deseo recibir 
    informaci&oacute;n de TSU Cosm&eacute;ticos (lanzamientos, promociones, newsletters, etc.)</td>
    </td></tr>
</table>
    <div class="tablaSeparador1">    </div>
    <b>T&eacute;rminos y condiciones generales</b>
<table>
    <asp:TextBox ID="TextBox1" runat="server" Height="115px" TextMode="MultiLine" 
        Width="710px" 
        Text="El acceso y/o uso del Sitio Web de Tsu Cosméticos (en adelante el 'Sitio Web' o TSU, indistintamente) requiere que todos los visitantes al mismo  acepten previamente los Términos y Condiciones, plenamente y sin reserva alguna, así como en su caso, las Condiciones Particulares que en el futuro puedan complementarlas, sustituirlas o modificarlas, siempre en relación con los servicios y contenidos del Sitio Web. Por el solo hecho de ingresar y hacer uso de este Sitio Web, usted (el 'Usuario') se adhiere en forma inmediata a todos y cada uno de los siguientes Términos y Condiciones. En consecuencia, el Usuario deberá leer detenidamente los Términos y Condiciones así como las Condiciones Particulares, que pudieran dictarse, antes de acceder y/o utilizar cualquier servicio del Sitio Web bajo su entera responsabilidad.
Modificación unilateral del Sitio Web
TSU se reserva el derecho de, en cualquier momento y sin necesidad de previo aviso, modificar o eliminar el contenido, estructura, diseño, servicios y condiciones de acceso y/o uso de este Sitio Web.

Registración
Es obligatorio completar el formulario de registración en todos sus campos con datos válidos para la adquisición de los productos y servicios ofrecidos en este sitio. La registración es gratuita.
El futuro usuario deberá completarlo con su información personal de manera exacta, precisa y verdadera  y asume el compromiso de actualizarlos siempre que  resulte necesario. TSU  podrá utilizar diversos medios para identificar a sus usuarios, pero TSU  no se responsabiliza por la certeza de los Datos Personales provistos por sus usuarios. Estos datos serán utilizados a los fines para los que son requeridos y en un todo de acuerdo con la ley 25.326 de protección de datos personales.
TSU se reserva el derecho de verificar la información proporcionada y de solicitar documentación o datos adicionales a efectos de corroborar los Datos Personales, así como de suspender temporal o definitivamente a aquellos usuarios cuyos datos no hayan podido ser confirmados.
El sitio se reserva el derecho de rechazar cualquier solicitud de registración o de cancelar una registración previamente aceptada, sin que esté obligado a comunicar o exponer las razones de su decisión y sin que ello genere algún derecho a indemnización o resarcimiento.
Para realizar un pedido Usted deberá ingresar al sitio y en el lugar indicado ingresar el usuario y contraseña. La contraseña es un dato personal e intransferible. En consecuencia, a partir de la habilitación del usuario, usted se hace responsable del uso y confidencialidad de los elementos que lo autentican y, habida cuenta que los datos que incorpore o consulte a través del sitio de TSU serán tenidos como ingresados/consultados por usted, debe comprometerse a mantener dicha clave como de su exclusivo conocimiento. Asimismo, deberá cambiarla periódicamente y modificarla de manera inmediata ante la suposición o certeza de que un tercero ha llegado a conocerla.

Legislación
El ingreso y utilización de este Sitio Web se encuentra sujeto y en un todo de acuerdo a las disposiciones aplicables de la legislación Argentina. TSU se encuentra inscripta ente el organismo creado por la ley 25.326, cumpliendo con todos sus lineamientos.
Uso del Sitio Web
El Usuario se compromete a utilizar el Sitio Web, sus servicios y contenidos sin contravenir la legislación aplicable, la buena fe y el orden público. En consecuencia, queda prohibido todo uso con fines ilícitos o que de algún modo perjudique, impida, dañe, altere o sobrecargue de cualquier forma, la utilización y normal funcionamiento del Sitio Web o directa o indirectamente atenten contra el mismo o contra cualquier derecho de un tercero.
La información suministrada en el sitio tiene una finalidad  específica, por lo tanto, y atento que es proporcionada al Usuario “en la forma en que se encuentra”, TSU no se hará responsable en modo alguno por el daño o perjuicio que de su utilización se derive. En consecuencia, TSU no asume responsabilidad alguna por cualquier perjuicio, costo, daño o pérdida de ninguna naturaleza originado como consecuencia de la falta de utilidad, adecuación y/o validez del contenido del Sitio Web para satisfacer necesidades y/o resultados concretos y/o expectativas de los Usuarios.

Responsabilidades
TSU no asume ningún tipo de responsabilidad que se derive de cualquier daño y/o perjuicio de cualquier naturaleza que se pudieran originar al Usuario como consecuencia de:
1. El acceso o utilización de este Sitio Web, incluyendo la responsabilidad relacionada con todo tipo de daños, como ser: virus, programas maliciosos o lesivos en sus contenidos o bien cualquier otro agente que pudiere infectar o dañar el sistema de computación utilizado por el Usuario.
2. La falta de disponibilidad, acceso, mantenimiento y efectivo funcionamiento del Sitio y/o de sus servicios y actualización, exactitud, exhaustividad, pertinencia, actualidad y fiabilidad de contenidos, cualquiera sea la causa en la que tengan su origen dichos hechos. 
3. La aplicación de contenidos del Sitio Web con fines y expectativas específicas y propias del Usuario, ajenos a TSU, 

General
Los presentes Términos y Condiciones constituyen el entero acuerdo entre las partes. La declaración de que alguna de las disposiciones de estos Términos y Condiciones fuese inválida o no ejecutable, no tendrá efecto alguno respecto de las demás provisiones de estos Términos y Condiciones, las cuales permanecerán con total efecto y vigencia, manteniendo pleno su carácter obligatorio.
Política de Privacidad aplicada al Sitio Web de TSU:
-TSU puede obtener la siguiente información, para brindar un servicio adecuado: nombre completo, dirección física, número de teléfono y dirección de email, datos necesarios.  
-SPAM: Es política de TSU no usar las direcciones de emails que le son suministrados para envío de emails y/o información publicitaria no solicitados, a menos que el usuario así lo permita. TSU no usará la dirección de correo electrónico suministrada por el usuario, para otros fines distintos a los relacionados con el servicio por el que fuera originada la comunicación.
-COOKIES: Las 'cookies' son archivos usados para almacenar y rastrear información sobre el usuario que la página web envía al navegador del usuario y es almacenado en la computadora del mismo. Puede que al ingresar al sitio TSU, el mismo guarde información en forma de Cookies, que son automáticamente bajados a su computadora. Las Cookies son seguras, igualmente si lo desea, usted puede eliminar las cookies que se archivan en su sistema a través de su navegador de Internet.
-La información brindada por el usuario sólo será manejada y compartida por personal autorizado de TSU. TSU no comparte ni revela información obtenida, excepto cuando haya sido autorizada por el usuario o le sea requerido por una autoridad competente y previo el cumplimiento del trámite legal correspondiente.
-Debido a que ninguna transmisión por Internet puede garantizar su íntegra seguridad, TSU no puede garantizar que la información transmitida utilizando un servicio electrónico sea completamente segura, con lo cual el usuario asume este riesgo que declara conocer y aceptar.
-El Sitio Web puede incluir dentro de sus contenidos, enlaces con sitios pertenecientes y/o gestionados por terceros con el objeto de facilitar el acceso a información disponible a través de Internet. TSU no asume ninguna responsabilidad derivada de la existencia de enlaces entre los contenidos de este sitio y contenidos situados fuera del mismo o de cualquier otra mención de contenidos externos a este sitio.

Registración
Para realizar un pedido Usted deberá ingresar a la página web de TSU y en el lugar indicado ingresar el usuario y contraseña. La contraseña es un dato personal e intransferible. En consecuencia, a partir de la habilitación del usuario, Usted se hace responsable del uso y confidencialidad de los elementos que lo autentican y, habida cuenta que los datos que incorpore o consulte a través del sitio de TSU serán tenidos como ingresados/consultados por usted, debe comprometerse a mantener dicha clave como de su exclusivo conocimiento. Asimismo, deberá cambiarla periódicamente y modificarla de manera inmediata a la suposición o certeza de que un tercero ha llegado a conocerla.
Pedidos online
La presente información y los detalles contenidos en este sitio web no constituyen una oferta de venta. No existirá ningún contrato entre nosotros y usted en relación con ningún producto hasta que su pedido haya sido aceptado por nosotros. 
Para realizar un pedido, deberá seguir el procedimiento de solicitud de compra online. Tenga en cuenta que esto no significa que su pedido haya sido aceptado, ya que el mismo constituye una solicitud que usted nos hace a nosotros para comprar uno o más productos. Todos los pedidos están sujetos a nuestra aceptación y le confirmaremos tal aceptación enviándole el pedido al domicilio que usted haya proporcionado. 

Disponibilidad de los productos
Todos los pedidos de productos están sujetos a la disponibilidad de los mismos y, en este sentido, si se producen dificultades en cuanto a su suministro, o si no quedan artículos en stock, nos reservamos el derecho de facilitarle información acerca de productos sustitutivos de calidad y valor igual o superior que Usted podrá encargar."></asp:TextBox>
        
</table>
<table>
    <tr><td width="20" style="width: 9px">
        <asp:CheckBox ID="CheckBox2" Checked="true" 
            runat="server" Text=" " /></td>
        <td width="675" align="left" valign="top" class="bold">Acepto T&eacute;rminos y Condiciones generales.</td>
    </tr>
    <tr>
        <td colspan="1" align="center">                    
    <%--<asp:Button ID="btnAceptar"  runat="server" Text="Aceptar" />--%>
    <asp:ImageButton ID="btnAceptar"  runat="server" ImageUrl="~/assets/images/boton_confirmar.gif" />
        </td>
    </tr>    
</table>
<br />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
   ErrorMessage="Debe ingresar una contraseña" ControlToValidate="tbpass"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe repetir la contraseña" ControlToValidate="tbpassrepetida"></asp:RequiredFieldValidator>            
    
    <asp:Panel runat="server" ID="paneladvertencia" Visible="false">
    <div class="mensaje_advertencia_715"> 
    <asp:Label  ID="lblAdvertencia" runat="server" />   
    </div>
    </asp:Panel>
    
</asp:Content>

