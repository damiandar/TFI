<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Inicio.master" AutoEventWireup="false" CodeFile="preguntasfrecuentesinicio.aspx.vb" Inherits="Tsu.Paginas.preguntasfrecuentes" title="::Preguntas Frecuentes::" %>

<%--<%@ Register src="../controles/MenuIzquierda.ascx" tagname="MenuIzquierda" tagprefix="uc1" %>
--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Menu" Runat="Server">
<asp:Menu ID="Menu1" runat="server">
<Items>
<asp:MenuItem NavigateUrl="../manualinicio/visor/index.htm" Text="Manual online" Target="_blank"></asp:MenuItem>
<asp:MenuItem NavigateUrl="../manualinicio/ManualInicio.pdf" Text="Manual en pdf" Target="_blank"></asp:MenuItem>
<asp:MenuItem NavigateUrl="" Text="Preguntas Frecuentes"></asp:MenuItem>
</Items>
</asp:Menu>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

<div class="Titulo">
PREGUNTAS FRECUENTES
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p><b>¿Qué debo hacer la primera vez que ingreso al sitio TSU?</b><br /> 
    &nbsp;&nbsp;&nbsp; Solicitar la contraseña, ingresando a nuevo usuario </p>

<p><b>¿Cómo obtengo la contraseña para poder ingresar?	</b><br />
&nbsp;&nbsp;&nbsp; Ingresando a nuevo usuario </p>

<p><b>¿Dónde obtengo el número de cuenta?</b><br />
&nbsp;&nbsp;&nbsp; En la factura o remito, se ubica en la parte superior izquierdo, en la boleta de depósito, donde dice Nº CUENTA: 02433799-5. Se debe escribir sin guiones ni barras, por lo tanto en este ejemplo, el número de cuenta sería 24337995. Sino comuníquese con su GDZ o al 0810 321-4878 y se lo informaremos desde SEDE.</p>

<p><b>No tengo DNI, tengo Libreta Cívica, Precaria, o soy extranjera. ¿Qué Nº de DNI ingreso?</b><br />
&nbsp;&nbsp;&nbsp;Colocar el numero correspondiente al documento que haya presentado cuando se incorporó.</p>

<p><b>Ingreso mi Documento y mi Nº de Cuenta correctamente, y sin embargo cuando hago click "Generar Contraseña" me da error, que hago?</b><br />
&nbsp;&nbsp;&nbsp;Comuníquese con el 0810 321-4878.</p>

<p><b>Soy nueva, no tengo numero de cuenta y quiero presentar mi primer pedido por Internet, puedo hacerlo?</b><br />
&nbsp;&nbsp;&nbsp;El primer pedido no se puede ingresar por esta vía, será necesario que lo entregue por medio de su GDZ. Para el próximo pedido ya tendrá el número de su cuenta en la factura y en la boleta de deposito que es lo que la habilitará a ingresar al sistema. El Nº de Cuenta será su usuario.</p>

<p><b>¿Qué debo hacer si olvidé mi contraseña?</b><br />
&nbsp;&nbsp;&nbsp;Ingrese a Olvide mi contraseña</p>

<p><b>¿Se puede ingresar sin contraseña al Espacio TSU, como invitado?</b><br />
&nbsp;&nbsp;&nbsp;No, no se puede, deberá tener habilitada su usuario (Nº de cuenta) y una contraseña para ingresar.</p>

<p><b>Si no soy Revendedora, puedo entrar al Espacio TSU?</b><br />
&nbsp;&nbsp;&nbsp;No, debe ser una Revendedora registrada para poder ingresar y utilizar el espacio TSU</p>

<p><b>¿Cómo hago para cambiar la contraseña?</b><br />
Dentro del sistema hay una opción “Cambiar contraseña” en el Menú superior: Datos personales. SubMenú: Cambiar contraseña.</p>

<p><b>¿Dónde me comunico si me sale un error o tengo alguna consulta?</b><br />
En la opción “Contacto” del menú superior, se puede completar el formulario que se enviará a Sede, sino te podés comunicar al 0-810-321-4878. </p>

<p><b>¿Tengo que instalar algo para poder utilizar el sistema de pedidos por internet?</b><br />
No, no es necesario instalar nada. Simplmente contar con una PC con conexión a Internet.</p>

<p><b>¿Qué hago si solicité la contraseña por mail y no me llegó?</b><br />
Antes de solicitar nuevamente la contraseña, deberás verificar si el mail no lo tenes como mail “no deseado”. Luego verificar si la dirección de mail ingresada en el sistema es la correcta. Si no, ingresar nuevamente en la opción "Usuario nuevo".  Ahí te permitirá solicitar nuevamente la contraseña por mail, ó cambiar para que te la envíen a tu domicilio con el próximo pedido.</p>

