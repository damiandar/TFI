<%@ Control Language="VB" AutoEventWireup="false" CodeFile="popProveedorInsert.ascx.vb" Inherits="controles_popProveedorInsert" %>
<%--<div id="detalleEvento"  style="width:100%; height:100%; z-index:5; display:block; position:absolute; left:0px; top: 0px; ">
      <div style="background-color:#FFF; border:solid 1px #000; position:absolute; left:50%; top:50%; margin-left:-267px; margin-top:-100px;">
        <div style="height:40px; background-color:#676767;">
            <div style="color:#FFF; text-transform:capitalize; font-family: Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; float:left; margin-top:10px; margin-left:10px;">
            Bienvenido
            </div>
            
            <div style="float:right; margin-top:10px; margin-right:10px;">
           <asp:ImageButton ID="btnCancel" ImageUrl="~/assets/images/Cerrar_Ventana.gif" width="20" height="20"  runat="server" />
            </div>
		</div>
<div style="padding:10px; font-family: Arial, Helvetica, sans-serif; font-size:12px;">--%>
<div class="row">
    <div  class="col-lg-12">
        <div role="form">
        <div class="col-sm-6">
        <!-- Text input-->
        <div class="form-group">
            <label for="tbRazonSocial">Razon Social</label>
            <asp:textbox class="form-control" placeholder="Razon Social" runat="server" ID="tbRazonSocial" ></asp:textbox> 
        </div>
        <div class="form-group">
            <label for="tbCuit">Cuit</label>
            <asp:textbox class="form-control" placeholder="CUIT"  runat="server" ID="tbCuit" ></asp:textbox>
         </div>
        <div class="form-group">
        <label for="comboResponsabilidad">Responsabilidad Fiscal</label>
       <asp:DropDownList class="form-control" placeholder="Responsabilidad Fiscal" ID="comboResponsabilidad" runat="server"></asp:DropDownList>  
        </div>
        <div class="form-group">
            <label for="tbDomicilio">Domicilio</label>
            <asp:textbox class="form-control" placeholder="Domicilio" runat="server" ID="tbDomicilio"></asp:textbox> 
       </div>
        <div class="form-group">
            <label for="tbLocalidad">Localidad</label>
            <asp:textbox class="form-control" placeholder="Localidad"  runat="server" ID="tbLocalidad"></asp:textbox> 
        </div>
        <div class="form-group">
            <label for="tbCodigoPostal">Código Postal</label>
            <asp:textbox class="form-control" placeholder="Código Postal" runat="server" ID="tbCodigoPostal"></asp:textbox> 
          </div>

        </div>
        <div class="col-sm-6">
        <div class="form-group">
            <label for="comboProvincia">Provincia</label>
            <asp:DropDownList class="form-control" placeholder="Provincia" ID="comboProvincia" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="tbTelefono">Telefono</label>
            <asp:textbox class="form-control" placeholder="Teléfono" runat="server" ID="tbTelefono"></asp:textbox> 
        </div>
        <div class="form-group">
            <label for="tbContacto">Contacto</label>
            <asp:textbox  class="form-control" placeholder="Contacto" runat="server" ID="tbContacto"></asp:textbox> 
         </div>
        <div class="form-group">
            <label for="exampleTextarea">Mail</label>
            <asp:textbox  class="form-control" placeholder="E-mail" runat="server" ID="tbMail"></asp:textbox> 
        </div>         
        <div class="form-group">
            <label for="tbWEB">Web</label>
            <asp:textbox  class="form-control"  placeholder="WEB" runat="server" ID="tbWEB"></asp:textbox> 
        </div>
        </div>
       
        </div>
    </div>
    <div class="col-lg-12">
        <div role="form">
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
              <div class="pull-right">
                <button type="submit" class="btn btn-default">Cancelar</button> 
                <asp:Button ID="btnGuardar" runat="server"  class="btn btn-primary" Text="Grabar"   />
                  <asp:Button ID="btnActualizar" runat="server"   class="btn btn-success" Text="Actualizar" />
              </div>
            </div>
          </div>
        <div class="form-group input-group">
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>  
         <asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label>  
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel> 
        </div>
        </div>
    </div>
</div>
<%--</div>
      </div>
</div>--%>