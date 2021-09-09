<%@ Control Language="VB" AutoEventWireup="false" CodeFile="pop.ascx.vb" Inherits="controles_pop" %>
  <div id="detalleEvento"  style="width:100%; height:100%; z-index:5; display:block; position:absolute; left:0px; top: 0px; ">
      <div style="width:535px; height:500px; background-color:#FFF; border:solid 1px #000; position:absolute; left:50%; top:50%; margin-left:-267px; margin-top:-100px;">
        <div style="width:535px; height:40px; background-color:#676767;">
            <div style="color:#FFF; text-transform:capitalize; font-family: Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; float:left; margin-top:10px; margin-left:10px;">
            Bienvenida
            </div>
            
            <div style="float:right; margin-top:10px; margin-right:10px;">
           <asp:ImageButton ID="btnCancel" ImageUrl="~/assets/images/Cerrar_Ventana.gif" width="20" height="20"  runat="server" />
            </div>
		</div>
        <div style="width:515px; padding:10px; font-family: Arial, Helvetica, sans-serif; font-size:12px;">
    <div class="row">

        <div  class="col-lg-6">
        <div role="form">
        <div class="form-group">
        <label>CUIT:</label><asp:textbox class="form-control"  runat="server" ID="tbCuit" ></asp:textbox>
        </div>
        <div class="form-group">

        <label>Razon Social:</label><asp:textbox class="form-control"  runat="server" ID="tbRazonSocial" ></asp:textbox> 
         </div>
        <div class="form-group">
        <label>Responsabilidad Fiscal:</label><asp:DropDownList class="form-control" ID="comboResponsabilidad" runat="server"></asp:DropDownList>  
         </div>
        <div class="form-group">     
        <label>Domicilio:</label><asp:textbox class="form-control"  runat="server" ID="tbDomicilio"></asp:textbox> 
         </div>
        <div class="form-group">
        <label>Localidad:</label><asp:textbox class="form-control"  runat="server" ID="tbLocalidad"></asp:textbox> 
         </div>
        <div class="form-group">
        <label>Código Postal:</label><asp:textbox class="form-control"  runat="server" ID="tbCodigoPostal"></asp:textbox> 
         </div>
        </div>
        </div>
        <div class="col-lg-6">
        <div role="form">
        <div class="form-group">
        <label>Provincia:</label><asp:DropDownList class="form-control" ID="comboProvincia" runat="server"></asp:DropDownList>
         </div>
        <div class="form-group">
        <label>Nº Teléfono:</label><asp:textbox class="form-control"  runat="server" ID="tbTelefono"></asp:textbox> 
         </div>
        <div class="form-group">
        <label>Contacto:</label><asp:textbox  class="form-control" runat="server" ID="tbContacto"></asp:textbox> 
         </div>
        <div class="form-group">
        <label>E-mail:</label><asp:textbox  class="form-control" runat="server" ID="tbMail"></asp:textbox> 
         </div>
        <div class="form-group">
        <label>WEB:</label><asp:textbox  class="form-control" runat="server" ID="tbWEB"></asp:textbox> 
         </div>
        
        </div>
        </div>
        <div class="col-lg-12">
        <div role="form">
        <div class="form-group">
        <asp:CheckBox ID="chkTerminos" runat="server" />
        Acepto <a id="A1" runat="server" href="javascript:void(0);" onclick="window.open('terminosycondiciones.htm', '_blank', 'width=640,height=480,scrollbars=yes,status=no,resizable=yes,screenx=0,screeny=0');">
                Términos y Condiciones</a>.
                <b style="color:#09F;">Por favor complete los datos.</b>
         </div>
        <div class="form-group input-group">
                <asp:Button ID="Button1" runat="server" Text="Button" cssclass="btn btn-default" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>  
         <asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label>  
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel> 
        </div>
        </div>
        </div>
    </div> <%-- fin de row--%>

    
</div>
      </div>
</div>