<p><b>¿Qué hago si solicité la contraseña para que me la envíen a mi domicilio y no me llegó?</b><br />
Verificar si ya te llegó el pedido de la campaña solicitada. Sino comunicate con el 0-810-321-4878. </p>

<p><b>¿Se pueden ver mis datos personales?</b><br />
Sí, en el menú superior Datos Personales, submenú Información personal.</p>

<p><b>¿Puedo cambiar mis datos personales?</b><br />
No dentro de la herramienta. Si podrás verificar tus datos y desde allí enviar un alerta a tu Gerente de Zona. Ella se comunicará con vos para poder realizar las modificaciones correspondientes en tus datos personales. Menú superior Datos Personales, submenú Información personal.</p>

<p><b>Cambié de domicilio y no puedo ingresar pedido?</b><br />
Para ingresar el pedido, es necesario que informe a la nueva GDZ su nuevo domicilio. Será un requisito previo para poder cargar el pedido en la nueva zona. </p>

<p><b>¿Se puede ingresar al sistema desde cualquier lugar?</b><br />
Si, desde cualquier PC que tenga conexión a internet. Si no es una PC segura (por ej. locutorio), se recomienda utilizar el teclado virtual para ingresar tu contraseña.</p>

<p><b>Hay productos que no me acepta, o me da incorrecto el código, qué hago?</b><br />
Verifique la campaña que figura en el margen superior de la pantalla, o verifique que el código se encuentre en el FAV de la campaña. En caso de persistir el error comuníquese al 0-810 321-4878</p>

<p><b>¿Hay un máximo de productos para cargar en la solicitud de compra?</b><br />
No, se puede cargar la cantidad ilimitada deseada.</p>

<p><b>¿Puedo modificar un producto ya cargado?</b><br />
&nbsp;&nbsp;&nbsp;
Si, te permite modificar sólo la cantidad de un producto ya cargado hasta el cierre de la zona haciendo click en el botón modificar. </p>

<p><b>¿Puedo agregar unidades a un producto ya cargado?</b><br />
&nbsp;&nbsp;&nbsp;
Sí, se puede agregar unnidades a un producto ya cargado, le preguntará si desea agregar la cantidad ingresada a la ya existente. </p>

<p><b>¿Puedo eliminar un producto ya cargado?</b><br />
&nbsp;&nbsp;&nbsp;
Si, se puede eliminar un producto ingresado hasta el cierre de la zona, mediante el botón “Eliminar”. </p>

<p><b>¿Puedo eliminar el pedido completo (productos, catálogos solicitados, cambios y reclamos, premios, etc)?</b><br />
&nbsp;&nbsp;&nbsp;
Sí, hasta el día de cierre de zona tenes la opción de eliminar el pedido completo presionando un botón “Eliminar todo el pedido”.</p>

<p><b>Al cargar mi pedido indique mal el domicilio de entrega o lo omití, puedo agregarlo?</b><br />
&nbsp;&nbsp;&nbsp;
Sí, se puede agregar siempre y cuando no haya cerrado la campaña según calendario. De querer agregarlo deberá ingresar a la opción “Domicilio de opción” que se encuentra dentro del menú “Solicitud de Compra”. </p>

<p><b>Puedo agregar productos a mi pedido luego que paso la fecha de calendario?</b><br />
&nbsp;&nbsp;&nbsp;
No, ya cerró la campaña. Podrá cargar los productos de la próxima campaña (lo podrá ver en el margen superior de la pantalla)</p>

<p><b>Si ya cerró la campaña, ¿puedo anular mi pedido?</b><br />
&nbsp;&nbsp;&nbsp;
No, una vez que ya cierra la zona, el pedido ya se transfiere y no se puede anular, el mismo será facturado y enviado a su domicilio.</p>

<p><b>¿Se pueden cargar pedidos de varias campañas a la vez?</b><br />
&nbsp;&nbsp;&nbsp;
No, sólo de la campaña vigente, una vez que cierra, automáticamente se cargará la siguiente. Sólo la Gerente de Zona, puede cargar el pedido de una Revendedora hasta la fecha de cierre de zona perteneciente a la Gerente de Zona.</p>

<p><b>¿Hasta qué día se puede cargar el pedido de la campaña vigente?</b><br />
&nbsp;&nbsp;&nbsp;
Hasta el día de cierre de zona que figura en la parte superior de la pantalla en color celeste.</p>

<p><b>Si entregué mi solicitud de compra a mi GDZ. ¿puedo ingresar mi pedido por internet?</b><br />
&nbsp;&nbsp;&nbsp;
No, la presentación de su pedido debe ser por una sola vía, por lo tanto si ya le entregó su solicitud a su GDZ, no deberá ingresar el pedido por internet.</p>

<p><b>Acabo de registrarme y no puedo visualizar mis datos personales.</b><br />
&nbsp;&nbsp;&nbsp;
Si su contraseña recientemente generada se envió por mail, recién al día siguiente podrá visualizar sus datos personales. </p>

</asp:Content>


